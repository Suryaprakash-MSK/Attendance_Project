using System.Windows.Forms;

namespace AttendanceAPP
{
    public partial class Loading : Form
    {
        int startpoint = 0;
        private Login log = new Login();
        public Loading()
        {
            InitializeComponent();
            labelProgress.Text = "";
        }
        private void progresstime_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            labelProgress.Text = "Loading...." + startpoint.ToString() + "%";
            progressBar.Value = startpoint;
            if (progressBar.Value == 100)
            {
                progressBar.Value = 0;
                progresstime.Stop();
                this.Hide();
                Application.EnableVisualStyles();
                log.Show();
            }
        }
        private void Loading_Load(object sender, EventArgs e)
        {
            progresstime.Start();
        }
    }
}
