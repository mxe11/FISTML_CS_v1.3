# Facial Identification System Through Machine Learning (FISTML) - v1.2

## Overview

FISTML is a facial recognition system developed using Visual Studio and .NET Framework with EmguCV for face detection and recognition. It detects faces, stores reference images in a SQL database, and identifies individuals based on stored data. The system is designed for integration into applications like security systems and personalized user experiences.
## Update (1.2)
- **Simple Anti Spoofing Algorithm:** If spoofing detected or liveness test fails, unknown will be detected.
  
## Features
- **Multiple Registration:** Can Save or Register Multiple Users in one session.
- **Face Detection:** Detects human faces in images or live video streams.
- **Face Recognition:** Matches detected faces with stored image paths in a MySQL database.
- **Database Storage:** Stores paths to reference images per person for matching.
- **Image Processing:** Utilizes machine learning techniques for high recognition accuracy.
- **Real-Time Performance:** Efficient real-time face detection and recognition.
- **Model Retraining:** Automatically retrains the recognition model when new faces are added.

## Requirements

### 1. Visual Studio
- Install **Visual Studio** with **Desktop development with .NET**.

### 2. .NET Framework
- Download and install the latest **.NET Framework** from [Microsoft's .NET page](https://dotnet.microsoft.com/download).

### 3. EmguCV (OpenCV wrapper for .NET)
- Install **EmguCV** via NuGet in Visual Studio:
  1. Go to **Tools > NuGet Package Manager > Manage NuGet Packages for Solution**.
  2. Search for `Emgu.CV`.
  3. Click **Install**.

### 4. MySQL Database
- Ensure **MySQL** is installed and running. The application uses SQL to store image paths:
  1. Install **MySQL Server** from [MySQL's official page](https://dev.mysql.com/downloads/mysql/).
  2. Create a database for the face recognition data (`fistmlbeta`).
  3. Create a table `facerecords` with fields for storing names and image paths.


