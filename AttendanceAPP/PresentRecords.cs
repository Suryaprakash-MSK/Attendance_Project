using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AttendanceAPP
{
    public partial class PresentRecords : UserControl
    {
        private System.Windows.Forms.Timer refreshTimer;
        public PresentRecords()
        {
            InitializeComponent();
        }
        private void AttendanceRecords_Load(object sender, EventArgs e)
        {
            InitializeTimer();

            dataGrid.CellClick += dataGrid_CellClick;

            dateTimePicker1.MinDate = new DateTime(2025, 4, 22);
            dateTimePicker1.MaxDate = DateTime.Today;

            dtpStartDate.MinDate = new DateTime(2025, 4, 22);
            dtpStartDate.MaxDate = DateTime.Today;

            dtpEndDate.MinDate = new DateTime(2025, 4, 22);
            dtpEndDate.MaxDate = DateTime.Today;

            dtpStartDate.Value = dtpStartDate.MinDate;
            setdataGrid(dataGrid);
            setdataGrid(dataGridView);
            Exportbtn.Enabled = true;
        }
        private void setdataGrid(DataGridView S)
        {
            S.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida", 10, FontStyle.Bold);
            S.DefaultCellStyle.Font = new Font("Lucida", 14);
            S.ColumnHeadersDefaultCellStyle.ForeColor = Color.OrangeRed;
            S.EnableHeadersVisualStyles = false;

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Exportbtn.Enabled = false;
            txtTotalDays.Clear();
            txtTotalDaysAbsent.Clear();
            txtUsername.Clear();
            dataGridView.DataSource = null;
            LoadUserData();
            Exportbtn.Enabled = true;
            if (pictureBoxImage.Image != null)
            {
                pictureBoxImage.Image.Dispose();
            }
            pictureBoxImage.Image = null;
        }
        private void LoadUserData()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Format for SQL

                    string query = "SELECT UserId, Username, Gender, Age, EnterTime, ExitTime, FORMAT(WorkedHours, '00') + ':' + FORMAT((WorkedHours * 60) % 60, '00') AS WorkedHours  FROM Attendance WHERE CONVERT(date, Date) = @SelectedDate";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGrid.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance records: " + ex.Message);
            }
        }
        private void Exportbtn_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Attendance Records";
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            CSVExporter.ExportToCSV(dataGrid, folderPath, selectedDate);
        }
        public class CSVExporter
        {
            public static void ExportToCSV(DataGridView dataGridView, string folderPath, string selectedDate)
            {
                // Ensure the folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                // Generate filename with today's date
                string fileName = $"Present_Attendance_{selectedDate}.csv";
                string filePath = Path.Combine(folderPath, fileName);

                StringBuilder csvContent = new StringBuilder();

                // Add column headers
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    csvContent.Append(dataGridView.Columns[i].HeaderText + (i < dataGridView.Columns.Count - 1 ? "," : ""));
                }
                csvContent.AppendLine();

                // Add row data
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow) // Skip the new row placeholder
                    {
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            csvContent.Append(row.Cells[i].Value?.ToString() + (i < dataGridView.Columns.Count - 1 ? "," : ""));
                        }
                        csvContent.AppendLine();
                    }
                }

                // Write to file
                File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);
                MessageBox.Show($"CSV file saved successfully!\nLocation: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnTotalDaysPresent_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string username = txtUsername.Text.Trim();

                    // Check if username is empty
                    if (string.IsNullOrEmpty(username))
                    {
                        MessageBox.Show("Please enter a username.", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTotalDays.Clear();
                        txtTotalDaysAbsent.Clear();
                        dataGridView.DataSource = null;
                        return;
                    }

                    // Check if username exists in the Users table
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @Username";
                    using (SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn))
                    {
                        checkUserCmd.Parameters.AddWithValue("@Username", username);
                        int userExists = (int)checkUserCmd.ExecuteScalar();

                        if (userExists == 0)
                        {
                            MessageBox.Show("Invalid Username! Please enter a valid username.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTotalDays.Clear();
                            txtTotalDaysAbsent.Clear();
                            txtUsername.Clear();
                            dataGridView.DataSource = null;
                            return;
                        }
                    }

                    // Query total days present for valid user
                    string query = @"
                                    SELECT COUNT(DISTINCT CONVERT(date, Date)) 
                                    FROM Attendance 
                                    WHERE Username = @Username 
                                    AND Date BETWEEN @StartDate AND @EndDate";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);

                        int totalDaysPresent = (int)cmd.ExecuteScalar();

                        int totalDaysInRange = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days + 1;
                        int totalDaysAbsent = totalDaysInRange - totalDaysPresent;

                        txtTotalDays.Text = totalDaysPresent.ToString();
                        txtTotalDaysAbsent.Text = totalDaysAbsent.ToString();

                        // Show detailed present day records in DataGridView
                        ShowDaysPresentForUser(username);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching attendance count: " + ex.Message);
            }

        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string username = dataGrid.Rows[e.RowIndex].Cells["Username"].Value?.ToString();
                int userId;
                if (dataGrid.Rows[e.RowIndex].Cells["UserId"].Value != DBNull.Value &&
                    int.TryParse(dataGrid.Rows[e.RowIndex].Cells["UserId"].Value.ToString(), out userId))
                {
                    txtUsername.Text = username;
                    LoadUserImage(userId);
                }
                else
                {
                    txtUsername.Clear();
                    if (pictureBoxImage.Image != null)
                    {
                        pictureBoxImage.Image.Dispose();
                    }
                    pictureBoxImage.Image = null;
                }
            }
        }
        private void LoadUserImage(int userId)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ImageData FROM Attendance WHERE UserId = @UserId AND CONVERT(date, Date) = @SelectedDate";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            byte[] imageData = (byte[])result;

                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBoxImage.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pictureBoxImage.Image = null; // Clear if no image found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
        private void ShowDaysPresentForUser(string username)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT DISTINCT CONVERT(date, Date) AS PresentDate 
                FROM Attendance 
                WHERE Username = @Username 
                AND Date BETWEEN @StartDate AND @EndDate 
                ORDER BY PresentDate";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView.DataSource = dt;
                        dataGridView.Columns[0].HeaderText = "Date Present";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user's attendance dates: " + ex.Message);
            }
        }

        private void InitializeTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 1000; // 1 second
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadUserData();
        }

    }
}
