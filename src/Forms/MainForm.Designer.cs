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
            btn_LogMonitor = new Button();
            btn_OpenSettings = new Button();
            btn_Test = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_LootedItems).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(438, 536);
            tabControl1.TabIndex = 0;
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
            // btn_LogMonitor
            // 
            btn_LogMonitor.Location = new Point(189, 554);
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
            btn_Test.Location = new Point(22, 588);
            btn_Test.Name = "btn_Test";
            btn_Test.Size = new Size(174, 24);
            btn_Test.TabIndex = 8;
            btn_Test.Text = "Test";
            btn_Test.UseVisualStyleBackColor = true;
            btn_Test.Click += btn_Test_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 624);
            Controls.Add(btn_Test);
            Controls.Add(btn_OpenSettings);
            Controls.Add(btn_LogMonitor);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Loot Goblin";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_LootedItems).EndInit();
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
    }
}
