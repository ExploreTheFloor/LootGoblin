namespace LootGoblin.Forms
{
    partial class BossManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label11 = new Label();
            label7 = new Label();
            txtbx_BossName = new TextBox();
            btn_AddOrEditBossDkpValue = new Button();
            txtbx_BossDkpValue = new TextBox();
            dgv_BossDkpValues = new DataGridView();
            BossName = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            btn_RemoveBossDkpValue = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_BossDkpValues).BeginInit();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 344);
            label11.Name = "label11";
            label11.Size = new Size(66, 15);
            label11.TabIndex = 33;
            label11.Text = "Boss Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(170, 343);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 32;
            label7.Text = "Dkp Value";
            // 
            // txtbx_BossName
            // 
            txtbx_BossName.Location = new Point(9, 362);
            txtbx_BossName.Name = "txtbx_BossName";
            txtbx_BossName.Size = new Size(155, 23);
            txtbx_BossName.TabIndex = 31;
            // 
            // btn_AddOrEditBossDkpValue
            // 
            btn_AddOrEditBossDkpValue.Location = new Point(235, 347);
            btn_AddOrEditBossDkpValue.Name = "btn_AddOrEditBossDkpValue";
            btn_AddOrEditBossDkpValue.Size = new Size(126, 42);
            btn_AddOrEditBossDkpValue.TabIndex = 30;
            btn_AddOrEditBossDkpValue.Text = "Add/Edit";
            btn_AddOrEditBossDkpValue.UseVisualStyleBackColor = true;
            // 
            // txtbx_BossDkpValue
            // 
            txtbx_BossDkpValue.Location = new Point(170, 362);
            txtbx_BossDkpValue.Name = "txtbx_BossDkpValue";
            txtbx_BossDkpValue.Size = new Size(59, 23);
            txtbx_BossDkpValue.TabIndex = 29;
            // 
            // dgv_BossDkpValues
            // 
            dgv_BossDkpValues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_BossDkpValues.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv_BossDkpValues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_BossDkpValues.Columns.AddRange(new DataGridViewColumn[] { BossName, Value });
            dgv_BossDkpValues.Location = new Point(12, 12);
            dgv_BossDkpValues.Name = "dgv_BossDkpValues";
            dgv_BossDkpValues.Size = new Size(422, 329);
            dgv_BossDkpValues.TabIndex = 27;
            // 
            // BossName
            // 
            BossName.HeaderText = "Boss";
            BossName.Name = "BossName";
            // 
            // Value
            // 
            Value.HeaderText = "Value";
            Value.Name = "Value";
            // 
            // btn_RemoveBossDkpValue
            // 
            btn_RemoveBossDkpValue.Location = new Point(367, 347);
            btn_RemoveBossDkpValue.Name = "btn_RemoveBossDkpValue";
            btn_RemoveBossDkpValue.Size = new Size(67, 42);
            btn_RemoveBossDkpValue.TabIndex = 28;
            btn_RemoveBossDkpValue.Text = "Remove";
            btn_RemoveBossDkpValue.UseVisualStyleBackColor = true;
            // 
            // BossManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 401);
            Controls.Add(label11);
            Controls.Add(label7);
            Controls.Add(txtbx_BossName);
            Controls.Add(btn_AddOrEditBossDkpValue);
            Controls.Add(txtbx_BossDkpValue);
            Controls.Add(dgv_BossDkpValues);
            Controls.Add(btn_RemoveBossDkpValue);
            Name = "BossManagerForm";
            Text = "Boss Management";
            ((System.ComponentModel.ISupportInitialize)dgv_BossDkpValues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label11;
        private Label label7;
        private TextBox txtbx_BossName;
        private Button btn_AddOrEditBossDkpValue;
        private TextBox txtbx_BossDkpValue;
        private DataGridView dgv_BossDkpValues;
        private Button btn_RemoveBossDkpValue;
        private DataGridViewTextBoxColumn BossName;
        private DataGridViewTextBoxColumn Value;
    }
}