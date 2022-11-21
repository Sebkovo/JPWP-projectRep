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
        private string[] craftings = {"Wooden Sword","Steel Sword","Wooden Armor","Steel Armor","Slime Sword","Slime Armor","Happy Potion","Angry Potion","Weird Potion","Dragon Blood Potion","Dragon Sword","Dragon Armor"};
        private string[] requirements = { "","","","","",""};
        public WaveOut audOut1 = new WaveOut();
        public WaveOut audOut2= new WaveOut();
        private WaveStream stream1 = new Mp3FileReader(@"E:\Projekcik\githubRep\JPWP-projectRep\Projekt JPWP Sebastian Kowanda\Projekt JPWP Sebastian Kowanda\Audio\bgMusic.mp3");
        public WaveStream stream2 = new AudioFileReader(@"E:\Projekcik\githubRep\JPWP-projectRep\Projekt JPWP Sebastian Kowanda\Projekt JPWP Sebastian Kowanda\Audio\Aaaaaah.wav");
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
            mainScreen.SelectTab(activeTab);
        }

        private void Giera_Load(object sender, EventArgs e)
        {
            craftConstTxt.Visible = false;
            craftIng1Txt.Text = "";
            craftIng2Txt.Text = "";
            craftIng3Txt.Text = "";
            craftIng4Txt.Text = "";
            craftButt.Visible = false;

            if (stream1 != null)
            {
                audOut1.Init(stream1);
            }
            if (stream2 != null)
            {
                audOut2.Init(stream2);
            }
            
            
            audOut1.Play();
            dayNightTimer.Start();
            string[] itemToAdd = { "", "", "",""};
            ListViewItem toList;
            foreach (string temp in craftings)
            {
                itemToAdd[0] = "";
                itemToAdd[1] = temp;
                itemToAdd[2] = "";
                toList = new ListViewItem(itemToAdd);
                craftingCityList.Items.Add(toList);
            }

            itemToAdd[0] = "";
            itemToAdd[1] = "Wood";
            itemToAdd[2] = "";
            itemToAdd[3] = "20";
            toList = new ListViewItem(itemToAdd);
            itemsList.Items.Add(toList);
            itemToAdd[0] = "";
            itemToAdd[1] = "Steel";
            itemToAdd[2] = "";
            itemToAdd[3] = "20";
            toList = new ListViewItem(itemToAdd);
            itemsList.Items.Add(toList);

            /*foreach (ListViewItem temp in itemsList.Items)
            {
                MessageBox.Show(temp.SubItems[1].Text);
            }*/

            //help for using functions
            //MessageBox.Show(itemsList.Items[1].SubItems[1].Text);
            //MessageBox.Show((Int32.Parse(itemsList.Items[0].SubItems[1].Text) +6).ToString());
            //MessageBox.Show(itemsList.Items[0].ToString());
            //MessageBox.Show(itemsList.Items.Count.ToString());

            //działa, do usunięcia w swoim czasie


        }
        private void setCraftingRequirements(string Item)
        {
            bool enough1 = false;
            bool enough2 = false;
            bool enough3 = false;
            craftIng1Txt.Text = "";
            craftIng2Txt.Text = "";
            craftIng3Txt.Text = "";
            for (int i = 0; i < 6; i++)
            {
                requirements[i] = "";
            }
            int allfound = 0;
            switch (Item)
            {
                case "Wooden Sword":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Wood":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 10)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Steel":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 2)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound==2)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Wood 10";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Steel 2";
                    if (Int16.Parse(levTXT.Text) >= 2)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-City level 2";
                    if (enough1 && enough2 && (Int16.Parse(levTXT.Text) >= 2))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Wood";
                    requirements[1] = "10";
                    requirements[2] = "Steel";
                    requirements[3] = "2";
                    break;
                case "Steel Sword":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        if(temp.SubItems[1].Text == "Steel")
                        {
                           if (Int16.Parse(temp.SubItems[3].Text) >= 8)
                           {
                              enough1 = true;
                           }
                          allfound++;
                        }
                        if (allfound == 1)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Steel 8";
                    if (Int16.Parse(levTXT.Text) >= 5)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-City level 5";
                    if (enough1 && (Int16.Parse(levTXT.Text) >= 5))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Steel";
                    requirements[1] = "8";
                    break;
                case "Wooden Armor":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        if (temp.SubItems[1].Text == "Wood")
                        {
                            if (Int16.Parse(temp.SubItems[3].Text) >= 15)
                            {
                                enough1 = true;
                            }
                            allfound++;
                        }
                        if (allfound == 1)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Wood 15";
                    if (Int16.Parse(levTXT.Text) >= 2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-City level 2";
                    if (enough1 && (Int16.Parse(levTXT.Text) >= 2))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Wood";
                    requirements[1] = "15";
                    break;
                case "Steel Armor":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        if (temp.SubItems[1].Text == "Steel")
                        {
                            if (Int16.Parse(temp.SubItems[3].Text) >= 12)
                            {
                                enough1 = true;
                            }
                            allfound++;
                        }
                        if (allfound == 1)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Steel 12";
                    if (Int16.Parse(levTXT.Text) >= 5)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-City level 5";
                    if (enough1 && (Int16.Parse(levTXT.Text) >= 5))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Steel";
                    requirements[1] = "12";
                    break;
                case "Slime Sword":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Slime essence":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 10)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Wood":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 2)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                            case "Steel":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 2)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound == 3)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Slime essence 10";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Wood 2";
                    if (enough3)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-Steel 2";
                    if (Int16.Parse(levTXT.Text) >= 6)
                    {
                        craftIng4Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng4Txt.ForeColor = Color.Red;
                    }
                    craftIng4Txt.Text = "-City level 6";
                    if (enough1 && enough2 && enough3 && (Int16.Parse(levTXT.Text) >= 6))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Slime essence";
                    requirements[1] = "10";
                    requirements[2] = "Wood";
                    requirements[3] = "2";
                    requirements[4] = "Steel";
                    requirements[5] = "2";
                    break;
                case "Slime Armor":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Slime essence":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 10)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Steel":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 5)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound == 2)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Slime essence 10";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Steel 5";
                    if (Int16.Parse(levTXT.Text) >= 6)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-City level 6";
                    if (enough1 && enough2 && (Int16.Parse(levTXT.Text) >= 6))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Slime essence";
                    requirements[1] = "10";
                    requirements[2] = "Steel";
                    requirements[3] = "5";
                    break;
                case "Glass Bottle":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        if (temp.SubItems[1].Text == "Sand")
                        {
                            if (Int16.Parse(temp.SubItems[3].Text) >= 5)
                            {
                                enough1 = true;
                            }
                            allfound++;
                        }
                        if (allfound == 1)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Sand 5";
                    if (Int16.Parse(levTXT.Text) >= 5)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-City level 5";
                    if (enough1 && (Int16.Parse(levTXT.Text) >= 5))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Sand";
                    requirements[1] = "5";
                    break;
                case "Happy Potion":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Happy essence":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 5)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Glass bottle":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 1)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound == 2)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Happy essence 5";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Glass bottle 1";
                    if (Int16.Parse(levTXT.Text) >= 6)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-City level 6";
                    if (enough1 && enough2 && (Int16.Parse(levTXT.Text) >= 6))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Happy essence";
                    requirements[1] = "5";
                    requirements[2] = "Glass bottle";
                    requirements[3] = "1";
                    break;
                case "Angry Potion":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Angry essence":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 5)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Glass bottle":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 1)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound == 2)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Angry essence 5";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Glass bottle 1";
                    if (Int16.Parse(levTXT.Text) >= 6)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-City level 6";
                    if (enough1 && enough2 && (Int16.Parse(levTXT.Text) >= 6))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Angry essence";
                    requirements[1] = "5";
                    requirements[2] = "Glass bottle";
                    requirements[3] = "1";
                    break;
                case "Weird Potion":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Weird essence":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 5)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Glass bottle":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 1)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound == 2)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Weird essence 5";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Glass bottle 1";
                    if (Int16.Parse(levTXT.Text) >= 6)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-City level 6";
                    if (enough1 && enough2 && (Int16.Parse(levTXT.Text) >= 6))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Weird essence";
                    requirements[1] = "5";
                    requirements[2] = "Glass bottle";
                    requirements[3] = "1";
                    break;
                case "Dragon Blood Potion":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Dragon blood":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 10)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Glass bottle":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 1)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound == 2)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Dragon Blood 10";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Glass bottle 1";
                    if (Int16.Parse(levTXT.Text) >= 12)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-City level 12";
                    if (enough1 && enough2 && (Int16.Parse(levTXT.Text) >= 12))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Dragon Blood";
                    requirements[1] = "10";
                    requirements[2] = "Glass bottle";
                    requirements[3] = "1";
                    break;
                case "Dragon Sword":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Dragon scale":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 10)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Steel":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 10)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound == 2)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Dragon scale 10";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Steel 10";
                    if (Int16.Parse(levTXT.Text) >= 15)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-City level 15";
                    if (enough1 && enough2 && (Int16.Parse(levTXT.Text) >= 15))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Dragon scale";
                    requirements[1] = "10";
                    requirements[2] = "Steel";
                    requirements[3] = "10";
                    break;
                case "Dragon Armor":
                    craftConstTxt.Visible = true;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        switch (temp.SubItems[1].Text)
                        {
                            case "Dragon scale":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 10)
                                {
                                    enough1 = true;
                                }
                                allfound++;
                                break;
                            case "Steel":
                                if (Int16.Parse(temp.SubItems[3].Text) >= 20)
                                {
                                    enough2 = true;
                                }
                                allfound++;
                                break;
                        }
                        if (allfound == 2)
                        {
                            break;
                        }
                    }
                    if (enough1)
                    {
                        craftIng1Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng1Txt.ForeColor = Color.Red;
                    }
                    craftIng1Txt.Text = "-Dragon scale 10";
                    if (enough2)
                    {
                        craftIng2Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng2Txt.ForeColor = Color.Red;
                    }
                    craftIng2Txt.Text = "-Steel 20";
                    if (Int16.Parse(levTXT.Text) >= 15)
                    {
                        craftIng3Txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        craftIng3Txt.ForeColor = Color.Red;
                    }
                    craftIng3Txt.Text = "-City level 15";
                    if (enough1 && enough2 && (Int16.Parse(levTXT.Text) >= 15))
                    {
                        craftButt.Visible = true;
                    }
                    else
                    {
                        craftButt.Visible = false;
                    }
                    requirements[0] = "Dragon scale";
                    requirements[1] = "10";
                    requirements[2] = "Steel";
                    requirements[3] = "20";
                    break;
            }
        }

        private void getLoot(string Ename)
        {
            Random r1 = new Random();
            int ran4 = r1.Next(1, 6);
            int ran5 = r1.Next(1, 4);
            int ran6 = r1.Next(0, 3);
            string textToShow = "Loot found: \n";
            bool added = false;
            switch (Ename)
            {
                case "Angry Slime":
                    if (ran4 != 0)
                    {
                        textToShow += ran4.ToString() + " Slime essence"+ "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Slime essence")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran4).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Slime essence", "2");
                            string[] ok = { "", itw.name, itw.value, ran4.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    if (ran5 != 0)
                    {
                        textToShow += ran5.ToString() + " Angry essence" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Angry essence")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran5).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Angry essence", "5");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    fightInfoTXT.Text = textToShow;
                    break;
                case "Happy Slime":
                    if (ran4 != 0)
                    {
                        textToShow += ran4.ToString() + " Slime essence" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Slime essence")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran4).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Slime essence", "2");
                            string[] ok = { "", itw.name, itw.value, ran4.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    if (ran5 != 0)
                    {
                        textToShow += ran5.ToString() + " Happy essence" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Happy essence")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran5).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Happy essence", "5");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    fightInfoTXT.Text = textToShow;
                    break;
                case "Weird Slime":
                    if (ran4 != 0)
                    {
                        textToShow += ran4.ToString() + " Slime essence" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Slime essence")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran4).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Slime essence", "2");
                            string[] ok = { "", itw.name, itw.value, ran4.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    if (ran5 != 0)
                    {
                        textToShow += ran5.ToString() + " Weird essence" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Weird essence")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran5).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Weird essence", "5");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    fightInfoTXT.Text = textToShow;
                    break;
                case "Lesser Dragon":
                    if (ran6 != 0)
                    {
                        textToShow += ran6.ToString() + " Dragon scale" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Dragon scale")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran6).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Dragon scale", "20");
                            string[] ok = { "", itw.name, itw.value, ran6.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    if (ran6 != 0)
                    {
                        textToShow += ran6.ToString() + " Dragon blood" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Dragon blood")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran6).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Dragon blood", "20");
                            string[] ok = { "", itw.name, itw.value, ran6.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    fightInfoTXT.Text = textToShow;
                    break;
                case "Dragon":
                    if (ran5 != 0)
                    {
                        textToShow += ran5.ToString() + " Dragon scale" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Dragon scale")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran5).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Dragon scale", "20");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    if (ran5 != 0)
                    {
                        textToShow += ran5.ToString() + " Dragon blood" + "\n";
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Dragon blood")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran5).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Dragon blood", "20");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    fightInfoTXT.Text = textToShow;
                    break;
                case "Cave":
                    if (ran5 != 0)
                    {
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Sand")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran5).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Sand", "1");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    if (ran6 != 0)
                    {
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Steel")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran6).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Steel", "4");
                            string[] ok = { "", itw.name, itw.value, ran6.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    break;
                case "Lumber mill":
                    if (ran5 != 0)
                    {
                        foreach (ListViewItem temp in itemsList.Items)
                        {
                            if (temp.SubItems[1].Text == "Wood")
                            {
                                temp.SubItems[3].Text = (Int16.Parse(temp.SubItems[3].Text) + ran5).ToString();
                                added = true;
                                break;
                            }
                        }
                        if (!added)
                        {
                            item itw = new item("Wood", "1");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString() };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    break;
            }
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
                if (activeTab == 1) { 
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
            mainScreen.SelectTab(5);
        }

        private void backpackIcon_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(3);
        }

        private void backButt2_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(activeTab);
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
            Random leme = new Random();
            int rand1 = leme.Next(1, 1000);
            if (rand1 <= 300)       //30% for fleeing
            {
                fightInfoTXT.Text = "Succesfully fled! \n You can leave now";
                fightLeaveButt.Visible = true;
                AttackButt.Visible = false;
            }
            else
            {
                fightInfoTXT.Text = "Fleeing failed! \n You can't try anymore";
                fleeButt.Visible = false;
            }
        }

        private void fightTab_Enter(object sender, EventArgs e)
        {
            fightInfoTXT.Text = "What to do?";
            YHealthTXT.Text = YHealthBar.Value.ToString() + '/' + playerHealth.ToString();
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
                    if ((EHealthBar.Value - (int)Math.Round((20 - 2 * (double)ticks / 10)))>0)
                    {
                        EHealthBar.Value -= (int)Math.Round((20 - 2 * (double)ticks / 10));
                        EHealthTXT.Text = EHealthBar.Value.ToString() + '/' + EHealthBar.Maximum.ToString();
                    }
                    else
                    {
                        EHealthBar.Value = 0;
                        EHealthTXT.Text = "0 / " + EHealthBar.Maximum.ToString();
                        getLoot(ENameTXT.Text);
                        fightLeaveButt.Visible = true;
                        //case of winning
                    }
                    
                    EDamageTXT.Text = '-' + Math.Round((20 - 2 * (double)ticks / 10)).ToString();
                    EDamageTXT.Visible = true;
                    dmgTimer.Start();
                }
                else
                {
                    fightInfoTXT.Text = "Żle!";
                    if ((YHealthBar.Value - (int)Math.Round((double.Parse(EPowerTXT.Text) / double.Parse(YPowerTXT.Text) * 4) + 5))>0)
                    {
                        YHealthBar.Value -= (int)Math.Round((double.Parse(EPowerTXT.Text) / double.Parse(YPowerTXT.Text) * 4) + 5);
                        YHealthTXT.Text = YHealthBar.Value.ToString() + '/' + YHealthBar.Maximum.ToString();
                    }
                    else
                    {
                        YHealthBar.Value = 0;
                        YHealthTXT.Text = "0 / " + YHealthBar.Maximum.ToString();
                        fightLeaveButt.Visible = true;
                        //case of loosing
                    }
                    
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

        private void backButt3_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(activeTab);
        }

        private void musicVolumeSlider_VolumeChanged(object sender, EventArgs e)
        {
            audOut1.Volume = musicVolumeSlider.Volume;
        }

        private void menuPullButt_Click(object sender, EventArgs e)
        {
            if (sideStripMenu.Location.X == 1237)
            {
                sideStripMenu.Location = new Point(1137, sideStripMenu.Location.Y);
            }
            else
            {
                sideStripMenu.Location = new Point(1237, sideStripMenu.Location.Y);
            }
            
        }

        private void startButt_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(1);
            activeTab = 1;
            sideStripMenu.Visible = true;
        }

        private void optionsButt_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(5);
        }

        private void exitButt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fightLeaveButt_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(1);
            activeTab = 1;
            fightLeaveButt.Visible = false;
            AttackButt.Visible = true;
            fleeButt.Visible = true;

        }

        private void craftingCityList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (craftingCityList.SelectedIndices.Count != 0)
            {
                setCraftingRequirements(craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[1].Text);
            }
            else
            {
                craftButt.Visible = false;
                craftIng1Txt.Text = "";
                craftIng2Txt.Text = "";
                craftIng3Txt.Text = "";
                craftIng4Txt.Text = "";
                craftConstTxt.Visible = false;
            }
                    
        }

        private void craftingCityList_MouseDown(object sender, MouseEventArgs e)
        {
            if (craftingCityList.SelectedIndices.Count != 0)
            {
                setCraftingRequirements(craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[1].Text);
            }
            else
            {
                craftButt.Visible = false;
                craftIng1Txt.Text = "";
                craftIng2Txt.Text = "";
                craftIng3Txt.Text = "";
                craftIng4Txt.Text = "";
                craftConstTxt.Visible = false;
            }
        }

        private void craftButt_Click(object sender, EventArgs e)
        {
            for(int n = 0; n < 6; n += 2)
            {
                if (requirements[n] != "")
                {
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        if (requirements[n] == temp.SubItems[1].Text)
                        {
                            if (Int32.Parse(temp.SubItems[3].Text) - Int32.Parse(requirements[n + 1]) <= 0)
                            {
                                temp.Remove();
                                break;
                            }
                            else
                            {
                                temp.SubItems[3].Text = (Int32.Parse(temp.SubItems[3].Text) - Int32.Parse(requirements[n + 1])).ToString();
                                break;
                            }
                        }
                    }
                }
            }
            bool isThere = false;
            foreach (ListViewItem temp in itemsList.Items)
            {
                if(temp.SubItems[1].Text == craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[1].Text)
                {
                    isThere = true;
                    craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[3].Text = (Int32.Parse(craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[3].Text) + 1).ToString();
                    break;
                }
            }
            if (!isThere)
            {
                string[] itemToAdd = { "", "", "",""};
                itemToAdd[0] = "";
                itemToAdd[1] = craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[1].Text;
                itemToAdd[2] = "";
                var toList = new ListViewItem(itemToAdd);
                itemsList.Items.Add(toList);
            }
            
        }
    }
}
