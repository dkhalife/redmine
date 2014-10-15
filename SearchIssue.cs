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
    public partial class SearchIssue : Form
    {
        public static int selection = 0;

        public SearchIssue()
        {
            InitializeComponent();
        }

        private void SearchIssue_Load(object sender, EventArgs e)
        {
            issue_id.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selection = 0;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            selection = (int) Math.Floor(issue_id.Value);
            Close();
        }

        private void issue_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                selection = (int)Math.Floor(issue_id.Value);
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                selection = 0;
                Close();
            }
        }

        private void SearchIssue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                selection = 0;
                Close();
            }
        }
    }
}
