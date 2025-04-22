namespace AttendanceAPP
{
    public partial class Login : Form
    {
        MainForm form = new MainForm();
        public Login()
        {
            InitializeComponent();
            PasswordTxt.UseSystemPasswordChar = true;
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
