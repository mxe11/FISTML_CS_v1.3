
using Emgu.CV;
using Emgu.CV.Structure;
namespace FISTML_CS_v0._0

{
    public partial class Form1 : Form
    {
        private VideoCapture _capture;
        private bool _captureInProgress;
        private CascadeClassifier _faceCascade;
        private Image<Bgr, Byte> _currentFrame;
        private string _trainingDataPath = "TrainedFaces";
        public Form1()
        {
            InitializeComponent();
            // Load the Haar Cascade for face detection
            _faceCascade = new CascadeClassifier("C:\\Users\\User\\source\\repos\\FISTML_CS_v0.0\\FISTML_CS_v0.0\\bin\\Debug\\net8.0-windows\\haarcascade_frontalface_default.xml");

            // Ensure the training data directory exists
            if (!Directory.Exists(_trainingDataPath))
            {
                Directory.CreateDirectory(_trainingDataPath);
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
            // Capture frame from the camera
            _currentFrame = _capture.QueryFrame().ToImage<Bgr, Byte>();

            if (_currentFrame != null)
            {
                // Convert the frame to grayscale for face detection
                using (var grayFrame = _currentFrame.Convert<Gray, Byte>())
                {
                    // Detect faces in the grayscale frame
                    Rectangle[] facesDetected = _faceCascade.DetectMultiScale(
                        grayFrame,
                        1.1,
                        10,
                        Size.Empty
                    );

                    // Draw rectangles around the detected faces
                    foreach (var faceRect in facesDetected)
                    {
                        // Draw a rectangle around each detected face
                        _currentFrame.Draw(faceRect, new Bgr(Color.Red), 2);
                    }

                    // Display the frame with rectangles in PictureBox1
                    pictureBox1.Image = _currentFrame.ToBitmap();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_currentFrame != null)
            {
                var grayFrame = _currentFrame.Convert<Gray, Byte>();
                var faces = _faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                if (faces.Length > 0)
                {
                    // Assume we're detecting only one face for simplicity
                    var faceRect = faces[0];
                    var faceImage = _currentFrame.GetSubRect(faceRect).Convert<Bgr, Byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);

                    // Display detected face in PictureBox2
                    pictureBox2.Image = faceImage.ToBitmap();

                    // Save face image with the name from TextBox1
                    string name = textBox1.Text;
                    string faceFileName = $"{_trainingDataPath}/{name}.jpg";
                    faceImage.Save(faceFileName);

                    MessageBox.Show("Face saved with name: " + name);
                }
                else
                {
                    MessageBox.Show("No face detected.");
                }
            }
        }
        private string RecognizeFace(Image<Bgr, Byte> faceImage)
        {
            foreach (string faceFile in Directory.GetFiles(_trainingDataPath, "*.jpg"))
            {
                // Load the saved face image
                var savedFace = new Image<Bgr, Byte>(faceFile).Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);

                // Compare the current face with saved face (simple pixel comparison)
                var diff = faceImage.AbsDiff(savedFace);
                var diffGray = diff.Convert<Gray, Byte>().ThresholdBinary(new Gray(30), new Gray(255));

                double totalDifference = CvInvoke.CountNonZero(diffGray);

                if (totalDifference < 1000) // Arbitrary threshold for face recognition
                {
                    return Path.GetFileNameWithoutExtension(faceFile); // Return the recognized name
                }
            }
            return null;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_capture != null)
            {
                _capture.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_currentFrame != null)
            {
                var grayFrame = _currentFrame.Convert<Gray, Byte>();
                var faces = _faceCascade.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                if (faces.Length > 0)
                {
                    var faceRect = faces[0];
                    var faceImage = _currentFrame.GetSubRect(faceRect).Convert<Bgr, Byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);
                    pictureBox2.Image = faceImage.ToBitmap();

                    // Recognize face by comparing with saved images
                    string recognizedName = RecognizeFace(faceImage);
                    if (!string.IsNullOrEmpty(recognizedName))
                    {
                        textBox2.Text = recognizedName;
                    }
                    else
                    {
                        MessageBox.Show("Face not recognized.");
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
