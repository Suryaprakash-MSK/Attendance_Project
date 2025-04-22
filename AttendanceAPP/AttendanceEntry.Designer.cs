namespace AttendanceAPP
{
    partial class AttendanceEntry
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
            label2 = new Label();
            pictureBox = new PictureBox();
            listBoxDevices = new ListBox();
            btnStart = new Button();
            btnStop = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(216, 23);
            label2.TabIndex = 6;
            label2.Text = "Entry Time Camera";
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = SystemColors.Desktop;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(13, 40);
            pictureBox.Margin = new Padding(4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1293, 454);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 21;
            pictureBox.TabStop = false;
            // 
            // listBoxDevices
            // 
            listBoxDevices.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            listBoxDevices.FormattingEnabled = true;
            listBoxDevices.ItemHeight = 17;
            listBoxDevices.Location = new Point(502, 12);
            listBoxDevices.Name = "listBoxDevices";
            listBoxDevices.Size = new Size(312, 21);
            listBoxDevices.TabIndex = 22;
            listBoxDevices.SelectedIndexChanged += listBoxDevices_SelectedIndexChanged;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStart.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnStart.Location = new Point(12, 501);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(550, 40);
            btnStart.TabIndex = 23;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStop.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnStop.Location = new Point(756, 501);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(550, 40);
            btnStop.TabIndex = 24;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // AttendanceEntry
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(listBoxDevices);
            Controls.Add(pictureBox);
            Controls.Add(label2);
            Name = "AttendanceEntry";
            Size = new Size(1319, 553);
            Load += AttendanceEntry_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private PictureBox pictureBox;
        private ListBox listBoxDevices;
        private Button btnStart;
        private Button btnStop;
    }
}