using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPT_Lab_act2
{
    internal class Globals
    {
        static public Color darkestGreen = Color.FromArgb(153, 188, 133);
        private static Image defaultImage;

        private static Profile profile;
        private static Skill skill;
        private static Certificate cert;

        public static Image DefaultImage { get => defaultImage; set => defaultImage = value; }
        internal static Profile Profile { get => profile; set => profile = value; }
        internal static Skill Skill { get => skill; set => skill = value; }
        internal static Certificate Cert { get => cert; set => cert = value; }
    }
}
