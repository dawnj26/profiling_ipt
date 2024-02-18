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
    public partial class SkillForm : Form
    {
        ProfileForm prevForm;
        Cert nextForm;
        Skill s = new Skill();
        public SkillForm(ProfileForm prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
        }

        void gotoPrev()
        {
            prevForm.Show();
            Hide();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            gotoPrev();
        }

        private void SkillForm_Load(object sender, EventArgs e)
        {
            skillLevelBox.SelectedIndex = 0;
            skillTable.DataSource = s.Table;
            nextForm = new Cert(this);

            foreach (DataGridViewColumn column in skillTable.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(skillTxt.Text))
            {
                MessageBox.Show("Form must be completed before proceeding", "Incomplete form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Add data to table
            s.Table.Rows.Add(skillTxt.Text, skillLevelBox.SelectedItem.ToString());
            //skillTable.Rows.Add(skillTxt.Text, skillLevelBox.SelectedItem.ToString());

            // Reset inputs
            skillLevelBox.SelectedIndex = 0;
            skillTxt.Clear();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (skillTable.SelectedRows.Count > 0)
            {
                int selectedIndex = skillTable.SelectedRows[0].Index;
                skillTable.Rows.RemoveAt(selectedIndex);
            }

            
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (s.Table.Rows.Count > 0)
            {
                Globals.Skill = s;

                Hide();
                nextForm.Show();
                return;
            }

            var response = MessageBox.Show("Skills are empty, are you sure you want to proceed?", "No skill/s found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (response == DialogResult.Yes)
            {
                Globals.Skill = s;

                Hide();
                nextForm.Show();
            }
        }
    }
}
