using Newtonsoft.Json.Linq;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            Config.Load();
            if (!String.IsNullOrEmpty(Config.HOST))
            {
                mProjects.Enabled = mIssues.Enabled = true;
            }

            timer.Tick += timer_Tick;
        }

        private long seconds = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            ++seconds;
            UpdateTime();
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            start.Enabled = false;
            pause.Enabled = true;
            stop.Enabled = true;
            restart.Enabled = true;
        }

        private void pause_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            start.Enabled = true;
            pause.Enabled = false;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            start.Enabled = true;
            pause.Enabled = false;
            restart.Enabled = false;

            seconds = 0;
            UpdateTime();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            seconds = 0;
            UpdateTime();
        }

        private void UpdateTime()
        {
            lblElapsedTime.Text = seconds.ToString();
        }

        private void mClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mSettings_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }

        private void mAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void mHelp_Click(object sender, EventArgs e)
        {
            new Help().ShowDialog();
        }

        private void mProjectsByName_Click(object sender, EventArgs e)
        {
            new SearchProject().ShowDialog();

            if (SearchProject.selection != null)
            {
                lblProject.Text = SearchProject.selection.name;
                lblIssueNumber.Text = "Select Issue";
                lblIssueNumber.ForeColor = SystemColors.MenuHighlight;
                lblIssueNumber.Font = new Font(lblIssueNumber.Font.Name, lblIssueNumber.Font.Size, FontStyle.Underline);
                lblIssueNumber.Click += lblIssueNumber_Click;
                lblIssueNumber.Cursor = Cursors.Hand;
            }
        }

        private void mIssuesById_Click(object sender, EventArgs e)
        {
            new SearchIssue().ShowDialog();

            if (SearchIssue.selection > 0)
            {
                Enabled = false;
                Request.Get("issues/" + SearchIssue.selection + ".json", null, new Request.ResponseCallback(FetchIssue));
            }
        }

        public void FetchIssue(string response)
        {
            Invoke(new MethodInvoker(() =>
            {
                Enabled = true;

                if (response == null)
                {
                    MessageBox.Show("Issue ID not found.", "Error");
                    return;
                }

                JObject R = JObject.Parse(response);
                JObject I = JObject.Parse(R["issue"].ToString());
                JObject P = JObject.Parse(I["project"].ToString());
                lblIssueNumber.Text = SearchIssue.selection.ToString();
                lblIssueTitle.Text = I["subject"].ToString();
                lblProject.Text = P["name"].ToString();

                lblIssueNumber.ForeColor = Color.Black;
                lblIssueNumber.Font = new Font(lblIssueNumber.Font.Name, lblIssueNumber.Font.Size, FontStyle.Regular);
                lblIssueNumber.Click -= lblIssueNumber_Click;
            }));
        }

        void lblIssueNumber_Click(object sender, EventArgs e)
        {
            // TODO: Show issues for project
        }
    }
}
