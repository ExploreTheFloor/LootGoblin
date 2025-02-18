using LootGoblin.Structure;
using Newtonsoft.Json;

namespace LootGoblin.Forms
{
    public partial class BossManagerForm : Form
    {
        public BossManagerForm()
        {
            InitializeComponent();
            dgv_BossDkpValues.DataSource = MainForm.BossValues;
        }

        private void btn_AddOrEditBossDkpValue_Click(object sender, EventArgs e)
        {
            if (MainForm.BossValues != null && MainForm.BossValues.Any(x => x.Name == txtbx_BossName.Text))
                return;
            var dkpValue = int.TryParse(txtbx_BossDkpValue.Text, out var dkpResult);
            if (!dkpValue)
                return;
            MainForm.BossValues?.Add(new BossManagement { Name = txtbx_BossName.Text, Dkp = dkpResult });
            ClearValues();
            SaveBossManagement();
        }

        private void btn_RemoveBossDkpValue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbx_BossName.Text) || string.IsNullOrEmpty(txtbx_BossDkpValue.Text))
                return;
            if (MainForm.BossValues != null)
            {
                var foundBoss = MainForm.BossValues.FirstOrDefault(x => x.Name == txtbx_BossName.Text);
                if (foundBoss != null)
                    MainForm.BossValues.Remove(foundBoss);
            }

            ClearValues();
        }

        private void ClearValues()
        {
            txtbx_BossName.Text = "";
            txtbx_BossDkpValue.Text = "";
        }

        private void dgv_BossDkpValues_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var selectedRow = dgv_BossDkpValues.Rows[e.RowIndex];
            txtbx_BossName.Text = selectedRow.Cells[0].Value.ToString();
            txtbx_BossDkpValue.Text = selectedRow.Cells[1].Value.ToString();
        }

        private void SaveBossManagement()
        {
            var fileName = $@"{AppDomain.CurrentDomain.BaseDirectory}Settings\BossManagement.json";
            var jsonString = JsonConvert.SerializeObject(MainForm.BossValues);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
