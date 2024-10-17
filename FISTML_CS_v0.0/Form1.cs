using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.Util;
using System.Data;
using MySql.Data.MySqlClient;
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

            _faceCascade = new CascadeClassifier("C:\\Users\\User\\source\\repos\\FISTML_CS_v0.0\\FISTML_CS_v0.0\\bin\\Debug\\net8.0-windows\\haarcascade_frontalface_default.xml");

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
                Matrix<int> labelMatrix = new Matrix<int>(_labels.Count, 1);
                for (int i = 0; i < _labels.Count; i++)
                {
                    labelMatrix[i, 0] = _labels[i];
                }

                // Train the recognizer with the images and labels
                _faceRecognizer.Train(imageVec, labelMatrix);
            }
        }




        private void button1_Click(object sender, EventArgs e)
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

        private async void button2_Click(object sender, EventArgs e)
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

                        Matrix<int> labelMatrix = new Matrix<int>(_labels.Count, 1);
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
                    Matrix<int> labelMatrix = new Matrix<int>(_labels.Count, 1);
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


        private async void button3_Click(object sender, EventArgs e)
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

                for (int i = 0; i < 9; i++)
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

    }
}