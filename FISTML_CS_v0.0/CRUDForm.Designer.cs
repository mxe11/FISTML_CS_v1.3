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
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Backgroundlogin;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
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
            button1.Location = new Point(57, 63);
            button1.Name = "button1";
            button1.Size = new Size(88, 23);
            button1.TabIndex = 7;
            button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(200, 52);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(525, 432);
            dataGridView1.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.BackgroundImage = Properties.Resources.Rectangle_7;
            panel5.BackgroundImageLayout = ImageLayout.Stretch;
            panel5.Location = new Point(62, 134);
            panel5.Name = "panel5";
            panel5.Size = new Size(83, 29);
            panel5.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = Properties.Resources.Rectangle_7;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(62, 183);
            panel2.Name = "panel2";
            panel2.Size = new Size(83, 29);
            panel2.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = Properties.Resources.Rectangle_7;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Location = new Point(62, 284);
            panel3.Name = "panel3";
            panel3.Size = new Size(83, 29);
            panel3.TabIndex = 15;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BackgroundImage = Properties.Resources.Rectangle_7;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Location = new Point(62, 235);
            panel4.Name = "panel4";
            panel4.Size = new Size(83, 29);
            panel4.TabIndex = 14;
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private DataGridView dataGridView1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
        private Panel panel5;
    }
}