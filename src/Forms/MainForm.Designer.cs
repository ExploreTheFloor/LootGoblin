namespace LootGoblin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            tabPage5 = new TabPage();
            label7 = new Label();
            textBox8 = new TextBox();
            button5 = new Button();
            textBox7 = new TextBox();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            BossName = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            textBox5 = new TextBox();
            label8 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            panel2 = new Panel();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            button3 = new Button();
            panel1 = new Panel();
            button2 = new Button();
            label2 = new Label();
            listView1 = new ListView();
            textBox1 = new TextBox();
            button1 = new Button();
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
            label9 = new Label();
            textBox6 = new TextBox();
            label10 = new Label();
            textBox9 = new TextBox();
            checkBox1 = new CheckBox();
            button6 = new Button();
            label11 = new Label();
            button7 = new Button();
            tabControl1.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
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
            tabPage5.Controls.Add(button7);
            tabPage5.Controls.Add(label11);
            tabPage5.Controls.Add(label7);
            tabPage5.Controls.Add(textBox8);
            tabPage5.Controls.Add(button5);
            tabPage5.Controls.Add(panel2);
            tabPage5.Controls.Add(textBox7);
            tabPage5.Controls.Add(dataGridView1);
            tabPage5.Controls.Add(button4);
            tabPage5.Controls.Add(panel4);
            tabPage5.Controls.Add(panel3);
            tabPage5.Controls.Add(panel1);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(430, 508);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Raid Management";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(115, 461);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 25;
            label7.Text = "Dkp Value";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(5, 479);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(104, 23);
            textBox8.TabIndex = 24;
            // 
            // button5
            // 
            button5.Location = new Point(189, 450);
            button5.Name = "button5";
            button5.Size = new Size(100, 23);
            button5.TabIndex = 23;
            button5.Text = "Add/Edit";
            button5.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(115, 479);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(59, 23);
            textBox7.TabIndex = 22;
            // 
            // button4
            // 
            button4.Location = new Point(189, 478);
            button4.Name = "button4";
            button4.Size = new Size(100, 23);
            button4.TabIndex = 21;
            button4.Text = "Remove";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { BossName, Value });
            dataGridView1.Location = new Point(6, 228);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(287, 216);
            dataGridView1.TabIndex = 19;
            // 
            // BossName
            // 
            BossName.HeaderText = "BossName";
            BossName.Name = "BossName";
            BossName.Width = 88;
            // 
            // Value
            // 
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.Width = 60;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label9);
            panel4.Controls.Add(textBox6);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(textBox9);
            panel4.Controls.Add(textBox5);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(button3);
            panel4.Location = new Point(6, 98);
            panel4.Name = "panel4";
            panel4.Size = new Size(287, 94);
            panel4.TabIndex = 18;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(80, 61);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(59, 23);
            textBox5.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 64);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 16;
            label8.Text = "DKP Value:";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(button6);
            panel3.Controls.Add(checkBox1);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(textBox3);
            panel3.Location = new Point(6, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(287, 86);
            panel3.TabIndex = 12;
            panel3.Paint += panel3_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 37);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 14;
            label6.Text = "Description:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(80, 34);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(202, 23);
            textBox4.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 8);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 12;
            label5.Text = "Raid Name:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(80, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(202, 23);
            textBox3.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(318, 395);
            panel2.Name = "panel2";
            panel2.Size = new Size(85, 106);
            panel2.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(10, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(62, 57);
            textBox2.TabIndex = 7;
            textBox2.Text = "60";
            textBox2.TextAlign = HorizontalAlignment.Center;
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
            // button3
            // 
            button3.Location = new Point(145, 61);
            button3.Name = "button3";
            button3.Size = new Size(137, 23);
            button3.TabIndex = 6;
            button3.Text = "Add Tick Manually";
            button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(295, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(128, 383);
            panel1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(3, 355);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 3;
            button2.Text = "Add Ignore";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 5);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 4;
            label2.Text = "Ignore These Bosses";
            // 
            // listView1
            // 
            listView1.Location = new Point(3, 23);
            listView1.Name = "listView1";
            listView1.Size = new Size(121, 268);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 326);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(3, 297);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 2;
            button1.Text = "Remove Selected";
            button1.UseVisualStyleBackColor = true;
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
            dgv_LootedItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            Time.Width = 58;
            // 
            // Player
            // 
            Player.HeaderText = "Player";
            Player.Name = "Player";
            Player.Width = 64;
            // 
            // Item
            // 
            Item.HeaderText = "Item";
            Item.Name = "Item";
            Item.Width = 56;
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
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 35);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 21;
            label9.Text = "Description:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(80, 32);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(202, 23);
            textBox6.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 6);
            label10.Name = "label10";
            label10.Size = new Size(68, 15);
            label10.TabIndex = 19;
            label10.Text = "Raid Name:";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(80, 3);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(202, 23);
            textBox9.TabIndex = 18;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 63);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(76, 19);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "Auto Tick";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(80, 59);
            button6.Name = "button6";
            button6.Size = new Size(202, 23);
            button6.TabIndex = 26;
            button6.Text = "Start Auto Tick";
            button6.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(5, 461);
            label11.Name = "label11";
            label11.Size = new Size(66, 15);
            label11.TabIndex = 26;
            label11.Text = "Boss Name";
            // 
            // button7
            // 
            button7.Location = new Point(6, 198);
            button7.Name = "button7";
            button7.Size = new Size(287, 23);
            button7.TabIndex = 27;
            button7.Text = "Submit Raid";
            button7.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 589);
            Controls.Add(btn_Test);
            Controls.Add(btn_OpenSettings);
            Controls.Add(btn_LogMonitor);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Loot Goblin";
            tabControl1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Button btn_Test;
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
        private TextBox textBox2;
        private Button button3;
        private Panel panel1;
        private Button button2;
        private Label label2;
        private ListView listView1;
        private TextBox textBox1;
        private Button button1;
        private Panel panel3;
        private TextBox textBox3;
        private Label label5;
        private Label label6;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label8;
        private Panel panel4;
        private DataGridView dataGridView1;
        private Label label7;
        private TextBox textBox8;
        private Button button5;
        private TextBox textBox7;
        private Button button4;
        private DataGridViewTextBoxColumn BossName;
        private DataGridViewTextBoxColumn Value;
        private Label label9;
        private TextBox textBox6;
        private Label label10;
        private TextBox textBox9;
        private Button button6;
        private CheckBox checkBox1;
        private Button button7;
        private Label label11;
    }
}
