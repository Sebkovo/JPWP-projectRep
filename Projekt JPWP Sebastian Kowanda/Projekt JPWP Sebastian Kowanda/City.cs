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
    public class City : PictureBox
    {
        /// <summary>
        /// City class 
        /// </summary>

        /// <summary>
        /// TabControl Parent reference 
        /// </summary>
        private TabControl parente;
        /// <summary>
        /// Money label refference
        /// </summary>
        private Label monLab;
        /// <summary>
        /// Level label reference
        /// </summary>
        private Label levLab;
        /// <summary>
        /// Gierka Parent reference 
        /// </summary>
        private Gierka parentRef;
        /// <summary>
        /// Size of one square on map
        /// </summary>
        public int square_size = 30;
        /// <summary>
        /// Level of a city
        /// </summary>
        public int level;
        /// <summary>
        /// Money of a city
        /// </summary>
        public int money;
        /// <summary>
        /// Variable for random generating
        /// </summary>
        Random r;
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);    //Without this line, the event won't be fired
            parentRef.activeCity = this;
            if(parente!= null)
            {
                parentRef.stopdayNight();
                parente.SelectTab(2);
                monLab.Text = money.ToString();
                levLab.Text = level.ToString();
            }
        }

        /// <summary>
        /// Write initial parameters to an object
        /// </summary>
        /// <param name="parent1">Specify the tabControl parent of an object</param>
        /// <param name="monLab1">Reference to money label</param>
        /// <param name="levLab1">Reference to level label</param>
        /// <param name="parentRef1">Specify the Gierka parent of an object</param>
        /// <param name="r1">Specify the Random variable created in the parent</param>
        public void writeParam(TabControl parent1,Label monLab1,Label levLab1,Gierka parentRef1,Random r1)
        {
            parente = parent1;
            monLab = monLab1;
            levLab = levLab1;
            parentRef = parentRef1;
            r = r1;

            int top = r.Next(-1500, 1500);
            int left = r.Next(-1500, 1500);
            level = r.Next(1, 20);
            money = r.Next(0, 3000);
            this.Location = new Point(left, top);
        }

        /// <summary>
        /// City main method
        /// </summary>
        public City()
        {
            this.Width = 2* square_size;
            this.Height = 2* square_size;
            this.Image = Resources.city;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
