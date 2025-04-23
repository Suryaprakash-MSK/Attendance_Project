namespace AttendanceAPP
{
    partial class Loading
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            label8 = new Label();
            label7 = new Label();
            Title = new Label();
            icon = new PictureBox();
            progressBar = new ProgressBar();
            progresstime = new System.Windows.Forms.Timer(components);
            labelProgress = new Label();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Lucida Fax", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.SkyBlue;
            label8.Location = new Point(370, 243);
            label8.Name = "label8";
            label8.Size = new Size(61, 17);
            label8.TabIndex = 25;
            label8.Text = "@2025";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.SkyBlue;
            label7.Location = new Point(339, 211);
            label7.Name = "label7";
            label7.Size = new Size(122, 23);
            label7.TabIndex = 24;
            label7.Text = "Version  1.0";
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top;
            Title.AutoSize = true;
            Title.Font = new Font("Century Gothic", 28F, FontStyle.Bold | FontStyle.Italic);
            Title.ForeColor = Color.SkyBlue;
            Title.Location = new Point(127, 144);
            Title.Name = "Title";
            Title.Size = new Size(546, 57);
            Title.TabIndex = 23;
            Title.Text = "Automatic Attendance";
            // 
            // icon
            // 
            icon.Anchor = AnchorStyles.Top;
            icon.BackgroundImageLayout = ImageLayout.Zoom;
            icon.Image = (Image)resources.GetObject("icon.Image");
            icon.Location = new Point(300, -25);
            icon.Name = "icon";
            icon.Size = new Size(200, 200);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.TabIndex = 22;
            icon.TabStop = false;
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Bottom;
            progressBar.ForeColor = Color.SkyBlue;
            progressBar.Location = new Point(0, 357);
            progressBar.Margin = new Padding(0);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(782, 8);
            progressBar.Step = 1;
            progressBar.TabIndex = 21;
            // 
            // progresstime
            // 
            progresstime.Interval = 50;
            progresstime.Tick += progresstime_Tick;
            // 
            // labelProgress
            // 
            labelProgress.Anchor = AnchorStyles.Bottom;
            labelProgress.AutoSize = true;
            labelProgress.Font = new Font("Lucida Fax", 9F, FontStyle.Bold | FontStyle.Italic);
            labelProgress.ForeColor = Color.DeepSkyBlue;
            labelProgress.Location = new Point(348, 320);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(87, 17);
            labelProgress.TabIndex = 26;
            labelProgress.Text = "Loading....";
            // 
            // Loading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(782, 365);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(Title);
            Controls.Add(icon);
            Controls.Add(progressBar);
            Controls.Add(labelProgress);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Loading";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Loading_Load;
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label8;
        private Label label7;
        private Label Title;
        private PictureBox icon;
        private ProgressBar progressBar;
        private System.Windows.Forms.Timer progresstime;
        private Label labelProgress;
    }
}
