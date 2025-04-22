namespace AttendanceAPP
{
    partial class PresentRecords
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
            pictureBoxImage = new PictureBox();
            label8 = new Label();
            txtTotalDaysAbsent = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtTotalDays = new TextBox();
            txtUsername = new TextBox();
            btnTotalDaysPresent = new Button();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            Exportbtn = new Button();
            dataGrid = new DataGridView();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBoxImage.BackColor = SystemColors.Desktop;
            pictureBoxImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImage.Location = new Point(1198, 443);
            pictureBoxImage.Margin = new Padding(4);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(197, 169);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 40;
            pictureBoxImage.TabStop = false;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label8.Location = new Point(714, 556);
            label8.Name = "label8";
            label8.Size = new Size(211, 22);
            label8.TabIndex = 39;
            label8.Text = "Total Days Absent  :";
            // 
            // txtTotalDaysAbsent
            // 
            txtTotalDaysAbsent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtTotalDaysAbsent.Location = new Point(930, 551);
            txtTotalDaysAbsent.Name = "txtTotalDaysAbsent";
            txtTotalDaysAbsent.ReadOnly = true;
            txtTotalDaysAbsent.Size = new Size(236, 27);
            txtTotalDaysAbsent.TabIndex = 38;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label7.Location = new Point(714, 520);
            label7.Name = "label7";
            label7.Size = new Size(210, 22);
            label7.TabIndex = 37;
            label7.Text = "Total Days Present :";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label6.Location = new Point(716, 484);
            label6.Name = "label6";
            label6.Size = new Size(210, 22);
            label6.TabIndex = 36;
            label6.Text = "Enter Username      :";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label5.Location = new Point(24, 523);
            label5.Name = "label5";
            label5.Size = new Size(120, 22);
            label5.TabIndex = 35;
            label5.Text = "Start Date :";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label4.Location = new Point(280, 523);
            label4.Name = "label4";
            label4.Size = new Size(111, 22);
            label4.TabIndex = 34;
            label4.Text = "End Date :";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.OrangeRed;
            label3.Location = new Point(23, 454);
            label3.Name = "label3";
            label3.Size = new Size(255, 23);
            label3.TabIndex = 33;
            label3.Text = "Get Total Days Present";
            // 
            // txtTotalDays
            // 
            txtTotalDays.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtTotalDays.Location = new Point(930, 518);
            txtTotalDays.Name = "txtTotalDays";
            txtTotalDays.ReadOnly = true;
            txtTotalDays.Size = new Size(236, 27);
            txtTotalDays.TabIndex = 32;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtUsername.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            txtUsername.Location = new Point(930, 484);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(236, 28);
            txtUsername.TabIndex = 31;
            // 
            // btnTotalDaysPresent
            // 
            btnTotalDaysPresent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTotalDaysPresent.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnTotalDaysPresent.Location = new Point(396, 582);
            btnTotalDaysPresent.Name = "btnTotalDaysPresent";
            btnTotalDaysPresent.Size = new Size(610, 30);
            btnTotalDaysPresent.TabIndex = 30;
            btnTotalDaysPresent.Text = "GET";
            btnTotalDaysPresent.UseVisualStyleBackColor = true;
            btnTotalDaysPresent.Click += btnTotalDaysPresent_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpEndDate.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            dtpEndDate.Location = new Point(280, 548);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 28);
            dtpEndDate.TabIndex = 29;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpStartDate.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            dtpStartDate.Location = new Point(24, 548);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 28);
            dtpStartDate.TabIndex = 28;
            // 
            // Exportbtn
            // 
            Exportbtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Exportbtn.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            Exportbtn.Location = new Point(1177, 15);
            Exportbtn.Name = "Exportbtn";
            Exportbtn.Size = new Size(218, 29);
            Exportbtn.TabIndex = 27;
            Exportbtn.Text = "Export";
            Exportbtn.UseVisualStyleBackColor = true;
            Exportbtn.Click += Exportbtn_Click;
            // 
            // dataGrid
            // 
            dataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(24, 50);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.Size = new Size(1127, 386);
            dataGrid.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 15);
            label2.Name = "label2";
            label2.Size = new Size(190, 23);
            label2.TabIndex = 25;
            label2.Text = "Present Records ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            dateTimePicker1.Location = new Point(573, 16);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 28);
            dateTimePicker1.TabIndex = 24;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label1.Location = new Point(435, 19);
            label1.Name = "label1";
            label1.Size = new Size(132, 22);
            label1.TabIndex = 23;
            label1.Text = "Select Date :";
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(1163, 50);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(232, 386);
            dataGridView.TabIndex = 41;
            // 
            // PresentRecords
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ControlLight;
            Controls.Add(dataGridView);
            Controls.Add(pictureBoxImage);
            Controls.Add(label8);
            Controls.Add(txtTotalDaysAbsent);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtTotalDays);
            Controls.Add(txtUsername);
            Controls.Add(btnTotalDaysPresent);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(Exportbtn);
            Controls.Add(dataGrid);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Name = "PresentRecords";
            Size = new Size(1420, 627);
            Load += AttendanceRecords_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxImage;
        private Label label8;
        private TextBox txtTotalDaysAbsent;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtTotalDays;
        private TextBox txtUsername;
        private Button btnTotalDaysPresent;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Button Exportbtn;
        private DataGridView dataGrid;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private DataGridView dataGridView;
    }
}