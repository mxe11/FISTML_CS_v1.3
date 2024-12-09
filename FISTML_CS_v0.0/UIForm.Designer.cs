namespace FISTML_CS_v0._0
{
    partial class UIForm
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
            btnRegister = new Button();
            lbPassword = new Label();
            tbpassword = new TextBox();
            btnLogin = new Button();
            lbUsername = new Label();
            tbUserid = new TextBox();
            panel10 = new Panel();
            lbfistml = new Label();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Backgroundlogin;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(lbfistml);
            panel1.Controls.Add(panel10);
            panel1.Location = new Point(1, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(770, 547);
            panel1.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.RoyalBlue;
            btnRegister.FlatStyle = FlatStyle.Popup;
            btnRegister.Location = new Point(168, 331);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 5;
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.BackColor = Color.Transparent;
            lbPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPassword.ForeColor = Color.AliceBlue;
            lbPassword.Location = new Point(63, 244);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(79, 21);
            lbPassword.TabIndex = 4;
            lbPassword.Text = "Password";
            // 
            // tbpassword
            // 
            tbpassword.BackColor = Color.AliceBlue;
            tbpassword.Location = new Point(63, 268);
            tbpassword.Name = "tbpassword";
            tbpassword.Size = new Size(180, 23);
            tbpassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(63, 331);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 2;
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.BackColor = Color.Transparent;
            lbUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUsername.ForeColor = Color.AliceBlue;
            lbUsername.Location = new Point(63, 169);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(63, 21);
            lbUsername.TabIndex = 1;
            lbUsername.Text = "User ID";
            // 
            // tbUserid
            // 
            tbUserid.BackColor = Color.AliceBlue;
            tbUserid.Location = new Point(63, 193);
            tbUserid.Name = "tbUserid";
            tbUserid.Size = new Size(180, 23);
            tbUserid.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Transparent;
            panel10.BackgroundImage = Properties.Resources.Rectangle_16;
            panel10.BackgroundImageLayout = ImageLayout.Stretch;
            panel10.Controls.Add(tbUserid);
            panel10.Controls.Add(lbUsername);
            panel10.Controls.Add(btnRegister);
            panel10.Controls.Add(btnLogin);
            panel10.Controls.Add(lbPassword);
            panel10.Controls.Add(tbpassword);
            panel10.Location = new Point(0, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(322, 541);
            panel10.TabIndex = 10;
            // 
            // lbfistml
            // 
            lbfistml.AutoSize = true;
            lbfistml.BackColor = Color.Transparent;
            lbfistml.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbfistml.ForeColor = Color.AliceBlue;
            lbfistml.Location = new Point(381, 184);
            lbfistml.Name = "lbfistml";
            lbfistml.Size = new Size(354, 141);
            lbfistml.TabIndex = 0;
            lbfistml.Text = "Facial Identification \r\n   System Through \r\n  Machine Learning";
            // 
            // UIForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 539);
            Controls.Add(panel1);
            Name = "UIForm";
            Text = "UIForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        public TextBox tbUserid;
        private Label lbPassword;
        public TextBox tbpassword;
        private Button btnLogin;
        private Label lbUsername;
        private Button btnRegister;
        private Panel panel10;
        private Label lbfistml;
    }
}