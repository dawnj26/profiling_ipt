using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPT_Lab_act2.forms
{
    public partial class Summary : Form
    {
        public Summary()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Summary_Load(object sender, EventArgs e)
        {
            profilePic.Image = Globals.Profile.ProfilePic;
            nameLabel.Text = Globals.Profile.Name;
            idLabel.Text = Globals.Profile.IdNumber;
            sexLabel.Text = Globals.Profile.IsMale ? "Male" : "Female";
            civilLabel.Text = Globals.Profile.CivilStatus;

            certTable.DataSource = Globals.Cert.Table;
            skillTable.DataSource = Globals.Skill.Table;

            foreach (DataGridViewColumn column in skillTable.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            int count = 1;
            foreach (DataGridViewColumn column in certTable.Columns)
            {
                if (count <= 2)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                else
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                count++;
            }

            skillTable?.ClearSelection();
            certTable?.ClearSelection();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {

            var response = MessageBox.Show("Do you want to create new?", "Finish", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (response == DialogResult.Yes)
            {
                Application.Restart();
            } else
            {
                Application.Exit();
            }

        }
    }
}
