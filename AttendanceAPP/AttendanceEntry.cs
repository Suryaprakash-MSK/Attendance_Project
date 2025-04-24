using AForge.Video;
using AForge.Video.DirectShow;
using SeetaFace6Sharp;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace AttendanceAPP
{
    public partial class AttendanceEntry : UserControl
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private FaceDetector faceDetector;
        private FaceRecognizer faceRecognizer;
        private FaceLandmarker faceMark;
        private FaceAntiSpoofing faceAntiSpoofing;
        private MaskDetector maskDetector;
        private Bitmap Cframe;
        private Dictionary<string, List<float[]>> storedFaceFeatures;
        static int frame = 0;
        public AttendanceEntry()
        {
            InitializeComponent();
            storedFaceFeatures = LoadFaceDataFromDatabase();
            faceDetector = new FaceDetector();
            faceRecognizer = new FaceRecognizer(new FaceRecognizeConfig(FaceType.Mask));
            faceMark = new FaceLandmarker();
            faceAntiSpoofing = new FaceAntiSpoofing();
            maskDetector = new MaskDetector();
        }
        private void AttendanceEntry_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }
            foreach (FilterInfo device in videoDevices)
            {
                listBoxDevices.Items.Add(device.Name);
            }
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += videoSource_NewFrame;
            SetDefaultCameraResolution(videoSource, 640, 480);
            btnStop.Enabled = false;
        }
        private void listBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDevices.SelectedIndex >= 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[listBoxDevices.SelectedIndex].MonikerString);
            }
        }
        private void SetDefaultCameraResolution(VideoCaptureDevice device, int width, int height)
        {
            VideoCapabilities[] capabilities = device.VideoCapabilities;

            foreach (var cap in capabilities)
            {
                if (cap.FrameSize.Width == width && cap.FrameSize.Height == height)
                {
                    device.VideoResolution = cap;
                    return;
                }
            }

            if (capabilities.Length > 0)
            {
                device.VideoResolution = capabilities[0];
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (videoSource != null && !videoSource.IsRunning)
            {
                videoSource.Start();
                btnStop.Enabled = true;
                btnStart.Enabled = false;
            }
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
                        DrawRecognizedFaces(frame, infos, imageData);

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void DrawRecognizedFaces(Bitmap frame, FaceInfo[] faces, FaceImage imageData)
        {
            String display, displayM;

            using (Graphics g = Graphics.FromImage(frame))
            {
                int matchedUsersCount = 0;
                int unmatchedUsersCount = 0;
                int fakeUsersCount = 0;
                bool faceDetected = faces.Length > 0;
                foreach (var face in faces)
                {
                    Rectangle faceRect = new Rectangle(face.Location.X, face.Location.Y, face.Location.Width, face.Location.Height);
                    FaceMarkPoint[] points = faceMark.Mark(imageData, face);

                    float[] faceFeature = faceRecognizer.Extract(imageData, points);

                    string matchedUser = CompareWithDatabase(faceFeature);
                    var result = faceAntiSpoofing.Predict(imageData, face, points);
                    using (Pen pen = new Pen(result.Status == AntiSpoofingStatus.Real ? Color.Green : Color.Red, 4))
                    {
                        g.DrawRectangle(pen, faceRect);
                    }
                    if (result.Status == AntiSpoofingStatus.Real)
                    {
                        display = "Real";
                    }
                    else
                    {
                        display = "Fake";
                    }

                    var resultMask = maskDetector.Detect(imageData, face);
                    if (resultMask.Status == true)
                    {
                        displayM = "  With Mask";
                    }
                    else
                    {
                        displayM = "";
                    }

                    using (Font font = new Font("Arial", 12, FontStyle.Bold))
                    using (SolidBrush brush = new SolidBrush(Color.Yellow))
                    {
                        string displayText = string.IsNullOrEmpty(matchedUser) ? "Unknown" : matchedUser;
                        displayText += $"- {display}";
                        displayText += $"{displayM}";

                        if (!string.IsNullOrEmpty(matchedUser))
                        {
                            if (result.Status == AntiSpoofingStatus.Real && !string.IsNullOrEmpty(matchedUser))
                            {
                                Rectangle Rect = new Rectangle(face.Location.X, face.Location.Y, face.Location.Width, face.Location.Height);
                                Cframe = CropImage(frame, Rect);
                                matchedUsersCount++;
                                byte[] imageBytes = ImageToByteArray(Cframe);
                                MarkAttendance(matchedUser, imageBytes);
                            }
                            else if (string.IsNullOrEmpty(matchedUser))
                            {
                                unmatchedUsersCount++;
                            }
                            else
                            {
                                fakeUsersCount++;
                            }
                            g.DrawString(displayText, font, brush, face.Location.X, face.Location.Y - 20);
                        }
                        else
                        {
                            g.DrawString("Unknown", font, brush, face.Location.X, face.Location.Y - 20);
                        }
                    }
                }
                if (faceDetected)
                {
                    string summaryText = $"Matched Users: {matchedUsersCount}, \nUnmatched Users: {unmatchedUsersCount},\n Fake Users: {fakeUsersCount}";

                    using (Font font = new Font("Arial", 16, FontStyle.Bold))
                    using (SolidBrush brush = new SolidBrush(Color.Red))
                    {
                        g.DrawString(summaryText, font, brush, new Point(10, 10));
                    }
                }
            }
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }
            pictureBox.Image = (Bitmap)frame.Clone();
        }
        private string CompareWithDatabase(float[] faceFeature)
        {
            string bestMatch = null;
            float highestSimilarity = 0.0f;

            foreach (var entry in storedFaceFeatures)
            {
                if (entry.Value == null || entry.Value.Count == 0) continue;

                foreach (var storedFeature in entry.Value)
                {
                    float similarity = faceRecognizer.Compare(storedFeature, faceFeature);
                    if (similarity > 0.7f && similarity > highestSimilarity)
                    {
                        highestSimilarity = similarity;
                        bestMatch = entry.Key;
                    }
                }
            }
            return bestMatch;
        }
        private Dictionary<string, List<float[]>> LoadFaceDataFromDatabase()
        {
            Dictionary<string, List<float[]>> faceData = new Dictionary<string, List<float[]>>();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Users.UserName, UserFaceFeatures.FeatureData FROM Users INNER JOIN UserFaceFeatures ON Users.UserId = UserFaceFeatures.UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader.GetString(0);
                        byte[] faceBytes = reader["FeatureData"] as byte[];

                        if (faceBytes != null && faceBytes.Length % sizeof(float) == 0)
                        {
                            float[] faceFeature = ConvertBytesToFloatArray(faceBytes);
                            if (faceFeature != null)
                            {
                                if (!faceData.ContainsKey(username))
                                {
                                    faceData[username] = new List<float[]>();
                                }
                                faceData[username].Add(faceFeature);
                            }
                        }
                    }
                }
            }
            return faceData;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            pictureBox.Image = null;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }
        private float[] ConvertBytesToFloatArray(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;

            if (byteArray.Length % sizeof(float) != 0)
            {
                Debug.WriteLine("Error: Face feature byte array is not a valid size.");
                return null;
            }

            float[] floatArray = new float[byteArray.Length / sizeof(float)];
            Buffer.BlockCopy(byteArray, 0, floatArray, 0, byteArray.Length);
            return floatArray;
        }
        private Bitmap CropImage(Bitmap source, Rectangle cropArea)
        {
            cropArea.Intersect(new Rectangle(0, 0, source.Width, source.Height));
            if (cropArea.Width <= 0 || cropArea.Height <= 0)
                return null;
            return source.Clone(cropArea, source.PixelFormat);
        }
        private byte[] ImageToByteArray(Bitmap image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void MarkAttendance(string userName, byte[] imageBytes)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Get user details from the Users table
                string getUserQuery = "SELECT UserId, Gender, Age FROM Users WHERE UserName = @UserName";
                int userIdFromUsers = 0;
                string gender = "";
                int age = 0;

                using (SqlCommand cmd = new SqlCommand(getUserQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userIdFromUsers = reader.GetInt32(0);
                            gender = reader.GetString(1);
                            age = reader.GetInt32(2);
                        }
                    }
                }
                if (userIdFromUsers == 0) return; // User not found

                // Check if the user has already recorded attendance today
                string checkAttendanceQuery = "SELECT COUNT(*) FROM Attendance WHERE UserId = @UserId AND Date = CAST(GETDATE() AS DATE)";

                using (SqlCommand cmd = new SqlCommand(checkAttendanceQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userIdFromUsers);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0) return;
                }

                // Insert new attendance record with image data
                string insertQuery = "INSERT INTO Attendance (UserId, Username, Gender, Age, EnterTime, ImageData) " +
                                     "VALUES (@UserId, @UserName, @Gender, @Age, CONVERT(VARCHAR(5), GETDATE(), 108), @ImageData)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userIdFromUsers);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@ImageData", imageBytes);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
