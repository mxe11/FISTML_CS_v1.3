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
            if (_currentFrame != null)
            {
                var grayFrame = _currentFrame.Convert<Gray, Byte>();
                var faces = _faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                if (faces.Length > 0)
                {
                    var largestFace = faces.OrderByDescending(f => f.Width * f.Height).First();

                    // Capture 5 images
                    for (int i = 0; i < 5; i++)
                    {
                        if (_imageCounter < 5)
                        {
                            var faceImage = _currentFrame.GetSubRect(largestFace)
                                              .Convert<Gray, Byte>()
                                              .Resize(500, 500, Emgu.CV.CvEnum.Inter.Linear);

                            pictureBox2.Image = faceImage.ToBitmap();

                            string name = textBox1.Text;
                            string faceFileName = $"{_trainingDataPath}/{name}_{_imageCounter}.jpg";
                            faceImage.Save(faceFileName);

                            // Save the image path to the database
                            InsertImagePathToDB(name, faceFileName);

                            _trainingImages.Add(faceImage);
                            _labels.Add(_labels.Count);
                            _labelNames[_labels.Count - 1] = name;
                            _imageCounter++;

                            await Task.Delay(50);  // Short delay between captures
                        }
                    }

                    try
                    {
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
                        SaveModel();  // Save the trained model
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


        private void button3_Click(object sender, EventArgs e)
        {
            if (_currentFrame != null)
            {
                var grayFrame = _currentFrame.Convert<Gray, Byte>();
                var faces = _faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                if (faces.Length > 0)
                {
                    var largestFace = faces.OrderByDescending(f => f.Width * f.Height).First();
                    var faceImage = _currentFrame.GetSubRect(largestFace).Convert<Gray, Byte>().Resize(500, 500, Emgu.CV.CvEnum.Inter.Linear);

                    pictureBox2.Image = faceImage.ToBitmap();

                    var result = _faceRecognizer.Predict(faceImage);

                    // Check if the label is valid and the distance is within the threshold
                    if (result.Label != -1 && result.Distance < 50)  // Adjust the distance threshold as needed
                    {
                        textBox2.Text = _labelNames[result.Label];  // Display the name of the recognized person
                    }
                    else
                    {
                        MessageBox.Show("Person unknown. Please register first.");
                    }

                }
                else
                {
                    MessageBox.Show("No face detected.");
                }
            }
        }



    }
}
