namespace FISTML_CS_v0._0
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelmain = new Panel();
            btnlivecam = new Button();
            btnatendanceprof = new Button();
            btncamsetup = new Button();
            btnattendancestudent = new Button();
            btngateentrance = new Button();
            PBlogout = new PictureBox();
            PBabout = new PictureBox();
            PBContact = new PictureBox();
            panelmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBlogout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBabout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBContact).BeginInit();
            SuspendLayout();
            // 
            // panelmain
            // 
            panelmain.BackColor = SystemColors.ActiveBorder;
            panelmain.Controls.Add(PBContact);
            panelmain.Controls.Add(PBabout);
            panelmain.Controls.Add(PBlogout);
            panelmain.Location = new Point(417, 0);
            panelmain.Name = "panelmain";
            panelmain.Size = new Size(200, 360);
            panelmain.TabIndex = 0;
            // 
            // btnlivecam
            // 
            btnlivecam.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnlivecam.Location = new Point(41, 37);
            btnlivecam.Name = "btnlivecam";
            btnlivecam.Size = new Size(140, 60);
            btnlivecam.TabIndex = 1;
            btnlivecam.Text = "LIVE CAMERA";
            btnlivecam.UseVisualStyleBackColor = true;
            // 
            // btnatendanceprof
            // 
            btnatendanceprof.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnatendanceprof.Location = new Point(210, 37);
            btnatendanceprof.Name = "btnatendanceprof";
            btnatendanceprof.Size = new Size(140, 60);
            btnatendanceprof.TabIndex = 2;
            btnatendanceprof.Text = "ATTENDANCE TRACKING \nFOR PROFESSORS";
            btnatendanceprof.UseVisualStyleBackColor = true;
            // 
            // btncamsetup
            // 
            btncamsetup.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncamsetup.Location = new Point(41, 113);
            btncamsetup.Name = "btncamsetup";
            btncamsetup.Size = new Size(140, 60);
            btncamsetup.TabIndex = 3;
            btncamsetup.Text = "CAMERA SETUP";
            btncamsetup.UseVisualStyleBackColor = true;
            // 
            // btnattendancestudent
            // 
            btnattendancestudent.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnattendancestudent.Location = new Point(210, 113);
            btnattendancestudent.Name = "btnattendancestudent";
            btnattendancestudent.Size = new Size(140, 60);
            btnattendancestudent.TabIndex = 4;
            btnattendancestudent.Text = "ATTENDANCE TRACKING \nFOR STUDENTS";
            btnattendancestudent.UseVisualStyleBackColor = true;
            // 
            // btngateentrance
            // 
            btngateentrance.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btngateentrance.Location = new Point(210, 195);
            btngateentrance.Name = "btngateentrance";
            btngateentrance.Size = new Size(140, 60);
            btngateentrance.TabIndex = 5;
            btngateentrance.Text = "GATE ENTRANCE IDENTITY\nTRACKER";
            btngateentrance.UseVisualStyleBackColor = true;
            // 
            // PBlogout
            // 
            PBlogout.Image = Properties.Resources.logoutICO;
            PBlogout.Location = new Point(58, 37);
            PBlogout.Name = "PBlogout";
            PBlogout.Size = new Size(100, 76);
            PBlogout.SizeMode = PictureBoxSizeMode.Zoom;
            PBlogout.TabIndex = 0;
            PBlogout.TabStop = false;
            // 
            // PBabout
            // 
            PBabout.Image = Properties.Resources.AboutICO;
            PBabout.Location = new Point(58, 142);
            PBabout.Name = "PBabout";
            PBabout.Size = new Size(100, 76);
            PBabout.SizeMode = PictureBoxSizeMode.Zoom;
            PBabout.TabIndex = 1;
            PBabout.TabStop = false;
            // 
            // PBContact
            // 
            PBContact.Image = Properties.Resources.ContactICO;
            PBContact.Location = new Point(58, 247);
            PBContact.Name = "PBContact";
            PBContact.Size = new Size(100, 76);
            PBContact.SizeMode = PictureBoxSizeMode.Zoom;
            PBContact.TabIndex = 2;
            PBContact.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 359);
            ControlBox = false;
            Controls.Add(btngateentrance);
            Controls.Add(btnattendancestudent);
            Controls.Add(btncamsetup);
            Controls.Add(btnatendanceprof);
            Controls.Add(btnlivecam);
            Controls.Add(panelmain);
            MaximumSize = new Size(631, 398);
            MinimumSize = new Size(631, 398);
            Name = "MainForm";
            Text = "Facial Recognition System  - Main Menu";
            panelmain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PBlogout).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBabout).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBContact).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelmain;
        private PictureBox PBContact;
        private PictureBox PBabout;
        private PictureBox PBlogout;
        private Button btnlivecam;
        private Button btnatendanceprof;
        private Button btncamsetup;
        private Button btnattendancestudent;
        private Button btngateentrance;
    }
}