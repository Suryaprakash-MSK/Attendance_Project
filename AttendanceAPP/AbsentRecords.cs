using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AttendanceAPP
{
    public partial class AbsentRecords : UserControl
    {
        private System.Windows.Forms.Timer refreshTimer;
        public AbsentRecords()
        {
            InitializeComponent();
            dtpStartDate.MinDate = new DateTime(2025, 4, 22);
            dtpStartDate.MaxDate = DateTime.Today;

            dtpEndDate.MinDate = new DateTime(2025, 4, 22);
            dtpEndDate.MaxDate = DateTime.Today;

            dataGrid.CellClick += dataGrid_CellClick;
            InitializeTimer();
            setdataGrid(dataGrid);
            setdataGrid(dataGridView);
            dtpStartDate.Value = dtpStartDate.MinDate;
        }
        private void setdataGrid(DataGridView S)
        {
            S.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida", 10, FontStyle.Bold);
            S.DefaultCellStyle.Font = new Font("Lucida", 14);
            S.ColumnHeadersDefaultCellStyle.ForeColor = Color.OrangeRed;
            S.EnableHeadersVisualStyles = false;

        }
        private void LoadAbsentUsersByDate(DateTime selectedDate)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT U.UserId, U.UserName, U.Gender, U.Age
                FROM Users U
                WHERE U.UserId NOT IN (
                    SELECT A.UserId
                    FROM Attendance A
                    WHERE CONVERT(date, A.Date) = @SelectedDate
                )";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGrid.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading absent users: " + ex.Message);
            }
        }
        private void AbsentRecords_Load(object sender, EventArgs e)
        {
            datePicker.MinDate = new DateTime(2025, 4, 22);
            datePicker.MaxDate = DateTime.Today;

            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida", 10, FontStyle.Bold);
            dataGrid.DefaultCellStyle.Font = new Font("Lucida", 14);
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.OrangeRed;
            dataGrid.EnableHeadersVisualStyles = false;
        }
        private void btnAbsentDays_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            string username = usernameTextBox.Text.Trim();

            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after end date.");
                dataGridView.DataSource = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.");
                dataGridView.DataSource = null;
                return;
            }

            LoadAbsentUsersByDateRangeAndUsername(startDate, endDate, username);
        }
        private void LoadAbsentUsersByDateRangeAndUsername(DateTime startDate, DateTime endDate, string username)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if username exists in the Users table
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @Username";
                    using (SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn))
                    {
                        checkUserCmd.Parameters.AddWithValue("@Username", username);
                        int userExists = (int)checkUserCmd.ExecuteScalar();

                        if (userExists == 0)
                        {
                            MessageBox.Show("Invalid Username! Please enter a valid username.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            usernameTextBox.Clear();
                            dataGridView.DataSource = null;
                            return;
                        }
                    }

                    string query = @"
                SELECT DISTINCT MissingDates.AbsentDate
                FROM Users U
                CROSS APPLY (
                    SELECT DATEADD(DAY, v.number, @StartDate) AS AbsentDate
                    FROM master.dbo.spt_values v
                    WHERE v.type = 'P' AND DATEADD(DAY, v.number, @StartDate) <= @EndDate
                ) AS MissingDates
                WHERE U.UserName = @Username
                AND NOT EXISTS (
                    SELECT 1
                    FROM Attendance A
                    WHERE A.UserId = U.UserId
                    AND CONVERT(date, A.Date) = MissingDates.AbsentDate
                )
                ORDER BY MissingDates.AbsentDate";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);
                        cmd.Parameters.AddWithValue("@Username", username);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading absent records: " + ex.Message);
            }
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = datePicker.Value.Date;
            LoadAbsentUsersByDate(selectedDate);
            dataGridView.DataSource = null;
        }

        private void Exportbtn_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Attendance Records";
            string selectedDate = datePicker.Value.ToString("yyyy-MM-dd");
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
                string fileName = $"Absent_Attendance_{selectedDate}.csv";
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
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string username = dataGrid.Rows[e.RowIndex].Cells["Username"].Value?.ToString();
                int userId;
                if (dataGrid.Rows[e.RowIndex].Cells["UserId"].Value != DBNull.Value &&
                    int.TryParse(dataGrid.Rows[e.RowIndex].Cells["UserId"].Value.ToString(), out userId))
                {
                    usernameTextBox.Text = username;
                }
                else
                {
                    usernameTextBox.Clear();
                }
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
            DateTime selectedDate = datePicker.Value.Date;
            LoadAbsentUsersByDate(selectedDate);
        }
    }
}
