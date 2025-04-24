using System.Runtime.InteropServices;
namespace AttendanceAPP
{
    public partial class MainForm : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private PresentRecords Presentview = new PresentRecords();
        private AttendanceEntry formenter = new AttendanceEntry();
        private AttendanceExit formexit = new AttendanceExit();
        private UserProfile userProfile = new UserProfile();
        private AbsentRecords absentview = new AbsentRecords();
        private Records records = new Records();
        private Home home = new Home();
        private About about = new About();
        private bool timerslide = true, timerMenu, timerRslide = true;
        public MainForm()
        {
            InitializeComponent();
            panelViewing(home);
            panelAttendnace.Size = panelAttendnace.MinimumSize;
            panelRecords.Size = panelRecords.MinimumSize;
            Menu.Width = 60;
            panelLeft.Top = btnHome.Top;
            panelLeft.Height = btnHome.Height;
            btnSave.Top = panelAttendnace.Bottom;
            btnRecords.Top = btnSave.Bottom;
            btnAbout.Top = btnRecords.Bottom;
            setBool(false, false, false, false, false, false);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            panelLeft.Top = btnHome.Top;
            panelLeft.Height = btnHome.Height;
            panelLeft.Visible = true;
            setcolor(Color.FromArgb(0, 122, 204), Color.FromArgb(0, 122, 180));
            setBool(true, false, false, false, false, false);
            panelViewing(home);
        }
        private void btnAttendance_Click(object sender, EventArgs e)
        {
            SlideTimer.Start();
            panelLeft.Top = btnAttendance.Top;
            panelLeft.Height = btnAttendance.Height;
            setBool(true, false, false, false, false, false);
        }
        private void btnEntry_Click(object sender, EventArgs e)
        {
            panelViewing(formenter);
            setBool(false, true, false, false, false, false);
            setcolor(Color.Indigo, Color.DarkSlateBlue);

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            panelViewing(formexit);
            setBool(false, false, true, false, false, false);
            setcolor(Color.Indigo, Color.DarkSlateBlue);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            panelLeft.Top = btnSave.Top;
            panelLeft.Height = btnSave.Height;
            setBool(true, false, false, false, false, false);
            panelViewing(userProfile);
            setcolor(Color.DarkGreen, Color.SeaGreen);
        }
        private void btnRecords_Click(object sender, EventArgs e)
        {
            RecordsTimer.Start();
            panelLeft.Top = btnRecords.Top;
            panelLeft.Height = btnRecords.Height;
            setBool(true, false, false, false, false, false);
        }
        private void btnPresent_Click(object sender, EventArgs e)
        {
            setcolor(Color.Crimson, Color.PaleVioletRed);
            setBool(false, false, false, true, false, false);
            panelViewing(Presentview);

        }
        private void btnAbsent_Click(object sender, EventArgs e)
        {
            setcolor(Color.Crimson, Color.PaleVioletRed);
            setBool(false, false, false, false, true, false);
            panelViewing(absentview);
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            panelLeft.Top = btnAbout.Top;
            panelLeft.Height = btnAbout.Height;
            setcolor(Color.SaddleBrown, Color.Sienna);
            setBool(true, false, false, false, false, false);
            panelViewing(about);
        }
        private void BtnSlide_Click(object sender, EventArgs e)
        {
            MenuTimer.Start();
        }
        UserControl prevControl = null;
        private void panelViewing(UserControl form1)
        {
            if (prevControl == form1)
            {
                return;
            }
            prevControl = form1;
            panelView.SuspendLayout();
            panelView.Controls.Clear();
            panelView.Controls.Add(form1);
            form1.Dock = DockStyle.Fill;
            panelView.ResumeLayout();
        }
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Closebtn_Click(object sender, EventArgs e)
        {
            Dispose();
            Environment.Exit(0);
            this.Close();
        }
        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void Maximize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Restore.Visible = true;
            Maximize.Visible = false;
        }
        private void Restore_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Maximize.Visible = true;
            Restore.Visible = false;
        }
        private void setcolor(Color C1, Color C2)
        {
            Menu.BackColor = C1;
            panelAttendnace.BackColor = C2;
            panelRecords.BackColor = C2;
            pictureTitle.BackColor = C1;
            Maximize.BackColor = C1;
            Minimize.BackColor = C1;
            Closebtn.BackColor = C1;
            Restore.BackColor = C1;
        }
        private void setBool(bool a, bool b, bool c, bool d, bool e, bool f)
        {
            panelLeft.Visible = a;
            panelEntry.Visible = b;
            panelExit.Visible = c;
            panelPresent.Visible = d;
            panelAbsent.Visible = e;
            panelARecords.Visible = f;
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            if (timerslide)
            {
                panelAttendnace.Height += 10;
                btnSave.Top = panelAttendnace.Bottom;
                btnRecords.Top = btnSave.Bottom;
                btnAbout.Top = panelRecords.Bottom;
                panelRecords.Top = btnRecords.Bottom;
                if (panelAttendnace.Size == panelAttendnace.MaximumSize)
                {
                    SlideTimer.Stop();
                    timerslide = false;
                }
            }
            else
            {
                panelAttendnace.Height -= 10;
                btnSave.Top = panelAttendnace.Bottom;
                btnRecords.Top = btnSave.Bottom;
                btnAbout.Top = panelRecords.Bottom;
                panelRecords.Top = btnRecords.Bottom;
                if (panelAttendnace.Size == panelAttendnace.MinimumSize)
                {
                    SlideTimer.Stop();
                    timerslide = true;
                }
            }
        }
        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (timerMenu)
            {
                Menu.Width -= 10;
                if (Menu.Width == 60)
                {
                    panelLeft.Visible = false;
                    MenuTimer.Stop();
                    timerMenu = false;
                }
            }
            else
            {
                Menu.Width += 10;
                if (Menu.Width == 250)
                {
                    panelLeft.Visible = true;
                    MenuTimer.Stop();
                    timerMenu = true;
                }
            }
        }
        private void RecordsTimer_Tick(object sender, EventArgs e)
        {
            if (timerRslide)
            {
                panelRecords.Height += 10;
                btnAbout.Top = panelRecords.Bottom;
                panelRecords.Top = btnRecords.Bottom;
                if (panelRecords.Size == panelRecords.MaximumSize)
                {
                    RecordsTimer.Stop();
                    timerRslide = false;
                }
            }
            else
            {
                panelRecords.Height -= 10;
                btnAbout.Top = panelRecords.Bottom;
                panelRecords.Top = btnRecords.Bottom;
                if (panelRecords.Size == panelRecords.MinimumSize)
                {
                    RecordsTimer.Stop();
                    timerRslide = true;
                }
            }
        }
        private void btnARecords_Click(object sender, EventArgs e)
        {
            panelARecords.Top = btnARecords.Top;
            panelARecords.Height = btnARecords.Height;
            setcolor(Color.Crimson, Color.PaleVioletRed);
            setBool(false, false, false, false, false, true);
            panelViewing(records);
        }
    }
}