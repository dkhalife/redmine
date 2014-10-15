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
    public partial class SearchProject : Form
    {
        public static Project selection = null;

        private List<Project> projects = new List<Project>();

        public SearchProject()
        {
            InitializeComponent();

            query.Enabled = false;
            query.Text = "Loading...";
            Request.Get("projects.json", null, new Request.ResponseCallback(PopulateProjects));
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

        public void PopulateProjects(string response)
        {
            JObject R = JObject.Parse(response);
            JArray list = R["projects"] as JArray;

            foreach (JObject project in list.Children())
            {
                projects.Add(new Project {
                    id = Convert.ToInt32(project["id"]),
                    name = project["name"].ToString()
                });
            }

            try {
                query.Invoke(new MethodInvoker(() =>
                {
                    query.Text = "";
                    query.Enabled = true;
                    query.DataSource = projects;
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
            selection = query.SelectedItem as Project;
        }
    }
}
