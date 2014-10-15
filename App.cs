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

        private int seconds = 0;
        private int minutes = 0;
        private long hours = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            if (++seconds == 60)
            {
                seconds = 0;
                if (++minutes == 60)
                {
                    ++hours;
                }
            }
            
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

            hours = seconds = minutes = 0;
            UpdateTime();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            hours = seconds = minutes = 0;
            UpdateTime();
        }

        private void UpdateTime()
        {
            lblElapsedTime.Text = hours.ToString().PadLeft(2, '0') + ':' + minutes.ToString().PadLeft(2, '0') + ':' + seconds.ToString().PadLeft(2, '0');
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
                JObject I = R["issue"] as JObject;
                JObject P = I["project"] as JObject;
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
            new BrowseIssues().ShowDialog();

            if (BrowseIssues.selection != null)
            {
                lblIssueNumber.Text = BrowseIssues.selection.id.ToString();
                lblIssueTitle.Text = BrowseIssues.selection.title;
                lblProject.Text = BrowseIssues.selection.project;

                lblIssueNumber.ForeColor = Color.Black;
                lblIssueNumber.Font = new Font(lblIssueNumber.Font.Name, lblIssueNumber.Font.Size, FontStyle.Regular);
                lblIssueNumber.Click -= lblIssueNumber_Click;
            }
        }
    }
}
