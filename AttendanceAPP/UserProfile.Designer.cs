namespace AttendanceAPP
{
    partial class UserProfile
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
            GenderComboBox = new ComboBox();
            AgeTXT = new TextBox();
            label2 = new Label();
            label1 = new Label();
            UserNameTXT = new TextBox();
            UseridTXT = new TextBox();
            Usernamelb = new Label();
            Useridlb = new Label();
            DetectedImage = new Label();
            pictureBoxImage = new PictureBox();
            Camera = new Label();
            pictureBox = new PictureBox();
            dataGrid = new DataGridView();
            btnStop = new Button();
            btnStart = new Button();
            btnCapture = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // GenderComboBox
            // 
            GenderComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GenderComboBox.Cursor = Cursors.IBeam;
            GenderComboBox.FlatStyle = FlatStyle.System;
            GenderComboBox.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            GenderComboBox.FormattingEnabled = true;
            GenderComboBox.Items.AddRange(new object[] { "Male", "Female", "Other" });
            GenderComboBox.Location = new Point(944, 140);
            GenderComboBox.Margin = new Padding(4);
            GenderComboBox.Name = "GenderComboBox";
            GenderComboBox.Size = new Size(493, 28);
            GenderComboBox.TabIndex = 39;
            // 
            // AgeTXT
            // 
            AgeTXT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AgeTXT.Cursor = Cursors.IBeam;
            AgeTXT.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            AgeTXT.Location = new Point(944, 189);
            AgeTXT.Margin = new Padding(4);
            AgeTXT.Name = "AgeTXT";
            AgeTXT.PlaceholderText = "Enter Age";
            AgeTXT.Size = new Size(493, 28);
            AgeTXT.TabIndex = 38;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            label2.Location = new Point(824, 140);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 37;
            label2.Text = "Gender     :";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            label1.Location = new Point(824, 189);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 36;
            label1.Text = "Age          :";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserNameTXT
            // 
            UserNameTXT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UserNameTXT.Cursor = Cursors.IBeam;
            UserNameTXT.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            UserNameTXT.Location = new Point(944, 89);
            UserNameTXT.Margin = new Padding(4);
            UserNameTXT.Name = "UserNameTXT";
            UserNameTXT.PlaceholderText = "Enter Username";
            UserNameTXT.Size = new Size(493, 28);
            UserNameTXT.TabIndex = 35;
            // 
            // UseridTXT
            // 
            UseridTXT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UseridTXT.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            UseridTXT.Location = new Point(944, 40);
            UseridTXT.Margin = new Padding(4);
            UseridTXT.Name = "UseridTXT";
            UseridTXT.PlaceholderText = "Updated Automatically";
            UseridTXT.Size = new Size(493, 28);
            UseridTXT.TabIndex = 34;
            // 
            // Usernamelb
            // 
            Usernamelb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Usernamelb.AutoSize = true;
            Usernamelb.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            Usernamelb.Location = new Point(824, 89);
            Usernamelb.Margin = new Padding(4, 0, 4, 0);
            Usernamelb.Name = "Usernamelb";
            Usernamelb.Size = new Size(112, 20);
            Usernamelb.TabIndex = 33;
            Usernamelb.Text = "UserName :";
            Usernamelb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Useridlb
            // 
            Useridlb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Useridlb.AutoSize = true;
            Useridlb.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            Useridlb.Location = new Point(824, 40);
            Useridlb.Margin = new Padding(4, 0, 4, 0);
            Useridlb.Name = "Useridlb";
            Useridlb.Size = new Size(112, 20);
            Useridlb.TabIndex = 32;
            Useridlb.Text = "UserID      :";
            Useridlb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DetectedImage
            // 
            DetectedImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DetectedImage.AutoSize = true;
            DetectedImage.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            DetectedImage.Location = new Point(824, 221);
            DetectedImage.Margin = new Padding(4, 0, 4, 0);
            DetectedImage.Name = "DetectedImage";
            DetectedImage.Size = new Size(168, 22);
            DetectedImage.TabIndex = 31;
            DetectedImage.Text = "Captured Image";
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBoxImage.BackColor = SystemColors.Desktop;
            pictureBoxImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImage.Location = new Point(824, 247);
            pictureBoxImage.Margin = new Padding(4);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(240, 225);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 30;
            pictureBoxImage.TabStop = false;
            // 
            // Camera
            // 
            Camera.AutoSize = true;
            Camera.Font = new Font("Lucida Fax", 12F, FontStyle.Bold);
            Camera.Location = new Point(13, 10);
            Camera.Margin = new Padding(4, 0, 4, 0);
            Camera.Name = "Camera";
            Camera.Size = new Size(91, 23);
            Camera.TabIndex = 29;
            Camera.Text = "Camera";
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = SystemColors.Desktop;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(13, 37);
            pictureBox.Margin = new Padding(4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(803, 437);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 28;
            pictureBox.TabStop = false;
            // 
            // dataGrid
            // 
            dataGrid.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.BackgroundColor = SystemColors.WindowFrame;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(13, 482);
            dataGrid.Margin = new Padding(4);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.Size = new Size(1424, 250);
            dataGrid.TabIndex = 44;
            dataGrid.Click += UserProfile_Load;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Right;
            btnStop.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnStop.Location = new Point(1105, 278);
            btnStop.Margin = new Padding(4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(300, 30);
            btnStop.TabIndex = 50;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Right;
            btnStart.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnStart.Location = new Point(1105, 225);
            btnStart.Margin = new Padding(4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(300, 30);
            btnStart.TabIndex = 48;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnCapture
            // 
            btnCapture.Anchor = AnchorStyles.Right;
            btnCapture.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnCapture.Location = new Point(1105, 331);
            btnCapture.Margin = new Padding(4);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(300, 30);
            btnCapture.TabIndex = 49;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Right;
            btnDelete.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnDelete.Location = new Point(1105, 384);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(300, 30);
            btnDelete.TabIndex = 47;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Right;
            btnSave.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnSave.Location = new Point(1105, 437);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(300, 30);
            btnSave.TabIndex = 45;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // UserProfile
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(btnCapture);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(dataGrid);
            Controls.Add(GenderComboBox);
            Controls.Add(AgeTXT);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(UserNameTXT);
            Controls.Add(UseridTXT);
            Controls.Add(Usernamelb);
            Controls.Add(Useridlb);
            Controls.Add(DetectedImage);
            Controls.Add(pictureBoxImage);
            Controls.Add(Camera);
            Controls.Add(pictureBox);
            Name = "UserProfile";
            Size = new Size(1450, 745);
            Load += UserProfile_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox GenderComboBox;
        private TextBox AgeTXT;
        private Label label2;
        private Label label1;
        private TextBox UserNameTXT;
        private TextBox UseridTXT;
        private Label Usernamelb;
        private Label Useridlb;
        private Label DetectedImage;
        private PictureBox pictureBoxImage;
        private Label Camera;
        private PictureBox pictureBox;
        private DataGridView dataGrid;
        private Button btnStop;
        private Button btnStart;
        private Button btnCapture;
        private Button btnDelete;
        private Button btnSave;
    }
}