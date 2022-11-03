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
    class Enemy : PictureBox
    {
        private TabControl parente;
        private Label healthLab;
        private Label powerLab;
        private Label nameLab;
        private Gierka parentRef;
        ProgressBar EHealthBar;
        public string name;
        public int health;
        public int power;
        protected override void OnClick(EventArgs e)
        {
            if(parentRef.audOut2.PlaybackState is NAudio.Wave.PlaybackState.Playing)
            {
                parentRef.audOut2.Stop();
            }
            parentRef.stream2.CurrentTime = new TimeSpan(0L);
            parentRef.audOut2.Play();
            base.OnClick(e);    //Without this line, the event won't be fired
            EHealthBar.Maximum = health;
            EHealthBar.Value = health;
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
                case "Retarded Slime":
                    parentRef.SetEnemyImage(Resources.Retard_Slime);
                    break;
                case "Lesser Dragon":
                    parentRef.SetEnemyImage(Resources.Lesser_Dragon);
                    break;
                case "Dragon":
                    parentRef.SetEnemyImage(Resources.city);
                    break;
            }
            parente.SelectTab(3);
            parentRef.activeTab = 3;

        }
        public void writeParam(TabControl parent1, Label healtLab1, Label powerLab1, Label nameLab1,ProgressBar EHealthBar1, Gierka parent)
        {
            parente = parent1;
            healthLab = healtLab1;
            powerLab = powerLab1;
            nameLab = nameLab1;
            EHealthBar = EHealthBar1;
            parentRef = parent;
        }
        public Enemy()
        {
            Random r = new Random();
            int top = r.Next(0, 994);
            int left = r.Next(0, 1171);
            this.Location = new Point(left, top);
            this.Width = 80;
            this.Height = 80;
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
                            name = "Retarded Slime";
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

            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
