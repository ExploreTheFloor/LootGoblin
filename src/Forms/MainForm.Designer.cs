namespace LootGoblin.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            tabPage5 = new TabPage();
            btn_ClearDkpWinner = new Button();
            btn_AddAutoTick = new Button();
            label13 = new Label();
            txtbx_AutoTickTimer = new TextBox();
            btn_BossManagement = new Button();
            btn_RemoveDkpWinner = new Button();
            label12 = new Label();
            btn_AddDkpWinner = new Button();
            txtbx_AutoTickDkp = new TextBox();
            btn_StartAutoTickTimer = new Button();
            label2 = new Label();
            txtbx_DkpBidderItem = new TextBox();
            btn_SubmitRaid = new Button();
            label11 = new Label();
            label7 = new Label();
            txtbx_DkpBidderName = new TextBox();
            panel2 = new Panel();
            txtbx_AutoTickCountdown = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtbx_DkpBidderValue = new TextBox();
            dgv_LootWinners = new DataGridView();
            panel4 = new Panel();
            label5 = new Label();
            label9 = new Label();
            txtbx_TickDescription = new TextBox();
            txtbx_RaidName = new TextBox();
            txtbx_TickDkpValue = new TextBox();
            label8 = new Label();
            btn_SubmitManualTick = new Button();
            tabPage1 = new TabPage();
            lbl_CurrentDkp = new Label();
            label1 = new Label();
            trv_CharacterList = new TreeView();
            btn_ClearDkpBids = new Button();
            trv_DkpBids = new TreeView();
            tabPage2 = new TabPage();
            trv_LootRolls = new TreeView();
            btn_ClearLootRolls = new Button();
            tabPage3 = new TabPage();
            btn_ClearLootedItems = new Button();
            dgv_LootedItems = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Player = new DataGridViewTextBoxColumn();
            Item = new DataGridViewTextBoxColumn();
            tabPage4 = new TabPage();
            btn_DuplicateLoot = new Button();
            dgv_DuplicateLoots = new DataGridView();
            btn_LogMonitor = new Button();
            btn_OpenSettings = new Button();
            btn_Test = new Button();
            RaidTickTimer = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabPage5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_LootWinners).BeginInit();
            panel4.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_LootedItems).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_DuplicateLoots).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(438, 536);
            tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(label5);
            tabPage5.Controls.Add(btn_ClearDkpWinner);
            tabPage5.Controls.Add(btn_AddAutoTick);
            tabPage5.Controls.Add(label13);
            tabPage5.Controls.Add(txtbx_AutoTickTimer);
            tabPage5.Controls.Add(txtbx_RaidName);
            tabPage5.Controls.Add(btn_BossManagement);
            tabPage5.Controls.Add(btn_RemoveDkpWinner);
            tabPage5.Controls.Add(label12);
            tabPage5.Controls.Add(btn_AddDkpWinner);
            tabPage5.Controls.Add(txtbx_AutoTickDkp);
            tabPage5.Controls.Add(btn_StartAutoTickTimer);
            tabPage5.Controls.Add(label2);
            tabPage5.Controls.Add(txtbx_DkpBidderItem);
            tabPage5.Controls.Add(btn_SubmitRaid);
            tabPage5.Controls.Add(label11);
            tabPage5.Controls.Add(label7);
            tabPage5.Controls.Add(txtbx_DkpBidderName);
            tabPage5.Controls.Add(panel2);
            tabPage5.Controls.Add(txtbx_DkpBidderValue);
            tabPage5.Controls.Add(dgv_LootWinners);
            tabPage5.Controls.Add(panel4);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(430, 508);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Raid Management";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_ClearDkpWinner
            // 
            btn_ClearDkpWinner.Location = new Point(294, 446);
            btn_ClearDkpWinner.Name = "btn_ClearDkpWinner";
            btn_ClearDkpWinner.Size = new Size(130, 23);
            btn_ClearDkpWinner.TabIndex = 36;
            btn_ClearDkpWinner.Text = "Clear Selection";
            btn_ClearDkpWinner.UseVisualStyleBackColor = true;
            btn_ClearDkpWinner.Click += btn_ClearDkpWinner_Click;
            // 
            // btn_AddAutoTick
            // 
            btn_AddAutoTick.Location = new Point(6, 115);
            btn_AddAutoTick.Name = "btn_AddAutoTick";
            btn_AddAutoTick.Size = new Size(200, 51);
            btn_AddAutoTick.TabIndex = 35;
            btn_AddAutoTick.Text = "Add Auto Tick";
            btn_AddAutoTick.UseVisualStyleBackColor = true;
            btn_AddAutoTick.Click += btn_AddAutoTick_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(205, 145);
            label13.Name = "label13";
            label13.Size = new Size(64, 15);
            label13.TabIndex = 34;
            label13.Text = "Tick Timer:";
            // 
            // txtbx_AutoTickTimer
            // 
            txtbx_AutoTickTimer.Location = new Point(275, 141);
            txtbx_AutoTickTimer.Name = "txtbx_AutoTickTimer";
            txtbx_AutoTickTimer.Size = new Size(61, 23);
            txtbx_AutoTickTimer.TabIndex = 33;
            txtbx_AutoTickTimer.Text = "60";
            // 
            // btn_BossManagement
            // 
            btn_BossManagement.Location = new Point(6, 478);
            btn_BossManagement.Name = "btn_BossManagement";
            btn_BossManagement.Size = new Size(129, 24);
            btn_BossManagement.TabIndex = 32;
            btn_BossManagement.Text = "Boss Management";
            btn_BossManagement.UseVisualStyleBackColor = true;
            btn_BossManagement.Click += btn_RaidManagement_Click;
            // 
            // btn_RemoveDkpWinner
            // 
            btn_RemoveDkpWinner.Location = new Point(150, 446);
            btn_RemoveDkpWinner.Name = "btn_RemoveDkpWinner";
            btn_RemoveDkpWinner.Size = new Size(130, 23);
            btn_RemoveDkpWinner.TabIndex = 21;
            btn_RemoveDkpWinner.Text = "Remove";
            btn_RemoveDkpWinner.UseVisualStyleBackColor = true;
            btn_RemoveDkpWinner.Click += btn_RemoveDkpWinner_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(236, 117);
            label12.Name = "label12";
            label12.Size = new Size(32, 15);
            label12.TabIndex = 31;
            label12.Text = "DKP:";
            // 
            // btn_AddDkpWinner
            // 
            btn_AddDkpWinner.Location = new Point(5, 446);
            btn_AddDkpWinner.Name = "btn_AddDkpWinner";
            btn_AddDkpWinner.Size = new Size(130, 23);
            btn_AddDkpWinner.TabIndex = 23;
            btn_AddDkpWinner.Text = "Add";
            btn_AddDkpWinner.UseVisualStyleBackColor = true;
            btn_AddDkpWinner.Click += btn_AddDkpWinner_Click;
            // 
            // txtbx_AutoTickDkp
            // 
            txtbx_AutoTickDkp.Location = new Point(275, 114);
            txtbx_AutoTickDkp.Name = "txtbx_AutoTickDkp";
            txtbx_AutoTickDkp.Size = new Size(61, 23);
            txtbx_AutoTickDkp.TabIndex = 30;
            txtbx_AutoTickDkp.Text = "2";
            // 
            // btn_StartAutoTickTimer
            // 
            btn_StartAutoTickTimer.Location = new Point(342, 113);
            btn_StartAutoTickTimer.Name = "btn_StartAutoTickTimer";
            btn_StartAutoTickTimer.Size = new Size(85, 51);
            btn_StartAutoTickTimer.TabIndex = 26;
            btn_StartAutoTickTimer.Text = "Start Timer";
            btn_StartAutoTickTimer.UseVisualStyleBackColor = true;
            btn_StartAutoTickTimer.Click += btn_StartAutoTickTimer_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 399);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 29;
            label2.Text = "Item";
            // 
            // txtbx_DkpBidderItem
            // 
            txtbx_DkpBidderItem.Location = new Point(132, 417);
            txtbx_DkpBidderItem.Name = "txtbx_DkpBidderItem";
            txtbx_DkpBidderItem.Size = new Size(226, 23);
            txtbx_DkpBidderItem.TabIndex = 28;
            // 
            // btn_SubmitRaid
            // 
            btn_SubmitRaid.Location = new Point(150, 479);
            btn_SubmitRaid.Name = "btn_SubmitRaid";
            btn_SubmitRaid.Size = new Size(274, 23);
            btn_SubmitRaid.TabIndex = 27;
            btn_SubmitRaid.Text = "Submit Raid";
            btn_SubmitRaid.UseVisualStyleBackColor = true;
            btn_SubmitRaid.Click += btn_SubmitRaid_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 399);
            label11.Name = "label11";
            label11.Size = new Size(39, 15);
            label11.TabIndex = 26;
            label11.Text = "Player";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(364, 399);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 25;
            label7.Text = "Dkp";
            // 
            // txtbx_DkpBidderName
            // 
            txtbx_DkpBidderName.Location = new Point(5, 417);
            txtbx_DkpBidderName.Name = "txtbx_DkpBidderName";
            txtbx_DkpBidderName.Size = new Size(121, 23);
            txtbx_DkpBidderName.TabIndex = 24;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtbx_AutoTickCountdown);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(342, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(85, 106);
            panel2.TabIndex = 10;
            // 
            // txtbx_AutoTickCountdown
            // 
            txtbx_AutoTickCountdown.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbx_AutoTickCountdown.Location = new Point(10, 28);
            txtbx_AutoTickCountdown.Name = "txtbx_AutoTickCountdown";
            txtbx_AutoTickCountdown.Size = new Size(62, 57);
            txtbx_AutoTickCountdown.TabIndex = 7;
            txtbx_AutoTickCountdown.Text = "0";
            txtbx_AutoTickCountdown.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 88);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 9;
            label4.Text = "minutes";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 10);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 8;
            label3.Text = "Next Tick:";
            // 
            // txtbx_DkpBidderValue
            // 
            txtbx_DkpBidderValue.Location = new Point(364, 417);
            txtbx_DkpBidderValue.Name = "txtbx_DkpBidderValue";
            txtbx_DkpBidderValue.Size = new Size(59, 23);
            txtbx_DkpBidderValue.TabIndex = 22;
            // 
            // dgv_LootWinners
            // 
            dgv_LootWinners.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_LootWinners.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv_LootWinners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_LootWinners.Location = new Point(6, 170);
            dgv_LootWinners.MultiSelect = false;
            dgv_LootWinners.Name = "dgv_LootWinners";
            dgv_LootWinners.ReadOnly = true;
            dgv_LootWinners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_LootWinners.Size = new Size(418, 219);
            dgv_LootWinners.TabIndex = 19;
            dgv_LootWinners.CellClick += dgv_LootWinners_CellClick;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label9);
            panel4.Controls.Add(txtbx_TickDescription);
            panel4.Controls.Add(txtbx_TickDkpValue);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(btn_SubmitManualTick);
            panel4.Location = new Point(6, 35);
            panel4.Name = "panel4";
            panel4.Size = new Size(330, 74);
            panel4.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 9);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 12;
            label5.Text = "Raid Name:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 13);
            label9.Name = "label9";
            label9.Size = new Size(66, 15);
            label9.TabIndex = 21;
            label9.Text = "Tick Name:";
            // 
            // txtbx_TickDescription
            // 
            txtbx_TickDescription.Location = new Point(80, 10);
            txtbx_TickDescription.Name = "txtbx_TickDescription";
            txtbx_TickDescription.Size = new Size(245, 23);
            txtbx_TickDescription.TabIndex = 20;
            // 
            // txtbx_RaidName
            // 
            txtbx_RaidName.Location = new Point(87, 6);
            txtbx_RaidName.Name = "txtbx_RaidName";
            txtbx_RaidName.Size = new Size(245, 23);
            txtbx_RaidName.TabIndex = 11;
            // 
            // txtbx_TickDkpValue
            // 
            txtbx_TickDkpValue.Location = new Point(80, 39);
            txtbx_TickDkpValue.Name = "txtbx_TickDkpValue";
            txtbx_TickDkpValue.Size = new Size(59, 23);
            txtbx_TickDkpValue.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 43);
            label8.Name = "label8";
            label8.Size = new Size(32, 15);
            label8.TabIndex = 16;
            label8.Text = "DKP:";
            // 
            // btn_SubmitManualTick
            // 
            btn_SubmitManualTick.Location = new Point(145, 39);
            btn_SubmitManualTick.Name = "btn_SubmitManualTick";
            btn_SubmitManualTick.Size = new Size(180, 23);
            btn_SubmitManualTick.TabIndex = 6;
            btn_SubmitManualTick.Text = "Add Tick Manually";
            btn_SubmitManualTick.UseVisualStyleBackColor = true;
            btn_SubmitManualTick.Click += btn_SubmitManualTick_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lbl_CurrentDkp);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(trv_CharacterList);
            tabPage1.Controls.Add(btn_ClearDkpBids);
            tabPage1.Controls.Add(trv_DkpBids);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(430, 508);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "DKP Bids";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbl_CurrentDkp
            // 
            lbl_CurrentDkp.AutoSize = true;
            lbl_CurrentDkp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_CurrentDkp.Location = new Point(328, 0);
            lbl_CurrentDkp.Name = "lbl_CurrentDkp";
            lbl_CurrentDkp.Size = new Size(19, 21);
            lbl_CurrentDkp.TabIndex = 11;
            lbl_CurrentDkp.Text = "#";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(295, 3);
            label1.Name = "label1";
            label1.Size = new Size(35, 17);
            label1.TabIndex = 10;
            label1.Text = "DKP:";
            // 
            // trv_CharacterList
            // 
            trv_CharacterList.HideSelection = false;
            trv_CharacterList.Location = new Point(228, 24);
            trv_CharacterList.Name = "trv_CharacterList";
            trv_CharacterList.Size = new Size(196, 451);
            trv_CharacterList.TabIndex = 8;
            // 
            // btn_ClearDkpBids
            // 
            btn_ClearDkpBids.Location = new Point(6, 478);
            btn_ClearDkpBids.Name = "btn_ClearDkpBids";
            btn_ClearDkpBids.Size = new Size(418, 24);
            btn_ClearDkpBids.TabIndex = 7;
            btn_ClearDkpBids.Text = "Clear DKP Bids";
            btn_ClearDkpBids.UseVisualStyleBackColor = true;
            btn_ClearDkpBids.Click += btn_ClearDkpBids_Click;
            // 
            // trv_DkpBids
            // 
            trv_DkpBids.HideSelection = false;
            trv_DkpBids.Location = new Point(6, 6);
            trv_DkpBids.Name = "trv_DkpBids";
            trv_DkpBids.ShowNodeToolTips = true;
            trv_DkpBids.Size = new Size(216, 469);
            trv_DkpBids.TabIndex = 0;
            trv_DkpBids.NodeMouseClick += trv_DkpBids_NodeMouseClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(trv_LootRolls);
            tabPage2.Controls.Add(btn_ClearLootRolls);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(430, 508);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Player Rolls";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // trv_LootRolls
            // 
            trv_LootRolls.Location = new Point(6, 6);
            trv_LootRolls.Name = "trv_LootRolls";
            trv_LootRolls.Size = new Size(418, 467);
            trv_LootRolls.TabIndex = 1;
            // 
            // btn_ClearLootRolls
            // 
            btn_ClearLootRolls.Location = new Point(6, 479);
            btn_ClearLootRolls.Name = "btn_ClearLootRolls";
            btn_ClearLootRolls.Size = new Size(418, 23);
            btn_ClearLootRolls.TabIndex = 0;
            btn_ClearLootRolls.Text = "Clear Loot Rolls";
            btn_ClearLootRolls.UseVisualStyleBackColor = true;
            btn_ClearLootRolls.Click += btn_ClearLootRolls_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btn_ClearLootedItems);
            tabPage3.Controls.Add(dgv_LootedItems);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(430, 508);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Looted Iems";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_ClearLootedItems
            // 
            btn_ClearLootedItems.Location = new Point(3, 482);
            btn_ClearLootedItems.Name = "btn_ClearLootedItems";
            btn_ClearLootedItems.Size = new Size(424, 23);
            btn_ClearLootedItems.TabIndex = 1;
            btn_ClearLootedItems.Text = "Clear Looted Items";
            btn_ClearLootedItems.UseVisualStyleBackColor = true;
            btn_ClearLootedItems.Click += btn_ClearLootedItems_Click;
            // 
            // dgv_LootedItems
            // 
            dgv_LootedItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_LootedItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_LootedItems.Columns.AddRange(new DataGridViewColumn[] { Time, Player, Item });
            dgv_LootedItems.Location = new Point(3, 3);
            dgv_LootedItems.Name = "dgv_LootedItems";
            dgv_LootedItems.Size = new Size(424, 473);
            dgv_LootedItems.TabIndex = 0;
            // 
            // Time
            // 
            Time.HeaderText = "Time";
            Time.Name = "Time";
            // 
            // Player
            // 
            Player.HeaderText = "Player";
            Player.Name = "Player";
            // 
            // Item
            // 
            Item.HeaderText = "Item";
            Item.Name = "Item";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btn_DuplicateLoot);
            tabPage4.Controls.Add(dgv_DuplicateLoots);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(430, 508);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Duplicate Loot";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_DuplicateLoot
            // 
            btn_DuplicateLoot.Location = new Point(6, 479);
            btn_DuplicateLoot.Name = "btn_DuplicateLoot";
            btn_DuplicateLoot.Size = new Size(418, 23);
            btn_DuplicateLoot.TabIndex = 1;
            btn_DuplicateLoot.Text = "Find Duplicate Loot";
            btn_DuplicateLoot.UseVisualStyleBackColor = true;
            btn_DuplicateLoot.Click += btn_DuplicateLoot_Click;
            // 
            // dgv_DuplicateLoots
            // 
            dgv_DuplicateLoots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            dgv_DuplicateLoots.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv_DuplicateLoots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_DuplicateLoots.Location = new Point(6, 6);
            dgv_DuplicateLoots.Name = "dgv_DuplicateLoots";
            dgv_DuplicateLoots.Size = new Size(418, 470);
            dgv_DuplicateLoots.TabIndex = 0;
            // 
            // btn_LogMonitor
            // 
            btn_LogMonitor.Location = new Point(272, 554);
            btn_LogMonitor.Name = "btn_LogMonitor";
            btn_LogMonitor.Size = new Size(174, 24);
            btn_LogMonitor.TabIndex = 5;
            btn_LogMonitor.Text = "Start Monitoring Log";
            btn_LogMonitor.UseVisualStyleBackColor = true;
            btn_LogMonitor.Click += btn_LogMonitor_Click;
            // 
            // btn_OpenSettings
            // 
            btn_OpenSettings.Location = new Point(16, 554);
            btn_OpenSettings.Name = "btn_OpenSettings";
            btn_OpenSettings.Size = new Size(174, 24);
            btn_OpenSettings.TabIndex = 6;
            btn_OpenSettings.Text = "Open Settings";
            btn_OpenSettings.UseVisualStyleBackColor = true;
            btn_OpenSettings.Click += btn_OpenSettings_Click;
            // 
            // btn_Test
            // 
            btn_Test.Location = new Point(16, 588);
            btn_Test.Name = "btn_Test";
            btn_Test.Size = new Size(174, 24);
            btn_Test.TabIndex = 8;
            btn_Test.Text = "Test";
            btn_Test.UseVisualStyleBackColor = true;
            btn_Test.Click += btn_Test_Click;
            // 
            // RaidTickTimer
            // 
            RaidTickTimer.Tick += timer1_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 723);
            Controls.Add(btn_Test);
            Controls.Add(btn_OpenSettings);
            Controls.Add(btn_LogMonitor);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Loot Goblin";
            Shown += MainForm_Shown;
            tabControl1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_LootWinners).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_LootedItems).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_DuplicateLoots).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TreeView trv_DkpBids;
        private Button btn_ClearDkpBids;
        private Button btn_LogMonitor;
        private TreeView trv_LootRolls;
        private Button btn_ClearLootRolls;
        private TabPage tabPage3;
        private DataGridView dgv_LootedItems;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Player;
        private DataGridViewTextBoxColumn Item;
        private Button btn_ClearLootedItems;
        private Button btn_OpenSettings;
        private Label label1;
        private TreeView trv_CharacterList;
        private Label lbl_CurrentDkp;
        private TabPage tabPage4;
        private Button btn_DuplicateLoot;
        private DataGridView dgv_DuplicateLoots;
        private TabPage tabPage5;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private TextBox txtbx_AutoTickCountdown;
        private Button btn_SubmitManualTick;
        private TextBox txtbx_RaidName;
        private Label label5;
        private TextBox txtbx_TickDkpValue;
        private Label label8;
        private Panel panel4;
        private DataGridView dgv_LootWinners;
        private Label label7;
        private TextBox txtbx_DkpBidderName;
        private Button btn_AddDkpWinner;
        private TextBox txtbx_DkpBidderValue;
        private Button btn_RemoveDkpWinner;
        private Label label9;
        private TextBox txtbx_TickDescription;
        private Button btn_StartAutoTickTimer;
        private Button btn_SubmitRaid;
        private Label label11;
        private TextBox txtbx_DkpBidderItem;
        private Label label2;
        private Label label12;
        private TextBox txtbx_AutoTickDkp;
        private Button btn_BossManagement;
        private Label label13;
        private TextBox txtbx_AutoTickTimer;
        private Button btn_AddAutoTick;
        private Button btn_Test;
        private System.Windows.Forms.Timer RaidTickTimer;
        private Button btn_ClearDkpWinner;
    }
}
