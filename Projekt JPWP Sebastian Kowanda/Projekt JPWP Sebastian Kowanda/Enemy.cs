using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using Projekt_JPWP_Sebastian_Kowanda.Properties;

namespace Projekt_JPWP_Sebastian_Kowanda
{
    public class Enemy : PictureBox
    {
        /// <summary>
        /// Enemy class
        /// </summary>
        private TabControl parente;
        private Label healthLab;
        private Label powerLab;
        private Label nameLab;
        private Gierka parentRef;
        ProgressBar EHealthBar;
        public string name;
        public int health;
        public int power;
        Random r;
        protected override void OnClick(EventArgs e)
        {
            parentRef.stopdayNight();
            if (parentRef.audOut2.PlaybackState is NAudio.Wave.PlaybackState.Playing)
            {
                parentRef.audOut2.Stop();
            }
            parentRef.stream2.CurrentTime = new TimeSpan(0L);
            parentRef.audOut2.Play();
            base.OnClick(e);    //Without this line, the event won't be fired
            EHealthBar.Maximum = health;
            EHealthBar.Value = health;
            parentRef.activeEnemy = this;
            powerLab.Text = power.ToString();
            healthLab.Text = health + "/" + health;
            nameLab.Text = name;
            switch (name)
            {
                case "Angry Slime":
                    parentRef.SetEnemyImage(Resources.Angry_Slime);
                    break;
                case "Happy Slime":
                    parentRef.SetEnemyImage(Resources.Happy_Slime);
                    break;
                case "Weird Slime":
                    parentRef.SetEnemyImage(Resources.Weird_Slime);
                    break;
                case "Lesser Dragon":
                    parentRef.SetEnemyImage(Resources.Lesser_Dragon);
                    break;
                case "Dragon":
                    parentRef.SetEnemyImage(Resources.Gragon_New);
                    break;
            }
            parente.SelectTab(4);
            parentRef.activeTab = 4;

        }
        /// <summary>
        /// Writ initial parameters to an object
        /// </summary>
        /// <param name="parent1">Specify the tabControl parent of an object</param>
        /// <param name="healtLab1">Reference to Enemy health Label on the screen</param>
        /// <param name="powerLab1">Reference to Enemy power Label on the screen</param>
        /// <param name="nameLab1">Reference to Enemy name Label on the screen</param>
        /// <param name="EHealthBar1">Reference to Enemy health bar on the screen</param>
        /// <param name="parent">Specify the Gierka parent of an object</param>
        /// <param name="r1">Specify the Random variable created in the parent</param>
        /// <param name="x1">Specify the min X of spawning area</param>
        /// <param name="x2">Specify the max X of spawning area</param>
        /// <param name="y1">Specify the min Y of spawning area</param>
        /// <param name="y2">Specify the max Y of spawning area</param>
        public void writeParam(TabControl parent1, Label healtLab1, Label powerLab1, Label nameLab1,ProgressBar EHealthBar1, Gierka parent,Random r1, int x1,int x2,int y1,int y2)
        {
            parente = parent1;
            healthLab = healtLab1;
            powerLab = powerLab1;
            nameLab = nameLab1;
            EHealthBar = EHealthBar1;
            parentRef = parent;
            r = r1;
            int top = r.Next(x1, x2);
            int left = r.Next(y1, y2);
            this.Location = new Point(left, top);
            int sw = r.Next(0, 800); // should be 0,1000
            switch (sw)
            {
                case int n when (n < 500 && n >= 0): // 50%
                    this.Image = Resources.Slime_Icon;
                    int ran = r.Next(0, 3);
                    switch (ran)
                    {
                        case 0:
                            name = "Angry Slime";
                            break;
                        case 1:
                            name = "Happy Slime";
                            break;
                        case 2:
                            name = "Weird Slime";
                            break;
                    }
                    health = r.Next(70, 120);
                    power = r.Next(2, 5);
                    break;
                case int n when (n < 700 && n >= 500): // 20%
                    this.Image = Resources.Lesser_Dragon_Icon;
                    health = r.Next(200, 300);
                    power = r.Next(5, 7);
                    name = "Lesser Dragon";
                    break;
                case int n when (n < 800 && n >= 700): // 10%
                    this.Image = Resources.Dragon_Icon;
                    health = r.Next(400, 500);
                    power = r.Next(10, 13);
                    name = "Dragon";
                    break;
                case int n when (n < 900 && n >= 800): // 10%
                    this.Image = Resources.city;
                    health = r.Next(500, 600);
                    power = r.Next(12, 15);
                    name = "Unknown";
                    break;
                case int n when (n < 1000 && n >= 900): // 10%
                    this.Image = Resources.city;
                    health = r.Next(700, 800);
                    power = r.Next(20, 25);
                    name = "Unknown";
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Enemy Class
        /// </summary>
        public Enemy()
        {
           
            this.Width = 80;
            this.Height = 80;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
