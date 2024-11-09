namespace FISTML_CS_v0._0
{
    partial class CRUDForm
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
            dataGridView1 = new DataGridView();
            panel5 = new Panel();
            lbfistml = new Label();
            panel6 = new Panel();
            lbbutton = new Label();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Backgroundlogin;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(lbfistml);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 577);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(44, 70);
            button1.Name = "button1";
            button1.Size = new Size(88, 23);
            button1.TabIndex = 7;
            button1.Text = "button";
            button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(211, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(525, 432);
            dataGridView1.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.BackgroundImage = Properties.Resources.Rectangle_7;
            panel5.BackgroundImageLayout = ImageLayout.Stretch;
            panel5.Controls.Add(lbbutton);
            panel5.Location = new Point(31, 114);
            panel5.Name = "panel5";
            panel5.Size = new Size(114, 38);
            panel5.TabIndex = 12;
            // 
            // lbfistml
            // 
            lbfistml.AutoSize = true;
            lbfistml.BackColor = Color.Transparent;
            lbfistml.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbfistml.ForeColor = Color.AliceBlue;
            lbfistml.Location = new Point(31, 22);
            lbfistml.Name = "lbfistml";
            lbfistml.Size = new Size(44, 21);
            lbfistml.TabIndex = 16;
            lbfistml.Text = "Title";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Transparent;
            panel6.BackgroundImage = Properties.Resources._00_Button;
            panel6.BackgroundImageLayout = ImageLayout.Stretch;
            panel6.Location = new Point(639, 22);
            panel6.Name = "panel6";
            panel6.Size = new Size(97, 30);
            panel6.TabIndex = 13;
            // 
            // lbbutton
            // 
            lbbutton.AutoSize = true;
            lbbutton.BackColor = Color.Transparent;
            lbbutton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbbutton.ForeColor = Color.AliceBlue;
            lbbutton.Location = new Point(23, 6);
            lbbutton.Name = "lbbutton";
            lbbutton.Size = new Size(64, 19);
            lbbutton.TabIndex = 5;
            lbbutton.Text = "btnname";
            lbbutton.Click += lbbutton_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = Properties.Resources.Rectangle_7__1_;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(31, 167);
            panel2.Name = "panel2";
            panel2.Size = new Size(114, 38);
            panel2.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.AliceBlue;
            label1.Location = new Point(23, 6);
            label1.Name = "label1";
            label1.Size = new Size(64, 19);
            label1.TabIndex = 5;
            label1.Text = "btnname";
            // 
            // CRUDForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 578);
            Controls.Add(panel1);
            Name = "CRUDForm";
            Text = "CRUDForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private DataGridView dataGridView1;
        private Panel panel5;
        private Label lbfistml;
        private Panel panel6;
        private Label lbbutton;
        private Panel panel2;
        private Label label1;
    }
}