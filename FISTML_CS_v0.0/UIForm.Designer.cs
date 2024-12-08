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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Backgroundlogin;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(lbPassword);
            panel1.Controls.Add(tbpassword);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(lbUsername);
            panel1.Controls.Add(tbUserid);
            panel1.Location = new Point(1, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(770, 547);
            panel1.TabIndex = 0;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.RoyalBlue;
            btnRegister.FlatStyle = FlatStyle.Popup;
            btnRegister.Location = new Point(175, 334);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.BackColor = Color.Transparent;
            lbPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPassword.ForeColor = Color.AliceBlue;
            lbPassword.Location = new Point(70, 247);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(79, 21);
            lbPassword.TabIndex = 4;
            lbPassword.Text = "Password";
            // 
            // tbpassword
            // 
            tbpassword.BackColor = Color.AliceBlue;
            tbpassword.Location = new Point(70, 271);
            tbpassword.Name = "tbpassword";
            tbpassword.Size = new Size(180, 23);
            tbpassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(70, 334);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.BackColor = Color.Transparent;
            lbUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUsername.ForeColor = Color.AliceBlue;
            lbUsername.Location = new Point(70, 172);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(63, 21);
            lbUsername.TabIndex = 1;
            lbUsername.Text = "User ID";
            // 
            // tbUserid
            // 
            tbUserid.BackColor = Color.AliceBlue;
            tbUserid.Location = new Point(70, 196);
            tbUserid.Name = "tbUserid";
            tbUserid.Size = new Size(180, 23);
            tbUserid.TabIndex = 0;
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
    }
}