using LootGoblin.Services;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Xml.Linq;
using LootGoblin.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using String = System.String;
using LootGoblin.Structure;

namespace LootGoblin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private LogMonitor? _logMonitor = null;
        private SettingsForm _settingsForm = new SettingsForm();
        public event EventHandler<string> MessageToProcess;

        private void ParseDkpBids(string messageToProcess)
        {

            //if (!messageToProcess.Contains($"{txtbx_BidChannel}:"))
            //    return;
            string bidAmount;
            string bidType;
            string itemName;
            string biddersName;
            try
            {
                var splitMessage = messageToProcess.Replace("'", $"").Split(',');
                biddersName = splitMessage[0][26..].Trim().Split(" ")[0].Trim();
                var bidMessage = splitMessage[1];
                var splitBidMessage = bidMessage.Split(" ");
                if (splitBidMessage[^1].ToLower().Contains("main") || splitBidMessage[^1].ToLower().Contains("alt"))
                {
                    bidAmount = splitBidMessage[^2];
                    bidType = splitBidMessage[^1];
                }
                else
                {
                    bidAmount = splitBidMessage[^1];
                    bidType = "Main";
                }

                itemName = bidMessage.Split(bidAmount)[0].Trim();

            }
            catch
            {
                return;
            }

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(bidAmount) || !Char.IsDigit(bidAmount.Last()) ||
                string.IsNullOrEmpty(biddersName) || string.IsNullOrEmpty(bidType))
                return;
            Task.Run(async ()=> await UpdateDkpBid(itemName, biddersName, bidAmount, bidType));
        }

        private Dictionary<string, List<CharacterItems>> CharactersAndItems = new Dictionary<string, List<CharacterItems>>();
        private async Task UpdateDkpBid(string itemName, string biddersName, string bidAmount, string bidType)
        {
            if (trv_DkpBids.InvokeRequired)
            {
                trv_DkpBids.BeginInvoke(new Action(delegate
                {
                    UpdateDkpBid(itemName, biddersName, bidAmount, bidType);
                }));
                return;
            }
            trv_DkpBids.BeginUpdate();
            var newTreeNodeText = $"{bidAmount} | {biddersName} | {bidType}";
            var foundItemName = Collect(trv_DkpBids.Nodes).FirstOrDefault(x => x.Text == itemName);
            if (foundItemName != null)
            {
                var foundBidderName = Collect(foundItemName.Nodes).FirstOrDefault(x => x.Text.Contains(biddersName));
                if (foundBidderName != null)
                {
                    var splitFoundBidder = foundBidderName.Text.Split("|");
                    if (Convert.ToInt32(splitFoundBidder[0].Trim()) > Convert.ToInt32(bidAmount))
                    {
                        trv_DkpBids.EndUpdate();
                        return;
                    }

                    foundBidderName.Text = newTreeNodeText;
                }
                else
                {
                    foundItemName.Nodes.Add(newTreeNodeText);
                }
            }
            else
            {
                trv_DkpBids.Nodes.Add(itemName).Nodes.Add(newTreeNodeText);
                var openDkp = new OpenDkp();
                var characters = await openDkp.GetCharacters();
                var foundCharacter = characters.FirstOrDefault(x => x.Name == biddersName);

                var linkedCharacters = await openDkp.GetLinkedCharacters(foundCharacter.CharacterId);
                var foundParent =
                    linkedCharacters.LinkedCharacters.FirstOrDefault(x => x.ParentId != foundCharacter.CharacterId);
                if (foundParent != null)
                {
                    foundCharacter = characters.FirstOrDefault(x => x.CharacterId == foundParent.ParentId);
                    linkedCharacters = await openDkp.GetLinkedCharacters(foundCharacter.CharacterId);
                }

                var characterItems = await openDkp.GetCharacterItems(foundCharacter.CharacterId);
                CharactersAndItems.Add(foundCharacter.Name, characterItems);

                foreach (var linkedCharacter in linkedCharacters.LinkedCharacters)
                {
                    characterItems = await openDkp.GetCharacterItems(linkedCharacter.ChildId);
                    CharactersAndItems.Add(linkedCharacter.ChildName, characterItems);
                }
            }
            trv_DkpBids.Sort();
            trv_DkpBids.EndUpdate();
        }

        private string _currentRandomLootPlayerName = "";

        private void ParseLootRolls(string messageToProcess)
        {
            if (!messageToProcess.Contains("**"))
                return;
            try
            {
                messageToProcess = messageToProcess.RemoveLastCharacter();
                if (messageToProcess.Contains("**A Magic Die is rolled by"))
                {
                    _currentRandomLootPlayerName = messageToProcess[54..].Trim();
                }

                if (messageToProcess.Contains("**It could have been any number from"))
                {
                    var trimmedMessage = messageToProcess[64..];
                    var splitMessage = trimmedMessage.Split(',');
                    var rollRange = splitMessage[0].Trim();
                    var playerRoll = splitMessage[1].Replace("but this time it turned up a ", $"").Trim();
                    UpdateLootRolls(rollRange, _currentRandomLootPlayerName, playerRoll);
                    _currentRandomLootPlayerName = "";
                }

            }
            catch
            {
            }
        }

        public async Task UpdateCharacterList(string playerName)
        {
            try
            {
                if (trv_CharacterList.InvokeRequired)
                {
                    trv_CharacterList.BeginInvoke(new Action(delegate { UpdateCharacterList(playerName); }));
                    return;
                }

                trv_CharacterList.Nodes.Clear();
                var openDkp = new OpenDkp();
                var characters = await openDkp.GetCharacters();
                var foundCharacter = characters.FirstOrDefault(x => x.Name == playerName);

                var linkedCharacters = await openDkp.GetLinkedCharacters(foundCharacter.CharacterId);
                var foundParent =
                    linkedCharacters.LinkedCharacters.FirstOrDefault(x => x.ParentId != foundCharacter.CharacterId);
                if (foundParent != null)
                {
                    foundCharacter = characters.FirstOrDefault(x => x.CharacterId == foundParent.ParentId);
                    linkedCharacters = await openDkp.GetLinkedCharacters(foundCharacter.CharacterId);
                }

                trv_CharacterList.BeginUpdate();
                var parentCharacter = new TreeNode($"{foundCharacter.Name} | {foundCharacter.Class}");
                var characterItems = await openDkp.GetCharacterItems(foundCharacter.CharacterId);
                foreach (var characterItem in characterItems)
                {
                    parentCharacter.Nodes.Add(new TreeNode($"{characterItem.ItemName} | {characterItem.Date}"));
                }

                foreach (var linkedCharacter in linkedCharacters.LinkedCharacters)
                {
                    var childCharacter = new TreeNode($"{linkedCharacter.ChildName} | {linkedCharacter.ChildClass}");
                    characterItems = await openDkp.GetCharacterItems(linkedCharacter.ChildId);
                    foreach (var characterItem in characterItems)
                    {
                        childCharacter.Nodes.Add(new TreeNode($"{characterItem.ItemName} | {characterItem.Date}"));
                    }

                    trv_CharacterList.Nodes.Add(childCharacter);
                }

                trv_CharacterList.Nodes.Add(parentCharacter);

                trv_CharacterList.EndUpdate();
                trv_CharacterList.Sort();

            }
            catch { }
        }

        public void UpdateLootRolls(string rollRange, string playerName, string playerRoll)
        {
            if (trv_LootRolls.InvokeRequired)
            {
                trv_LootRolls.BeginInvoke(new Action(delegate
                {
                    UpdateLootRolls(rollRange, playerName, playerRoll);
                }));
                return;

            }
            trv_LootRolls.BeginUpdate();
            var newTreeNodeText = $"{playerRoll} | {playerName}";
            var foundRollRange = Collect(trv_LootRolls.Nodes).FirstOrDefault(x => x.Text == rollRange);

            if (foundRollRange != null)
            {
                var foundPlayersName = Collect(foundRollRange.Nodes).FirstOrDefault(x => x.Text.Contains(playerName));
                if (foundPlayersName != null)
                {
                    var splitFoundRoller = foundPlayersName.Text.Split("|");
                    if (Convert.ToInt32(splitFoundRoller[0].Trim()) > Convert.ToInt32(playerRoll))
                    {
                        trv_LootRolls.EndUpdate();
                        return;
                    }

                    foundPlayersName.Text = newTreeNodeText;
                }
                else
                {
                    foundRollRange.Nodes.Add(newTreeNodeText);
                }
            }
            else
            {
                trv_LootRolls.Nodes.Add(rollRange).Nodes.Add(newTreeNodeText);
            }
            trv_LootRolls.EndUpdate();
            trv_LootRolls.Sort();
        }

        public void ParseLootedItems(string messageToProcess)
        {
            if (!messageToProcess.Contains("] --") && !messageToProcess.Contains("has looted a"))
                return;
            try
            {
                var trimmedDateTime = messageToProcess.Replace("--", "")[26..].Replace("has looted a ", "").RemoveLastCharacter().Trim();
                var playerName = trimmedDateTime.Split(" ")[0];
                var lootedItem = trimmedDateTime[playerName.Length..].Trim();
                if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(lootedItem))
                    return;
                UpdateLootedItems(playerName, lootedItem);
            }
            catch { }
        }

        public void UpdateLootedItems(string playerName, string lootedItem)
        {
            if (dgv_LootedItems.InvokeRequired)
            {
                dgv_LootedItems.BeginInvoke(new Action(delegate { UpdateLootedItems(playerName, lootedItem); }));
                return;
            }
            dgv_LootedItems.Rows.Add(DateTime.Now.ToShortTimeString(), playerName, lootedItem);
            dgv_LootedItems.Update();
        }

        IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;

                //foreach (var child in Collect(node.Nodes))
                //    yield return child;
            }
        }

        /// <summary>
        /// Indicates whether the given file path points to a valid log file.
        /// </summary>
        public bool IsValidLogPath(string logPath)
        {
            return !String.IsNullOrWhiteSpace(logPath) && File.Exists(logPath) &&
                   Path.GetExtension(logPath) == ".txt";
        }

        private bool _isMonitoringLog = false;
        private void btn_LogMonitor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LootGoblin.Default.LogLocation))
                return;
            _logMonitor ??= new LogMonitor(LootGoblin.Default.LogLocation);
            if (!_isMonitoringLog)
            {
                _isMonitoringLog = true;
                btn_LogMonitor.Text = "Stop Monitoring Log";
                if (!_logMonitor.IsMonitoring)
                    _logMonitor.BeginMonitoring();
                _logMonitor.MessageReceived += ParseDkpBids;
                _logMonitor.MessageReceived += ParseLootRolls;
                _logMonitor.MessageReceived += ParseLootedItems;
            }
            else
            {
                btn_LogMonitor.Text = "Start Monitoring Log";
                if (_logMonitor.IsMonitoring)
                    _logMonitor.StopMonitoring();
                _logMonitor.MessageReceived += ParseDkpBids;
                _logMonitor.MessageReceived += ParseLootRolls;
                _logMonitor.MessageReceived += ParseLootedItems;
            }
        }
        private void test()
        {
            var rand = new Random();
            ParseDkpBids($"[Mon Nov 25 21:59:15 2024] Leetbeat tells the raid,  'Robe of the Azure Sky {rand.Next(10, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:18 2024] Shiroe tells the raid,  'Yunnb's Earring {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:28 2024] Gustuv tells the raid,  'Katana of Flowing Water {rand.Next(100, 300)} alt'");
            ParseDkpBids($"[Mon Nov 25 21:59:15 2024] Destruction tells the raid,  'Robe of the Azure Sky {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:15 2024] Leetbeat tells the raid,  'Robe of the Azure Sky {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:15 2024] Zumbuser tells the raid,  'Robe of the Azure Sky {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:15 2024] Xumbuser tells the raid,  'Robe of the Azure Sky {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:58:55 2024] Shiroe tells the raid,  'Yunnb's Earring {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:58:58 2024] Splodies's eyes glow violet.");
            ParseDkpBids($"[Mon Nov 25 21:58:59 2024] Cyrano tells the raid,  'Crown of Rile {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:02 2024] Karbin tells the raid,  'Robe of the Azure Sky {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:02 2024] Broby tells the raid,  'Crown of Rile {rand.Next(100, 500)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:02 2024] Xarszx tells the raid,  'Crown of Rile {rand.Next(100, 500)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:03 2024] Thebob tells the raid,  'Crown of Rile {rand.Next(100, 500)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:04 2024] Zibb tells the raid,  'Yunnb's Earring {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:15 2024] Ibekickin tells the raid,  'Crown of Rile {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:15 2024] Leetbeat tells the raid,  'Robe of the Azure Sky {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:18 2024] Shiroe tells the raid,  'Yunnb's Earring {rand.Next(100, 300)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:24 2024] Dookii tells the raid,  'Crown of Rile {rand.Next(100, 500)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:24 2024] Booshsoaker tells the raid,  'Robe of the Azure Sky {rand.Next(100, 300)}'");
            ParseDkpBids($"Mon Nov 25 21:59:24 2024] Xarszx tells the raid,  'Crown of Rile {rand.Next(100, 500)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:28 2024] Gustuv tells the raid,  'Katana of Flowing Water {rand.Next(1, 30)} alt'");
            ParseDkpBids($"[Mon Nov 25 21:59:33 2024] Ibekickin tells the raid,  'Crown of Rile {rand.Next(100, 500)}'");
            ParseDkpBids($"[Mon Nov 25 21:59:34 2024] Adann tells the raid,  'Oom afk'");
            ParseDkpBids($"[Mon Nov 25 21:59:35 2024] Thebob tells the raid,  'Crown of Rile {rand.Next(100, 500)}'");


            ParseLootRolls($"[Mon Jan 06 20:41:51 2025] **A Magic Die is rolled by Lenna.");
            ParseLootRolls($"[Mon Jan 06 20:41:51 2025] **It could have been any number from 0 to 333, but this time it turned up a 329.");
            ParseLootRolls($"[Mon Jan 06 20:41:47 2025] **A Magic Die is rolled by Larrmada.");
            ParseLootRolls($"[Mon Jan 06 20:41:47 2025] **It could have been any number from 0 to 444, but this time it turned up a 108.");
            ParseLootRolls($"[Mon Jan 06 20:41:44 2025] **A Magic Die is rolled by Skallagrimsson.");
            ParseLootRolls($"[Mon Jan 06 20:41:44 2025] **It could have been any number from 0 to 444, but this time it turned up a 167.");
            ParseLootRolls($"[Mon Jan 06 20:41:43 2025] **A Magic Die is rolled by Gaff.");
            ParseLootRolls($"[Mon Jan 06 20:41:43 2025] **It could have been any number from 0 to 333, but this time it turned up a 88.");
            ParseLootRolls($"[Tue Jan 07 20:43:34 2025] **A Magic Die is rolled by Katrenia.");
            ParseLootRolls($"[Tue Jan 07 20:43:34 2025] **It could have been any number from 0 to 44, but this time it turned up a 35.");
            ParseLootRolls($"[Tue Jan 07 20:42:25 2025] **A Magic Die is rolled by Katrenia.");
            ParseLootRolls($"[Tue Jan 07 20:42:25 2025] **It could have been any number from 0 to 443, but this time it turned up a 132.");

            ParseLootedItems("[Tue Jan 07 23:02:17 2025] --Brodin has looted a Noise Maker.--");
            ParseLootedItems("[Tue Jan 07 22:58:58 2025] --Keliae has looted a Noise Maker.--");
            ParseLootedItems("[Wed Jan 08 09:49:19 2025] --Spideroxy has looted a Salil's Writ Pg. 174.--");
            ParseLootedItems("[Wed Jan 08 09:49:21 2025] --Atlasius has looted a Green Silken Drape.--");
            ParseLootedItems("[Wed Jan 08 14:23:56 2025] --Duvos has looted a Black Henbane.--");
            ParseLootedItems("[Mon Jan 06 20:34:55 2025] --Shadowsong has looted a Spell: Talisman of the Cat.--");
            ParseLootedItems("[Mon Jan 06 20:44:26 2025] --Arrecha has looted a Fire Opal.--");
        }
        private void btn_ClearDkpBids_Click(object sender, EventArgs e)
        {
            trv_DkpBids.Nodes.Clear();
        }

        private void btn_ClearLootRolls_Click(object sender, EventArgs e)
        {
            trv_LootRolls.Nodes.Clear();
        }

        private void btn_ClearLootedItems_Click(object sender, EventArgs e)
        {
            dgv_LootedItems.Rows.Clear();
        }

        private bool isSettingsFormShown = false;
        private void btn_OpenSettings_Click(object sender, EventArgs e)
        {
            if (!isSettingsFormShown)
            {
                isSettingsFormShown = true;
                _settingsForm.Show();
                btn_OpenSettings.Text = "Close Settings";
            }
            else
            {
                isSettingsFormShown = false;
                _settingsForm.Hide();
                btn_OpenSettings.Text = "Open Settings";
            }
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            test();
            return;
            var openDkp = new OpenDkp();
            try
            {
                var authenticationResult = openDkp.GetCharacters();
                var test = authenticationResult.Result;
                var test2 = openDkp.GetDkpInformationList().Result;
                var test3 = openDkp.GetLinkedCharacters(test2.Models.FirstOrDefault().CharacterId).Result;

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                throw;
            }
        }

        private void trv_DkpBids_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var playerName = e.Node.Text.Split(" | ")[1];
                Task.Run(async () => await UpdateCharacterList(playerName));
            }
            catch { }
        }
    }
}
