using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkTimer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            host.Text = Config.HOST;
            protocol.SelectedIndex = Config.PROTOCOL;
            method.SelectedIndex = Config.AUTHENTICATION_METHOD;
            username.Text = Config.USERNAME;
            password.Text = Config.PASSWORD;

            method_SelectedIndexChanged(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.HOST = host.Text;
            Config.PROTOCOL = protocol.SelectedIndex;
            Config.AUTHENTICATION_METHOD = method.SelectedIndex;
            Config.USERNAME = username.Text;
            Config.PASSWORD = password.Text;
            
            Config.Save();
            Close();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string h = Config.HOST;
            int pr = Config.PROTOCOL;
            int m = Config.AUTHENTICATION_METHOD;
            string u = Config.USERNAME;
            string pa = Config.PASSWORD;

            Config.HOST = host.Text;
            Config.PROTOCOL = protocol.SelectedIndex;
            Config.AUTHENTICATION_METHOD = method.SelectedIndex;
            Config.USERNAME = username.Text;
            Config.PASSWORD = password.Text;

            Enabled = false;
            Config.Test(new Config.TestCallback(Test_Callback));
            Enabled = true;

            Config.HOST = h;
            Config.PROTOCOL = pr;
            Config.AUTHENTICATION_METHOD = m;
            Config.USERNAME = u;
            Config.PASSWORD = pa;
        }

        private void method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (method.SelectedIndex == 0)
            {
                lblUsername.Text = "API Key:";
                lblPassword.Visible = password.Visible = false; 
            }
            else
            {
                lblUsername.Text = "Username:";
                lblPassword.Visible = password.Visible = true;
            }
        }

        public void Test_Callback(bool success)
        {
            MessageBox.Show(success ? "The connection was successfully established!" : "There was a problem connecting to Redmine");
            Enabled = true;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            host.Focus();
        }
    }
}
