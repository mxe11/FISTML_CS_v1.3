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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelmain = new Panel();
            btnlivecam = new Button();
            btnatendanceprof = new Button();
            btncamsetup = new Button();
            btnattendancestudent = new Button();
            btngateentrance = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            imageListmenu = new ImageList(components);
            panelmain.SuspendLayout();
            SuspendLayout();
            // 
            // panelmain
            // 
            panelmain.BackColor = SystemColors.ActiveBorder;
            panelmain.Controls.Add(button3);
            panelmain.Controls.Add(button2);
            panelmain.Controls.Add(button1);
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
            // button1
            // 
            button1.BackColor = SystemColors.ActiveBorder;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ImageIndex = 2;
            button1.ImageList = imageListmenu;
            button1.Location = new Point(52, 37);
            button1.Name = "button1";
            button1.Size = new Size(100, 76);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveBorder;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ImageIndex = 0;
            button2.ImageList = imageListmenu;
            button2.Location = new Point(52, 142);
            button2.Name = "button2";
            button2.Size = new Size(100, 76);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveBorder;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ImageIndex = 1;
            button3.ImageList = imageListmenu;
            button3.Location = new Point(52, 249);
            button3.Name = "button3";
            button3.Size = new Size(100, 76);
            button3.TabIndex = 5;
            button3.UseVisualStyleBackColor = false;
            // 
            // imageListmenu
            // 
            imageListmenu.ColorDepth = ColorDepth.Depth32Bit;
            imageListmenu.ImageStream = (ImageListStreamer)resources.GetObject("imageListmenu.ImageStream");
            imageListmenu.TransparentColor = Color.Transparent;
            imageListmenu.Images.SetKeyName(0, "ContactICO.png");
            imageListmenu.Images.SetKeyName(1, "AboutICO.png");
            imageListmenu.Images.SetKeyName(2, "logoutICO.png");
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panelmain;
        private Button btnlivecam;
        private Button btnatendanceprof;
        private Button btncamsetup;
        private Button btnattendancestudent;
        private Button btngateentrance;
        private Button button3;
        private Button button2;
        private ImageList imageListmenu;
        private Button button1;
    }
}