# Facial Identification System Through Machine Learning (FISTML) - v0.0

## Overview

FISTML is a facial recognition system developed as part of a software engineering course. The system is built using Visual Studio and .NET Framework, utilizing OpenCV or similar facial recognition libraries. It is capable of detecting and identifying faces through machine learning techniques. The purpose of this project is to create a reliable and efficient facial identification tool that can be integrated into various applications such as security systems, attendance tracking, or personalized user experiences.

## Features

- **Face Detection:** Identifies human faces in images or live video streams.
- **Face Recognition:** Matches detected faces with a database to identify individuals.
- **Image Processing:** Utilizes machine learning to enhance recognition accuracy.
- **Real-Time Performance:** Fast and efficient recognition using optimized algorithms.

## Requirements

### 1. Visual Studio
- Ensure you have **Visual Studio** installed with the **Desktop development with .NET** workload.
  
### 2. .NET Framework
- If the .NET Framework is not already installed with Visual Studio, follow these steps:
  1. Visit the official [.NET downloads page](https://dotnet.microsoft.com/download).
  2. Download and install the latest **.NET Framework** version.
  3. Follow the installation instructions.
  4. To verify the installation, open a command prompt and type:
     ```bash
     dotnet --version
     ```

### 3. OpenCV (or any other facial recognition library)
- This project requires a facial recognition library like **OpenCV**. You can install OpenCV for .NET as follows:
  1. Open your project in Visual Studio.
  2. Go to **Tools > NuGet Package Manager > Manage NuGet Packages for Solution**.
  3. In the **Browse** tab, search for `OpenCvSharp4` (a .NET wrapper for OpenCV).
  4. Click **Install** to add the library to your project.
  - Alternatively, you can use **Emgu.CV**, another facial recognition library for .NET.

### 4. Git (Version Control)
- **Git** is required for version control and collaboration.
  1. Visit the official [Git website](https://git-scm.com).
  2. Download the appropriate version for your operating system.
  3. Run the installer and follow the on-screen instructions.
  4. To verify installation, open a terminal or command prompt and type:
     ```bash
     git --version
     ```

### Optional
- **CUDA (GPU Acceleration)**: If you want to accelerate your facial recognition process, you can use a GPU-enabled version of OpenCV (requires CUDA installation).

## Installation Guide

### Step 1: Clone the Repository
To get started, clone the repository to your local machine using the following command:

```bash
git clone https://github.com/jasferdelacruz/FISTML.git


3 Push the changes to your GitHub repository:

git push origin feature-branch-name Open a Pull Request from your forked repository.
