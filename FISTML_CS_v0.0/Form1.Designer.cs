namespace FISTML_CS_v0._0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            testingPANEL = new Panel();
            back = new Button();
            textBox2 = new TextBox();
            detectFaceBTN = new Button();
            saveImageBTN = new Button();
            openCamBTN = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            schedulerPANEL = new Panel();
            subName = new TextBox();
            classCodeText = new TextBox();
            schedulerReturnBTN = new Button();
            roomSelectorComboBox = new ComboBox();
            submitToDbBTN = new Button();
            timeSelectorComboBox = new ComboBox();
            profText = new TextBox();
            dashboard = new Panel();
            schedulerWindowBTN = new Button();
            testingBTN = new Button();
            testingPANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            schedulerPANEL.SuspendLayout();
            dashboard.SuspendLayout();
            SuspendLayout();
            // 
            // testingPANEL
            // 
            testingPANEL.Controls.Add(back);
            testingPANEL.Controls.Add(textBox2);
            testingPANEL.Controls.Add(detectFaceBTN);
            testingPANEL.Controls.Add(saveImageBTN);
            testingPANEL.Controls.Add(openCamBTN);
            testingPANEL.Controls.Add(textBox1);
            testingPANEL.Controls.Add(label2);
            testingPANEL.Controls.Add(label1);
            testingPANEL.Controls.Add(pictureBox2);
            testingPANEL.Controls.Add(pictureBox1);
            testingPANEL.Location = new Point(0, 0);
            testingPANEL.Name = "testingPANEL";
            testingPANEL.Size = new Size(803, 501);
            testingPANEL.TabIndex = 10;
            // 
            // back
            // 
            back.Location = new Point(657, 450);
            back.Margin = new Padding(3, 2, 3, 2);
            back.Name = "back";
            back.Size = new Size(129, 22);
            back.TabIndex = 19;
            back.Text = "Back To Dashboard";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(422, 449);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(110, 23);
            textBox2.TabIndex = 18;
            // 
            // detectFaceBTN
            // 
            detectFaceBTN.Location = new Point(335, 447);
            detectFaceBTN.Margin = new Padding(3, 2, 3, 2);
            detectFaceBTN.Name = "detectFaceBTN";
            detectFaceBTN.Size = new Size(82, 22);
            detectFaceBTN.TabIndex = 17;
            detectFaceBTN.Text = "detect face";
            detectFaceBTN.UseVisualStyleBackColor = true;
            detectFaceBTN.Click += detectFaceBTN_Click;
            // 
            // saveImageBTN
            // 
            saveImageBTN.Location = new Point(335, 421);
            saveImageBTN.Margin = new Padding(3, 2, 3, 2);
            saveImageBTN.Name = "saveImageBTN";
            saveImageBTN.Size = new Size(82, 22);
            saveImageBTN.TabIndex = 16;
            saveImageBTN.Text = "save image";
            saveImageBTN.UseVisualStyleBackColor = true;
            saveImageBTN.Click += saveImageBTN_Click;
            // 
            // openCamBTN
            // 
            openCamBTN.Location = new Point(335, 395);
            openCamBTN.Margin = new Padding(3, 2, 3, 2);
            openCamBTN.Name = "openCamBTN";
            openCamBTN.Size = new Size(82, 22);
            openCamBTN.TabIndex = 15;
            openCamBTN.Text = "open cam";
            openCamBTN.UseVisualStyleBackColor = true;
            openCamBTN.Click += openCamBTN_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(422, 421);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 23);
            textBox1.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(732, 30);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 13;
            label2.Text = "captured";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(352, 28);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 12;
            label1.Text = "camera";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(404, 47);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(382, 326);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(16, 47);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(382, 326);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // schedulerPANEL
            // 
            schedulerPANEL.Controls.Add(subName);
            schedulerPANEL.Controls.Add(classCodeText);
            schedulerPANEL.Controls.Add(schedulerReturnBTN);
            schedulerPANEL.Controls.Add(roomSelectorComboBox);
            schedulerPANEL.Controls.Add(submitToDbBTN);
            schedulerPANEL.Controls.Add(timeSelectorComboBox);
            schedulerPANEL.Controls.Add(profText);
            schedulerPANEL.Location = new Point(0, 0);
            schedulerPANEL.Name = "schedulerPANEL";
            schedulerPANEL.Size = new Size(803, 501);
            schedulerPANEL.TabIndex = 11;
            // 
            // subName
            // 
            subName.Location = new Point(16, 79);
            subName.Name = "subName";
            subName.PlaceholderText = "Enter subject name.";
            subName.Size = new Size(277, 23);
            subName.TabIndex = 7;
            // 
            // classCodeText
            // 
            classCodeText.Location = new Point(16, 49);
            classCodeText.Name = "classCodeText";
            classCodeText.PlaceholderText = "Enter class code.";
            classCodeText.Size = new Size(147, 23);
            classCodeText.TabIndex = 6;
            // 
            // schedulerReturnBTN
            // 
            schedulerReturnBTN.Location = new Point(16, 199);
            schedulerReturnBTN.Name = "schedulerReturnBTN";
            schedulerReturnBTN.Size = new Size(289, 23);
            schedulerReturnBTN.TabIndex = 5;
            schedulerReturnBTN.Text = "Return";
            schedulerReturnBTN.UseVisualStyleBackColor = true;
            schedulerReturnBTN.Click += schedulerReturnBTN_Click;
            // 
            // roomSelectorComboBox
            // 
            roomSelectorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roomSelectorComboBox.FormattingEnabled = true;
            roomSelectorComboBox.Items.AddRange(new object[] { "AP202", "AP203" });
            roomSelectorComboBox.Location = new Point(16, 139);
            roomSelectorComboBox.Name = "roomSelectorComboBox";
            roomSelectorComboBox.Size = new Size(121, 23);
            roomSelectorComboBox.TabIndex = 4;
            // 
            // submitToDbBTN
            // 
            submitToDbBTN.Location = new Point(16, 169);
            submitToDbBTN.Name = "submitToDbBTN";
            submitToDbBTN.Size = new Size(289, 23);
            submitToDbBTN.TabIndex = 3;
            submitToDbBTN.Text = "Submit Scheduled Detection To Database";
            submitToDbBTN.UseVisualStyleBackColor = true;
            submitToDbBTN.Click += submitToDbBTN_Click;
            // 
            // timeSelectorComboBox
            // 
            timeSelectorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            timeSelectorComboBox.FormattingEnabled = true;
            timeSelectorComboBox.Items.AddRange(new object[] { "06:00 am - 07:00 am", "07:00 am - 08:00 am", "08:00 am - 09:00 am", "10:00 am - 11:00 am", "11:00 am - 12:00 pm", "12:00 pm - 01:00 pm", "01:00 pm - 02:00 pm", "02:00 pm - 03:00 pm", "03:00 pm - 04:00 pm", "04:00 pm - 05:00 pm", "05:00 pm - 06:00 pm", "06:00 pm - 07:00 pm", "07:00 pm - 08:00 pm", "08:00 pm - 09:00 pm", "09:00 pm - 10:00 pm" });
            timeSelectorComboBox.Location = new Point(16, 109);
            timeSelectorComboBox.Name = "timeSelectorComboBox";
            timeSelectorComboBox.Size = new Size(121, 23);
            timeSelectorComboBox.TabIndex = 1;
            // 
            // profText
            // 
            profText.Location = new Point(16, 19);
            profText.Name = "profText";
            profText.PlaceholderText = "Enter a prof to detect.";
            profText.Size = new Size(277, 23);
            profText.TabIndex = 0;
            // 
            // dashboard
            // 
            dashboard.Controls.Add(schedulerWindowBTN);
            dashboard.Controls.Add(testingBTN);
            dashboard.Location = new Point(0, 0);
            dashboard.Name = "dashboard";
            dashboard.Size = new Size(803, 501);
            dashboard.TabIndex = 20;
            // 
            // schedulerWindowBTN
            // 
            schedulerWindowBTN.Location = new Point(16, 51);
            schedulerWindowBTN.Name = "schedulerWindowBTN";
            schedulerWindowBTN.Size = new Size(147, 23);
            schedulerWindowBTN.TabIndex = 1;
            schedulerWindowBTN.Text = "Scheduler Window";
            schedulerWindowBTN.UseVisualStyleBackColor = true;
            schedulerWindowBTN.Click += schedulerWindowBTN_Click;
            // 
            // testingBTN
            // 
            testingBTN.Location = new Point(16, 22);
            testingBTN.Name = "testingBTN";
            testingBTN.Size = new Size(147, 23);
            testingBTN.TabIndex = 0;
            testingBTN.Text = "Testing Window";
            testingBTN.UseVisualStyleBackColor = true;
            testingBTN.Click += testingBTN_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 498);
            Controls.Add(schedulerPANEL);
            Controls.Add(dashboard);
            Controls.Add(testingPANEL);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(816, 537);
            MinimumSize = new Size(816, 537);
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FISTML ";
            testingPANEL.ResumeLayout(false);
            testingPANEL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            schedulerPANEL.ResumeLayout(false);
            schedulerPANEL.PerformLayout();
            dashboard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel testingPANEL;
        private TextBox textBox2;
        private Button detectFaceBTN;
        private Button saveImageBTN;
        private Button openCamBTN;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button back;
        private Panel schedulerPANEL;
        private Panel dashboard;
        private Button testingBTN;
        private ComboBox timeSelectorComboBox;
        private Button submitToDbBTN;
        private TextBox profText;
        private ComboBox roomSelectorComboBox;
        private Button schedulerWindowBTN;
        private Button schedulerReturnBTN;
        private TextBox classCodeText;
        private TextBox subName;
    }
}
