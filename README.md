# FISTML_CS_v0.0

Facial Recognition Project
This project is a facial recognition system developed in Visual Studio as part of a software engineering course.

Requirements
Visual Studio
.NET Framework
Steps to install: If you installed Visual Studio with the Desktop development with .NET workload, .NET is already installed. To manually install or check the version: Go to the official .NET downloads page. Download and install the latest .NET Framework version. Follow the installation instructions. To check if .NET Framework is already installed, open a command prompt and type:

dotnet --version

OpenCV or any other facial recognition library you are using Steps to install (for OpenCV with .NET in Visual Studio): Install OpenCV via NuGet (a package manager for Visual Studio): Open your project in Visual Studio. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution. In the Browse tab, search for "OpenCvSharp4" (a .NET wrapper for OpenCV). Click Install to add the library to your project. Alternatively, you can use Emgu.CV for .NET.

Git installed in your system

Steps to install Git: Go to the official Git website. Download the appropriate version for your operating system. Run the installer and follow the on-screen instructions. During installation, you can leave most options as default unless you have specific requirements. After installation, verify that Git is installed by opening a terminal/command prompt and typing: git --version

Cloning the Repository
To clone the repository, use the following command in your terminal or command line:

git clone 

Making Changes and Pull Requests
To contribute to this project:

1 Create a new branch for your changes:

git checkout -b feature-branch-name ## for example: login authentication-DelaCruz

2 Make your changes and commit them:

git add . git commit -m "Description of changes"

3 Push the changes to your GitHub repository:

git push origin feature-branch-name Open a Pull Request from your forked repository.
