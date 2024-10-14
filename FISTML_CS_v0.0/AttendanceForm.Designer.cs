namespace FISTML_CS_v0._0
{
    partial class AttendanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceForm));
            btnback = new Button();
            btnmenu = new Button();
            dateTimePickertoday = new DateTimePicker();
            lbdate = new Label();
            DGVattendance = new DataGridView();
            tbsearch = new TextBox();
            btnseach = new Button();
            imageList = new ImageList(components);
            label1 = new Label();
            btnA2Z = new Button();
            BtnZ2A = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVattendance).BeginInit();
            SuspendLayout();
            // 
            // btnback
            // 
            btnback.BackColor = Color.FromArgb(64, 64, 64);
            btnback.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnback.ForeColor = SystemColors.Control;
            btnback.Location = new Point(551, 33);
            btnback.Name = "btnback";
            btnback.Size = new Size(94, 35);
            btnback.TabIndex = 0;
            btnback.Text = "BACK";
            btnback.UseVisualStyleBackColor = false;
            // 
            // btnmenu
            // 
            btnmenu.BackColor = Color.FromArgb(64, 64, 64);
            btnmenu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnmenu.ForeColor = SystemColors.Control;
            btnmenu.Location = new Point(660, 33);
            btnmenu.Name = "btnmenu";
            btnmenu.Size = new Size(94, 35);
            btnmenu.TabIndex = 1;
            btnmenu.Text = "MENU";
            btnmenu.UseVisualStyleBackColor = false;
            // 
            // dateTimePickertoday
            // 
            dateTimePickertoday.Location = new Point(33, 51);
            dateTimePickertoday.Name = "dateTimePickertoday";
            dateTimePickertoday.Size = new Size(200, 23);
            dateTimePickertoday.TabIndex = 2;
            // 
            // lbdate
            // 
            lbdate.AutoSize = true;
            lbdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbdate.Location = new Point(33, 33);
            lbdate.Name = "lbdate";
            lbdate.Size = new Size(34, 15);
            lbdate.TabIndex = 3;
            lbdate.Text = "Date";
            // 
            // DGVattendance
            // 
            DGVattendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVattendance.Location = new Point(33, 158);
            DGVattendance.Name = "DGVattendance";
            DGVattendance.Size = new Size(729, 264);
            DGVattendance.TabIndex = 4;
            // 
            // tbsearch
            // 
            tbsearch.ForeColor = SystemColors.WindowFrame;
            tbsearch.Location = new Point(51, 128);
            tbsearch.Name = "tbsearch";
            tbsearch.Size = new Size(182, 23);
            tbsearch.TabIndex = 5;
            tbsearch.Text = "Search";
            // 
            // btnseach
            // 
            btnseach.ImageIndex = 0;
            btnseach.ImageList = imageList;
            btnseach.Location = new Point(239, 123);
            btnseach.Name = "btnseach";
            btnseach.Size = new Size(37, 30);
            btnseach.TabIndex = 6;
            btnseach.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "searchico.png");
            imageList.Images.SetKeyName(1, "filter1ICO.png");
            imageList.Images.SetKeyName(2, "filter2ICO.png");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(618, 131);
            label1.Name = "label1";
            label1.Size = new Size(47, 21);
            label1.TabIndex = 7;
            label1.Text = "Filter";
            // 
            // btnA2Z
            // 
            btnA2Z.ImageIndex = 1;
            btnA2Z.ImageList = imageList;
            btnA2Z.Location = new Point(671, 124);
            btnA2Z.Name = "btnA2Z";
            btnA2Z.Size = new Size(36, 28);
            btnA2Z.TabIndex = 8;
            btnA2Z.UseVisualStyleBackColor = true;
            // 
            // BtnZ2A
            // 
            BtnZ2A.ImageIndex = 2;
            BtnZ2A.ImageList = imageList;
            BtnZ2A.Location = new Point(713, 124);
            BtnZ2A.Name = "BtnZ2A";
            BtnZ2A.Size = new Size(36, 28);
            BtnZ2A.TabIndex = 9;
            BtnZ2A.UseVisualStyleBackColor = true;
            BtnZ2A.Click += button1_Click;
            // 
            // AttendanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(793, 441);
            ControlBox = false;
            Controls.Add(BtnZ2A);
            Controls.Add(btnA2Z);
            Controls.Add(label1);
            Controls.Add(btnseach);
            Controls.Add(tbsearch);
            Controls.Add(DGVattendance);
            Controls.Add(lbdate);
            Controls.Add(dateTimePickertoday);
            Controls.Add(btnmenu);
            Controls.Add(btnback);
            ForeColor = SystemColors.ActiveCaptionText;
            MaximumSize = new Size(809, 480);
            MinimumSize = new Size(809, 480);
            Name = "AttendanceForm";
            Text = "Facial Recognition System  -  Attendance Record Professor";
            TransparencyKey = Color.Transparent;
            Load += AttendanceForm_Load;
            ((System.ComponentModel.ISupportInitialize)DGVattendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnback;
        private Button btnmenu;
        private DateTimePicker dateTimePickertoday;
        private Label lbdate;
        private DataGridView DGVattendance;
        private TextBox tbsearch;
        private Button btnseach;
        private ImageList imageList;
        private Label label1;
        private Button btnA2Z;
        private Button BtnZ2A;
    }
}