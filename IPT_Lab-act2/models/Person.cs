using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPT_Lab_act2
{
    internal class Profile
    {
        private string idNumber;
        private string name;
        private bool isMale = true;
        private DateTime birthDate;
        private string civilStatus;
        private Image profilePic;

        public string IdNumber { get => idNumber; set => idNumber = value; }
        public string Name { get => name; set => name = value; }
        public bool IsMale { get => isMale; set => isMale = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string CivilStatus { get => civilStatus; set => civilStatus = value; }
        public Image ProfilePic { get => profilePic; set => profilePic = value; }
    }

    internal class Skill
    {
        private DataTable table = new DataTable();

        public Skill()
        {
            table.Columns.Add(new DataColumn("Skill name/desc", typeof(string)));
            table.Columns.Add(new DataColumn("Skill level", typeof(string)));
        }
        public DataTable Table { get => table; set => table = value; }
    }

    internal class Certificate
    {
        private DataTable table = new DataTable();

        public Certificate()
        {
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("Body", typeof(string)));
            table.Columns.Add(new DataColumn("Valid from", typeof(string)));
            table.Columns.Add(new DataColumn("Valid to", typeof(string)));
        }
        public DataTable Table { get => table; set => table = value; }
    }
}
