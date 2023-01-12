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
using System.IO;
using Projekt_JPWP_Sebastian_Kowanda.Properties;


namespace Projekt_JPWP_Sebastian_Kowanda
{

    /// <summary>
    /// Gierka main method
    /// </summary>
    public partial class Gierka : Form
    {
        /// <summary>
        /// Main class of the program
        /// </summary>


        /// <summary>
        /// Width around an object to ignore building
        /// </summary>
        private int widthToIgnore = 80;
        /// <summary>
        /// Size of one square on map
        /// </summary>
        private int square_size = 30;
        /// <summary>
        /// Indicator variable of player available money
        /// </summary>
        private int playerMoney = 0;
        /// <summary>
        /// Variable counter for fighy timer
        /// </summary>
        private long ticks = 0;
        /// <summary>
        /// Variable counter for animation timer
        /// </summary>
        private long ticks2 = 0;
        /// <summary>
        /// Variable counter for dayNight timer
        /// </summary>
        private long ticks3 = 0;
        /// <summary>
        /// Boolean indicator of Day-Night state
        /// </summary>
        private bool isDay = true;
        /// <summary>
        /// Indicator variable of player max health
        /// </summary>
        private int playerHealth = 100;
        /// <summary>
        /// Indicator variable of player actual power
        /// </summary>
        private int playerPower = 1;
        /// <summary>
        /// Indicator variable of player actual armor
        /// </summary>
        private int playerArmor = 0;
        /// <summary>
        /// Indicator variable of player actual sword
        /// </summary>
        private int playerSword = 0;
        /// <summary>
        /// Indicator variable of active tab
        /// </summary>
        public int activeTab = 0;
        /// <summary>
        /// Actual Enemy image variable
        /// </summary>
        public Image EnemyImageVar;
        /// <summary>
        /// Variable indicating if the calculations are over
        /// </summary>
        private bool isCalc = false;
        /// <summary>
        /// Variable with the right answer for current excercise
        /// </summary>
        private int answer;
        /// <summary>
        /// Indicator variable for active city
        /// </summary>
        public City activeCity;
        /// <summary>
        /// Indicator variable for active enemy
        /// </summary>
        public Enemy activeEnemy;
        /// <summary>
        /// List of available craftings
        /// </summary>
        private string[] craftings = {"Wooden sword","Steel sword","Wooden armor","Steel armor","Slime sword","Slime armor","Happy potion","Angry potion","Weird potion","Dragon blood potion","Dragon sword","Dragon armor","Glass bottle"};
        /// <summary>
        /// List of prices for crafted items
        /// </summary>
        private string[] prices = { "100", "240", "150", "360", "230", "300", "125", "125", "125", "525", "900", "1200", "25" };
        /// <summary>
        /// blank requirements string array, for indicating requirements
        /// </summary>
        private string[] requirements = { "","","","","",""};
        /// <summary>
        /// Audio stream out variable 1
        /// </summary>
        public WaveOut audOut1 = new WaveOut();
        /// <summary>
        /// Audio stream out variable 2
        /// </summary>
        public WaveOut audOut2= new WaveOut();
        /// <summary>
        /// Variable for background music
        /// </summary>
        private WaveStream stream1 = new Mp3FileReader(@"E:\Projekcik\githubRep\JPWP-projectRep\Projekt JPWP Sebastian Kowanda\Projekt JPWP Sebastian Kowanda\Audio\bgMusic.mp3");
        /// <summary>
        /// Variable for sound effect
        /// </summary>
        public WaveStream stream2 = new AudioFileReader(@"E:\Projekcik\githubRep\JPWP-projectRep\Projekt JPWP Sebastian Kowanda\Projekt JPWP Sebastian Kowanda\Audio\Aaaaaah.wav");
        /// <summary>
        /// Variable player for sound effect
        /// </summary>
        SoundPlayer simpleSound = new SoundPlayer(Resources.Aaah);
        /// <summary>
        /// List of City objects
        /// </summary>
        List<City> cities_Array = new List<City>();
        /// <summary>
        /// List of Enemy objects
        /// </summary>
        List<Enemy> enemy_Array = new List<Enemy>();
        /// <summary>
        /// Variable for random generating
        /// </summary>
        Random r = new Random();

