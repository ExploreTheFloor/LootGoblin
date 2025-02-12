namespace LootGoblin.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            txtbx_BidChannel.Text = LootGoblin.Default.BidChannel;
            txtbx_Client.Text = LootGoblin.Default.Client;
            txtbx_Host.Text = LootGoblin.Default.Host;
            txtbx_LogFile.Text = LootGoblin.Default.LogLocation;
            txtbx_Password.Text = LootGoblin.Default.Password;
            txtbx_Username.Text = LootGoblin.Default.Username;
            txtbx_CharacterName.Text = LootGoblin.Default.CharacterName;
        }

        private void btn_SaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void SaveSettings()
        {
            LootGoblin.Default.BidChannel = txtbx_BidChannel.Text;
            LootGoblin.Default.Client = txtbx_Client.Text;
            LootGoblin.Default.Host = txtbx_Host.Text;
            LootGoblin.Default.LogLocation = txtbx_LogFile.Text;
            LootGoblin.Default.Password = txtbx_Password.Text;
            LootGoblin.Default.Username = txtbx_Username.Text;
            LootGoblin.Default.CharacterName = txtbx_CharacterName.Text;
            LootGoblin.Default.Save();
        }

        private void btn_LocateLog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "EQ Log files (eqlog*.txt)|eqlog*.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtbx_LogFile.Text = openFileDialog1.FileName;
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
    }
}
