using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.Util;
using System.Data;
using MySql.Data.MySqlClient;

using DlibDotNet;
using DlibDotNet.Extensions;




namespace FISTML_CS_v0._0
{
    public partial class Form1 : Form
    {

        private VideoCapture _capture;
        private bool _captureInProgress;
        private CascadeClassifier _faceCascade;
        private Image<Bgr, Byte> _currentFrame;
        private string _trainingDataPath = "TrainedFaces";
        private LBPHFaceRecognizer _faceRecognizer;
        private List<Image<Gray, byte>> _trainingImages = new List<Image<Gray, byte>>();
        private List<int> _labels = new List<int>();
        private Dictionary<int, string> _labelNames = new Dictionary<int, string>();
        private int _imageCounter = 0;
        private int _angleStage = 0;
        private string _connectionString = "server=localhost;port=3306;database=fistmlbeta;uid=root;pwd=root;";
        private List<string> GetImagePathsFromDB(string userName)
        {
            List<string> imagePaths = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ImagePath FROM FaceRecords WHERE UserName = @UserName";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                imagePaths.Add(reader.GetString(0));
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"MySQL Error: {ex.Message}");
                }
            }
            return imagePaths;
        }
        private void InsertImagePathToDB(string userName, string imagePath)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO FaceRecords (UserName, ImagePath) VALUES (@UserName, @ImagePath)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@ImagePath", imagePath);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"MySQL Error: {ex.Message}");
                }
            }
        }

        public Form1()
        {
            if (!Directory.Exists(_trainingDataPath))
            {
                Directory.CreateDirectory(_trainingDataPath);
            }

            _faceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 100);

            // Load training data from the database on startup
            LoadTrainingDataFromDB();
            InitializeComponent();
            dashboard.BringToFront();
            testingPANEL.Hide();
            schedulerPANEL.Hide();
            _faceCascade = new CascadeClassifier("F:\\FISTML\\FISTML_CS_v1.3\\haarcascade_frontalface_default.xml");


            if (!Directory.Exists(_trainingDataPath))
            {
                Directory.CreateDirectory(_trainingDataPath);
            }

            _faceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 100);

            // Load the model if it exists
            if (File.Exists("faceRecognizerModel.xml"))
            {
                _faceRecognizer.Read("faceRecognizerModel.xml");
            }
            else
            {
                LoadTrainingData();
            }
        }


        private void LoadTrainingData()
        {
            var faceFiles = Directory.GetFiles(_trainingDataPath, "*.jpg");
            int labelCounter = 0;

            foreach (var file in faceFiles)
            {
                var grayImage = new Image<Gray, Byte>(file);
                _trainingImages.Add(grayImage.Resize(1000, 1000, Emgu.CV.CvEnum.Inter.Linear));  // Changed size to 300x300

                _labels.Add(labelCounter);
                string name = Path.GetFileNameWithoutExtension(file);
                _labelNames[labelCounter] = name;

                labelCounter++;
            }

            if (_trainingImages.Count > 0)
            {
                // Convert List<Image<Gray, byte>> to VectorOfMat for training
                VectorOfMat imageVec = new VectorOfMat();
                foreach (var img in _trainingImages)
                {
                    imageVec.Push(img.Mat);
                }

                // Convert List<int> to Matrix<int> for labels
                Emgu.CV.Matrix<int> labelMatrix = new Emgu.CV.Matrix<int>(_labels.Count, 1);
                for (int i = 0; i < _labels.Count; i++)
                {
                    labelMatrix[i, 0] = _labels[i];
                }

                // Train the recognizer with the images and labels
                _faceRecognizer.Train(imageVec, labelMatrix);
            }
        }






        private void ProcessFrame(object sender, EventArgs e)
        {
            _currentFrame = _capture.QueryFrame().ToImage<Bgr, Byte>();

            if (_currentFrame != null)
            {
                using (var grayFrame = _currentFrame.Convert<Gray, Byte>())
                {
                    var facesDetected = _faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                    if (facesDetected.Length > 0)
                    {
                        // Find the largest face (to avoid faces on walls or small objects)
                        var largestFace = facesDetected.OrderByDescending(f => f.Width * f.Height).First();

                        _currentFrame.Draw(largestFace, new Bgr(Color.Red), 2);
                    }

                    pictureBox1.Image = _currentFrame.ToBitmap();
                }
            }
        }


        private void LoadTrainingDataFromDB()
        {
            // Clear existing training data
            _trainingImages.Clear();
            _labels.Clear();
            _labelNames.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT UserName, ImagePath FROM FaceRecords";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int labelCounter = 0;

                            while (reader.Read())
                            {
                                string userName = reader.GetString(0);
                                string imagePath = reader.GetString(1);

                                var grayImage = new Image<Gray, Byte>(imagePath);
                                _trainingImages.Add(grayImage.Resize(500, 500, Emgu.CV.CvEnum.Inter.Linear));  // Resize to match your capture settings

                                _labels.Add(labelCounter);
                                _labelNames[labelCounter] = userName;
                                labelCounter++;
                            }
                        }
                    }
                }

                if (_trainingImages.Count > 0)
                {
                    // Convert List<Image<Gray, byte>> to VectorOfMat for training
                    VectorOfMat imageVec = new VectorOfMat();
                    foreach (var img in _trainingImages)
                    {
                        imageVec.Push(img.Mat);
                    }

                    // Convert List<int> to Matrix<int> for labels
                    Emgu.CV.Matrix<int> labelMatrix = new Emgu.CV.Matrix<int>(_labels.Count, 1);
                    for (int i = 0; i < _labels.Count; i++)
                    {
                        labelMatrix[i, 0] = _labels[i];
                    }

                    // Train the recognizer with the images and labels
                    _faceRecognizer.Train(imageVec, labelMatrix);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error loading data from database: {ex.Message}");
            }
        }


        private void SaveModel()
        {
            _faceRecognizer.Write("faceRecognizerModel.xml");
        }





        private void ResetRecognizer()
        {
            _trainingImages.Clear();
            _labels.Clear();
            _labelNames.Clear();
            _faceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 100);

            // Load training data from the database again
            LoadTrainingDataFromDB();
        }
        private void SaveAndReloadModel()
        {
            SaveModel(); // Save the model after training
            _faceRecognizer = new LBPHFaceRecognizer(1, 8, 8, 8, 100); // Reinitialize the recognizer
            _faceRecognizer.Read("faceRecognizerModel.xml"); // Reload the saved model
        }


        private void back_Click(object sender, EventArgs e)
        {
            testingPANEL.Hide();
            dashboard.BringToFront();
        }

        private void openCamBTN_Click(object sender, EventArgs e)
        {

            if (_capture == null)
            {
                _capture = new VideoCapture();
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
                _captureInProgress = true;
            }
            else if (!_captureInProgress)
            {
                _capture.Start();
                _captureInProgress = true;
            }
        }

        // Track subtle eye movement over time (EAR)
        private static double GetEyeAspectRatio(VectorOfPointF landmarks, int[] eyeIndices)
        {
            var eyePoints = eyeIndices.Select(i => new PointF(landmarks[i].X, landmarks[i].Y)).ToArray();
            var a = Distance(eyePoints[1], eyePoints[5]);
            var b = Distance(eyePoints[2], eyePoints[4]);
            var c = Distance(eyePoints[0], eyePoints[3]);

            return (a + b) / (2.0 * c);
        }

        private static double GetMouthAspectRatio(VectorOfPointF landmarks)
        {
            var mouthPoints = new PointF[]
            {
            new PointF(landmarks[48].X, landmarks[48].Y),
            new PointF(landmarks[54].X, landmarks[54].Y),
            new PointF(landmarks[51].X, landmarks[51].Y),
            new PointF(landmarks[57].X, landmarks[57].Y)
            };

            var a = Distance(mouthPoints[1], mouthPoints[3]);
            var b = Distance(mouthPoints[0], mouthPoints[2]);

            return a / b;
        }

        // Measure distance between two points
        private static double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        // Compare relative positions of key facial points to detect subtle head movements
        private static double CompareHeadMovement(VectorOfPointF landmarks, VectorOfPointF prevLandmarks)
        {
            double movementScore = 0;
            for (int i = 0; i < landmarks.Size; i++)
            {
                PointF currentPoint = landmarks[i];
                PointF previousPoint = prevLandmarks[i];
                movementScore += Distance(currentPoint, previousPoint);  // Calculate movement distance
            }
            return movementScore / landmarks.Size;  // Average movement score
        }

        // Analyze subtle movements in blinking, head position, and mouth expansion to detect liveness
        public static bool IsLive(VectorOfPointF landmarks, VectorOfPointF prevLandmarks = null)
        {
            // Blink detection (Eye Aspect Ratio)
            double ear = GetEyeAspectRatio(landmarks, new[] { 36, 37, 38, 39, 40, 41 }); // Right eye
            ear += GetEyeAspectRatio(landmarks, new[] { 42, 43, 44, 45, 46, 47 }); // Left eye

            // Mouth expansion detection (Mouth Aspect Ratio)
            double mar = GetMouthAspectRatio(landmarks);

            // Track subtle head movement based on facial landmarks (nose, eyes, etc.)
            double headMovementScore = 0;
            if (prevLandmarks != null)
            {
                // Compare the change in relative positions of key facial points
                headMovementScore = CompareHeadMovement(landmarks, prevLandmarks);
            }

            // Thresholds for detecting liveness based on subtle movements
            double earThreshold = 0.25;  // Subtle blinking
            double marThreshold = 1.5;   // Mouth expansion
            double headMovementThreshold = 0.05; // Small head movement detection

            // Initialize liveness score
            double livenessScore = 0;

            // Subtle blinking detection
            if (ear < earThreshold)
                livenessScore += 30;

            // Subtle mouth expansion detection
            if (mar > marThreshold)
                livenessScore += 30;

            // Subtle head movement detection
            if (headMovementScore > headMovementThreshold)
                livenessScore += 40;

            // Determine if the person is live based on subtle movement detection
            double liveThreshold = 60.0; // Minimum liveness score required to consider live
            return livenessScore >= liveThreshold;
        }

        private async Task ScheduledDetection()
        {
            string connectionString = "server=localhost;port=3306;database=fistmlbeta;uid=root;pwd=root;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve current schedules with start_time and end_time
                string query = "SELECT id, code, start_time, end_time, prof_name FROM testclass_table";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string code = reader.GetString(1);
                        DateTime startTime = reader.GetDateTime(2);
                        DateTime endTime = reader.GetDateTime(3);
                        string profName = reader.GetString(4);

                        if (DateTime.Now >= startTime && DateTime.Now <= endTime)
                        {
                            await DetectFaceTesting(5, code, profName, startTime); // Run detection with set captures
                        }
                    }
                }
            }
        }
       
        private async Task DetectFaceTesting(int captureCount, string classCode, string profName, DateTime startTime)
        {
            if (_trainingImages.Count == 0 || _labels.Count == 0)
            {
                MessageBox.Show("No face data available in the database. Please add faces first.");
                return;
            }

            ResetRecognizer();

            if (_capture == null)
            {
                _capture = new VideoCapture();
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
                _captureInProgress = true;
            }

            List<string> recognizedNames = new List<string>();
            VectorOfPointF prevLandmarks = null;
            int frameCaptureCount = 0;

            while (frameCaptureCount < captureCount)
            {
                _currentFrame = _capture.QueryFrame().ToImage<Bgr, Byte>();

                if (_currentFrame != null)
                {
                    var grayFrame = _currentFrame.Convert<Gray, Byte>();
                    var faces = _faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                    if (faces.Length > 0)
                    {
                        var largestFace = faces.OrderByDescending(f => f.Width * f.Height).First();
                        var faceImage = _currentFrame.GetSubRect(largestFace).Convert<Gray, Byte>().Resize(500, 500, Emgu.CV.CvEnum.Inter.Linear);

                        pictureBox2.Image = faceImage.ToBitmap();

                        var landmarks = GetFacialLandmarks(_currentFrame.Mat, largestFace);
                        bool isLive = IsLive(landmarks, prevLandmarks);
                        prevLandmarks = landmarks;

                        var result = _faceRecognizer.Predict(faceImage);
                        if (isLive && result.Label != -1 && result.Distance < 50 && _labelNames[result.Label] == profName)
                        {
                            recognizedNames.Add(profName);
                        }
                        else
                        {
                            recognizedNames.Add("Unknown");
                        }
                    }
                    else
                    {
                        recognizedNames.Add("No face detected");
                    }

                    frameCaptureCount++;
                    await Task.Delay(100);
                }
            }

            var mostCommonName = recognizedNames
                .GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .First().Key;

            textBox2.Text = mostCommonName;

            TimeSpan elapsedTime = DateTime.Now - startTime;
            string attendanceStatus = DetermineAttendanceStatus(mostCommonName, profName, startTime);

            if (attendanceStatus != null)
            {
                RecordAttendance(classCode, profName, attendanceStatus, startTime);
            }

            CloseCamera();
        }

        private string DetermineAttendanceStatus(string detectedName, string profName, DateTime startTime)
        {
            if (detectedName == profName)
            {
                TimeSpan arrivalTime = DateTime.Now - startTime;
                if (arrivalTime.TotalMinutes <= 10)
                    return "Present";
                else if (arrivalTime.TotalMinutes <= 15)
                    return "Late";
            }
            return "Absent";
        }

        private void RecordAttendance(string classCode, string profName, string attendanceStatus, DateTime startTime)
        {
            string connectionString = "server=localhost;port=3306;database=fistmlbeta;uid=root;pwd=root;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO attendance_records (code, date, prof_name, status) VALUES (@code, @date, @profName, @status)", connection))
                {
                    DateTime attendanceDate = attendanceStatus == "Present" ? startTime : DateTime.Today;

                    cmd.Parameters.AddWithValue("@code", classCode);
                    cmd.Parameters.AddWithValue("@date", attendanceDate);
                    cmd.Parameters.AddWithValue("@profName", profName);
                    cmd.Parameters.AddWithValue("@status", attendanceStatus);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void CloseCamera()
        {
            if (_capture != null)
            {
                _capture.Stop();
                _capture.Dispose();
                _capture = null;
                _captureInProgress = false;
            }
        }


        private async void saveImageBTN_Click(object sender, EventArgs e)
        {
            ResetRecognizer();
            if (_currentFrame != null)
            {
                string name = textBox1.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a name.");
                    return;
                }

                var grayFrame = _currentFrame.Convert<Gray, Byte>();
                var faces = _faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                if (faces.Length > 0)
                {
                    var largestFace = faces.OrderByDescending(f => f.Width * f.Height).First();

                    // Capture 5 images per user
                    for (int i = 0; i < 1; i++)
                    {
                        var faceImage = _currentFrame.GetSubRect(largestFace)
                                          .Convert<Gray, Byte>()
                                          .Resize(500, 500, Emgu.CV.CvEnum.Inter.Linear);

                        pictureBox2.Image = faceImage.ToBitmap();

                        string faceFileName = $"{_trainingDataPath}/{name}_{_imageCounter}.jpg";
                        faceImage.Save(faceFileName);

                        // Save the image path to the database
                        InsertImagePathToDB(name, faceFileName);

                        // Add unique label for new user
                        if (!_labelNames.Values.Contains(name))
                        {
                            _labelNames[_labels.Count] = name;  // Ensure unique labels for new users
                        }

                        _trainingImages.Add(faceImage);
                        _labels.Add(_labels.Count);  // Increment label counter correctly
                        _imageCounter++;

                        await Task.Delay(50);  // Short delay between captures
                    }

                    try
                    {
                        // Train the recognizer
                        VectorOfMat imageVec = new VectorOfMat();
                        foreach (var img in _trainingImages)
                        {
                            imageVec.Push(img.Mat);
                        }

                        Emgu.CV.Matrix<int> labelMatrix = new Emgu.CV.Matrix<int>(_labels.Count, 1);
                        for (int i = 0; i < _labels.Count; i++)
                        {
                            labelMatrix[i, 0] = _labels[i];
                        }

                        _faceRecognizer.Train(imageVec, labelMatrix);

                        SaveAndReloadModel();  // Save and reload the model after training

                        MessageBox.Show("Face capture completed and model retrained.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred during training: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("No face detected.");
                }
                if (!_labelNames.Values.Contains(name))
                {
                    _labelNames[_labels.Count] = name;  // Ensure unique labels for new users
                                                        // Add the user to the training set and train only if the user is new
                }
            }
        }
        public VectorOfPointF GetFacialLandmarks(Mat frame, System.Drawing.Rectangle faceRegion)
        {
            // Convert the frame to grayscale (face detection works better on grayscale images)
            var grayFrame = frame.ToImage<Gray, Byte>();

            // Load the Dlib shape predictor model
            var shapePredictor = ShapePredictor.Deserialize("F:\\FISTML\\FISTML_CS_v1.3\\FISTML_CS_v0.0\\bin\\Debug\\net8.0-windows\\shape_predictor_68_face_landmarks.dat");

            // Define the face region
            var dlibRectangle = new DlibDotNet.Rectangle(faceRegion.X, faceRegion.Y, faceRegion.Width, faceRegion.Height);

            // Convert Mat to Bitmap
            Bitmap bitmap = grayFrame.ToBitmap();

            // Convert Bitmap to DlibDotNet Array2D
            // Convert the 8bpp indexed Bitmap to a 24bpp RGB Bitmap
            Bitmap rgbBitmap = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(rgbBitmap))
            {
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, rgbBitmap.Width, rgbBitmap.Height));
            }

            // Convert the 24bpp RGB Bitmap to DlibDotNet Array2D
            var array2D = DlibDotNet.Extensions.BitmapExtensions.ToArray2D<RgbPixel>(rgbBitmap);

            // Get the facial landmarks using the shape predictor
            var landmarks = shapePredictor.Detect(array2D, dlibRectangle);

            // Convert the landmarks to a VectorOfPointF (Emgu CV format)
            var landmarksList = new VectorOfPointF();
            for (uint i = 0; i < landmarks.Parts; i++)
            {
                var point = landmarks.GetPart(i);
                landmarksList.Push(new PointF[] { new PointF(point.X, point.Y) });
            }

            return landmarksList;
        }

        private async void detectFaceBTN_Click(object sender, EventArgs e)
        {
            DetectFaceTesting(3);
        }

        private async void DetectFaceTesting(int captureCount)
        {
            if (_trainingImages.Count == 0 || _labels.Count == 0)
            {
                MessageBox.Show("No face data available in the database. Please add faces first.");
                return;
            }
            ResetRecognizer();  // Reset the recognizer before running detection
            if (_capture != null && _captureInProgress)
            {
                List<string> recognizedNames = new List<string>();

                // Initialize variables for previous landmarks (used for liveness detection)
                VectorOfPointF prevLandmarks = null;

                for (int i = 0; i < captureCount; i++)
                {
                    _currentFrame = _capture.QueryFrame().ToImage<Bgr, Byte>(); // Get a new frame each time

                    if (_currentFrame != null)
                    {
                        var grayFrame = _currentFrame.Convert<Gray, Byte>();
                        var faces = _faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                        if (faces.Length > 0)
                        {
                            var largestFace = faces.OrderByDescending(f => f.Width * f.Height).First();
                            var faceImage = _currentFrame.GetSubRect(largestFace).Convert<Gray, Byte>().Resize(500, 500, Emgu.CV.CvEnum.Inter.Linear);

                            // Update pictureBox2 with the current frame's detected face
                            pictureBox2.Image = faceImage.ToBitmap();

                            // Detect landmarks (for liveness detection)
                            Mat matFrame2 = _currentFrame.Mat;

                            var landmarks = GetFacialLandmarks(matFrame2, largestFace); // Assume this is a function that gets landmarks

                            // Liveness check based on blinking, head movement, and mouth expansion
                            bool isLive = IsLive(landmarks, prevLandmarks);
                            prevLandmarks = landmarks; // Save the current landmarks for comparison in the next frame

                            // Display liveness status
                            string livenessStatus = isLive ? "Live" : "Not Live";
                            textBox2.Text = livenessStatus;  // Display result in textBox3

                            var result = _faceRecognizer.Predict(faceImage);

                            // Check if the label is valid and the distance is within the threshold
                            if (result.Label != -1 && result.Distance < 50) // Adjust the distance threshold as needed
                            {
                                if (_labelNames.ContainsKey(result.Label))
                                {
                                    recognizedNames.Add(_labelNames[result.Label]);
                                }
                                else
                                {
                                    recognizedNames.Add("Unknown");
                                }
                            }
                            else
                            {
                                recognizedNames.Add("Unknown");
                            }
                        }
                        else
                        {
                            recognizedNames.Add("No face detected");
                        }

                        await Task.Delay(100); // Wait 100ms before capturing the next frame
                    }
                }

                // Find the most common recognized name
                var mostCommonName = recognizedNames
                    .GroupBy(n => n)
                    .OrderByDescending(g => g.Count())
                    .First().Key;

                // Display the most common name in textBox2
                textBox2.Text = mostCommonName;

                // Ask the user if the guess was correct
                var dialogResult = MessageBox.Show($"Is the detected person {mostCommonName}?", "Confirm Identity", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    // If the guess was incorrect, ask for the correct name
                    string correctName = Microsoft.VisualBasic.Interaction.InputBox("Enter the correct name:", "Correct Name", "");

                    if (!string.IsNullOrWhiteSpace(correctName))
                    {
                        // Save the face image with the correct name
                        string faceFileName = $"{_trainingDataPath}/{correctName}_{_imageCounter}.jpg";
                        var largestFace = _faceCascade.DetectMultiScale(_currentFrame.Convert<Gray, Byte>(), 1.1, 10, Size.Empty)
                            .OrderByDescending(f => f.Width * f.Height).First();
                        var faceImage = _currentFrame.GetSubRect(largestFace).Convert<Gray, Byte>().Resize(500, 500, Emgu.CV.CvEnum.Inter.Linear);
                        faceImage.Save(faceFileName);

                        // Save the image path to the database
                        InsertImagePathToDB(correctName, faceFileName);

                        // Add the new face to the training data
                        _trainingImages.Add(faceImage);
                        _labels.Add(_labels.Count);
                        _labelNames[_labels.Count - 1] = correctName;
                        _imageCounter++;

                        // Retrain the recognizer
                        SaveAndReloadModel();
                    }
                }
            }
            else
            {
                MessageBox.Show("No camera capture in progress.");
            }
        }

        private void testingBTN_Click_1(object sender, EventArgs e)
        {
            testingPANEL.Show();
            testingPANEL.BringToFront();

        }

        private void schedulerWindowBTN_Click(object sender, EventArgs e)
        {
            schedulerPANEL.Show();
            schedulerPANEL.BringToFront();
        }
        public void InsertClassData(string profText, string classCodeText, string subName, string timeSelectorComboBox, string roomSelectorComboBox)
        {
            string connectionString = "Server=localhost;Port=3306;Database=fistmlbeta;Uid=root;Pwd=root;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Split the selected time interval into start and end times
                    string[] times = timeSelectorComboBox.Split('-');
                    DateTime startTime = DateTime.Parse(times[0].Trim());
                    DateTime endTime = DateTime.Parse(times[1].Trim());

                    // Update query to insert start_time and end_time instead of a single time
                    string query = "INSERT INTO testclass_table (prof_name, code, sub_name, start_time, end_time, classroom) " +
                                   "VALUES (@profName, @classCode, @subName, @startTime, @endTime, @classroom)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@profName", profText);
                        cmd.Parameters.AddWithValue("@classCode", classCodeText);
                        cmd.Parameters.AddWithValue("@subName", subName);
                        cmd.Parameters.AddWithValue("@startTime", startTime);
                        cmd.Parameters.AddWithValue("@endTime", endTime);
                        cmd.Parameters.AddWithValue("@classroom", roomSelectorComboBox);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert data.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void schedulerReturnBTN_Click(object sender, EventArgs e)
        {
            schedulerPANEL.Hide();
            dashboard.BringToFront();
        }

        private void submitToDbBTN_Click(object sender, EventArgs e)
        {
            InsertClassData(profText.Text, classCodeText.Text, subName.Text, timeSelectorComboBox.Text, roomSelectorComboBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private System.Windows.Forms.Timer detectionTimer;

        private void Form1_Load(object sender, EventArgs e)
        {
            detectionTimer = new System.Windows.Forms.Timer { Interval = 5000 }; // Set to 5 seconds
            detectionTimer.Tick += async (s, args) => await ScheduledDetection();
            detectionTimer.Start();

        }
    }
}