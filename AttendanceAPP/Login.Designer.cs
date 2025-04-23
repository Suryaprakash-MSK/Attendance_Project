namespace AttendanceAPP
{
    partial class Login
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            checkBox = new CheckBox();
            btnLogIn = new Button();
            btnClear = new Button();
            btnExit = new Button();
            label1 = new Label();
            PasswordTxt = new TextBox();
            UsernameTxt = new TextBox();
            Passwordlabel = new Label();
            Usernamelabel = new Label();
            Title = new Label();
            icon = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(0, 10, 10);
            panel1.Controls.Add(checkBox);
            panel1.Controls.Add(btnLogIn);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(PasswordTxt);
            panel1.Controls.Add(UsernameTxt);
            panel1.Controls.Add(Passwordlabel);
            panel1.Controls.Add(Usernamelabel);
            panel1.Location = new Point(214, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(483, 427);
            panel1.TabIndex = 0;
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Cursor = Cursors.Hand;
            checkBox.ForeColor = Color.PaleGoldenrod;
            checkBox.Location = new Point(185, 268);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(132, 24);
            checkBox.TabIndex = 8;
            checkBox.Text = "Show Password";
            checkBox.TextAlign = ContentAlignment.MiddleCenter;
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = SystemColors.ActiveCaptionText;
            btnLogIn.Cursor = Cursors.Hand;
            btnLogIn.Enabled = false;
            btnLogIn.FlatAppearance.BorderColor = Color.DarkTurquoise;
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnLogIn.ForeColor = Color.DarkTurquoise;
            btnLogIn.Location = new Point(200, 321);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(100, 40);
            btnLogIn.TabIndex = 5;
            btnLogIn.Text = "LogIn";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ActiveCaptionText;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.DarkTurquoise;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.DarkTurquoise;
            btnClear.Location = new Point(331, 321);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 40);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnExit.ForeColor = Color.MistyRose;
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnExit.Location = new Point(21, 388);
            btnExit.Margin = new Padding(0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 29);
            btnExit.TabIndex = 7;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Tan;
            label1.Location = new Point(206, 44);
            label1.Name = "label1";
            label1.Size = new Size(92, 35);
            label1.TabIndex = 4;
            label1.Text = "LOGIN";
            // 
            // PasswordTxt
            // 
            PasswordTxt.BackColor = SystemColors.InactiveCaptionText;
            PasswordTxt.Cursor = Cursors.IBeam;
            PasswordTxt.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            PasswordTxt.ForeColor = Color.DarkTurquoise;
            PasswordTxt.Location = new Point(185, 216);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PlaceholderText = "Enter Passsword";
            PasswordTxt.Size = new Size(265, 30);
            PasswordTxt.TabIndex = 3;
            // 
            // UsernameTxt
            // 
            UsernameTxt.BackColor = SystemColors.InactiveCaptionText;
            UsernameTxt.Cursor = Cursors.IBeam;
            UsernameTxt.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameTxt.ForeColor = Color.DarkTurquoise;
            UsernameTxt.Location = new Point(185, 116);
            UsernameTxt.Name = "UsernameTxt";
            UsernameTxt.PlaceholderText = "Enter Username";
            UsernameTxt.Size = new Size(265, 30);
            UsernameTxt.TabIndex = 2;
            // 
            // Passwordlabel
            // 
            Passwordlabel.AutoSize = true;
            Passwordlabel.Font = new Font("Segoe UI", 15F);
            Passwordlabel.ForeColor = Color.DarkCyan;
            Passwordlabel.Location = new Point(50, 211);
            Passwordlabel.Name = "Passwordlabel";
            Passwordlabel.Size = new Size(139, 35);
            Passwordlabel.TabIndex = 1;
            Passwordlabel.Text = "Password  :";
            // 
            // Usernamelabel
            // 
            Usernamelabel.AutoSize = true;
            Usernamelabel.Font = new Font("Segoe UI", 15F);
            Usernamelabel.ForeColor = Color.DarkCyan;
            Usernamelabel.Location = new Point(50, 111);
            Usernamelabel.Name = "Usernamelabel";
            Usernamelabel.Size = new Size(139, 35);
            Usernamelabel.TabIndex = 0;
            Usernamelabel.Text = "Username :";
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top;
            Title.AutoSize = true;
            Title.BackColor = Color.Transparent;
            Title.Font = new Font("Century Gothic", 34.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Title.ForeColor = Color.DarkTurquoise;
            Title.ImageAlign = ContentAlignment.TopLeft;
            Title.Location = new Point(111, -6);
            Title.Name = "Title";
            Title.Size = new Size(689, 72);
            Title.TabIndex = 12;
            Title.Text = "Automatic Attendance ";
            // 
            // icon
            // 
            icon.Anchor = AnchorStyles.Top;
            icon.BackColor = Color.Transparent;
            icon.BackgroundImageLayout = ImageLayout.Zoom;
            icon.Image = (Image)resources.GetObject("icon.Image");
            icon.Location = new Point(842, 456);
            icon.Name = "icon";
            icon.Size = new Size(70, 70);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.TabIndex = 11;
            icon.TabStop = false;
            // 
            // Login
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(910, 524);
            Controls.Add(Title);
            Controls.Add(icon);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label Passwordlabel;
        private Label Usernamelabel;
        private TextBox PasswordTxt;
        private TextBox UsernameTxt;
        private Label label1;
        private Button btnClear;
        private Button btnLogIn;
        private Button btnExit;
        private Label Title;
        private PictureBox icon;
        private CheckBox checkBox;
    }
}
