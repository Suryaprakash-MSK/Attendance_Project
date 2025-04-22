using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AttendanceAPP
{
    public partial class Records : UserControl
    {
        private System.Windows.Forms.Timer refreshTimer;
        public Records()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = new DateTime(2025, 4, 22);
            dateTimePicker1.MaxDate = DateTime.Today;

            dateTimePickerStart.MinDate = new DateTime(2025, 4, 22);
            dateTimePickerStart.MaxDate = DateTime.Today;

            dateTimePickerEnd.MinDate = new DateTime(2025, 4, 22);
            dateTimePickerEnd.MaxDate = DateTime.Today;

            dateTimePickerStart.Value = dateTimePickerStart.MinDate;
        }

        private void Exportbtn_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Attendance Records";
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string fileName = $"Attendance_Records_{selectedDate}.csv";
            CSVExporter.ExportToCSV(dataGrid, folderPath, fileName);
        }

        private void Records_Load(object sender, EventArgs e)
        {
            setdataGrid(dataGrid);
            setdataGrid(dataGridView);
            InitializeTimer();
        }
        private void setdataGrid(DataGridView S)
        {
            S.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida", 10, FontStyle.Bold);
            S.DefaultCellStyle.Font = new Font("Lucida", 14);
            S.ColumnHeadersDefaultCellStyle.ForeColor = Color.OrangeRed;
            S.EnableHeadersVisualStyles = false;

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

                    //string query = "SELECT \r\n    u.UserId,\r\n    u.UserName,\r\n    u.Gender,\r\n    u.Age,\r\n    CASE \r\n        WHEN a.UserId IS NOT NULL THEN 'Present'\r\n        ELSE 'Absent'\r\n    END AS Status\r\nFROM Users u\r\nLEFT JOIN Attendance a\r\n    ON u.UserId = a.UserId AND a.Date = @SelectedDate\r\nORDER BY u.UserId;";

                    string query = @"
                                    SELECT 
                                        u.UserId,
                                        u.UserName,
                                        u.Gender,
                                        u.Age,
                                        CASE 
                                            WHEN a.UserId IS NOT NULL THEN 'Present'
                                            ELSE 'Absent'
                                        END AS Status
                                    FROM Users u
                                    LEFT JOIN Attendance a
                                        ON u.UserId = a.UserId AND a.Date = @SelectedDate
                                    WHERE u.JoinDate <= @SelectedDate
                                    ORDER BY u.UserId;";

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
        public class CSVExporter
        {
            public static void ExportToCSV(DataGridView dataGridView, string folderPath, string fileName)
            {
                // Ensure the folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                // Generate filename with today's date
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
        private void btnGet_Click(object sender, EventArgs e)
        {
            LoadAttendanceFromStartToEnd();
            ExportbtnFilter.Enabled = true;
        }
        private void LoadAttendanceFromStartToEnd()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            int totalDays = (endDate - startDate).Days + 1;

            // Build dynamic SQL CASE columns
            StringBuilder pivotColumns = new StringBuilder();
            for (int i = 0; i < totalDays; i++)
            {
                DateTime day = startDate.AddDays(i);
                string columnName = day.ToString("yyyy-MM-dd");
                pivotColumns.AppendLine($@",
            MAX(CASE WHEN a.Date = '{columnName}' THEN 'Present' ELSE 'Absent' END) AS [{columnName}]");
            }
            /*
            string query = $@"
                                SELECT 
                                    u.UserName
                                    {pivotColumns}
                                FROM Users u
                                LEFT JOIN Attendance a 
                                    ON u.UserId = a.UserId AND a.Date BETWEEN @startDate AND @endDate
                                GROUP BY u.UserName
                                ORDER BY u.UserName;
                            ";*/
            
            string query = $@"
                            SELECT 
                                u.UserName
                                {pivotColumns}
                            FROM Users u
                            LEFT JOIN Attendance a 
                                ON u.UserId = a.UserId AND a.Date BETWEEN @startDate AND @endDate
                            WHERE u.JoinDate <= @startDate
                            GROUP BY u.UserName
                            ORDER BY u.UserName;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance records: " + ex.Message);
            }
        }

        private void ExportbtnFilter_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Attendance Records";
            string startDate = dateTimePickerStart.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePickerEnd.Value.ToString("yyyy-MM-dd");
            string fileName = $"Attendance_Records_{startDate}_to_{endDate}.csv";
            CSVExporter.ExportToCSV(dataGridView, folderPath, fileName);
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            ExportbtnFilter.Enabled = false;
        }
        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            ExportbtnFilter.Enabled = false;
        }
    }
}
