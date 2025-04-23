namespace AttendanceAPP
{
    partial class Records
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
            panel1 = new Panel();
            label2 = new Label();
            Exportbtn = new Button();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            dataGrid = new DataGridView();
            panel2 = new Panel();
            ExportbtnFilter = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dataGridView = new DataGridView();
            btnGet = new Button();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(Exportbtn);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGrid);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1404, 399);
            panel1.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 12);
            label2.Name = "label2";
            label2.Size = new Size(231, 23);
            label2.TabIndex = 36;
            label2.Text = "Attendance Records ";
            // 
            // Exportbtn
            // 
            Exportbtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Exportbtn.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            Exportbtn.Location = new Point(1173, 10);
            Exportbtn.Name = "Exportbtn";
            Exportbtn.Size = new Size(218, 29);
            Exportbtn.TabIndex = 35;
            Exportbtn.Text = "Export";
            Exportbtn.UseVisualStyleBackColor = true;
            Exportbtn.Click += Exportbtn_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            dateTimePicker1.Location = new Point(578, 13);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 28);
            dateTimePicker1.TabIndex = 34;
            dateTimePicker1.ValueChanged += Records_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label1.Location = new Point(440, 13);
            label1.Name = "label1";
            label1.Size = new Size(132, 22);
            label1.TabIndex = 33;
            label1.Text = "Select Date :";
            // 
            // dataGrid
            // 
            dataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(13, 47);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.Size = new Size(1378, 341);
            dataGrid.TabIndex = 32;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(ExportbtnFilter);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(dataGridView);
            panel2.Controls.Add(btnGet);
            panel2.Controls.Add(dateTimePickerEnd);
            panel2.Controls.Add(dateTimePickerStart);
            panel2.Location = new Point(3, 400);
            panel2.Name = "panel2";
            panel2.Size = new Size(1401, 342);
            panel2.TabIndex = 37;
            // 
            // ExportbtnFilter
            // 
            ExportbtnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExportbtnFilter.Enabled = false;
            ExportbtnFilter.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            ExportbtnFilter.Location = new Point(1170, 63);
            ExportbtnFilter.Name = "ExportbtnFilter";
            ExportbtnFilter.Size = new Size(218, 29);
            ExportbtnFilter.TabIndex = 47;
            ExportbtnFilter.Text = "Export Filter";
            ExportbtnFilter.UseVisualStyleBackColor = true;
            ExportbtnFilter.Click += ExportbtnFilter_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.OrangeRed;
            label3.Location = new Point(13, 17);
            label3.Name = "label3";
            label3.Size = new Size(67, 23);
            label3.TabIndex = 46;
            label3.Text = "Filter";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label4.Location = new Point(74, 73);
            label4.Name = "label4";
            label4.Size = new Size(111, 22);
            label4.TabIndex = 45;
            label4.Text = "End Date :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Fax", 11F, FontStyle.Bold);
            label5.Location = new Point(68, 40);
            label5.Name = "label5";
            label5.Size = new Size(120, 22);
            label5.TabIndex = 44;
            label5.Text = "Start Date :";
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(13, 102);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1375, 230);
            dataGridView.TabIndex = 43;
            // 
            // btnGet
            // 
            btnGet.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            btnGet.Location = new Point(423, 63);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(218, 29);
            btnGet.TabIndex = 42;
            btnGet.Text = "GET";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            dateTimePickerEnd.Location = new Point(191, 68);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(205, 28);
            dateTimePickerEnd.TabIndex = 41;
            dateTimePickerEnd.ValueChanged += dateTimePickerEnd_ValueChanged;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Font = new Font("Lucida Fax", 10.2F, FontStyle.Bold);
            dateTimePickerStart.Location = new Point(191, 34);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(205, 28);
            dateTimePickerStart.TabIndex = 40;
            dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
            // 
            // Records
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Records";
            Size = new Size(1404, 745);
            Load += Records_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Button Exportbtn;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private DataGridView dataGrid;
        private Panel panel2;
        private Button ExportbtnFilter;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dataGridView;
        private Button btnGet;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
    }
}
