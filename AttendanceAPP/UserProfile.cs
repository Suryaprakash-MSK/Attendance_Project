using AForge.Video;
using AForge.Video.DirectShow;
using SeetaFace6Sharp;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace AttendanceAPP
{
    public partial class UserProfile : UserControl
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Bitmap Cframe;
        private FaceDetector faceDetector;
        private FaceRecognizer faceRecognizer;
        private MaskDetector maskDetector;
        private Rectangle faceRectangle;
        static int frame = 0;

        public UserProfile()
        {
            InitializeComponent();
        }
        private void UserProfile_Load(object sender, EventArgs e)
        {
           videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            faceRecognizer = new FaceRecognizer(new FaceRecognizeConfig(FaceType.Mask));
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += videoSource_NewFrame;
            dataGrid.CellClick += dataGrid_CellContentClick;

            SetDefaultCameraResolution(videoSource, 640, 480);

            LoadUserData();
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida", 10, FontStyle.Bold);
            dataGrid.DefaultCellStyle.Font = new Font("Lucida", 14);
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.OrangeRed;
            dataGrid.EnableHeadersVisualStyles = false;
            btnSave.Enabled = false;
            btnCapture.Enabled = false;
            btnStop.Enabled = false;
            UseridTXT.Enabled = false;
        }

        Queue<Bitmap> bitmapQueue = new Queue<Bitmap>();
        Object sycObj = new object();
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                frame++;
                if (frame % 3 == 0)
                {
                    var frame = new Bitmap(eventArgs.Frame);
                    bitmapQueue.Enqueue(frame);
                    if (faceDetector == null)
                    {
                        faceDetector = new FaceDetector();
                    }
                    Bitmap currentBitmap = null;

                    lock (sycObj)
                    {
                        while (bitmapQueue.Count > 0)
                        {
                            currentBitmap = bitmapQueue.Dequeue();
                        }
                    }

                    if (currentBitmap != null)
                    {
                        var imageData = currentBitmap.ToFaceImage();
                        FaceInfo[] infos = faceDetector.Detect(imageData);
                        DrawDetectedFaces(currentBitmap, infos, imageData);

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void DrawDetectedFaces(Bitmap frame, FaceInfo[] infos, FaceImage imageData)
        {
            String display;
            using (Graphics g = Graphics.FromImage(frame))
            {
                int count = infos.Length;
                foreach (var info in infos)
                {
                    Rectangle faceRect = new Rectangle(info.Location.X, info.Location.Y, info.Location.Width, info.Location.Height);
                    faceRectangle = faceRect;
                    maskDetector = new MaskDetector();

                    using (Pen pen = new Pen(Color.Red, 2))
                    {
                        g.DrawRectangle(pen, faceRect);
                    }

                    var resultMask = maskDetector.Detect(imageData, info);
                    if (resultMask.Status == true)
                    {
                        display = $"Please remove Your Mask, \n No of Faces Detected:{count}";
                    }
                    else
                    {
                        if(count>=1)
                        {
                            if(count>1)
                            {
                                display = $"No of Faces Detected:{count},\n Only one User face should save at a time";
                            }
                            else
                            {
                                display = $"No of Faces Detected:{count}";
                            }
                        }
                        else
                        {
                            display = "";
                        }
                    }
                    using (Font font = new Font("Arial", 16, FontStyle.Bold))
                    using (SolidBrush brush = new SolidBrush(count== 1 ? Color.GreenYellow : Color.Red))
                    {
                        g.DrawString(display, font, brush, new Point(0, 0));
                    }
                    Debug.WriteLine(count);
                }
            }
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }
            pictureBox.Image = frame;
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            Cframe = CropImage((Bitmap)pictureBox.Image, faceRectangle);

            if (Cframe != null)
            {
                if (pictureBoxImage.Image != null)
                {
                    pictureBoxImage.Image.Dispose();
                }
                if (Cframe != null)
                {
                    pictureBoxImage.Image = (Bitmap)Cframe.Clone();
                }
                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("No frame captured to save.");
            }
            UseridTXT.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = UserNameTXT.Text.Trim();
            string? userGender = GenderComboBox.SelectedItem?.ToString();
            int userAge = GetInteger(AgeTXT);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userGender) || userAge == 0)
            {
                MessageBox.Show("Please enter all details");
                return;
            }
            else if (userAge < 1 || userAge > 110)
            {
                MessageBox.Show("Please enter an age between 1 - 110");
                return;
            }
            int userid = GetUserId(username);
            UseridTXT.Text = userid.ToString();

            float[] faceFeature = ExtractSingleFaceFeature(Cframe);

            SaveUserToDatabase(userid, username, userGender, userAge, faceFeature);
            LoadUserData();
            MessageBox.Show("UserInfo saved successfully!");
            btnSave.Enabled = false;
            if (pictureBoxImage.Image != null)
            {
                pictureBoxImage.Image.Dispose();
            }
            pictureBoxImage.Image = null;
        }
        private void SaveUserToDatabase(int userId, string username, string gender, int age, float[] faceFeature)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert user information if not already present
                    string userQuery = "IF NOT EXISTS (SELECT 1 FROM Users WHERE UserId = @UserId) " +
                                       "INSERT INTO Users (UserId, UserName, Gender, Age) VALUES (@UserId, @UserName, @Gender, @Age)";
                    using (SqlCommand cmd = new SqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.ExecuteNonQuery();
                    }


                    if (faceFeature == null)
                    {
                        MessageBox.Show("No face detected. Cannot save user.");
                        return;
                    }

                    // Insert face feature into database
                    string featureQuery = "INSERT INTO UserFaceFeatures (UserId, FeatureData) VALUES (@UserId, @FeatureData)";
                    using (SqlCommand cmd = new SqlCommand(featureQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@FeatureData", FloatArrayToByteArray(faceFeature));
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }
        private Bitmap CropImage(Bitmap source, Rectangle cropArea)
        {
            cropArea.Intersect(new Rectangle(0, 0, source.Width, source.Height));
            if (cropArea.Width <= 0 || cropArea.Height <= 0)
                return null;
            return source.Clone(cropArea, source.PixelFormat);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            videoSource.Start();
            btnCapture.Enabled = true;
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }
        private int GetUserId(string username)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT UserId FROM Users WHERE UserName = @UserName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                string maxIdQuery = "SELECT ISNULL(MAX(UserId), 0) + 1 FROM Users";
                using (SqlCommand cmd = new SqlCommand(maxIdQuery, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        private int GetInteger(TextBox textBox)
        {
            return int.TryParse(textBox.Text, out int result) ? result : 0;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            btnStart.Enabled = true;
            pictureBoxImage.Image = null;
            pictureBox.Image = null;
            btnCapture.Enabled = false;
            btnSave.Enabled = false;
            btnStop.Enabled = false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["UserId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteUserFromDatabase(userId);
                    LoadUserData();
                    MessageBox.Show("User deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
        private void SetDefaultCameraResolution(VideoCaptureDevice device, int width, int height)
        {
            // Get the available resolutions
            VideoCapabilities[] capabilities = device.VideoCapabilities;

            // Find the closest matching resolution
            foreach (var cap in capabilities)
            {
                if (cap.FrameSize.Width == width && cap.FrameSize.Height == height)
                {
                    device.VideoResolution = cap;
                    return;
                }
            }

            // If the exact resolution isn't found, set the first available one
            if (capabilities.Length > 0)
            {
                device.VideoResolution = capabilities[0];
            }
        }
        private float[] ExtractSingleFaceFeature(Bitmap image)
        {
            if (faceRecognizer == null || faceDetector == null) return null;

            var imageData = image.ToFaceImage();
            FaceInfo[] faces = faceDetector.Detect(imageData);

            if (faces.Length == 0)
                return null;
            using FaceLandmarker faceMark = new FaceLandmarker();
            FaceMarkPoint[] landmarks = faceMark.Mark(imageData, faces[0]);

            if (landmarks == null || landmarks.Length == 0)
                return null;

            return faceRecognizer.Extract(imageData, landmarks);
        }
        private byte[] FloatArrayToByteArray(float[] floatArray)
        {
            byte[] byteArray = new byte[floatArray.Length * sizeof(float)];
            Buffer.BlockCopy(floatArray, 0, byteArray, 0, byteArray.Length);
            return byteArray;
        }
        private void LoadUserData()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserId, UserName, Gender, Age FROM Users";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGrid.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message);
            }
        }
        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a row is selected
            {
                DataGridViewRow row = dataGrid.Rows[e.RowIndex];

                row.Selected = true;

                dataGrid.CurrentCell = row.Cells[0];
            }
        }
        private void DeleteUserFromDatabase(int userId)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE UserId = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }
    }
}