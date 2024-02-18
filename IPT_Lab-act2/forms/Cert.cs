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
    public partial class Cert : Form
    {
        SkillForm prevForm;
        Certificate c = new Certificate();

        void gotoPrev()
        {
            prevForm.Show();
            Hide();
        }

        public Cert(SkillForm prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
        }

        private void Cert_Load(object sender, EventArgs e)
        {
            certTable.DataSource = c.Table;

            int count = 1;
            foreach (DataGridViewColumn column in certTable.Columns)
            {
                if (count <= 2)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                else
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                count++;
            }

        }

        private void validFromDate_ValueChanged(object sender, EventArgs e)
        {
            validToDate.Value = validFromDate.Value;
            validToDate.MinDate = validFromDate.Value;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            gotoPrev();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(certName.Text) || string.IsNullOrEmpty(certBody.Text))
            {
                MessageBox.Show("Form must be completed before proceeding", "Incomplete form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            c.Table.Rows.Add(certName.Text, certBody.Text, validFromDate.Value.ToString("MMMM dd, yyyy"), validToDate.Value.ToString("MMMM dd, yyyy"));

            certName.Clear();
            certBody.Clear();
            validFromDate.Value = DateTime.Now;
            validToDate.Value = DateTime.Now;
            validToDate.MinDate = DateTime.Parse("1/1/1753");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (certTable.SelectedRows.Count > 0)
            {
                int selectedIndex = certTable.SelectedRows[0].Index;
                certTable.Rows.RemoveAt(selectedIndex);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (c.Table.Rows.Count == 0)
            {
                var response = MessageBox.Show("Certificate/s are empty, are you sure you want to proceed?", "No certificate/s found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                var response2 = MessageBox.Show("Form will be final, are you sure you want to proceed?", "Finale", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (response == DialogResult.Yes && response2 == DialogResult.Yes)
                {
                    Summary s = new Summary();

                    Globals.Cert = c;

                    s.Show();
                    Hide();

                }
                return;
            }

            var response3 = MessageBox.Show("Form will be final, are you sure you want to proceed?", "Finale", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (response3 == DialogResult.No)
            {
                return;
            }

            Summary sm = new Summary();

            Globals.Cert = c;

            sm.Show();
            Hide();
        }
    }
}
