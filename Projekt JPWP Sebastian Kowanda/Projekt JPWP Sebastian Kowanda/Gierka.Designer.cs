
namespace Projekt_JPWP_Sebastian_Kowanda
{
    partial class Gierka
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainScreen = new System.Windows.Forms.TabControl();
            this.planszaTab = new System.Windows.Forms.TabPage();
            this.Warrior = new System.Windows.Forms.PictureBox();
            this.cityInfo = new System.Windows.Forms.TabPage();
            this.monTXT = new System.Windows.Forms.Label();
            this.levTXT = new System.Windows.Forms.Label();
            this.levConstTXT = new System.Windows.Forms.Label();
            this.moneyConstTXT = new System.Windows.Forms.Label();
            this.backButt1 = new System.Windows.Forms.PictureBox();
            this.backpackTab = new System.Windows.Forms.TabPage();
            this.backButt2 = new System.Windows.Forms.PictureBox();
            this.itemsList = new System.Windows.Forms.ListView();
            this.d = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Items = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fightTab = new System.Windows.Forms.TabPage();
            this.YDamageTXT = new System.Windows.Forms.Label();
            this.EDamageTXT = new System.Windows.Forms.Label();
            this.EnemyNameTxtPanel = new System.Windows.Forms.Panel();
            this.ENameTXT = new System.Windows.Forms.Label();
            this.exerciseTxtPanel = new System.Windows.Forms.Panel();
            this.exerciseTXT = new System.Windows.Forms.Label();
            this.fightInfoTxtPanel = new System.Windows.Forms.Panel();
            this.fightInfoTXT = new System.Windows.Forms.Label();
            this.secondsForResponseTXT = new System.Windows.Forms.Label();
            this.responseTimeConstTXT = new System.Windows.Forms.Label();
            this.questionMarkConst2 = new System.Windows.Forms.Label();
            this.questionMarkConst1 = new System.Windows.Forms.Label();
            this.answerBox = new System.Windows.Forms.TextBox();
            this.fleeButt = new System.Windows.Forms.Button();
            this.AttackButt = new System.Windows.Forms.Button();
            this.YPowerTXT = new System.Windows.Forms.Label();
            this.YPowerConstTXT = new System.Windows.Forms.Label();
            this.EPowerTXT = new System.Windows.Forms.Label();
            this.EPowerContsTXT = new System.Windows.Forms.Label();
            this.EHealthTXT = new System.Windows.Forms.Label();
            this.YHealthTXT = new System.Windows.Forms.Label();
            this.EHealthBar = new System.Windows.Forms.ProgressBar();
            this.YHealthBar = new System.Windows.Forms.ProgressBar();
            this.YourHealthConstTXT = new System.Windows.Forms.Label();
            this.EnemyHealthConstTXT = new System.Windows.Forms.Label();
            this.EnemyImage = new System.Windows.Forms.PictureBox();
            this.menuTab = new System.Windows.Forms.TabPage();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.backButt3 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backpackIcon = new System.Windows.Forms.PictureBox();
            this.gearIcon = new System.Windows.Forms.PictureBox();
            this.fightTimer = new System.Windows.Forms.Timer(this.components);
            this.dmgTimer = new System.Windows.Forms.Timer(this.components);
            this.dayNightTimer = new System.Windows.Forms.Timer(this.components);
            this.optionsConstTxT = new System.Windows.Forms.Label();
            this.musicVolumeSlider = new NAudio.Gui.VolumeSlider();
            this.optionsConstTxt2 = new System.Windows.Forms.Label();
            this.soundVolumeSlider = new NAudio.Gui.VolumeSlider();
            this.mainScreen.SuspendLayout();
            this.planszaTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Warrior)).BeginInit();
            this.cityInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backButt1)).BeginInit();
            this.backpackTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backButt2)).BeginInit();
            this.fightTab.SuspendLayout();
            this.EnemyNameTxtPanel.SuspendLayout();
            this.exerciseTxtPanel.SuspendLayout();
            this.fightInfoTxtPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyImage)).BeginInit();
            this.optionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backButt3)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backpackIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // mainScreen
            // 
            this.mainScreen.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.mainScreen.Controls.Add(this.planszaTab);
            this.mainScreen.Controls.Add(this.cityInfo);
            this.mainScreen.Controls.Add(this.backpackTab);
            this.mainScreen.Controls.Add(this.fightTab);
            this.mainScreen.Controls.Add(this.menuTab);
            this.mainScreen.Controls.Add(this.optionsTab);
            this.mainScreen.ItemSize = new System.Drawing.Size(1, 1);
            this.mainScreen.Location = new System.Drawing.Point(-8, -9);
            this.mainScreen.Margin = new System.Windows.Forms.Padding(2);
            this.mainScreen.Multiline = true;
            this.mainScreen.Name = "mainScreen";
            this.mainScreen.SelectedIndex = 0;
            this.mainScreen.Size = new System.Drawing.Size(1278, 1002);
            this.mainScreen.TabIndex = 0;
            this.mainScreen.TabStop = false;
            // 
            // planszaTab
            // 
            this.planszaTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.planszaTab.Controls.Add(this.Warrior);
            this.planszaTab.Location = new System.Drawing.Point(4, 4);
            this.planszaTab.Margin = new System.Windows.Forms.Padding(2);
            this.planszaTab.Name = "planszaTab";
            this.planszaTab.Padding = new System.Windows.Forms.Padding(2);
            this.planszaTab.Size = new System.Drawing.Size(1269, 994);
            this.planszaTab.TabIndex = 0;
            // 
            // Warrior
            // 
            this.Warrior.Image = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.warrior_with_sword_and_shield;
            this.Warrior.Location = new System.Drawing.Point(635, 497);
            this.Warrior.Name = "Warrior";
            this.Warrior.Size = new System.Drawing.Size(40, 40);
            this.Warrior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Warrior.TabIndex = 0;
            this.Warrior.TabStop = false;
            // 
            // cityInfo
            // 
            this.cityInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cityInfo.Controls.Add(this.monTXT);
            this.cityInfo.Controls.Add(this.levTXT);
            this.cityInfo.Controls.Add(this.levConstTXT);
            this.cityInfo.Controls.Add(this.moneyConstTXT);
            this.cityInfo.Controls.Add(this.backButt1);
            this.cityInfo.Location = new System.Drawing.Point(4, 4);
            this.cityInfo.Margin = new System.Windows.Forms.Padding(2);
            this.cityInfo.Name = "cityInfo";
            this.cityInfo.Padding = new System.Windows.Forms.Padding(2);
            this.cityInfo.Size = new System.Drawing.Size(1269, 994);
            this.cityInfo.TabIndex = 1;
            // 
            // monTXT
            // 
            this.monTXT.AutoSize = true;
            this.monTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monTXT.Location = new System.Drawing.Point(322, 95);
            this.monTXT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.monTXT.Name = "monTXT";
            this.monTXT.Size = new System.Drawing.Size(36, 37);
            this.monTXT.TabIndex = 4;
            this.monTXT.Text = "5";
            // 
            // levTXT
            // 
            this.levTXT.AutoSize = true;
            this.levTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.levTXT.Location = new System.Drawing.Point(130, 95);
            this.levTXT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.levTXT.Name = "levTXT";
            this.levTXT.Size = new System.Drawing.Size(36, 37);
            this.levTXT.TabIndex = 3;
            this.levTXT.Text = "5";
            // 
            // levConstTXT
            // 
            this.levConstTXT.AutoSize = true;
            this.levConstTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.levConstTXT.Location = new System.Drawing.Point(72, 70);
            this.levConstTXT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.levConstTXT.Name = "levConstTXT";
            this.levConstTXT.Size = new System.Drawing.Size(152, 25);
            this.levConstTXT.TabIndex = 2;
            this.levConstTXT.Text = "Poziom miasta";
            // 
            // moneyConstTXT
            // 
            this.moneyConstTXT.AutoSize = true;
            this.moneyConstTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.moneyConstTXT.Location = new System.Drawing.Point(256, 70);
            this.moneyConstTXT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.moneyConstTXT.Name = "moneyConstTXT";
            this.moneyConstTXT.Size = new System.Drawing.Size(168, 25);
            this.moneyConstTXT.TabIndex = 0;
            this.moneyConstTXT.Text = "Dostępne środki";
            // 
            // backButt1
            // 
            this.backButt1.ErrorImage = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt1.Image = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt1.InitialImage = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt1.Location = new System.Drawing.Point(11, 18);
            this.backButt1.Margin = new System.Windows.Forms.Padding(2);
            this.backButt1.Name = "backButt1";
            this.backButt1.Size = new System.Drawing.Size(22, 24);
            this.backButt1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backButt1.TabIndex = 1;
            this.backButt1.TabStop = false;
            this.backButt1.Click += new System.EventHandler(this.backButt1_Click);
            // 
            // backpackTab
            // 
            this.backpackTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.backpackTab.Controls.Add(this.backButt2);
            this.backpackTab.Controls.Add(this.itemsList);
            this.backpackTab.Location = new System.Drawing.Point(4, 4);
            this.backpackTab.Name = "backpackTab";
            this.backpackTab.Padding = new System.Windows.Forms.Padding(3);
            this.backpackTab.Size = new System.Drawing.Size(1269, 994);
            this.backpackTab.TabIndex = 2;
            this.backpackTab.Text = "BackpackTab";
            // 
            // backButt2
            // 
            this.backButt2.ErrorImage = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt2.Image = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt2.InitialImage = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt2.Location = new System.Drawing.Point(11, 18);
            this.backButt2.Margin = new System.Windows.Forms.Padding(2);
            this.backButt2.Name = "backButt2";
            this.backButt2.Size = new System.Drawing.Size(22, 24);
            this.backButt2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backButt2.TabIndex = 2;
            this.backButt2.TabStop = false;
            this.backButt2.Click += new System.EventHandler(this.backButt2_Click);
            // 
            // itemsList
            // 
            this.itemsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.itemsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.d,
            this.Items,
            this.Value,
            this.Count});
            this.itemsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.itemsList.FullRowSelect = true;
            this.itemsList.GridLines = true;
            this.itemsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.itemsList.HideSelection = false;
            this.itemsList.LabelWrap = false;
            this.itemsList.Location = new System.Drawing.Point(38, 42);
            this.itemsList.MultiSelect = false;
            this.itemsList.Name = "itemsList";
            this.itemsList.Size = new System.Drawing.Size(480, 486);
            this.itemsList.TabIndex = 0;
            this.itemsList.TabStop = false;
            this.itemsList.UseCompatibleStateImageBehavior = false;
            this.itemsList.View = System.Windows.Forms.View.Details;
            this.itemsList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.itemsList_ColumnWidthChanging);
            // 
            // d
            // 
            this.d.Text = "";
            this.d.Width = 0;
            // 
            // Items
            // 
            this.Items.Text = "Items";
            this.Items.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Items.Width = 296;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Value.Width = 85;
            // 
            // Count
            // 
            this.Count.Text = "Count";
            this.Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Count.Width = 95;
            // 
            // fightTab
            // 
            this.fightTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.fightTab.Controls.Add(this.YDamageTXT);
            this.fightTab.Controls.Add(this.EDamageTXT);
            this.fightTab.Controls.Add(this.EnemyNameTxtPanel);
            this.fightTab.Controls.Add(this.exerciseTxtPanel);
            this.fightTab.Controls.Add(this.fightInfoTxtPanel);
            this.fightTab.Controls.Add(this.secondsForResponseTXT);
            this.fightTab.Controls.Add(this.responseTimeConstTXT);
            this.fightTab.Controls.Add(this.questionMarkConst2);
            this.fightTab.Controls.Add(this.questionMarkConst1);
            this.fightTab.Controls.Add(this.answerBox);
            this.fightTab.Controls.Add(this.fleeButt);
            this.fightTab.Controls.Add(this.AttackButt);
            this.fightTab.Controls.Add(this.YPowerTXT);
            this.fightTab.Controls.Add(this.YPowerConstTXT);
            this.fightTab.Controls.Add(this.EPowerTXT);
            this.fightTab.Controls.Add(this.EPowerContsTXT);
            this.fightTab.Controls.Add(this.EHealthTXT);
            this.fightTab.Controls.Add(this.YHealthTXT);
            this.fightTab.Controls.Add(this.EHealthBar);
            this.fightTab.Controls.Add(this.YHealthBar);
            this.fightTab.Controls.Add(this.YourHealthConstTXT);
            this.fightTab.Controls.Add(this.EnemyHealthConstTXT);
            this.fightTab.Controls.Add(this.EnemyImage);
            this.fightTab.Location = new System.Drawing.Point(4, 4);
            this.fightTab.Name = "fightTab";
            this.fightTab.Padding = new System.Windows.Forms.Padding(3);
            this.fightTab.Size = new System.Drawing.Size(1269, 994);
            this.fightTab.TabIndex = 3;
            this.fightTab.Text = "fightTab";
            this.fightTab.Enter += new System.EventHandler(this.fightTab_Enter);
            // 
            // YDamageTXT
            // 
            this.YDamageTXT.AutoSize = true;
            this.YDamageTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YDamageTXT.ForeColor = System.Drawing.Color.Red;
            this.YDamageTXT.Location = new System.Drawing.Point(185, 493);
            this.YDamageTXT.Name = "YDamageTXT";
            this.YDamageTXT.Size = new System.Drawing.Size(51, 24);
            this.YDamageTXT.TabIndex = 26;
            this.YDamageTXT.Text = "dmg";
            this.YDamageTXT.Visible = false;
            // 
            // EDamageTXT
            // 
            this.EDamageTXT.AutoSize = true;
            this.EDamageTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EDamageTXT.ForeColor = System.Drawing.Color.Red;
            this.EDamageTXT.Location = new System.Drawing.Point(939, 493);
            this.EDamageTXT.Name = "EDamageTXT";
            this.EDamageTXT.Size = new System.Drawing.Size(51, 24);
            this.EDamageTXT.TabIndex = 25;
            this.EDamageTXT.Text = "dmg";
            this.EDamageTXT.Visible = false;
            // 
            // EnemyNameTxtPanel
            // 
            this.EnemyNameTxtPanel.Controls.Add(this.ENameTXT);
            this.EnemyNameTxtPanel.Location = new System.Drawing.Point(442, 523);
            this.EnemyNameTxtPanel.Name = "EnemyNameTxtPanel";
            this.EnemyNameTxtPanel.Size = new System.Drawing.Size(293, 30);
            this.EnemyNameTxtPanel.TabIndex = 24;
            // 
            // ENameTXT
            // 
            this.ENameTXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ENameTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ENameTXT.Location = new System.Drawing.Point(0, 0);
            this.ENameTXT.Name = "ENameTXT";
            this.ENameTXT.Size = new System.Drawing.Size(293, 30);
            this.ENameTXT.TabIndex = 12;
            this.ENameTXT.Text = "Potworek";
            this.ENameTXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exerciseTxtPanel
            // 
            this.exerciseTxtPanel.Controls.Add(this.exerciseTXT);
            this.exerciseTxtPanel.Location = new System.Drawing.Point(403, 769);
            this.exerciseTxtPanel.Name = "exerciseTxtPanel";
            this.exerciseTxtPanel.Size = new System.Drawing.Size(379, 33);
            this.exerciseTxtPanel.TabIndex = 23;
            // 
            // exerciseTXT
            // 
            this.exerciseTXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exerciseTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exerciseTXT.Location = new System.Drawing.Point(0, 0);
            this.exerciseTXT.Name = "exerciseTXT";
            this.exerciseTXT.Size = new System.Drawing.Size(379, 33);
            this.exerciseTXT.TabIndex = 15;
            this.exerciseTXT.Text = "--------";
            this.exerciseTXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exerciseTXT.Visible = false;
            // 
            // fightInfoTxtPanel
            // 
            this.fightInfoTxtPanel.Controls.Add(this.fightInfoTXT);
            this.fightInfoTxtPanel.Location = new System.Drawing.Point(424, 662);
            this.fightInfoTxtPanel.Name = "fightInfoTxtPanel";
            this.fightInfoTxtPanel.Size = new System.Drawing.Size(331, 58);
            this.fightInfoTxtPanel.TabIndex = 22;
            // 
            // fightInfoTXT
            // 
            this.fightInfoTXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fightInfoTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fightInfoTXT.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.fightInfoTXT.Location = new System.Drawing.Point(0, 0);
            this.fightInfoTXT.Name = "fightInfoTXT";
            this.fightInfoTXT.Size = new System.Drawing.Size(331, 58);
            this.fightInfoTXT.TabIndex = 19;
            this.fightInfoTXT.Text = "info";
            this.fightInfoTXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondsForResponseTXT
            // 
            this.secondsForResponseTXT.AutoSize = true;
            this.secondsForResponseTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.secondsForResponseTXT.Location = new System.Drawing.Point(944, 731);
            this.secondsForResponseTXT.Name = "secondsForResponseTXT";
            this.secondsForResponseTXT.Size = new System.Drawing.Size(27, 20);
            this.secondsForResponseTXT.TabIndex = 21;
            this.secondsForResponseTXT.Text = "20";
            // 
            // responseTimeConstTXT
            // 
            this.responseTimeConstTXT.AutoSize = true;
            this.responseTimeConstTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.responseTimeConstTXT.Location = new System.Drawing.Point(845, 696);
            this.responseTimeConstTXT.Name = "responseTimeConstTXT";
            this.responseTimeConstTXT.Size = new System.Drawing.Size(242, 25);
            this.responseTimeConstTXT.TabIndex = 20;
            this.responseTimeConstTXT.Text = "Seconds for response";
            // 
            // questionMarkConst2
            // 
            this.questionMarkConst2.AutoSize = true;
            this.questionMarkConst2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.questionMarkConst2.Location = new System.Drawing.Point(652, 809);
            this.questionMarkConst2.Name = "questionMarkConst2";
            this.questionMarkConst2.Size = new System.Drawing.Size(21, 24);
            this.questionMarkConst2.TabIndex = 18;
            this.questionMarkConst2.Text = "?";
            this.questionMarkConst2.Visible = false;
            // 
            // questionMarkConst1
            // 
            this.questionMarkConst1.AutoSize = true;
            this.questionMarkConst1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.questionMarkConst1.Location = new System.Drawing.Point(512, 809);
            this.questionMarkConst1.Name = "questionMarkConst1";
            this.questionMarkConst1.Size = new System.Drawing.Size(21, 24);
            this.questionMarkConst1.TabIndex = 17;
            this.questionMarkConst1.Text = "?";
            this.questionMarkConst1.Visible = false;
            // 
            // answerBox
            // 
            this.answerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerBox.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.answerBox.Location = new System.Drawing.Point(539, 808);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(107, 26);
            this.answerBox.TabIndex = 16;
            this.answerBox.Visible = false;
            this.answerBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answerBox_KeyDown);
            this.answerBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.answerBox_KeyPress);
            // 
            // fleeButt
            // 
            this.fleeButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fleeButt.Location = new System.Drawing.Point(618, 587);
            this.fleeButt.Name = "fleeButt";
            this.fleeButt.Size = new System.Drawing.Size(117, 28);
            this.fleeButt.TabIndex = 14;
            this.fleeButt.Text = "Flee";
            this.fleeButt.UseVisualStyleBackColor = true;
            this.fleeButt.Click += new System.EventHandler(this.fleeButt_Click);
            // 
            // AttackButt
            // 
            this.AttackButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AttackButt.Location = new System.Drawing.Point(442, 587);
            this.AttackButt.Name = "AttackButt";
            this.AttackButt.Size = new System.Drawing.Size(117, 28);
            this.AttackButt.TabIndex = 13;
            this.AttackButt.Text = "Attack";
            this.AttackButt.UseVisualStyleBackColor = true;
            this.AttackButt.Click += new System.EventHandler(this.AttackButt_Click);
            // 
            // YPowerTXT
            // 
            this.YPowerTXT.AutoSize = true;
            this.YPowerTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YPowerTXT.Location = new System.Drawing.Point(205, 663);
            this.YPowerTXT.Name = "YPowerTXT";
            this.YPowerTXT.Size = new System.Drawing.Size(27, 20);
            this.YPowerTXT.TabIndex = 11;
            this.YPowerTXT.Text = "20";
            // 
            // YPowerConstTXT
            // 
            this.YPowerConstTXT.AutoSize = true;
            this.YPowerConstTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YPowerConstTXT.Location = new System.Drawing.Point(161, 629);
            this.YPowerConstTXT.Name = "YPowerConstTXT";
            this.YPowerConstTXT.Size = new System.Drawing.Size(119, 24);
            this.YPowerConstTXT.TabIndex = 10;
            this.YPowerConstTXT.Text = "Your Power";
            // 
            // EPowerTXT
            // 
            this.EPowerTXT.AutoSize = true;
            this.EPowerTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EPowerTXT.Location = new System.Drawing.Point(944, 663);
            this.EPowerTXT.Name = "EPowerTXT";
            this.EPowerTXT.Size = new System.Drawing.Size(27, 20);
            this.EPowerTXT.TabIndex = 9;
            this.EPowerTXT.Text = "20";
            // 
            // EPowerContsTXT
            // 
            this.EPowerContsTXT.AutoSize = true;
            this.EPowerContsTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EPowerContsTXT.Location = new System.Drawing.Point(887, 629);
            this.EPowerContsTXT.Name = "EPowerContsTXT";
            this.EPowerContsTXT.Size = new System.Drawing.Size(140, 24);
            this.EPowerContsTXT.TabIndex = 8;
            this.EPowerContsTXT.Text = "Enemy Power";
            // 
            // EHealthTXT
            // 
            this.EHealthTXT.AutoSize = true;
            this.EHealthTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EHealthTXT.Location = new System.Drawing.Point(923, 595);
            this.EHealthTXT.Name = "EHealthTXT";
            this.EHealthTXT.Size = new System.Drawing.Size(67, 20);
            this.EHealthTXT.TabIndex = 7;
            this.EHealthTXT.Text = "100/100";
            // 
            // YHealthTXT
            // 
            this.YHealthTXT.AutoSize = true;
            this.YHealthTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YHealthTXT.Location = new System.Drawing.Point(185, 595);
            this.YHealthTXT.Name = "YHealthTXT";
            this.YHealthTXT.Size = new System.Drawing.Size(67, 20);
            this.YHealthTXT.TabIndex = 6;
            this.YHealthTXT.Text = "100/100";
            // 
            // EHealthBar
            // 
            this.EHealthBar.BackColor = System.Drawing.Color.Maroon;
            this.EHealthBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.EHealthBar.Location = new System.Drawing.Point(807, 569);
            this.EHealthBar.MarqueeAnimationSpeed = 40;
            this.EHealthBar.Name = "EHealthBar";
            this.EHealthBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EHealthBar.Size = new System.Drawing.Size(304, 23);
            this.EHealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.EHealthBar.TabIndex = 5;
            this.EHealthBar.Value = 100;
            // 
            // YHealthBar
            // 
            this.YHealthBar.BackColor = System.Drawing.Color.Maroon;
            this.YHealthBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.YHealthBar.Location = new System.Drawing.Point(64, 569);
            this.YHealthBar.MarqueeAnimationSpeed = 40;
            this.YHealthBar.Name = "YHealthBar";
            this.YHealthBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.YHealthBar.Size = new System.Drawing.Size(304, 23);
            this.YHealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.YHealthBar.TabIndex = 3;
            this.YHealthBar.Value = 100;
            // 
            // YourHealthConstTXT
            // 
            this.YourHealthConstTXT.AutoSize = true;
            this.YourHealthConstTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YourHealthConstTXT.Location = new System.Drawing.Point(161, 542);
            this.YourHealthConstTXT.Name = "YourHealthConstTXT";
            this.YourHealthConstTXT.Size = new System.Drawing.Size(120, 24);
            this.YourHealthConstTXT.TabIndex = 2;
            this.YourHealthConstTXT.Text = "Your Health";
            this.YourHealthConstTXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyHealthConstTXT
            // 
            this.EnemyHealthConstTXT.AutoSize = true;
            this.EnemyHealthConstTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EnemyHealthConstTXT.Location = new System.Drawing.Point(886, 542);
            this.EnemyHealthConstTXT.Name = "EnemyHealthConstTXT";
            this.EnemyHealthConstTXT.Size = new System.Drawing.Size(141, 24);
            this.EnemyHealthConstTXT.TabIndex = 1;
            this.EnemyHealthConstTXT.Text = "Enemy Health";
            this.EnemyHealthConstTXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyImage
            // 
            this.EnemyImage.Location = new System.Drawing.Point(335, 17);
            this.EnemyImage.Name = "EnemyImage";
            this.EnemyImage.Size = new System.Drawing.Size(500, 500);
            this.EnemyImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EnemyImage.TabIndex = 0;
            this.EnemyImage.TabStop = false;
            // 
            // menuTab
            // 
            this.menuTab.Location = new System.Drawing.Point(4, 4);
            this.menuTab.Name = "menuTab";
            this.menuTab.Padding = new System.Windows.Forms.Padding(3);
            this.menuTab.Size = new System.Drawing.Size(1269, 994);
            this.menuTab.TabIndex = 4;
            this.menuTab.Text = "tabPage1";
            this.menuTab.UseVisualStyleBackColor = true;
            // 
            // optionsTab
            // 
            this.optionsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.optionsTab.Controls.Add(this.soundVolumeSlider);
            this.optionsTab.Controls.Add(this.optionsConstTxt2);
            this.optionsTab.Controls.Add(this.musicVolumeSlider);
            this.optionsTab.Controls.Add(this.optionsConstTxT);
            this.optionsTab.Controls.Add(this.backButt3);
            this.optionsTab.Location = new System.Drawing.Point(4, 4);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTab.Size = new System.Drawing.Size(1269, 994);
            this.optionsTab.TabIndex = 5;
            this.optionsTab.Text = "optionsTab";
            // 
            // backButt3
            // 
            this.backButt3.ErrorImage = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt3.Image = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt3.InitialImage = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.back;
            this.backButt3.Location = new System.Drawing.Point(11, 18);
            this.backButt3.Margin = new System.Windows.Forms.Padding(2);
            this.backButt3.Name = "backButt3";
            this.backButt3.Size = new System.Drawing.Size(22, 24);
            this.backButt3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backButt3.TabIndex = 3;
            this.backButt3.TabStop = false;
            this.backButt3.Click += new System.EventHandler(this.backButt3_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelMenu.Controls.Add(this.progressBar1);
            this.panelMenu.Controls.Add(this.backpackIcon);
            this.panelMenu.Controls.Add(this.gearIcon);
            this.panelMenu.Location = new System.Drawing.Point(1065, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(102, 986);
            this.panelMenu.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 963);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(93, 10);
            this.progressBar1.TabIndex = 2;
            // 
            // backpackIcon
            // 
            this.backpackIcon.Image = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.backpack;
            this.backpackIcon.Location = new System.Drawing.Point(2, 124);
            this.backpackIcon.Margin = new System.Windows.Forms.Padding(2);
            this.backpackIcon.Name = "backpackIcon";
            this.backpackIcon.Size = new System.Drawing.Size(98, 86);
            this.backpackIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backpackIcon.TabIndex = 1;
            this.backpackIcon.TabStop = false;
            this.backpackIcon.Click += new System.EventHandler(this.backpackIcon_Click);
            // 
            // gearIcon
            // 
            this.gearIcon.ErrorImage = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.gear;
            this.gearIcon.Image = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.gear;
            this.gearIcon.InitialImage = global::Projekt_JPWP_Sebastian_Kowanda.Properties.Resources.gear;
            this.gearIcon.Location = new System.Drawing.Point(2, 3);
            this.gearIcon.Margin = new System.Windows.Forms.Padding(2);
            this.gearIcon.Name = "gearIcon";
            this.gearIcon.Size = new System.Drawing.Size(98, 97);
            this.gearIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gearIcon.TabIndex = 0;
            this.gearIcon.TabStop = false;
            this.gearIcon.Click += new System.EventHandler(this.gearIcon_Click);
            // 
            // fightTimer
            // 
            this.fightTimer.Tick += new System.EventHandler(this.fightTimer_Tick);
            // 
            // dmgTimer
            // 
            this.dmgTimer.Interval = 1000;
            this.dmgTimer.Tick += new System.EventHandler(this.dmgTimer_Tick);
            // 
            // dayNightTimer
            // 
            this.dayNightTimer.Interval = 1000;
            this.dayNightTimer.Tick += new System.EventHandler(this.dayNightTimer_Tick);
            // 
            // optionsConstTxT
            // 
            this.optionsConstTxT.AutoSize = true;
            this.optionsConstTxT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.optionsConstTxT.Location = new System.Drawing.Point(414, 68);
            this.optionsConstTxT.Name = "optionsConstTxT";
            this.optionsConstTxT.Size = new System.Drawing.Size(147, 25);
            this.optionsConstTxT.TabIndex = 4;
            this.optionsConstTxT.Text = "Music Volume";
            // 
            // musicVolumeSlider
            // 
            this.musicVolumeSlider.Location = new System.Drawing.Point(389, 96);
            this.musicVolumeSlider.Name = "musicVolumeSlider";
            this.musicVolumeSlider.Size = new System.Drawing.Size(196, 18);
            this.musicVolumeSlider.TabIndex = 5;
            this.musicVolumeSlider.VolumeChanged += new System.EventHandler(this.musicVolumeSlider_VolumeChanged);
            // 
            // optionsConstTxt2
            // 
            this.optionsConstTxt2.AutoSize = true;
            this.optionsConstTxt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.optionsConstTxt2.Location = new System.Drawing.Point(414, 131);
            this.optionsConstTxt2.Name = "optionsConstTxt2";
            this.optionsConstTxt2.Size = new System.Drawing.Size(152, 25);
            this.optionsConstTxt2.TabIndex = 6;
            this.optionsConstTxt2.Text = "Sound Volume";
            // 
            // soundVolumeSlider
            // 
            this.soundVolumeSlider.Location = new System.Drawing.Point(389, 159);
            this.soundVolumeSlider.Name = "soundVolumeSlider";
            this.soundVolumeSlider.Size = new System.Drawing.Size(196, 18);
            this.soundVolumeSlider.TabIndex = 7;
            this.soundVolumeSlider.VolumeChanged += new System.EventHandler(this.soundVolumeSlider_VolumeChanged);
            // 
            // Gierka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.mainScreen);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gierka";
            this.Text = "Gierka";
            this.Load += new System.EventHandler(this.Giera_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gierka_KeyDown);
            this.mainScreen.ResumeLayout(false);
            this.planszaTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Warrior)).EndInit();
            this.cityInfo.ResumeLayout(false);
            this.cityInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backButt1)).EndInit();
            this.backpackTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backButt2)).EndInit();
            this.fightTab.ResumeLayout(false);
            this.fightTab.PerformLayout();
            this.EnemyNameTxtPanel.ResumeLayout(false);
            this.exerciseTxtPanel.ResumeLayout(false);
            this.fightInfoTxtPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnemyImage)).EndInit();
            this.optionsTab.ResumeLayout(false);
            this.optionsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backButt3)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backpackIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gearIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainScreen;
        private System.Windows.Forms.TabPage planszaTab;
        private System.Windows.Forms.TabPage cityInfo;
        private System.Windows.Forms.PictureBox gearIcon;
        private System.Windows.Forms.PictureBox backButt1;
        private System.Windows.Forms.Label moneyConstTXT;
        private System.Windows.Forms.Label monTXT;
        private System.Windows.Forms.Label levTXT;
        private System.Windows.Forms.Label levConstTXT;
        private System.Windows.Forms.PictureBox Warrior;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox backpackIcon;
        private System.Windows.Forms.TabPage backpackTab;
        private System.Windows.Forms.ListView itemsList;
        private System.Windows.Forms.PictureBox backButt2;
        private System.Windows.Forms.ColumnHeader d;
        private System.Windows.Forms.ColumnHeader Items;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.TabPage fightTab;
        private System.Windows.Forms.PictureBox EnemyImage;
        private System.Windows.Forms.Label YourHealthConstTXT;
        private System.Windows.Forms.Label EnemyHealthConstTXT;
        private System.Windows.Forms.ProgressBar YHealthBar;
        private System.Windows.Forms.ProgressBar EHealthBar;
        private System.Windows.Forms.Label EPowerTXT;
        private System.Windows.Forms.Label EPowerContsTXT;
        private System.Windows.Forms.Label EHealthTXT;
        private System.Windows.Forms.Label YHealthTXT;
        private System.Windows.Forms.Label YPowerConstTXT;
        private System.Windows.Forms.Label YPowerTXT;
        private System.Windows.Forms.Label ENameTXT;
        private System.Windows.Forms.Timer fightTimer;
        private System.Windows.Forms.Button fleeButt;
        private System.Windows.Forms.Button AttackButt;
        private System.Windows.Forms.Label questionMarkConst2;
        private System.Windows.Forms.Label questionMarkConst1;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.Label exerciseTXT;
        private System.Windows.Forms.Label secondsForResponseTXT;
        private System.Windows.Forms.Label responseTimeConstTXT;
        private System.Windows.Forms.Label fightInfoTXT;
        private System.Windows.Forms.Panel exerciseTxtPanel;
        private System.Windows.Forms.Panel fightInfoTxtPanel;
        private System.Windows.Forms.Panel EnemyNameTxtPanel;
        private System.Windows.Forms.Label YDamageTXT;
        private System.Windows.Forms.Label EDamageTXT;
        private System.Windows.Forms.Timer dmgTimer;
        private System.Windows.Forms.ColumnHeader Count;
        private System.Windows.Forms.TabPage menuTab;
        private System.Windows.Forms.Timer dayNightTimer;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.PictureBox backButt3;
        private NAudio.Gui.VolumeSlider soundVolumeSlider;
        private System.Windows.Forms.Label optionsConstTxt2;
        private NAudio.Gui.VolumeSlider musicVolumeSlider;
        private System.Windows.Forms.Label optionsConstTxT;
    }
}

