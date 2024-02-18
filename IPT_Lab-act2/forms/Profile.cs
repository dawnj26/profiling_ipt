using IPT_Lab_act2.forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IPT_Lab_act2
{
    public partial class ProfileForm : Form
    {
        Profile profile = new Profile();
        SkillForm nextForm;

        void checkBtn(bool male)
        {
            if (male)
            {
                maleBtn.BackColor = Globals.darkestGreen;
                femaleBtn.BackColor = Color.Transparent;
            } else
            {
                maleBtn.BackColor = Color.Transparent;
                femaleBtn.BackColor = Globals.darkestGreen;
            }

            profile.IsMale = male;
        }

        public ProfileForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void SkillsForm_Load(object sender, System.EventArgs e)
        {
            profile.ProfilePic = profilePic.Image;
            civilStatusCmboBox.SelectedIndex = 0;
            Globals.DefaultImage = profilePic.Image;
            nextForm = new SkillForm(this);
        }

        private void maleBtn_Click(object sender, System.EventArgs e)
        {
            checkBtn(true);
        }

        private void femaleBtn_Click(object sender, System.EventArgs e)
        {
            checkBtn(false);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (picDialog.ShowDialog() == DialogResult.OK)
            {
                profilePic.Image = new System.Drawing.Bitmap(picDialog.FileName);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idNum.Text) || string.IsNullOrEmpty(nameTxt.Text))
            {
                MessageBox.Show("Form must be completed before proceeding", "Incomplete form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            profile.Name = nameTxt.Text;
            profile.IdNumber = idNum.Text;
            profile.BirthDate = birthDate.Value.Date;
            profile.CivilStatus = civilStatusCmboBox.SelectedItem.ToString();
            profile.ProfilePic = profilePic.Image;

            Globals.Profile = profile;

            nextForm.Show();
            Hide();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            nameTxt.Clear();
            idNum.Clear();
            birthDate.Value = DateTime.Now;
            civilStatusCmboBox.SelectedIndex = 0;
            profilePic.Image = Globals.DefaultImage;
        }
    }
}
