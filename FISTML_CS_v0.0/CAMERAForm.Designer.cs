namespace FISTML_CS_v0._0
{
    partial class CAMERAForm
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
            panel1 = new Panel();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            button6 = new Button();
            button7 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Backgroundlogin;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(856, 636);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(722, 440);
            button1.Name = "button1";
            button1.Size = new Size(88, 23);
            button1.TabIndex = 18;
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.AliceBlue;
            label2.Location = new Point(598, 74);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 17;
            label2.Text = "CAPTURED";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.AliceBlue;
            label1.Location = new Point(194, 74);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 16;
            label1.Text = "CAMERA";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.AliceBlue;
            pictureBox2.Location = new Point(428, 91);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(382, 326);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.AliceBlue;
            pictureBox1.Location = new Point(40, 91);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(382, 326);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // button6
            // 
            button6.BackColor = Color.RoyalBlue;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Location = new Point(428, 440);
            button6.Name = "button6";
            button6.Size = new Size(88, 23);
            button6.TabIndex = 11;
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.RoyalBlue;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Location = new Point(40, 440);
            button7.Name = "button7";
            button7.Size = new Size(88, 23);
            button7.TabIndex = 10;
            button7.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(334, 440);
            button2.Name = "button2";
            button2.Size = new Size(88, 23);
            button2.TabIndex = 9;
            button2.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.BackgroundImage = Properties.Resources.Camera_off;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(614, 233);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 37);
            panel2.TabIndex = 20;
            // 
            // panel3
            // 
            panel3.BackColor = Color.AliceBlue;
            panel3.BackgroundImage = Properties.Resources.Camera_off;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Location = new Point(204, 233);
            panel3.Name = "panel3";
            panel3.Size = new Size(32, 37);
            panel3.TabIndex = 21;
            // 
            // CAMERAForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 638);
            Controls.Add(panel1);
            Name = "CAMERAForm";
            Text = "CAMERAForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button6;
        private Button button7;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Panel panel2;
    }
}