        /// <summary>
        /// initial method of a class
        /// </summary>
        public Gierka()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }
        /// <summary>
        /// Public method for stopping the dayNightTimer
        /// </summary>
        public void stopdayNight()
        {
            dayNightTimer.Stop();
        }
        /// <summary>
        /// eventHandler for clicking backButt1
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void backButt1_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(activeTab);
        }
        /// <summary>
        /// initial method run when the game starts
        /// </summary>
        /// <param name="sender">out object of the load event method</param>
        /// <param name="e">EventArgs of the load event</param>
        private void Giera_Load(object sender, EventArgs e)
        {
            powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
            swordBackTXT.Text = playerSword.ToString();
            craftConstTxt.Visible = false;
            craftIng1Txt.Text = "";
            craftIng2Txt.Text = "";
            craftIng3Txt.Text = "";
            craftIng4Txt.Text = "";
            cityBuyButt.Visible = false;
            citySellButt.Visible = false;
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
            string[] itemToAdd = { "", "", "","",""};
            ListViewItem toList;
            foreach (string temp in craftings)
            {
                itemToAdd[0] = prices[craftings.ToList().IndexOf(temp)];
                itemToAdd[1] = temp;
                itemToAdd[2] = "";
                toList = new ListViewItem(itemToAdd);
                craftingCityList.Items.Add(toList);
            }
        }
        /// <summary>
        /// Method for spawning a specified ammount of enemies on the region specified by parameters
        /// </summary>
        /// <param name="count">The ammount of enemies to spawn</param>
        /// <param name="x1">Specify the min X of spawning area</param>
        /// <param name="x2">Specify the max X of spawning area</param>
        /// <param name="y1">Specify the min Y of spawning area</param>
        /// <param name="y2">Specify the max X of spawning area</param>
        private void spawnMobs(int count, int x1, int x2, int y1, int y2)
        {
            Enemy newE;
            for (int i = 0; i < count; i++)
            {
                newE = new Enemy();
                newE.writeParam(mainScreen, EHealthTXT, EPowerTXT, ENameTXT, EHealthBar, this,r,x1,x2,y1,y2);
                bool git = true;
                if (cities_Array.Count != 0)
                {
                    cities_Array.ForEach(delegate (City item)
                    {
                        if (item != null)
                        {
                            if (item.Location.X <= newE.Location.X - widthToIgnore || item.Location.X >= newE.Location.X + widthToIgnore || item.Location.Y <= newE.Location.Y - widthToIgnore || item.Location.Y >= newE.Location.Y + widthToIgnore)
                            {
                            }
                            else
                            {
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
                            }
                                else
                                {
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
                    planszaTab.Controls.Add(newE);
                    enemy_Array.Add(newE);
                }
                else
                {
                    newE.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Method for synchronising backpack with sell list
        /// </summary>
        private void updateSellList()
        {
            string[] itemToAdd = { "", "", "", "","" };
            ListViewItem toList;
            citySellList.Items.Clear();
            foreach (ListViewItem temp in itemsList.Items)
            {
                itemToAdd[1] = temp.SubItems[1].Text;
                itemToAdd[2] = temp.SubItems[2].Text;
                itemToAdd[3] = temp.SubItems[3].Text;
                itemToAdd[4] = temp.SubItems[4].Text;
                toList = new ListViewItem(itemToAdd);
                citySellList.Items.Add(toList);
            }
        }
        /// <summary>
        /// Method for updating and checking crafting requirements
        /// </summary>
        /// <param name="Item">Name of the item to craft</param>
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
                case "Wooden sword":
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
                case "Steel sword":
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
                case "Wooden armor":
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
                case "Steel armor":
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
                case "Slime sword":
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
                                    enough3 = true;
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
                case "Slime armor":
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
                case "Glass bottle":
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
                case "Happy potion":
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
                case "Angry potion":
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
                case "Weird potion":
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
                case "Dragon blood potion":
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
                    craftIng1Txt.Text = "-Dragon blood 10";
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
                    requirements[0] = "Dragon blood";
                    requirements[1] = "10";
                    requirements[2] = "Glass bottle";
                    requirements[3] = "1";
                    break;
                case "Dragon sword":
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
                case "Dragon armor":
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
        /// <summary>
        /// Method for generating a random loot after defeating an enemy
        /// </summary>
        /// <param name="Ename">The name of the conquered enemy</param>
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
                            item itw = new item("Slime essence", "15");
                            string[] ok = { "", itw.name, itw.value, ran4.ToString(),"" };
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
                            item itw = new item("Angry essence", "20");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString(), "" };
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
                            item itw = new item("Slime essence", "15");
                            string[] ok = { "", itw.name, itw.value, ran4.ToString(), "" };
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
                            item itw = new item("Happy essence", "20");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString(), "" };
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
                            item itw = new item("Slime essence", "15");
                            string[] ok = { "", itw.name, itw.value, ran4.ToString(), "" };
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
                            item itw = new item("Weird essence", "20");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString(), "" };
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
                            item itw = new item("Dragon scale", "60");
                            string[] ok = { "", itw.name, itw.value, ran6.ToString(), "" };
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
                            item itw = new item("Dragon blood", "50");
                            string[] ok = { "", itw.name, itw.value, ran6.ToString(), "" };
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
                            item itw = new item("Dragon scale", "60");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString(), "" };
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
                            item itw = new item("Dragon blood", "50");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString(), "" };
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
                            item itw = new item("Sand", "5");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString(), "" };
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
                            item itw = new item("Steel", "30");
                            string[] ok = { "", itw.name, itw.value, ran6.ToString(), "" };
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
                            item itw = new item("Wood", "10");
                            string[] ok = { "", itw.name, itw.value, ran5.ToString(), "" };
                            var toList = new ListViewItem(ok);
                            itemsList.Items.Add(toList);
                        }
                        added = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// Method for generating an easy Excercise and its answer
        /// </summary>
        /// <returns>int</returns>
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
        /// <summary>
        /// KeyDown event handler
        /// </summary>
        /// <param name="sender">out object of the keyDown event method</param>
        /// <param name="e">EventArgs of the keyDown event</param>
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
                noweM.writeParam(mainScreen, monTXT, levTXT, this, r);
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
                spawnMobs(3,0,1200,0,1200);
            }
        }
        /// <summary>
        /// eventHandler for clicking gearIcon
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void gearIcon_Click(object sender, EventArgs e)
        {
            dayNightTimer.Stop();
            mainScreen.SelectTab(5);
        }
        /// <summary>
        /// eventHandler for clicking backpackIcon
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void backpackIcon_Click(object sender, EventArgs e)
        {
            dayNightTimer.Stop();
            mainScreen.SelectTab(3);
        }
        /// <summary>
        /// eventHandler for clicking backButt2
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void backButt2_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(activeTab);
            secondsForResponseTXT.Text = Math.Round((double.Parse(YPowerTXT.Text) / double.Parse(EPowerTXT.Text) * 4) + 5).ToString();
        }
        /// <summary>
        /// Function for blocking column resizing
        /// </summary>
        /// <param name="sender">out object of the ColumnWidthChanging event method</param>
        /// <param name="e">EventArgs of the ColumnWidthChanging event</param>
        private void itemsList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = ((ListView)sender).Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
        /// <summary>
        /// Public method for changing enemy image 
        /// </summary>
        /// <param name="imageVar">new image name</param>
        public void SetEnemyImage(Image imageVar)
        {
            EnemyImage.Image = imageVar;
        }
        /// <summary>
        /// Method that works on every fightTimer tick
        /// </summary>
        /// <param name="sender">out object of the Tick event method</param>
        /// <param name="e">EventArgs of the Tick event</param>
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
        /// <summary>
        /// Method for setting initial parameters before the battle
        /// </summary>
        /// <param name="sender">out object of the Enter event method</param>
        /// <param name="e">EventArgs of the Enter event</param>
        private void fightTab_Enter(object sender, EventArgs e)
        {
            fightInfoTXT.Text = "What to do?";
            playerHealth = 100;
            YHealthBar.Value = 100;
            YHealthTXT.Text = YHealthBar.Value.ToString() + '/' + playerHealth.ToString();
            YPowerTXT.Text = (playerArmor / 5 + playerPower).ToString();
            secondsForResponseTXT.Text = Math.Round((double.Parse(YPowerTXT.Text)/ double.Parse(EPowerTXT.Text)*4)+5).ToString();
        }
        /// <summary>
        /// EventHandler for entering the answer while fighting
        /// </summary>
        /// <param name="sender">out object of the KeyDown event method</param>
        /// <param name="e">EventArgs of the KeyDown event</param>
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
                    if ((EHealthBar.Value - (int)Math.Round((20 - 2 * (double)ticks / 10) * ((playerSword + 10) / 10))) > 0)
                    {
                        EHealthBar.Value -= (int)Math.Round((20 - 2 * (double)ticks / 10) * ((playerSword + 10) / 10));
                        EHealthTXT.Text = EHealthBar.Value.ToString() + '/' + EHealthBar.Maximum.ToString();
                        using (StreamWriter writetext = new StreamWriter(statPath.Text + "/stats.txt", append: true))
                        {
                            writetext.WriteLine(Math.Floor((double)ticks / 10).ToString() + ':' + (ticks - (Math.Floor((double)ticks / 10)) * 10).ToString());
                        }
                    }
                    else
                    {
                        EHealthBar.Value = 0;
                        EHealthTXT.Text = "0 / " + EHealthBar.Maximum.ToString();
                        getLoot(ENameTXT.Text);
                        fightLeaveButt.Visible = true;
                        //case of winning

                        planszaTab.Controls.Remove(activeEnemy);
                        activeEnemy.Dispose();
                    }
                    
                    EDamageTXT.Text = '-' + Math.Round((20 - 2 * (double)ticks / 10) * ((playerSword + 10) / 10)).ToString();
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
        /// <summary>
        /// EventHandler used for allowing only digits
        /// </summary>
        /// <param name="sender">out object of the KeyPress event method</param>
        /// <param name="e">EventArgs of the KeyPress event</param>
        private void answerBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((!char.IsDigit(e.KeyChar) && !(e.KeyChar == '-')) && !char.IsControl(e.KeyChar));
        }
        /// <summary>
        /// Method that works on every dmgTimer tick
        /// </summary>
        /// <param name="sender">out object of the Tick event method</param>
        /// <param name="e">EventArgs of the Tick event</param>
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
        /// <summary>
        /// Method that works on every dayNightTimer tick
        /// </summary>
        /// <param name="sender">out object of the Tick event method</param>
        /// <param name="e">EventArgs of the Tick event</param>
        private void dayNightTimer_Tick(object sender, EventArgs e)
        {
            ticks3++;
            dayNightBar.Value = (int)ticks3;
            if (ticks3 >= 300 && isDay)
            {
                // its starts getting dark
                planszaTab.BackColor = Color.FromArgb(planszaTab.BackColor.A,planszaTab.BackColor.R-1, planszaTab.BackColor.G - 1, planszaTab.BackColor.B - 1);
                sideStripMenu.BackColor = Color.FromArgb(planszaTab.BackColor.A, planszaTab.BackColor.R - 1, planszaTab.BackColor.G - 1, planszaTab.BackColor.B - 1);
                if (planszaTab.BackColor.R <= 140)
                {
                    // the night started
                    dayNightBar.Value = 0;
                    spawnMobs(5,0,1200,0,1200);
                    moonSunPic.Image = Resources.Moon;
                    dayNightBar.ForeColor = Color.Blue;
                    isDay = false;
                    ticks3 = 0;
                }
            }
            else if (ticks3 >= 300 && !isDay)
            {
                planszaTab.BackColor = Color.FromArgb(planszaTab.BackColor.A, planszaTab.BackColor.R + 1, planszaTab.BackColor.G + 1, planszaTab.BackColor.B + 1);
                sideStripMenu.BackColor = Color.FromArgb(planszaTab.BackColor.A, planszaTab.BackColor.R + 1, planszaTab.BackColor.G + 1, planszaTab.BackColor.B + 1);
                if (planszaTab.BackColor.R >= 240)
                {
                    // the day started
                    dayNightBar.Value = 0;
                    moonSunPic.Image = Resources.Sun;
                    dayNightBar.ForeColor = Color.Yellow;
                    isDay = true;
                    ticks3 = 0;
                }
            }
        }
        /// <summary>
        /// EventHandler for clicking backButt3
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void backButt3_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(activeTab);
        }
        /// <summary>
        /// EventHandler for changing music Volume if slider value changed
        /// </summary>
        /// <param name="sender">out object of the VolumeChanged event method</param>
        /// <param name="e">EventArgs of the VolumeChanged event</param>
        private void musicVolumeSlider_VolumeChanged(object sender, EventArgs e)
        {
            audOut1.Volume = musicVolumeSlider.Volume;
        }
        /// <summary>
        /// EventHandler for clicking menuPullButt
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
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
        /// <summary>
        /// EventHandler for clicking startButt
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void startButt_Click(object sender, EventArgs e)
        {
            City noweM;
            bool git = true;
            //spawn cities
            for (int i = 0; i < 20; i++)
            {
                
                while(true)
                {
                    noweM = new City();
                    git = true;
                    //MessageBox.Show(square_size.ToString());
                    noweM.writeParam(mainScreen, monTXT, levTXT, this, r);
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
                        //MessageBox.Show("PASS");
                        //plansza.Controls.Remove();
                        planszaTab.Controls.Add(noweM);
                        cities_Array.Add(noweM);
                        break;
                    }
                    else
                    {
                        noweM.Dispose();
                    }
                }
                //MessageBox.Show(i.ToString());
            }
            spawnMobs(7, 0, 1200, 0, 1200);
            spawnMobs(7, 1200,2000, 0, 1200);
            spawnMobs(7, -1200, 0, 0, 1200);
            spawnMobs(7, 0, 1200, 1200,2000);
            spawnMobs(7, 0, 1200, -1200, 0);
            spawnMobs(7, 1200, 2000, 1200, 2000);
            spawnMobs(7, 1200, 2000, -1200, 0);
            spawnMobs(7, -1200, 0, 1200, 2000);
            spawnMobs(7, -1200, 0, -1200, 0);
            mainScreen.SelectTab(1);
            activeTab = 1;
            sideStripMenu.Visible = true;
        }
        /// <summary>
        /// EventHandler for clicking optionsButt
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void optionsButt_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(5);
            dayNightTimer.Stop();
        }
        /// <summary>
        /// EventHandler for clicking exitButt
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void exitButt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// EventHandler for clicking fightLeaveButt
        /// </summary>
        /// <param name="sender">out object of the click event method</param>
        /// <param name="e">EventArgs of the click event</param>
        private void fightLeaveButt_Click(object sender, EventArgs e)
        {
            mainScreen.SelectTab(1);
            activeTab = 1;
            fightLeaveButt.Visible = false;
            AttackButt.Visible = true;
            fleeButt.Visible = true;
        }
        /// <summary>
        /// EventHandler for changing item selection in crafting list
        /// </summary>
        /// <param name="sender">out object of the ItemSelectionChanged event method</param>
        /// <param name="e">EventArgs of the ItemSelectionChanged event</param>
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
        /// <summary>
        /// EventHandler for clicking inside craftingCityList
        /// </summary>
        /// <param name="sender">out object of the MouseDown event method</param>
        /// <param name="e">EventArgs of the MouseDown event</param>
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

        /// <summary>
        /// Method for initialising informations while entering city tab
        /// </summary>
        /// <param name="sender">out object of the Enter event method</param>
        /// <param name="e">EventArgs of the Enter event</param>
        private void cityInfoTab_Enter(object sender, EventArgs e)
        {
            yMonTXT.Text = playerMoney.ToString();
            updateSellList();
        }
        /// <summary>
        /// EventHandler called while changing the selection of the item inside cityBuyList
        /// </summary>
        /// <param name="sender">out object of the ItemSelectionChanged event method</param>
        /// <param name="e">EventArgs of the ItemSelectionChanged event</param>
        private void cityBuyList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (cityBuyList.SelectedIndices.Count != 0)
            {
                if (Int32.Parse(cityBuyList.Items[cityBuyList.SelectedIndices[0]].SubItems[2].Text)<=playerMoney)
                {
                    cityBuyButt.Visible = true;
                }
                else
                {
                    cityBuyButt.Visible = false;
                }
            }
            else
            {
                cityBuyButt.Visible = false;
            }
        }
        /// <summary>
        /// EventHandler called while changing the selection of the item inside citySellList
        /// </summary>
        /// <param name="sender">out object of the ItemSelectionChanged event method</param>
        /// <param name="e">EventArgs of the ItemSelectionChanged event</param>
        private void citySellList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (citySellList.SelectedIndices.Count != 0)
            {
                if (Int32.Parse(citySellList.Items[citySellList.SelectedIndices[0]].SubItems[2].Text) <= activeCity.money)
                {
                    citySellButt.Visible = true;
                }
                else
                {
                    citySellButt.Visible = false;
                }
            }
            else
            {
                citySellButt.Visible = false;
            }
        }
        /// <summary>
        /// EventHandler called while entering plansza tab
        /// </summary>
        /// <param name="sender">out object of the Enter event method</param>
        /// <param name="e">EventArgs of the Enter event</param>
        private void planszaTab_Enter(object sender, EventArgs e)
        {
            dayNightTimer.Start();
        }
        /// <summary>
        /// EventHandler for clicking equipButt
        /// </summary>
        /// <param name="sender">out object of the Click event method</param>
        /// <param name="e">EventArgs of the Click event</param>
        private void equipButt_Click(object sender, EventArgs e)
        {
            if (itemsList.SelectedIndices.Count != 0)
            {
                if (itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text != "equipped")
                {
                    switch (itemsList.Items[itemsList.SelectedIndices[0]].SubItems[1].Text)
                    {
                        case "Wooden armor":
                            foreach (ListViewItem temp in itemsList.Items)
                            {
                                if (temp.SubItems[4].Text == "equipped")
                                {
                                    switch (temp.SubItems[1].Text)
                                    {
                                        case "Steel armor":
                                            temp.SubItems[4].Text = "";
                                            break;
                                        case "Slime armor":
                                            temp.SubItems[4].Text = "";
                                            break;
                                        case "Dragon armor":
                                            temp.SubItems[4].Text = "";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "equipped";
                            playerArmor = 10;
                            powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
                            break;
                        case "Steel armor":
                                foreach (ListViewItem temp in itemsList.Items)
                                {
                                    if (temp.SubItems[4].Text == "equipped")
                                    {
                                        switch (temp.SubItems[1].Text)
                                        {
                                            case "Wooden armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Slime armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Dragon armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "equipped";
                                playerArmor = 25;
                                powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
                            break;
                        case "Wooden sword":
                                foreach (ListViewItem temp in itemsList.Items)
                                {
                                    if (temp.SubItems[4].Text == "equipped")
                                    {
                                        switch (temp.SubItems[1].Text)
                                        {
                                            case "Steel sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Slime sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Dragon sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "equipped";
                                playerSword = 10;
                                swordBackTXT.Text = playerSword.ToString();
                            break;
                        case "Steel sword":
                                foreach (ListViewItem temp in itemsList.Items)
                                {
                                    if (temp.SubItems[4].Text == "equipped")
                                    {
                                        switch (temp.SubItems[1].Text)
                                        {
                                            case "Wooden sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Slime sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Dragon sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "equipped";
                                playerSword = 30;
                                swordBackTXT.Text = playerSword.ToString();
                            break;
                        case "Slime armor":
                                foreach (ListViewItem temp in itemsList.Items)
                                {
                                    if (temp.SubItems[4].Text == "equipped")
                                    {
                                        switch (temp.SubItems[1].Text)
                                        {
                                            case "Steel armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Wooden armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Dragon armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "equipped";
                                playerArmor = 15;
                                powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
                            break;
                        case "Slime sword":
                                foreach (ListViewItem temp in itemsList.Items)
                                {
                                    if (temp.SubItems[4].Text == "equipped")
                                    {
                                        switch (temp.SubItems[1].Text)
                                        {
                                            case "Steel sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Wooden sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Dragon sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "equipped";
                                playerSword = 20;
                                swordBackTXT.Text = playerSword.ToString();
                            break;
                        case "Dragon armor":
                                foreach (ListViewItem temp in itemsList.Items)
                                {
                                    if (temp.SubItems[4].Text == "equipped")
                                    {
                                        switch (temp.SubItems[1].Text)
                                        {
                                            case "Steel armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Slime armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Wooden armor":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "equipped";
                                playerArmor = 40;
                                powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
                            break;
                        case "Dragon sword":
                                foreach (ListViewItem temp in itemsList.Items)
                                {
                                    if (temp.SubItems[4].Text == "equipped")
                                    {
                                        switch (temp.SubItems[1].Text)
                                        {
                                            case "Steel sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Slime sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            case "Wooden sword":
                                                temp.SubItems[4].Text = "";
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "equipped";
                                playerSword = 50;
                                swordBackTXT.Text = playerSword.ToString();
                            break;
                    }
                }
                else
                {
                    itemsList.Items[itemsList.SelectedIndices[0]].SubItems[4].Text = "";
                    switch (itemsList.Items[itemsList.SelectedIndices[0]].SubItems[1].Text)
                    {
                        case "Wooden sword":
                            playerSword = 0;
                            swordBackTXT.Text = playerSword.ToString();
                            break;
                        case "Steel sword":
                            playerSword = 0;
                            swordBackTXT.Text = playerSword.ToString();
                            break;
                        case "Slime sword":
                            playerSword = 0;
                            swordBackTXT.Text = playerSword.ToString();
                            break;
                        case "Wooden armor":
                            playerArmor = 0;
                            powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
                            break;
                        case "Steel armor":
                            playerArmor = 0;
                            powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
                            break;
                        case "Slime armor":
                            playerArmor = 0;
                            powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
                            break;
                        case "Dragon sword":
                            playerSword = 0;
                            swordBackTXT.Text = playerSword.ToString();
                            break;
                        case "Dragon armor":
                            playerArmor = 0;
                            powerBackTXT.Text = (playerArmor / 5 + playerPower).ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// EventHandler for clicking folderButt
        /// </summary>
        /// <param name="sender">out object of the Click event method</param>
        /// <param name="e">EventArgs of the Click event</param>
        private void folderButt_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                statPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        /// <summary>
        /// EventHandler for clicking craftButt
        /// </summary>
        /// <param name="sender">out object of the Click event method</param>
        /// <param name="e">EventArgs of the Click event</param>
        private void craftButt_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < 6; n += 2)
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
                if (temp.SubItems[1].Text == craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[1].Text)
                {
                    isThere = true;
                    temp.SubItems[3].Text = (Int32.Parse(temp.SubItems[3].Text) + 1).ToString();
                    break;
                }
            }
            if (!isThere)
            {
                string[] itemToAdd = { "", "", "", "1", "" };
                itemToAdd[0] = "";
                itemToAdd[1] = craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[1].Text;
                itemToAdd[2] = craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[0].Text;
                var toList = new ListViewItem(itemToAdd);
                itemsList.Items.Add(toList);
            }
            setCraftingRequirements(craftingCityList.Items[craftingCityList.SelectedIndices[0]].SubItems[1].Text);
            updateSellList();
        }
        /// <summary>
        /// EventHandler for clicking citySellButt
        /// </summary>
        /// <param name="sender">out object of the Click event method</param>
        /// <param name="e">EventArgs of the Click event</param>
        private void citySellButt_Click(object sender, EventArgs e)
        {
            if (citySellList.Items.Count != 0 && citySellList.SelectedIndices.Count != 0)
            {
                if (citySellList.Items[citySellList.SelectedIndices[0]].SubItems[4].Text != "equipped")
                {
                    int selectedIndex;
                    foreach (ListViewItem temp in itemsList.Items)
                    {
                        if (temp.SubItems[1].Text == citySellList.Items[citySellList.SelectedIndices[0]].SubItems[1].Text)
                        {
                            if ((Int32.Parse(temp.SubItems[3].Text) - 1) > 0)
                            {
                                temp.SubItems[3].Text = (Int32.Parse(temp.SubItems[3].Text) - 1).ToString();
                            }
                            else
                            {
                                temp.Remove();
                            }

                            break;
                        }
                    }
                    activeCity.money -= Int32.Parse(citySellList.Items[citySellList.SelectedIndices[0]].SubItems[2].Text);
                    playerMoney += Int32.Parse(citySellList.Items[citySellList.SelectedIndices[0]].SubItems[2].Text);
                    selectedIndex = citySellList.SelectedIndices[0];
                    updateSellList();
                    if (citySellList.Items.Count != 0 && (citySellList.Items.Count - 1) >= selectedIndex)
                    {
                        citySellList.Items[selectedIndex].Selected = true;
                    }
                    yMonTXT.Text = playerMoney.ToString();
                    monTXT.Text = activeCity.money.ToString();
                    if (citySellList.Items.Count == 0)
                    {
                        citySellButt.Visible = false;
                    }
                    if (cityBuyList.SelectedIndices.Count != 0)
                    {
                        if (Int32.Parse(cityBuyList.Items[cityBuyList.SelectedIndices[0]].SubItems[2].Text) <= playerMoney)
                        {
                            cityBuyButt.Visible = true;
                        }
                        else
                        {
                            cityBuyButt.Visible = false;
                        }
                    }
                    else
                    {
                        cityBuyButt.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Item equippd!");
                }
            }
        }
        /// <summary>
        /// EventHandler for clicking cityBuyButt
        /// </summary>
        /// <param name="sender">out object of the Click event method</param>
        /// <param name="e">EventArgs of the Click event</param>
        private void cityBuyButt_Click(object sender, EventArgs e)
        {
            playerMoney -= Int32.Parse(cityBuyList.Items[cityBuyList.SelectedIndices[0]].SubItems[2].Text);
            activeCity.money += Int32.Parse(cityBuyList.Items[cityBuyList.SelectedIndices[0]].SubItems[2].Text);
            bool isThere = false;
            foreach (ListViewItem temp in itemsList.Items)
            {
                if (temp.SubItems[1].Text == cityBuyList.Items[cityBuyList.SelectedIndices[0]].SubItems[1].Text)
                {
                    isThere = true;
                    temp.SubItems[3].Text = (Int32.Parse(temp.SubItems[3].Text) + 1).ToString();
                    break;
                }
            }
            if (!isThere)
            {
                string[] itemToAdd = { "", "", "", "1", "" };
                itemToAdd[0] = "";
                itemToAdd[1] = cityBuyList.Items[cityBuyList.SelectedIndices[0]].SubItems[1].Text;
                itemToAdd[2] = (Int32.Parse(cityBuyList.Items[cityBuyList.SelectedIndices[0]].SubItems[2].Text) / 3).ToString();
                var toList = new ListViewItem(itemToAdd);
                itemsList.Items.Add(toList);
            }
            updateSellList();
            yMonTXT.Text = playerMoney.ToString();
            monTXT.Text = activeCity.money.ToString();
            if (cityBuyList.SelectedIndices.Count != 0)
            {
                if (Int32.Parse(cityBuyList.Items[cityBuyList.SelectedIndices[0]].SubItems[2].Text) <= playerMoney)
                {
                    cityBuyButt.Visible = true;
                }
                else
                {
                    cityBuyButt.Visible = false;
                }
            }
            else
            {
                cityBuyButt.Visible = false;
            }
        }
        /// <summary>
        /// EventHandler for clicking AttackButt
        /// </summary>
        /// <param name="sender">out object of the Click event method</param>
        /// <param name="e">EventArgs of the Click event</param>
        private void AttackButt_Click(object sender, EventArgs e)
        {
            fightTimer.Start();
        }
        /// <summary>
        /// EventHandler for clicking fleeButt
        /// </summary>
        /// <param name="sender">out object of the Click event method</param>
        /// <param name="e">EventArgs of the Click event</param>
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
    }
}
