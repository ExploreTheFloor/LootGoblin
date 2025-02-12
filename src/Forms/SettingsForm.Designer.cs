namespace LootGoblin.Forms
{
    partial class SettingsForm
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
            btn_LocateLog = new Button();
            txtbx_LogFile = new TextBox();
            label2 = new Label();
            txtbx_BidChannel = new TextBox();
            panel1 = new Panel();
            label6 = new Label();
            txtbx_Host = new TextBox();
            label5 = new Label();
            txtbx_Client = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtbx_Password = new TextBox();
            label1 = new Label();
            txtbx_Username = new TextBox();
            panel2 = new Panel();
            txtbx_CharacterName = new TextBox();
            label7 = new Label();
            label9 = new Label();
            btn_SaveSettings = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_LocateLog
            // 
            btn_LocateLog.Location = new Point(9, 131);
            btn_LocateLog.Name = "btn_LocateLog";
            btn_LocateLog.Size = new Size(290, 23);
            btn_LocateLog.TabIndex = 11;
            btn_LocateLog.Text = "Locate Log";
            btn_LocateLog.UseVisualStyleBackColor = true;
            btn_LocateLog.Click += btn_LocateLog_Click;
            // 
            // txtbx_LogFile
            // 
            txtbx_LogFile.Location = new Point(9, 102);
            txtbx_LogFile.Name = "txtbx_LogFile";
            txtbx_LogFile.Size = new Size(290, 23);
            txtbx_LogFile.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 76);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 9;
            label2.Text = "Bidding Channel";
            // 
            // txtbx_BidChannel
            // 
            txtbx_BidChannel.Location = new Point(106, 73);
            txtbx_BidChannel.Name = "txtbx_BidChannel";
            txtbx_BidChannel.Size = new Size(193, 23);
            txtbx_BidChannel.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtbx_Host);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtbx_Client);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtbx_Password);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtbx_Username);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(307, 153);
            panel1.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 120);
            label6.Name = "label6";
            label6.Size = new Size(32, 15);
            label6.TabIndex = 18;
            label6.Text = "Host";
            // 
            // txtbx_Host
            // 
            txtbx_Host.Location = new Point(83, 117);
            txtbx_Host.Name = "txtbx_Host";
            txtbx_Host.Size = new Size(216, 23);
            txtbx_Host.TabIndex = 17;
            txtbx_Host.Text = "api.opendkp.com";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 91);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 16;
            label5.Text = "Client";
            // 
            // txtbx_Client
            // 
            txtbx_Client.Location = new Point(83, 88);
            txtbx_Client.Name = "txtbx_Client";
            txtbx_Client.Size = new Size(216, 23);
            txtbx_Client.TabIndex = 15;
            txtbx_Client.Text = "Savage";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(53, 6);
            label4.Name = "label4";
            label4.Size = new Size(178, 21);
            label4.TabIndex = 14;
            label4.Text = "OpenDkp Information";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 62);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 13;
            label3.Text = "Password";
            // 
            // txtbx_Password
            // 
            txtbx_Password.Location = new Point(83, 59);
            txtbx_Password.Name = "txtbx_Password";
            txtbx_Password.PasswordChar = '*';
            txtbx_Password.Size = new Size(216, 23);
            txtbx_Password.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 33);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 11;
            label1.Text = "Username";
            // 
            // txtbx_Username
            // 
            txtbx_Username.Location = new Point(83, 30);
            txtbx_Username.Name = "txtbx_Username";
            txtbx_Username.Size = new Size(216, 23);
            txtbx_Username.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtbx_CharacterName);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtbx_LogFile);
            panel2.Controls.Add(btn_LocateLog);
            panel2.Controls.Add(txtbx_BidChannel);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 162);
            panel2.Name = "panel2";
            panel2.Size = new Size(307, 165);
            panel2.TabIndex = 13;
            // 
            // txtbx_CharacterName
            // 
            txtbx_CharacterName.Location = new Point(106, 44);
            txtbx_CharacterName.Name = "txtbx_CharacterName";
            txtbx_CharacterName.Size = new Size(193, 23);
            txtbx_CharacterName.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 47);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 16;
            label7.Text = "Character Name";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(53, 7);
            label9.Name = "label9";
            label9.Size = new Size(181, 21);
            label9.TabIndex = 14;
            label9.Text = "Everquest Information";
            // 
            // btn_SaveSettings
            // 
            btn_SaveSettings.Location = new Point(3, 333);
            btn_SaveSettings.Name = "btn_SaveSettings";
            btn_SaveSettings.Size = new Size(307, 23);
            btn_SaveSettings.TabIndex = 14;
            btn_SaveSettings.Text = "Save Settings and Close";
            btn_SaveSettings.UseVisualStyleBackColor = true;
            btn_SaveSettings.Click += btn_SaveSettings_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 359);
            Controls.Add(btn_SaveSettings);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SettingsForm";
            Text = "SettingsForm";
            FormClosed += SettingsForm_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_LocateLog;
        private TextBox txtbx_LogFile;
        private Label label2;
        private TextBox txtbx_BidChannel;
        private Panel panel1;
        private Label label3;
        private TextBox txtbx_Password;
        private Label label1;
        private TextBox txtbx_Username;
        private Label label6;
        private TextBox txtbx_Host;
        private Label label5;
        private TextBox txtbx_Client;
        private Label label4;
        private Panel panel2;
        private Label label9;
        private Button btn_SaveSettings;
        private TextBox txtbx_CharacterName;
        private Label label7;
    }
}