using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace WorkTimer
{
    public partial class BrowseIssues : Form
    {
        public static Issue selection = null;
        private List<Issue> issues = new List<Issue>();

        public BrowseIssues()
        {
            InitializeComponent();

            query.Enabled = false;
            query.Text = "Loading...";
            Request.Get("issues.json", "limit=100000&project_id=" + SearchProject.selection.id, new Request.ResponseCallback(PopulateIssues));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selection = null;
            Close();
        }

        public void PopulateIssues(string response)
        {
            JObject R = JObject.Parse(response);
            JArray list = R["issues"] as JArray;

            foreach (JObject issue in list.Children())
            {
                issues.Add(new Issue {
                    id = Convert.ToInt32(issue["id"]),
                    title = issue["subject"].ToString(),
                    project = issue["project"]["name"].ToString()
                });
            }

            try {
                query.Invoke(new MethodInvoker(() =>
                {
                    query.Text = "";
                    query.Enabled = true;
                    query.DataSource = issues;
                    query.Focus();

                    btnOK.Enabled = true;
                }));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Attempted to modify disposed UI. Exception: {0}", e.Message);
            }
        }

        private void query_SelectedIndexChanged(object sender, EventArgs e)
        {
            selection = query.SelectedItem as Issue;
        }

        private void query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selection = query.SelectedItem as Issue;
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                selection = null;
                Close();
            }
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                selection = null;
                Close();
            }
        }
    }
}
