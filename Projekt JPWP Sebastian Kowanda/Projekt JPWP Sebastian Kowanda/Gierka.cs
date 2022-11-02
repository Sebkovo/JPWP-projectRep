using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using Projekt_JPWP_Sebastian_Kowanda.Properties;


namespace Projekt_JPWP_Sebastian_Kowanda
{
    public partial class Gierka : Form
    {
        private int widthToIgnore = 80;
        private int square_size = 30;
        private long ticks = 0;     // fight timer
        private long ticks2 = 0;    // animation timer
        private long ticks3 = 0;    // dayNight timer
        private bool isDay = true;
        private int playerHealth = 100;
        private int playerPower = 1;
        public int activeTab = 0;
        public Image EnemyImageVar;
        private bool isCalc = false;
        private int answer;
        SoundPlayer simpleSound = new SoundPlayer(Resources.Aaah);
        List<City> cities_Array = new List<City>();
        List<Enemy> enemy_Array = new List<Enemy>();
        
        public Gierka()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void backButt1_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(0);
            activeTab = 0;
        }

        private void Giera_Load(object sender, EventArgs e)
        {
            dayNightTimer.Start();
            //działa, do usunięcia w swoim czasie
            item itw = new item("sword", "23");
            string[] ok = {"" ,itw.name, itw.value };
            var toList = new ListViewItem(ok);
            itemsList.Items.Add(toList);
             itw = new item("iron", "5");
            string[] ok2 = { "", itw.name, itw.value };
             toList = new ListViewItem(ok2);
            itemsList.Items.Add(toList);
             itw = new item("faa", "dziala");
            string[] ok3 = { "", itw.name, itw.value };
             toList = new ListViewItem(ok3);
            itemsList.Items.Add(toList);
             itw = new item("nice", "dziala");
            string[] ok4 = { "", itw.name, itw.value };
             toList = new ListViewItem(ok4);
            itemsList.Items.Add(toList);
            foreach (ListViewItem temp in itemsList.Items)
            {
                //MessageBox.Show(temp.ToString());
            }

            //help for using functions
            //MessageBox.Show(itemsList.Items[1].SubItems[1].Text);
            //MessageBox.Show((Int32.Parse(itemsList.Items[0].SubItems[1].Text) +6).ToString());
            //MessageBox.Show(itemsList.Items[0].ToString());
            //MessageBox.Show(itemsList.Items.Count.ToString());

            //działa, do usunięcia w swoim czasie


        }
        private (string, int) genExerEASY()
        {
            Random r = new Random();
            int ran = r.Next(0, 15);
            int ran2 = r.Next(0, 15);
            int ran3 = r.Next(0, 15);
            int ranS = r.Next(0, 4);
            switch (ranS)
            {
                case 0:
                    return ((ran.ToString()+'-'+ran2.ToString()+'-'+ran3.ToString()), ran-ran2-ran3);
                case 1:
                    return ((ran.ToString() + '+' + ran2.ToString() + '-' + ran3.ToString()), ran + ran2 - ran3);
                case 2:
                    return ((ran.ToString() + '+' + ran2.ToString() + '+' + ran3.ToString()), ran + ran2 + ran3);
                case 3:
                    return ((ran.ToString() + '-' + ran2.ToString() + '+' + ran3.ToString()), ran - ran2 + ran3);
                default:
                    return ("ERROR", 0);
            }
        }
        private void Gierka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                cities_Array.ForEach(delegate (City item)
                {
                    item.Location = new Point(item.Location.X, item.Location.Y + square_size);
                });
                enemy_Array.ForEach(delegate (Enemy item)
                {
                    item.Location = new Point(item.Location.X, item.Location.Y + square_size);
                });
            }
            else if (e.KeyCode == Keys.S)
            {
                cities_Array.ForEach(delegate (City item)
                {
                    item.Location = new Point(item.Location.X, item.Location.Y - square_size);
                });
                enemy_Array.ForEach(delegate (Enemy item)
                {
                    item.Location = new Point(item.Location.X, item.Location.Y - square_size);
                });
            }
            else if (e.KeyCode == Keys.A)
            {
                cities_Array.ForEach(delegate (City item)
                {
                    item.Location = new Point(item.Location.X + square_size, item.Location.Y);
                });
                enemy_Array.ForEach(delegate (Enemy item)
                {
                    item.Location = new Point(item.Location.X + square_size, item.Location.Y);
                });
            }
            else if (e.KeyCode == Keys.D)
            {
                cities_Array.ForEach(delegate (City item)
                {
                    item.Location = new Point(item.Location.X - square_size, item.Location.Y);
                });
                enemy_Array.ForEach(delegate (Enemy item)
                {
                    item.Location = new Point(item.Location.X - square_size, item.Location.Y);
                });
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (activeTab == 0) { 
                City noweM = new City();
                //MessageBox.Show(square_size.ToString());
                noweM.writeParam(mainScreen, monTXT, levTXT, this);
                bool git = true;
                if (cities_Array.Count != 0)
                {
                    cities_Array.ForEach(delegate (City item)
                    {
                        if (item != null)
                        {
                            if (item.Location.X <= noweM.Location.X - widthToIgnore || item.Location.X >= noweM.Location.X + widthToIgnore || item.Location.Y <= noweM.Location.Y - widthToIgnore || item.Location.Y >= noweM.Location.Y + widthToIgnore)
                            {
                                //MessageBox.Show("PASS");
                                //MessageBox.Show("item:\nX:\t" + item.Location.X.ToString() + "\tY:\t" + item.Location.Y.ToString() + "\n" + "noweM:\nX:\t" + noweM.Location.X.ToString() + "\tY:\t" + noweM.Location.Y.ToString());
                            }
                            else
                            {
                                //MessageBox.Show("NOK");
                                //MessageBox.Show("item:\nX:\t" + item.Location.X.ToString() + "\tY:\t" + item.Location.Y.ToString() + "\n" + "noweM:\nX:\t" + noweM.Location.X.ToString() + "\tY:\t" + noweM.Location.Y.ToString());
                                git = false;
                            }
                        }
                        else
                        {
                            git = true;
                        }
                    });
                }
                else
                {
                    git = true;
                }
                if (git)
                 {
                     if (enemy_Array.Count != 0)
                     {
                       enemy_Array.ForEach(delegate (Enemy item)
                        {
                            if (item != null)
                            {
                                if (item.Location.X <= noweM.Location.X - widthToIgnore || item.Location.X >= noweM.Location.X + widthToIgnore || item.Location.Y <= noweM.Location.Y - widthToIgnore || item.Location.Y >= noweM.Location.Y + widthToIgnore)
                                {
                                    //MessageBox.Show("PASS");
                                    //MessageBox.Show("item:\nX:\t" + item.Location.X.ToString() + "\tY:\t" + item.Location.Y.ToString() + "\n" + "noweM:\nX:\t" + noweM.Location.X.ToString() + "\tY:\t" + noweM.Location.Y.ToString());
                                }
                                else
                                {
                                    //MessageBox.Show("NOK");
                                    //MessageBox.Show("item:\nX:\t" + item.Location.X.ToString() + "\tY:\t" + item.Location.Y.ToString() + "\n" + "noweM:\nX:\t" + newE.Location.X.ToString() + "\tY:\t" + newE.Location.Y.ToString());
                                    git = false;
                                }
                            }
                            else
                            {
                                 git = true;
                            }
                       });
                     }
                     else
                     {
                        git = true;
                     }
                 }
                if (git)
                {
                    //plansza.Controls.Remove();
                    planszaTab.Controls.Add(noweM);
                    cities_Array.Add(noweM);
                }
            }
            }
            else if (e.KeyCode == Keys.G)
            {
                simpleSound.Play();
                Enemy newE = new Enemy();
                 //MessageBox.Show(square_size.ToString());
                 newE.writeParam(mainScreen, EHealthTXT, EPowerTXT, ENameTXT, EHealthBar, this);
                 bool git = true;
                 if (cities_Array.Count != 0)
                 {
                     cities_Array.ForEach(delegate (City item)
                     {
                         if (item != null)
                         {
                             if (item.Location.X <= newE.Location.X - widthToIgnore || item.Location.X >= newE.Location.X + widthToIgnore || item.Location.Y <= newE.Location.Y - widthToIgnore || item.Location.Y >= newE.Location.Y + widthToIgnore)
                             {
                                 //MessageBox.Show("PASS");
                               //MessageBox.Show("item:\nX:\t" + item.Location.X.ToString() + "\tY:\t" + item.Location.Y.ToString() + "\n" + "noweM:\nX:\t" + noweM.Location.X.ToString() + "\tY:\t" + noweM.Location.Y.ToString());
                             }
                             else
                             {
                                 //MessageBox.Show("NOK");
                                //MessageBox.Show("item:\nX:\t" + item.Location.X.ToString() + "\tY:\t" + item.Location.Y.ToString() + "\n" + "noweM:\nX:\t" + newE.Location.X.ToString() + "\tY:\t" + newE.Location.Y.ToString());
                                git = false;
                             }
                         }
                         else
                         {
                            git = true;
                         }
                     });
                 }
                 else
                 {
                      git = true;
                 }
                 if (git)
                 {
                     if (enemy_Array.Count != 0)
                     {
                       enemy_Array.ForEach(delegate (Enemy item)
                        {
                            if (item != null)
                            {
                                if (item.Location.X <= newE.Location.X - widthToIgnore || item.Location.X >= newE.Location.X + widthToIgnore || item.Location.Y <= newE.Location.Y - widthToIgnore || item.Location.Y >= newE.Location.Y + widthToIgnore)
                                {
                                    //MessageBox.Show("PASS");
                                    //MessageBox.Show("item:\nX:\t" + item.Location.X.ToString() + "\tY:\t" + item.Location.Y.ToString() + "\n" + "noweM:\nX:\t" + noweM.Location.X.ToString() + "\tY:\t" + noweM.Location.Y.ToString());
                                }
                                else
                                {
                                    //MessageBox.Show("NOK");
                                    //MessageBox.Show("item:\nX:\t" + item.Location.X.ToString() + "\tY:\t" + item.Location.Y.ToString() + "\n" + "noweM:\nX:\t" + newE.Location.X.ToString() + "\tY:\t" + newE.Location.Y.ToString());
                                    git = false;
                                }
                            }
                            else
                            {
                                 git = true;
                            }
                       });
                     }
                     else
                     {
                        git = true;
                     }
                 }
                 if (git)
                 {
                    //plansza.Controls.Remove();
                     planszaTab.Controls.Add(newE);
                     enemy_Array.Add(newE);
                 }
            }
        }

        private void gearIcon_Click(object sender, EventArgs e)
        {

        }

        private void backpackIcon_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(2);
            activeTab = 2;
        }

        private void backButt2_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(0);
            activeTab = 0;
        }
        //block column resizing
        private void itemsList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = ((ListView)sender).Columns[e.ColumnIndex].Width;
            //Cancel the event.
            e.Cancel = true;
        }//block column resizing
        public void SetEnemyImage(Image imageVar)
        {
            EnemyImage.Image = imageVar;
        }

        private void fightTimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (!isCalc)
            {
                fightInfoTXT.Text = "Make ready... " + (ticks / 10).ToString();
                if (ticks >= 30)
                {
                    fightInfoTXT.Text = "Do the math!";
                    isCalc = true;
                    ticks = 0;
                    var randomExer = genExerEASY();
                    exerciseTXT.Text = randomExer.Item1;
                    answer = randomExer.Item2;
                }
            }
            else
            {
                questionMarkConst1.Visible = true;
                questionMarkConst2.Visible = true;
                exerciseTXT.Visible = true;
                answerBox.Visible = true;
                answerBox.Focus();
                ENameTXT.Text = exerciseTXT.Focused.ToString();
                fightInfoTXT.Text = "Do the math!  "+ Math.Floor((double)ticks / 10).ToString()+':'+(ticks-(Math.Floor((double)ticks/10))*10).ToString();
                if(Math.Floor((double)ticks / 10) >= Int16.Parse(secondsForResponseTXT.Text))
                {
                    isCalc = false;
                    fightInfoTXT.Text = "End of time!";
                    answerBox.Text = "";
                    fightTimer.Stop();
                    YHealthBar.Value -= (int)Math.Round((double.Parse(EPowerTXT.Text) / double.Parse(YPowerTXT.Text) * 4) + 5);
                    YHealthTXT.Text = YHealthBar.Value.ToString() + '/' + YHealthBar.Maximum.ToString();
                    YDamageTXT.Text = '-' + Math.Round((double.Parse(EPowerTXT.Text) / double.Parse(YPowerTXT.Text) * 4) + 5).ToString();
                    YDamageTXT.Visible = true;
                    dmgTimer.Start();
                    ticks = 0;
                    questionMarkConst1.Visible = false;
                    questionMarkConst2.Visible = false;
                    exerciseTXT.Visible = false;
                    answerBox.Visible = false;
                }
            }
            
        }

        private void AttackButt_Click(object sender, EventArgs e)
        {
            fightTimer.Start();
        }

        private void fleeButt_Click(object sender, EventArgs e)
        {

        }

        private void fightTab_Enter(object sender, EventArgs e)
        {
            fightInfoTXT.Text = "What to do?";
            YHealthTXT.Text = playerHealth.ToString() + '/' + playerHealth.ToString();
            YPowerTXT.Text = playerPower.ToString();
            secondsForResponseTXT.Text = Math.Round((double.Parse(YPowerTXT.Text)/ double.Parse(EPowerTXT.Text)*4)+5).ToString();
        }

        private void answerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                fightTimer.Stop();
                questionMarkConst1.Visible = false;
                questionMarkConst2.Visible = false;
                exerciseTXT.Visible = false;
                answerBox.Visible = false;
                isCalc = false;
                if (answerBox.Text == answer.ToString())
                {
                    fightInfoTXT.Text = "Dobrze!"+' '+ Math.Floor((double)ticks / 10).ToString() + ':' + (ticks - (Math.Floor((double)ticks / 10)) * 10).ToString()+'s';
                    EHealthBar.Value -= (int)Math.Round((20 - 2 * (double)ticks / 10));
                    EHealthTXT.Text = EHealthBar.Value.ToString() + '/' + EHealthBar.Maximum.ToString();
                    EDamageTXT.Text = '-' + Math.Round((20 - 2 * (double)ticks / 10)).ToString();
                    EDamageTXT.Visible = true;
                    dmgTimer.Start();
                }
                else
                {
                    fightInfoTXT.Text = "Żle!";
                    YHealthBar.Value -= (int)Math.Round((double.Parse(EPowerTXT.Text) / double.Parse(YPowerTXT.Text) * 4) + 5);
                    YHealthTXT.Text = YHealthBar.Value.ToString() + '/' + YHealthBar.Maximum.ToString();
                    YDamageTXT.Text = '-'+Math.Round((double.Parse(EPowerTXT.Text) / double.Parse(YPowerTXT.Text) * 4) + 5).ToString();
                    YDamageTXT.Visible = true;
                    dmgTimer.Start();
                }
                ticks = 0;
                answerBox.Text = "";
            }
        }
        // allow only digits( doesn't work with copy/paste)
        private void answerBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((!char.IsDigit(e.KeyChar) && !(e.KeyChar == '-')) && !char.IsControl(e.KeyChar));
        }// allow only digits( doesn't work with copy/paste)

        private void dmgTimer_Tick(object sender, EventArgs e)
        {
            ticks2++;
            if (ticks2 >= 1)
            {
                EDamageTXT.Visible = false;
                YDamageTXT.Visible = false;
                dmgTimer.Stop();
                ticks2 = 0;
            }
        }

        private void dayNightTimer_Tick(object sender, EventArgs e)
        {
            ticks3++;
            if (ticks3 >= 300 && isDay)
            {
                planszaTab.BackColor = Color.FromArgb(planszaTab.BackColor.A,planszaTab.BackColor.R-1, planszaTab.BackColor.G - 1, planszaTab.BackColor.B - 1);
                if (planszaTab.BackColor.R <= 140)
                {
                    isDay = false;
                    ticks3 = 0;
                }
            }
            else if (ticks3 >= 300 && !isDay)
            {
                planszaTab.BackColor = Color.FromArgb(planszaTab.BackColor.A, planszaTab.BackColor.R + 1, planszaTab.BackColor.G + 1, planszaTab.BackColor.B + 1);
                if (planszaTab.BackColor.R >= 240)
                {
                    isDay = true;
                    ticks3 = 0;
                }
            }
        }
        public void disposeMe(WaveOut obj)
        {
            obj.Dispose();
        }
    }
}
