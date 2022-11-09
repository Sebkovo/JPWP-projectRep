using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Projekt_JPWP_Sebastian_Kowanda.Properties;
using System.Security.Cryptography.X509Certificates;

namespace Projekt_JPWP_Sebastian_Kowanda
{
    class City : PictureBox
    {
        private TabControl parente;
        private Label monLab;
        private Label levLab;
        private Gierka parentRef;
        public int square_size = 30;
        public int level;
        public int money;
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);    //Without this line, the event won't be fired
            if(parente!= null)
            {
                parente.SelectTab(2);
                monLab.Text = money.ToString();
                levLab.Text = level.ToString();
            }
        }
        public void writeParam(TabControl parent1,Label monLab1,Label levLab1,Gierka parentRef1)
        {
            parente = parent1;
            monLab = monLab1;
            levLab = levLab1;
            parentRef = parentRef1;
        }
        public City()
        {
            Random r = new Random();
            int top = r.Next(0, 994);
            int left = r.Next(0, 1171);
            level = r.Next(1, 20);
            money = r.Next(0, 3000);
            this.Location = new Point(left, top);
            this.Width = 2* square_size;
            this.Height = 2* square_size;
            this.Image = Resources.city;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
