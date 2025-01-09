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
            btn_ClearDkpBids = new Button();
            trv_DkpBids = new TreeView();
            tabPage2 = new TabPage();
            trv_LootRolls = new TreeView();
            btn_ClearLootRolls = new Button();
            tabPage3 = new TabPage();
            dataGridView1 = new DataGridView();
            btn_LogMonitor = new Button();
            label2 = new Label();
            txtbx_BidChannel = new TextBox();
            txtbx_LogFile = new TextBox();
            btn_LocateLog = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            tabControl1.Size = new Size(351, 536);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btn_ClearDkpBids);
            tabPage1.Controls.Add(trv_DkpBids);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(343, 508);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "DKP Bids";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_ClearDkpBids
            // 
            btn_ClearDkpBids.Location = new Point(6, 478);
            btn_ClearDkpBids.Name = "btn_ClearDkpBids";
            btn_ClearDkpBids.Size = new Size(331, 24);
            btn_ClearDkpBids.TabIndex = 7;
            btn_ClearDkpBids.Text = "Clear DKP Bids";
            btn_ClearDkpBids.UseVisualStyleBackColor = true;
            btn_ClearDkpBids.Click += btn_ClearDkpBids_Click;
            // 
            // trv_DkpBids
            // 
            trv_DkpBids.Location = new Point(6, 6);
            trv_DkpBids.Name = "trv_DkpBids";
            trv_DkpBids.Size = new Size(331, 469);
            trv_DkpBids.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(trv_LootRolls);
            tabPage2.Controls.Add(btn_ClearLootRolls);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(343, 508);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Player Rolls";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // trv_LootRolls
            // 
            trv_LootRolls.Location = new Point(6, 6);
            trv_LootRolls.Name = "trv_LootRolls";
            trv_LootRolls.Size = new Size(331, 467);
            trv_LootRolls.TabIndex = 1;
            // 
            // btn_ClearLootRolls
            // 
            btn_ClearLootRolls.Location = new Point(6, 479);
            btn_ClearLootRolls.Name = "btn_ClearLootRolls";
            btn_ClearLootRolls.Size = new Size(331, 23);
            btn_ClearLootRolls.TabIndex = 0;
            btn_ClearLootRolls.Text = "Clear Loot Rolls";
            btn_ClearLootRolls.UseVisualStyleBackColor = true;
            btn_ClearLootRolls.Click += btn_ClearLootRolls_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridView1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(343, 508);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Looted Iems";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(340, 502);
            dataGridView1.TabIndex = 0;
            // 
            // btn_LogMonitor
            // 
            btn_LogMonitor.Location = new Point(12, 608);
            btn_LogMonitor.Name = "btn_LogMonitor";
            btn_LogMonitor.Size = new Size(343, 24);
            btn_LogMonitor.TabIndex = 5;
            btn_LogMonitor.Text = "Start Monitoring Log";
            btn_LogMonitor.UseVisualStyleBackColor = true;
            btn_LogMonitor.Click += btn_LogMonitor_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 553);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 4;
            label2.Text = "Bdding Channel";
            // 
            // txtbx_BidChannel
            // 
            txtbx_BidChannel.Location = new Point(117, 550);
            txtbx_BidChannel.Name = "txtbx_BidChannel";
            txtbx_BidChannel.Size = new Size(236, 23);
            txtbx_BidChannel.TabIndex = 3;
            // 
            // txtbx_LogFile
            // 
            txtbx_LogFile.Location = new Point(117, 579);
            txtbx_LogFile.Name = "txtbx_LogFile";
            txtbx_LogFile.Size = new Size(236, 23);
            txtbx_LogFile.TabIndex = 6;
            // 
            // btn_LocateLog
            // 
            btn_LocateLog.Location = new Point(16, 578);
            btn_LocateLog.Name = "btn_LocateLog";
            btn_LocateLog.Size = new Size(95, 23);
            btn_LocateLog.TabIndex = 7;
            btn_LocateLog.Text = "Locate Log";
            btn_LocateLog.UseVisualStyleBackColor = true;
            btn_LocateLog.Click += btn_LocateLog_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 637);
            Controls.Add(btn_LocateLog);
            Controls.Add(txtbx_LogFile);
            Controls.Add(label2);
            Controls.Add(btn_LogMonitor);
            Controls.Add(txtbx_BidChannel);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Loot Goblin";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TreeView trv_DkpBids;
        private Label label2;
        private TextBox txtbx_BidChannel;
        private Button btn_ClearDkpBids;
        private Button btn_LogMonitor;
        private TreeView trv_LootRolls;
        private Button btn_ClearLootRolls;
        private TextBox txtbx_LogFile;
        private Button btn_LocateLog;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
    }
}
