namespace AttendanceAPP
{
    public partial class Login : Form
    {
        MainForm form = new MainForm();
        int count = 0;
        private System.Windows.Forms.Timer refreshTimer;
        public Login()
        {
            InitializeComponent();
            PasswordTxt.UseSystemPasswordChar = true;
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 100; // 1 second
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (PasswordTxt.Text.Length >= 4 && UsernameTxt.Text.Length > 1)
            {
                btnLogIn.Enabled = true;
            }
            else
            {
                btnLogIn.Enabled = false;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            UsernameTxt.Clear();
            PasswordTxt.Clear();
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UsernameTxt.Text.Trim();
                string password = PasswordTxt.Text.Trim();
               
                if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please Enter Username  and Password");
                }
                else if (string.IsNullOrWhiteSpace(username) && PasswordTxt.Text != null)
                {
                    MessageBox.Show("Please Enter Username");
                }
                else if (UsernameTxt.Text != null && string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please Enter Password");
                }
                else if (UsernameTxt.Text != null && PasswordTxt.Text != null)
                {
                    if (UsernameTxt.Text == "AA" && PasswordTxt.Text == "1234")
                    {
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.WindowState = FormWindowState.Maximized;
                        form.Show();
                        this.Close();
                    }
                    else if (UsernameTxt.Text == "AA" && PasswordTxt.Text != "1234")
                    {
                        MessageBox.Show("Wrong Password");
                        count++;
                        if (count == 1)
                        {
                            MessageBox.Show("you have 2 chance left to login");
                        }
                        else if (count == 2)
                        {
                            MessageBox.Show("you have 1 chance left to login");
                        }
                        else
                        {
                            MessageBox.Show("you have No chance left to login");
                            refreshTimer.Stop();
                            UsernameTxt.Enabled = false;
                            PasswordTxt.Enabled = false;
                            btnLogIn.Enabled = false;
                            btnClear.Enabled = false;
                        }
                    }

                    else if (UsernameTxt.Text != "AA")
                    {
                        MessageBox.Show("Invalid Username");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                PasswordTxt.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTxt.UseSystemPasswordChar = true;
            }
        }

    }
}
