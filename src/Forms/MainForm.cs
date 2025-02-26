using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using LootGoblin.Helpers;
using LootGoblin.Services;
using LootGoblin.Structure;
using LootGoblin.Windows;
using Newtonsoft.Json;
using Log = Serilog.Log;
using Microsoft.Toolkit.Uwp.Notifications;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace LootGoblin.Forms
{
    public partial class MainForm : Form
    {
        public static BindingList<BossManagement>? BossValues = new BindingList<BossManagement>();
        private readonly OpenDkp _openDkp = new OpenDkp();
        private LogMonitor? _logMonitor = null;
        private readonly SettingsForm _settingsForm = new SettingsForm();
        private BossManagerForm _bossManagerForm = new BossManagerForm();
        private List<Character> _characters = new List<Character>();
        private DKPSummary _dkpSummary = new DKPSummary();
        public CurrentRaid CurrentRaid = new CurrentRaid();
        private BindingList<DkpWinner> _dkpWinners = new BindingList<DkpWinner>();
        private BindingList<Tick> _raidTicks = new BindingList<Tick>();
        private Dictionary<int, string>? _itemDictionary;
        private readonly List<DkpBidder> _charactersAndItems = new List<DkpBidder>();

        public MainForm()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                _characters = await _openDkp.GetCharacters();
                _dkpSummary = await _openDkp.GetDKPSummary();
                var raidManagement = new RaidManagement();
                await raidManagement.ClearRaidTickFiles();
            });
            dgv_LootWinners.DataSource = _dkpWinners;
            dgv_RaidTicks.DataSource = _raidTicks;
            if (!Directory.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}\BackUp"))
                Directory.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}\BackUp");
            if (!Directory.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}Settings"))
                Directory.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}Settings");
            if (!Directory.Exists(
                    $@"{AppDomain.CurrentDomain.BaseDirectory}\BackUp\{DateTime.Now.ToShortDateString().Replace("/", "-")}"))
                Directory.CreateDirectory(
                    $@"{AppDomain.CurrentDomain.BaseDirectory}\BackUp\{DateTime.Now.ToShortDateString().Replace("/", "-")}");
            _itemDictionary =
                JsonConvert.DeserializeObject<Dictionary<int, string>>(
                    File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Resources\\Items.Json"));
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}Settings\\BossManagement.Json"))
            {
                BossValues =
                    JsonConvert.DeserializeObject<BindingList<BossManagement>>(
                        File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Settings\\BossManagement.Json"));
            }

            trv_DkpBids.TreeViewNodeSorter = new BidSorter();
            trv_LootRolls.TreeViewNodeSorter = new BidSorter();
            BindObjectToTreeView(CurrentRaid, trv_RaidDisplay);
            tabControl2.ItemSize = tabControl2.ItemSize = tabControl2.ItemSize with { Width = ((tabControl2.Width - 20) / tabControl2.TabPages.Count) - 1 };
        }

        private void BindObjectToTreeView(object? obj, TreeView treeView)
        {
            Log.Debug($"[{nameof(BindObjectToTreeView)}]");
            // Ensure modifications to TreeView are done on the UI thread
            if (treeView.InvokeRequired)
            {
                treeView.Invoke((Delegate)(() => BindObjectToTreeView(obj, treeView)));
            }
            else
            {
                // Create a root node
                TreeNode rootNode = new TreeNode(obj.GetType().Name);

                // Start the recursive binding
                AddObjectPropertiesToTreeView(obj, rootNode);

                // Add root node to TreeView and expand all nodes
                treeView.Nodes.Clear();
                treeView.Nodes.Add(rootNode);
                treeView.Nodes[0].Expand();
                treeView.Refresh();
            }
        }

        private void UpdateRaidInformation()
        {
            Log.Debug($"[{nameof(UpdateRaidInformation)}]");
            BindObjectToTreeView(CurrentRaid, trv_RaidDisplay);
        }

        private void SaveCurrentRaid()
        {
            Log.Debug($"[{nameof(SaveCurrentRaid)}]");
            var fileName =
                $@"{AppDomain.CurrentDomain.BaseDirectory}\BackUp\{DateTime.Now.ToShortDateString().Replace("/", "-")}\{txtbx_RaidName.Text}.json";
            var jsonString = JsonConvert.SerializeObject(CurrentRaid);
            File.WriteAllText(fileName, jsonString);
        }

        private void AddObjectPropertiesToTreeView(object? obj, TreeNode parentNode, string parentPropertyName = "")
        {
            Log.Debug($"[{nameof(AddObjectPropertiesToTreeView)}]");
            // If the object is null, return
            if (obj == null) return;

            // If the parentPropertyName is empty, it means we are starting with the root node
            if (string.IsNullOrEmpty(parentPropertyName))
            {
                parentPropertyName = obj.GetType().Name; // Use the class name for the root node if it's the first call
            }

            // Check if it's a collection (List/Array), and handle it
            if (obj is IEnumerable<object> collection)
            {
                int index = 0;
                foreach (var item in collection)
                {
                    // Use the parent node's name and the index for item text
                    string nodeName = $"{parentPropertyName.TrimEnd('s')} {index++}"; // Example: "Tick 0", "Item 1", etc.

                    TreeNode node = new TreeNode(nodeName);
                    parentNode.Nodes.Add(node);
                    AddObjectPropertiesToTreeView(item, node, parentPropertyName); // Recursively add nested objects in collection
                }
            }
            else
            {
                PropertyInfo[] properties = obj.GetType().GetProperties();
                foreach (var property in properties)
                {
                    try
                    {
                        // Check for indexed properties and skip them (e.g., collections, arrays)
                        if (property.GetIndexParameters().Length > 0)
                        {
                            continue; // Skip indexed properties
                        }

                        var propertyValue = property.GetValue(obj);

                        // If the property value is null, just display the name
                        if (propertyValue == null)
                        {
                            parentNode.Nodes.Add($"{property.Name}: null");
                        }
                        // Handle strings separately to avoid length being displayed
                        else if (propertyValue is string stringValue)
                        {
                            // Directly cast and show the actual string value
                            parentNode.Nodes.Add($"{property.Name}: {stringValue}");
                        }
                        // Handle collections of strings (like Characters in Ticks)
                        else if (propertyValue is IEnumerable<string> stringCollection)
                        {
                            // Create child nodes for each character
                            TreeNode charactersNode = new TreeNode($"{property.Name}:");
                            parentNode.Nodes.Add(charactersNode);

                            foreach (var character in stringCollection)
                            {
                                // Add each character as a child node
                                charactersNode.Nodes.Add($"{character}");
                            }
                        }
                        // Check for primitive types and display them
                        else if (propertyValue.GetType().IsPrimitive || propertyValue is DateTime)
                        {
                            parentNode.Nodes.Add($"{property.Name}: {propertyValue}");
                        }
                        else
                        {
                            // Handle nested objects by recursively calling AddObjectPropertiesToTreeView
                            TreeNode propertyNode = new TreeNode($"{property.Name}:");
                            parentNode.Nodes.Add(propertyNode);
                            AddObjectPropertiesToTreeView(propertyValue, propertyNode, property.Name); // Recursive call for nested objects
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors while accessing property values
                        parentNode.Nodes.Add($"{property.Name}: Error!");
                        Log.Error($"[{nameof(AddObjectPropertiesToTreeView)}] Error accessing property {property.Name}: {ex.Message}");
                    }
                }
            }
        }

        private string ItemToLinkFromId(int itemId)
        {
            Log.Debug($"[{nameof(GetItemNameFromId)}] {itemId}");
            Clipboard.SetText("\u0012" + $"00{itemId} {GetItemNameFromId(itemId)}" + "\u0012");
            return "\u0012" + $"{itemId} {GetItemNameFromId(itemId)}" + "\u0012";
        }

        private string ItemToLinkFromName(string itemName)
        {
            Log.Debug($"[{nameof(GetItemNameFromId)}] {itemName}");
            return "\u0012" + $"00{GetItemIdFromName(itemName)} {itemName}" + "\u0012";
        }

        private int GetItemIdFromName(string itemName)
        {
            Log.Debug($"[{nameof(GetItemNameFromId)}] {itemName}");
            return _itemDictionary != null ? _itemDictionary.FirstOrDefault(x => x.Value == itemName).Key : 0;
        }

        private string GetItemNameFromId(int itemId)
        {
            Log.Debug($"[{nameof(GetItemNameFromId)}] {itemId}");
            return _itemDictionary != null ? _itemDictionary.FirstOrDefault(x => x.Key == itemId).Value : "";
        }

        IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
        {
            return nodes.Cast<TreeNode>();
        }

        #region ParseMessages

        private void MessageMonitor(string? messageToProcess)
        {
            if (messageToProcess == null)
                return;
            if (messageToProcess.Contains("Druzzil Ro tells the guild") && messageToProcess.Contains("has killed a"))
            {
                Task.Run(async () =>
                {
                    await ParseKillMessage(messageToProcess);
                    UpdateRaidInformation();
                });
                return;
            }

            if (messageToProcess.Contains("Congratulations!") && messageToProcess.Contains("bid") &&
                messageToProcess.Contains("dkp for item:"))
            {
                Task.Run(async () =>
                {
                    await ParseAwardedLoot(messageToProcess);
                    UpdateRaidInformation();
                });
                return;
            }

            if (messageToProcess.Contains("**"))
            {
                Task.Run(async () =>
                {
                    await ParseLootRolls(messageToProcess);
                });
                return;
            }

            if (messageToProcess.Contains("] --") && messageToProcess.Contains("has looted a"))
            {
                Task.Run(async () =>
                {
                    await ParseLootedItems(messageToProcess);
                });
                return;
            }

            if (!string.IsNullOrWhiteSpace(LootGoblin.Default.BidChannel) &&
                !messageToProcess.Contains($"tells {LootGoblin.Default.BidChannel}:") ||
                (string.IsNullOrWhiteSpace(LootGoblin.Default.BidChannel) &&
                 !messageToProcess.Contains($"tells the guild") && !messageToProcess.Contains($"tells the raid")))
                return;

            Task.Run(async () =>
            {
                await ParseDkpBids(messageToProcess);
            });
        }

        private async Task ParseKillMessage(string messageToProcess)
        {
            if (BossValues == null || !BossValues.Any())
                return;
            //Druzzil Ro tells the guild, 'Remorse of Savage> has killed a dracoliche in Plane of Fear Instanced !'
            Log.Debug($"[{nameof(ParseKillMessage)}] {messageToProcess}");

            var nameOfKill = messageToProcess.Split("has killed a")[1].Trim().Split(" in ")[0].Trim();
            if (string.IsNullOrWhiteSpace(nameOfKill))
            {
                Log.Error($"[{nameof(ParseKillMessage)}] Unable to Parse Kill Message: {nameOfKill}!");
                return;
            }

            var foundBoss = BossValues.FirstOrDefault(x => x.Name == nameOfKill);
            if (foundBoss == null)
            {
                Log.Debug($"[{nameof(ParseKillMessage)}] There is no value set for boss: {nameOfKill}!");
                return;
            }

            new ToastContentBuilder()
                .AddText($"Boss Kill: {foundBoss}")
                .AddText("Please type /output RaidList in game!")
                .Show();

            MessageBox.Show("Please type /output raidlist in game and then hit Ok.", $"{nameOfKill} - Raid Tick Kill");

            var raidManagement = new RaidManagement();
            var raidAttendance = await raidManagement.GetRaidAttendance();
            if (!raidAttendance.Any())
            {
                Log.Warning($"[{nameof(ParseKillMessage)}] Unable to raid attendance!");
                return;
            }

            if (_characters != null)
            {
                var characters = raidAttendance.Select(x => x.Player).ToList();

                var autoTick = new Tick
                {
                    Characters = characters,
                    Description = $"{txtbx_RaidName.Text} - Kill: {nameOfKill}",
                    Value = foundBoss.Dkp.ToString()
                };
                CurrentRaid.Ticks.Add(autoTick);
            }
            else
            {
                MessageBox.Show(
                    @"Unable to locate characters for Raid Attendance.  Please type /output RaidList in game.");
            }
        }

        private async Task ParseAwardedLoot(string messageToProcess)
        {
            try
            {
                //var grats = $"Congratulations! {PlayerName} bid {bidAmount} dkp for item: {item}";
                Log.Debug($"[{nameof(ParseAwardedLoot)}] {messageToProcess}");
                var splitWholeMessage = messageToProcess[26..].Trim().Replace("'", $"").Split(',');
                var messagePoster = splitWholeMessage[0].Trim().Split(" ")[0].Trim();
                if (messagePoster.ToLower() != "you")
                    return;
                var splitCongratsMessage = splitWholeMessage[1].Trim().Split("!")[1].Trim();
                var playerName = splitCongratsMessage.Split(" ")[0].Trim();
                var bidAmount = Convert.ToInt32(splitCongratsMessage.Split(" ")[2].Trim());
                var itemWon = messageToProcess[26..].Trim().Split(":")[1].Trim();
                await Task.FromResult(UpdateAwardedLoot(new DkpWinner(playerName, bidAmount, itemWon)));
            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(ParseAwardedLoot)}] {ex.InnerException}");
            }
        }

        public Task UpdateAwardedLoot(DkpWinner dkpWinner)
        {
            if (dgv_LootWinners.InvokeRequired)
            {
                dgv_LootWinners.BeginInvoke(delegate { UpdateAwardedLoot(dkpWinner); });
                return Task.CompletedTask;
            }

            try
            {
                Log.Information(
                    $"[{nameof(UpdateAwardedLoot)}] Player: {dkpWinner.Player} | Item: {dkpWinner.Item} | Bid: {dkpWinner.Bid}");
                CurrentRaid.Items.Add(new Item
                {
                    CharacterName = dkpWinner.Player,
                    Dkp = dkpWinner.Bid,
                    GameItemId = GetItemIdFromName(dkpWinner.Item),
                    ItemId = GetItemIdFromName(dkpWinner.Item),
                    ItemName = dkpWinner.Item,
                    Notes = txtbx_RaidName.Text
                });
                _dkpWinners.Add(dkpWinner);
                dgv_LootWinners.Refresh();
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(UpdateAwardedLoot)}] {ex.InnerException}");
            }

            return Task.CompletedTask;
        }

        private async Task ParseDkpBids(string messageToProcess)
        {
            Log.Debug($"[{nameof(ParseDkpBids)}] {messageToProcess}");
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
            catch (Exception ex)
            {
                //Log.Error($"[{nameof(ParseDkpBids)}] {messageToProcess} {ex.InnerException}");
                return;
            }

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(bidAmount) || !Char.IsDigit(bidAmount.Last()) ||
                string.IsNullOrEmpty(biddersName) || string.IsNullOrEmpty(bidType))
                return;
            await UpdateDkpBid(itemName, biddersName, bidAmount, bidType);
        }

        private async Task UpdateDkpBid(string itemName, string biddersName, string bidAmount, string bidType)
        {
            Log.Debug($"[{nameof(UpdateDkpBid)}]");
            if (trv_DkpBids.InvokeRequired)
            {
                trv_DkpBids.BeginInvoke(delegate
                {
                    _ = UpdateDkpBid(itemName, biddersName, bidAmount, bidType);
                });
                return;
            }

            try
            {
                Log.Debug(
                    $"[{nameof(UpdateDkpBid)}] Player: {biddersName} | Item: {itemName} | Bid: {bidAmount} | Type: {bidType}");
                await AddBidderToCharacterItemList(biddersName);

                trv_DkpBids.BeginUpdate();
                var foundCharacter = _charactersAndItems.FirstOrDefault(x => x.Character.Name == biddersName);

                var foundDuplicateItems = _charactersAndItems
                    .Where(x => x.ParentId == foundCharacter?.ParentId &&
                                x.CharacterItems.Any(x => x.ItemName == itemName))
                    .Select(y => new
                    {
                        Name = y.Character.Name,
                        Date = y.CharacterItems.FirstOrDefault(z => z.ItemName == itemName)?.Date.ToShortDateString()
                    }).Distinct().ToList();

                var foundItemName = Collect(trv_DkpBids.Nodes).FirstOrDefault(x => x.Text == itemName);
                var newTreeNodeText = new TreeNode($"{bidAmount} | {biddersName} | {bidType}");

                if (foundDuplicateItems.Any())
                {
                    newTreeNodeText.ForeColor = Color.Red;
                    foreach (var foundDuplicateItem in foundDuplicateItems)
                    {
                        newTreeNodeText.ToolTipText += $"{foundDuplicateItem.Name} | {foundDuplicateItem.Date}";
                    }
                }

                if (foundItemName != null)
                {
                    var foundBidderName =
                        Collect(foundItemName.Nodes).FirstOrDefault(x => x.Text.Contains(biddersName));
                    if (foundBidderName != null)
                    {
                        var splitFoundBidder = foundBidderName.Text.Split("|");
                        if (Convert.ToInt32(splitFoundBidder[0].Trim()) > Convert.ToInt32(bidAmount))
                        {
                            trv_DkpBids.EndUpdate();
                            return;
                        }

                        foundItemName.Nodes.RemoveAt(foundBidderName.Index);
                    }

                    foundItemName.Nodes.Add(newTreeNodeText);
                }
                else
                {
                    var item = new TreeNode(itemName);
                    item.Nodes.Add(newTreeNodeText);
                    trv_DkpBids.Nodes.Add(item);
                }

                trv_DkpBids.Sort();
                trv_DkpBids.EndUpdate();

            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(UpdateDkpBid)}] {ex.InnerException}");
            }
        }

        private async Task AddBidderToCharacterItemList(string biddersName)
        {
            Log.Debug($"[{nameof(AddBidderToCharacterItemList)}] {biddersName}");
            try
            {
                Log.Debug($"[{nameof(AddBidderToCharacterItemList)}] Player: {biddersName}");
                if (_characters == null)
                {
                    Log.Warning($"[{nameof(AddBidderToCharacterItemList)}] Character List is Empty.");
                    return;
                }

                if (_charactersAndItems.Any(x => x.Character.Name == biddersName))
                {
                    Log.Warning($"[{nameof(AddBidderToCharacterItemList)}] Bidder Already Exists.");
                    return;
                }

                var foundCharacter = _characters.FirstOrDefault(x => x.Name == biddersName);

                if (foundCharacter == null)
                {
                    Log.Warning(
                        $"[{nameof(AddBidderToCharacterItemList)}] Unable to locate Bidder in Known Character List.");
                    return;
                }

                var linkedCharacters = await _openDkp.GetLinkedCharacters(foundCharacter.CharacterId);
                if (linkedCharacters?.LinkedCharacters == null || !linkedCharacters.LinkedCharacters.Any())
                {
                    Log.Information(
                        $"[{nameof(AddBidderToCharacterItemList)}] Added Parent: {foundCharacter.Name} to Character Items.");
                    var characterItems = await _openDkp.GetCharacterItems(foundCharacter.CharacterId);
                    _charactersAndItems.Add(new DkpBidder(foundCharacter, foundCharacter.CharacterId, characterItems));
                    Log.Debug(
                        $"[{nameof(AddBidderToCharacterItemList)}] {foundCharacter.Name} has no linked Characters");
                    return;
                }

                var foundLinkedCharacter =
                    linkedCharacters?.LinkedCharacters.FirstOrDefault(x => x.ParentId != foundCharacter.CharacterId);
                if (foundLinkedCharacter != null)
                {
                    var foundParent = _characters.FirstOrDefault(x => x.CharacterId == foundLinkedCharacter.ParentId);

                    if (foundParent != null)
                    {
                        foundCharacter = foundParent;
                        linkedCharacters = await _openDkp.GetLinkedCharacters(foundParent.CharacterId);
                        if (_charactersAndItems.All(x => x.Character.CharacterId != foundParent.CharacterId))
                        {
                            var characterItems = await _openDkp.GetCharacterItems(foundParent.CharacterId);
                            Log.Information(
                                $"[{nameof(AddBidderToCharacterItemList)}] Added Parent: {foundParent.Name} to Character Items.");
                            _charactersAndItems.Add(new DkpBidder(foundParent, foundParent.CharacterId,
                                characterItems));
                        }
                    }
                }
                else
                {
                    Log.Information(
                        $"[{nameof(AddBidderToCharacterItemList)}] Added Parent: {foundCharacter.Name} to Character Items.");
                    var characterItems = await _openDkp.GetCharacterItems(foundCharacter.CharacterId);
                    _charactersAndItems.Add(new DkpBidder(foundCharacter, foundCharacter.CharacterId, characterItems));
                }

                foreach (var linkedCharacter in linkedCharacters.LinkedCharacters.Where(linkedCharacter =>
                             _charactersAndItems.All(x => x.Character.CharacterId != linkedCharacter.ChildId)))
                {
                    var foundChild =
                        _characters.FirstOrDefault(x => x.CharacterId == linkedCharacter.ChildId);

                    if (foundChild == null)
                    {
                        Log.Debug(
                            $"[{nameof(AddBidderToCharacterItemList)}] No Child Found In Known Characters for: {foundCharacter.Name}");
                        continue;
                    }

                    if (_charactersAndItems.Any(x => x.Character.CharacterId == foundChild.CharacterId) ||
                        _charactersAndItems.Any(x => x.Character.Name == foundChild.Name))
                    {
                        Log.Debug(
                            $"[{nameof(AddBidderToCharacterItemList)}] Child Already Found for: {foundCharacter.Name}");
                        continue;
                    }

                    var characterItems = await _openDkp.GetCharacterItems(linkedCharacter.ChildId);
                    Log.Information(
                        $"[{nameof(AddBidderToCharacterItemList)}] Added Child: {foundChild.Name} to Character Items.");
                    _charactersAndItems.Add(new DkpBidder(foundChild, linkedCharacter.ParentId, characterItems));
                }

            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(AddBidderToCharacterItemList)}] {ex.InnerException}");
            }
        }


        public Task UpdateCharacterList(string playerName)
        {
            Log.Debug($"[{nameof(UpdateCharacterList)}] {playerName}");
            if (trv_CharacterList.InvokeRequired)
            {
                trv_CharacterList.BeginInvoke(delegate { UpdateCharacterList(playerName); });
                return Task.CompletedTask;
            }

            try
            {
                trv_CharacterList.Nodes.Clear();
                var foundCharacter = _charactersAndItems.FirstOrDefault(x => x.Character.Name == playerName);

                if (foundCharacter != null)
                {
                    var parentBidder = foundCharacter;
                    if (foundCharacter.ParentId != foundCharacter.Character.CharacterId)
                    {
                        Log.Debug($"[{nameof(UpdateCharacterList)}] Found Parent: {foundCharacter.Character.Name}");
                        parentBidder =
                            _charactersAndItems.FirstOrDefault(x => x.Character.CharacterId == foundCharacter.ParentId);
                    }

                    var linkedCharacters = _charactersAndItems.Distinct().Where(x =>
                        x.ParentId == foundCharacter.ParentId && x.Character.CharacterId != foundCharacter.ParentId);

                    trv_CharacterList.BeginUpdate();
                    var parentCharacter =
                        new TreeNode(
                            $"{parentBidder.Character.Name} | {parentBidder.Character.Class}");

                    foreach (var characterItem in parentBidder.CharacterItems)
                    {
                        Log.Debug(
                            $"[{nameof(UpdateCharacterList)}] Adding Item: {characterItem.ItemName} to [Parent]:{parentBidder.Character.Name}");
                        parentCharacter.Nodes.Add(
                            new TreeNode(
                                $"{characterItem.ItemName} | {characterItem.Date.ToShortDateString()}"));
                    }

                    foreach (var linkedCharacter in linkedCharacters)
                    {
                        var childCharacter =
                            new TreeNode(
                                $"{linkedCharacter.Character.Name} | {linkedCharacter.Character.Class}");
                        foreach (var characterItem in linkedCharacter.CharacterItems)
                        {
                            Log.Debug(
                                $"[{nameof(UpdateCharacterList)}] Adding Item: {characterItem.ItemName} to [Linked]:{linkedCharacter.Character.Name}");
                            childCharacter.Nodes.Add(
                                new TreeNode(
                                    $"{characterItem.ItemName} | {characterItem.Date.ToShortDateString()}"));
                        }

                        Log.Debug(
                            $"[{nameof(UpdateCharacterList)}] Adding Child Name: {linkedCharacter.Character.Name} | Class: {linkedCharacter.Character.Class}");
                        trv_CharacterList.Nodes.Add(childCharacter);
                    }

                    Log.Debug(
                        $"[{nameof(UpdateCharacterList)}] Adding Parent Name: {parentBidder.Character.Name} | Class: {parentBidder.Character.Class}");
                    trv_CharacterList.Nodes.Add(parentCharacter);

                    trv_CharacterList.EndUpdate();
                    trv_CharacterList.Sort();

                }
            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(UpdateCharacterList)}] {ex.InnerException}");
            }

            return Task.CompletedTask;
        }

        private string _currentRandomLootPlayerName = "";

        private async Task ParseLootRolls(string messageToProcess)
        {
            Log.Debug($"[{nameof(ParseLootRolls)}] {messageToProcess}");
            if (!messageToProcess.Contains("**"))
                return;
            try
            {
                Log.Debug($"[{nameof(ParseLootRolls)}] {messageToProcess}");
                messageToProcess = messageToProcess.RemoveLastCharacter();
                if (messageToProcess.Contains("**A Magic Die is rolled by"))
                {
                    _currentRandomLootPlayerName = messageToProcess[54..].Trim();
                    return;
                }

                if (!messageToProcess.Contains("**It could have been any number from"))
                    return;

                var trimmedMessage = messageToProcess[64..];
                var splitMessage = trimmedMessage.Split(',');
                var rollRange = splitMessage[0].Trim();
                var playerRoll = splitMessage[1].Replace("but this time it turned up a ", $"").Trim();
                await Task.FromResult(UpdateLootRolls(rollRange, _currentRandomLootPlayerName, playerRoll));
            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(ParseLootRolls)}] {ex.InnerException}");
            }
        }

        public Task UpdateLootRolls(string rollRange, string playerName, string playerRoll)
        {
            Log.Debug($"[{nameof(UpdateLootRolls)}] {rollRange} {playerName} {playerRoll}");
            if (trv_LootRolls.InvokeRequired)
            {
                trv_LootRolls.BeginInvoke(delegate { UpdateLootRolls(rollRange, playerName, playerRoll); });
                return Task.CompletedTask;
            }

            try
            {
                Log.Debug(
                    $"[{nameof(UpdateLootRolls)}] Player: {playerName} | Range: {rollRange} | Roll: {playerRoll}");
                trv_LootRolls.BeginUpdate();
                var newTreeNodeText = $"{playerRoll} | {playerName}";
                var foundRollRange = Collect(trv_LootRolls.Nodes).FirstOrDefault(x => x.Text == rollRange);

                if (foundRollRange != null)
                {
                    var foundPlayersName =
                        Collect(foundRollRange.Nodes).FirstOrDefault(x => x.Text.Contains(playerName));
                    if (foundPlayersName != null)
                    {
                        var splitFoundRoller = foundPlayersName.Text.Split("|");
                        if (Convert.ToInt32(splitFoundRoller[0].Trim()) > Convert.ToInt32(playerRoll))
                        {
                            trv_LootRolls.EndUpdate();
                            return Task.CompletedTask;
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

                Log.Information(
                    $"[{nameof(ParseLootRolls)}] Added Range: {rollRange} Name: {playerName} Roll: {playerRoll}");
                trv_LootRolls.EndUpdate();
                trv_LootRolls.Sort();
                _currentRandomLootPlayerName = "";
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(UpdateLootRolls)}] {ex.InnerException}");
                return Task.CompletedTask;
            }
        }

        public async Task ParseLootedItems(string messageToProcess)
        {
            Log.Debug($"[{nameof(ParseLootedItems)}] {messageToProcess}");
            if (!messageToProcess.Contains("] --") && !messageToProcess.Contains("has looted a"))
                return;
            Log.Information($"[{nameof(ParseLootRolls)}] {messageToProcess}");
            try
            {
                var trimmedDateTime = messageToProcess.Replace("--", "")[26..].Replace("has looted a ", "")
                    .RemoveLastCharacter().Trim();
                var playerName = trimmedDateTime.Split(" ")[0];
                var lootedItem = trimmedDateTime[playerName.Length..].Trim();
                if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(lootedItem))
                    return;
                await Task.FromResult(UpdateLootedItems(playerName, lootedItem));
            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(ParseLootedItems)}] {ex.InnerException}");
            }
        }

        public Task UpdateLootedItems(string playerName, string lootedItem)
        {
            Log.Debug($"[{nameof(UpdateLootedItems)}] {playerName} {lootedItem}");
            try
            {
                if (dgv_LootedItems.InvokeRequired)
                {
                    dgv_LootedItems.BeginInvoke(delegate { UpdateLootedItems(playerName, lootedItem); });
                    return Task.CompletedTask;
                }

                Log.Debug($"[{nameof(UpdateLootedItems)}] Player: {playerName} | Item: {lootedItem}");
                dgv_LootedItems.Rows.Add(DateTime.Now.ToShortTimeString(), playerName, lootedItem);
                dgv_LootedItems.Update();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(UpdateLootedItems)}] {ex.InnerException}");
                return Task.CompletedTask;
            }
        }

        #endregion ParseMessages

        private Task Test()
        {
            Log.Debug($"[{nameof(Test)}]");
            var rand = new Random();

            #region Kill Message

            //MessageMonitor("Druzzil Ro tells the guild, 'Remorse of Savage> has killed a dracoliche in Plane of Fear Instanced !'");

            #endregion Kill Message

            #region Awarded Loot

            //var grats = $"Congratulations! {PlayerName} bid {bidAmount} dkp for item: {item}"
            MessageMonitor(
                $"[Tue Jan 07 20:42:25 2025] You tell the raid,  'Congratulations! Test1 bid 3 dkp for item: Ton Po's Eye Patch");
            MessageMonitor(
                $"[Tue Jan 07 20:42:25 2025] You tell the raid,  'Congratulations! Test2 bid 4 dkp for item: Ton Po's Shoulder Wraps");
            MessageMonitor(
                $"[Tue Jan 07 20:42:25 2025] You tell the raid,  'Congratulations! Test3 bid 5 dkp for item: Ton Po's Bo Stick of Understanding");

            #endregion Awarded Loot

            #region Bids

            MessageMonitor($"[Mon Nov 25 21:59:04 2024] Zibb tells the raid,  'Yunnb's Earring {rand.Next(200, 300)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:15 2024] Leetbeat tells the raid,  'Robe of the Azure Sky {rand.Next(1, 100)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:18 2024] Shiroe tells the raid,  'Yunnb's Earring {rand.Next(1, 100)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:28 2024] Gustuv tells the raid,  'Katana of Flowing Water {rand.Next(1, 100)} alt'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:15 2024] Leetbeat tells the raid,  'Robe of the Azure Sky {rand.Next(1, 100)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:58:55 2024] Shiroe tells the raid,  'Yunnb's Earring {rand.Next(100, 200)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:58:58 2024] Splodies's eyes glow violet.");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:58:59 2024] Cyrano tells the raid,  'Crown of Rile {rand.Next(1, 100)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:02 2024] Karbin tells the raid,  'Robe of the Azure Sky {rand.Next(1, 100)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:02 2024] Broby tells the raid,  'Crown of Rile {rand.Next(100, 520)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:02 2024] Xarszx tells the raid,  'Crown of Rile {rand.Next(100, 200)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:03 2024] Thebob tells the raid,  'Crown of Rile {rand.Next(100, 200)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:04 2024] Zibb tells the raid,  'Yunnb's Earring {rand.Next(200, 300)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:02 2024] Broby tells the raid,  'Crown of Rile {rand.Next(200, 500)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:02 2024] Xarszx tells the raid,  'Crown of Rile {rand.Next(200, 500)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:03 2024] Thebob tells the raid,  'Crown of Rile {rand.Next(200, 500)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:04 2024] Zibb tells the raid,  'Yunnb's Earring {rand.Next(200, 300)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:15 2024] Ibekickin tells the raid,  'Crown of Rile {rand.Next(300, 500)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:15 2024] Leetbeat tells the raid,  'Robe of the Azure Sky {rand.Next(200, 300)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:18 2024] Shiroe tells the raid,  'Yunnb's Earring {rand.Next(200, 300)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:24 2024] Dookii tells the raid,  'Crown of Rile {rand.Next(300, 500)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:24 2024] Booshsoaker tells the raid,  'Robe of the Azure Sky {rand.Next(200, 300)}'");
            Thread.Sleep(1000);
            MessageMonitor($"Mon Nov 25 21:59:24 2024] Xarszx tells the raid,  'Crown of Rile {rand.Next(400, 500)}'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:28 2024] Gustuv tells the raid,  'Katana of Flowing Water {rand.Next(1, 30)} alt'");
            Thread.Sleep(1000);
            MessageMonitor(
                $"[Mon Nov 25 21:59:33 2024] Ibekickin tells the raid,  'Crown of Rile {rand.Next(400, 500)}'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:34 2024] Adann tells the raid,  'Oom afk'");
            Thread.Sleep(1000);
            MessageMonitor($"[Mon Nov 25 21:59:35 2024] Thebob tells the raid,  'Crown of Rile {rand.Next(400, 500)}'");

            #endregion Bids

            #region Rolls

            MessageMonitor($"[Mon Jan 06 20:41:51 2025] **A Magic Die is rolled by Lenna.");
            MessageMonitor(
                $"[Mon Jan 06 20:41:51 2025] **It could have been any number from 0 to 333, but this time it turned up a 329.");
            MessageMonitor($"[Mon Jan 06 20:41:47 2025] **A Magic Die is rolled by Larrmada.");
            MessageMonitor(
                $"[Mon Jan 06 20:41:47 2025] **It could have been any number from 0 to 444, but this time it turned up a 108.");
            MessageMonitor($"[Mon Jan 06 20:41:44 2025] **A Magic Die is rolled by Skallagrimsson.");
            MessageMonitor(
                $"[Mon Jan 06 20:41:44 2025] **It could have been any number from 0 to 444, but this time it turned up a 167.");
            MessageMonitor($"[Mon Jan 06 20:41:43 2025] **A Magic Die is rolled by Gaff.");
            MessageMonitor(
                $"[Mon Jan 06 20:41:43 2025] **It could have been any number from 0 to 333, but this time it turned up a 88.");
            MessageMonitor($"[Tue Jan 07 20:43:34 2025] **A Magic Die is rolled by Katrenia.");
            MessageMonitor(
                $"[Tue Jan 07 20:43:34 2025] **It could have been any number from 0 to 44, but this time it turned up a 35.");
            MessageMonitor($"[Tue Jan 07 20:42:25 2025] **A Magic Die is rolled by Katrenia.");
            MessageMonitor(
                $"[Tue Jan 07 20:42:25 2025] **It could have been any number from 0 to 443, but this time it turned up a 132.");

            #endregion Rolls

            #region Looted

            MessageMonitor("[Tue Jan 07 23:02:17 2025] --Brodin has looted a Noise Maker.--");
            MessageMonitor("[Tue Jan 07 22:58:58 2025] --Keliae has looted a Noise Maker.--");
            MessageMonitor("[Wed Jan 08 09:49:19 2025] --Spideroxy has looted a Salil's Writ Pg. 174.--");
            MessageMonitor("[Wed Jan 08 09:49:21 2025] --Atlasius has looted a Green Silken Drape.--");
            MessageMonitor("[Wed Jan 08 14:23:56 2025] --Duvos has looted a Black Henbane.--");
            MessageMonitor("[Mon Jan 06 20:34:55 2025] --Shadowsong has looted a Spell: Talisman of the Cat.--");
            MessageMonitor("[Mon Jan 06 20:44:26 2025] --Arrecha has looted a Fire Opal.--");

            #endregion Looted

            UpdateTicksTest();
            UpdateRaidInformation();

            return Task.CompletedTask;
        }

        private void UpdateTicksTest()
        {
            Log.Debug($"[{nameof(UpdateTicksTest)}]");
            if (dgv_RaidTicks.InvokeRequired)
            {
                dgv_RaidTicks.BeginInvoke(delegate { UpdateTicksTest(); });
                return;
            }
            CurrentRaid?.Ticks.Add(new Tick
            {
                Characters = _characters.Take(5).ToList().Select(x => x.Name).ToList(),
                Description = $"{txtbx_RaidName.Text} - AutoTick: 1",
                Value = txtbx_AutoTickDkp.Text
            });
            _raidTicks.Add(new Tick
            {
                Characters = _characters.Take(5).ToList().Select(x => x.Name).ToList(),
                Description = $"{txtbx_RaidName.Text} - AutoTick: 1",
                Value = txtbx_AutoTickDkp.Text
            });

            CurrentRaid.Ticks.Add(new Tick
            {
                Characters = _characters.Skip(5).Take(5).ToList().Select(x => x.Name).ToList(),
                Description = $"{txtbx_RaidName.Text} - AutoTick: 2",
                Value = txtbx_AutoTickDkp.Text
            });
            _raidTicks.Add(new Tick
            {
                Characters = _characters.Skip(5).Take(5).ToList().Select(x => x.Name).ToList(),
                Description = $"{txtbx_RaidName.Text} - AutoTick: 2",
                Value = txtbx_AutoTickDkp.Text
            });

            CurrentRaid.Ticks.Add(new Tick
            {
                Characters = _characters.Skip(3).Take(5).ToList().Select(x => x.Name).ToList(),
                Description = $"{txtbx_RaidName.Text} - AutoTick: 3",
                Value = txtbx_AutoTickDkp.Text
            });
            _raidTicks.Add(new Tick
            {
                Characters = _characters.Skip(3).Take(5).ToList().Select(x => x.Name).ToList(),
                Description = $"{txtbx_RaidName.Text} - AutoTick: 3",
                Value = txtbx_AutoTickDkp.Text
            });
        }


        private void RefreshDataGridView(DataGridView dgv)
        {
            Log.Debug($"[{nameof(RefreshDataGridView)}]");
            if (dgv.InvokeRequired)
            {
                dgv.BeginInvoke(delegate { RefreshDataGridView(dgv); });
                return;
            }
            dgv.Refresh();
        }

        #region Events

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(MainForm_Shown)}]");
            if (string.IsNullOrEmpty(LootGoblin.Default.Client) ||
                string.IsNullOrEmpty(LootGoblin.Default.Host) ||
                string.IsNullOrEmpty(LootGoblin.Default.LogLocation) ||
                string.IsNullOrEmpty(LootGoblin.Default.Password) ||
                string.IsNullOrEmpty(LootGoblin.Default.Username) ||
                string.IsNullOrEmpty(LootGoblin.Default.CharacterName))
            {
                var result = MessageBox.Show("You have not setup Loot Goblin, would you like to enter settings now?",
                    "Confirmation", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        _settingsForm.Show();
                        break;
                    case DialogResult.No:
                        MessageBox.Show("Loot Goblin will not run properly until you fill out the settings.");
                        break;
                }
            }
        }

        private void btn_DuplicateLoot_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_DuplicateLoot_Click)}]");
            Task.Run(async () =>
            {
                try
                {
                    Log.Information($"[{nameof(btn_DuplicateLoot_Click)}] Starting Duplicate Item Search");
                    var tools = new Tools();
                    var findDupes = await tools.FindDuplicateLoots();
                    var dupeLootSource = new BindingList<GridViewItemDuplicate>(findDupes.Select(x =>
                        new GridViewItemDuplicate(x.User, x.Item.ItemName, x.Item.Date.ToShortDateString())).ToList());
                    await UpdateDupeLoot(dupeLootSource);
                }
                catch (Exception ex)
                {
                    Log.Error($"[{nameof(btn_DuplicateLoot_Click)}] {ex.InnerException}");
                }
            });

        }

        public Task UpdateDupeLoot(BindingList<GridViewItemDuplicate> dupeLootSource)
        {
            Log.Debug($"[{nameof(UpdateDupeLoot)}]");
            if (trv_LootRolls.InvokeRequired)
            {
                trv_LootRolls.BeginInvoke(delegate { UpdateDupeLoot(dupeLootSource); });
                return Task.CompletedTask;
            }

            dgv_DuplicateLoots.DataSource = dupeLootSource;
            dgv_DuplicateLoots.Refresh();
            return Task.CompletedTask;
        }

        public void UpdateTextBoxForegroundColor(TextBox textBox, Color color)
        {
            Log.Debug($"[{nameof(UpdateTextBoxForegroundColor)}]");
            if (textBox.InvokeRequired)
            {
                textBox.BeginInvoke(delegate { UpdateTextBoxForegroundColor(textBox, color); });
                return;
            }

            textBox.ForeColor = color;
        }

        public void UpdateTextBoxBackgroundColor(TextBox textBox, Color color)
        {
            Log.Debug($"[{nameof(UpdateTextBoxBackgroundColor)}]");
            if (textBox.InvokeRequired)
            {
                textBox.BeginInvoke(delegate { UpdateTextBoxBackgroundColor(textBox, color); });
                return;
            }

            textBox.BackColor = color;
        }

        private string GetTextBoxText(TextBox textBox)
        {
            Log.Debug($"[{nameof(GetTextBoxText)}]");
            if (!textBox.InvokeRequired)
            {
                return textBox.Text;
            }

            var text = string.Empty;
            textBox.Invoke(() => { text = textBox.Text; });
            return text;
        }

        private bool _bossManagerFormShown = false;

        private void btn_RaidManagement_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_RaidManagement_Click)}]");
            if (!_bossManagerFormShown)
            {
                _bossManagerFormShown = true;
                _bossManagerForm = new BossManagerForm();
                _bossManagerForm.Show();
                btn_BossManagement.Text = "Close Boss Management";
            }
            else
            {
                _bossManagerFormShown = false;
                _bossManagerForm.Close();
                btn_BossManagement.Text = "Open Boss Management";
            }
        }

        private void btn_ClearDkpBids_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_ClearDkpBids_Click)}]");
            trv_DkpBids.Nodes.Clear();
        }

        private void btn_ClearLootRolls_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_ClearLootRolls_Click)}]");
            trv_LootRolls.Nodes.Clear();
        }

        private void btn_ClearLootedItems_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_ClearLootedItems_Click)}]");
            dgv_LootedItems.Rows.Clear();
        }

        private bool _isSettingsFormShown = false;

        private void btn_OpenSettings_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_OpenSettings_Click)}]");
            if (!_isSettingsFormShown)
            {
                _isSettingsFormShown = true;
                _settingsForm.Show();
                btn_OpenSettings.Text = "Close Settings";
            }
            else
            {
                _isSettingsFormShown = false;
                _settingsForm.Hide();
                btn_OpenSettings.Text = "Open Settings";
            }
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_Test_Click)}]");
            Task.Run(() => Task.FromResult(Test()));
        }

        private void trv_DkpBids_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Log.Debug($"[{nameof(trv_DkpBids_NodeMouseClick)}]");
            try
            {
                if (!e.Node.Text.Contains(" | "))
                    return;
                //new TreeNode($"{bidAmount} | {biddersName} | {bidType}");
                var splitBidInfo = e.Node.Text.Split(" | ");
                var playerName = splitBidInfo[1];
                if (playerName == "You")
                    playerName = LootGoblin.Default.CharacterName;
                Task.Run(async () =>
                    await ClipboardManager.CopyToClipboard(
                        $"Congratulations! {playerName} bid {splitBidInfo[0]} dkp for item: {ItemToLinkFromName(e.Node.Parent.Text.Trim())}"));
                Task.Run(async () => await UpdateCharacterList(playerName));
                var currentDkp = _dkpSummary.Models.FirstOrDefault(x => x.CharacterName == playerName)!.CurrentDKP;
                Task.Run(async () => await UpdateCharacterDkp(currentDkp));

            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(trv_DkpBids_NodeMouseClick)}] {ex.InnerException}");
            }
        }

        public Task UpdateCharacterDkp(double currentDkp)
        {
            Log.Debug($"[{nameof(UpdateCharacterDkp)}] Dkp: {currentDkp}");
            try
            {
                if (lbl_CurrentDkp.InvokeRequired)
                {
                    lbl_CurrentDkp.BeginInvoke(delegate { UpdateCharacterDkp(currentDkp); });
                    return Task.CompletedTask;
                }

                lbl_CurrentDkp.Text = currentDkp.ToString();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Error($"{UpdateCharacterDkp} CurrentDkp: {currentDkp} {ex.InnerException}");
                return Task.CompletedTask;
            }
        }

        private void btn_SubmitManualTick_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_SubmitManualTick_Click)}]");
            Task.Run(async () =>
            {
                var raidManagement = new RaidManagement();
                var raidAttendance = await raidManagement.GetRaidAttendance();
                if (!raidAttendance.Any())
                {
                    Log.Warning($"[{nameof(btn_SubmitManualTick_Click)}] Unable to get raid attendance! Please type /output RaidList in game and try again.");
                    return;
                }

                if (_characters.Any())
                {
                    var characters = _characters.Where(x => raidAttendance.Select(x => x.Player).Contains(x.Name))
                        .ToList();

                    var autoTick = new Tick
                    {
                        Characters = characters.Select(x => x.Name).ToList(),
                        Description = $"{txtbx_TickDescription.Text}",
                        Value = txtbx_TickDkpValue.Text
                    };
                    _autoTickCount++;
                    CurrentRaid?.Ticks.Add(autoTick);
                    _raidTicks.Add(autoTick);
                }
                else
                {
                    MessageBox.Show(@"Unable to locate Raid Tick.  Please type /output RaidList in game.");
                }

                txtbx_TickDescription.Text = "";
                txtbx_TickDkpValue.Text = "";
                UpdateRaidInformation();
            });
        }

        private int _autoTickCount = 1;

        private void btn_AddAutoTick_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_AddAutoTick_Click)}]");
            Task.Run(async () =>
            {
                var raidManagement = new RaidManagement();
                var raidAttendance = await raidManagement.GetRaidAttendance();
                if (!raidAttendance.Any())
                {
                    Log.Warning($"[{nameof(btn_AddAutoTick_Click)}] Unable to raid attendance!");
                    return;
                }

                var characters = raidAttendance.Select(x => x.Player).ToList();

                var autoTick = new Tick
                {
                    Characters = characters,
                    Description = $"{txtbx_RaidName.Text} - AutoTick: {_autoTickCount}",
                    Value = txtbx_AutoTickDkp.Text
                };
                _autoTickCount++;
                CurrentRaid.Ticks.Add(autoTick);
                _raidTicks.Add(autoTick);
                UpdateRaidInformation();
            });
        }

        private bool _timerStarted = false;

        private void btn_StartAutoTickTimer_Click(object sender, EventArgs e)
        {
            try
            {
                Log.Debug($"[{nameof(btn_StartAutoTickTimer_Click)}]");
                //Cancel the Reminder if it is running
                if (AutoTickReminder.IsBusy)
                {
                    AutoTickReminder.CancelAsync();
                }

                if (!_timerStarted)
                {
                    UpdateTextBoxBackgroundColor(txtbx_AutoTickCountdownMinutes, Color.White);
                    UpdateTextBoxBackgroundColor(txtbx_AutoTickCountdownSeconds, Color.White);
                    txtbx_AutoTickCountdownMinutes.Text = (int.Parse(txtbx_AutoTickTimer.Text) - 1).ToString();
                    txtbx_AutoTickCountdownSeconds.Text = "60";
                    RaidTickTimer.Interval = 1000;
                    _timerStarted = true;
                    RaidTickTimer.Start();
                    btn_StartAutoTickTimer.Text = "Stop Timer";
                }
                else
                {
                    _timerStarted = false;
                    RaidTickTimer.Stop();
                    btn_StartAutoTickTimer.Text = "Start Timer";
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(btn_StartAutoTickTimer_Click)}] {ex.InnerException}");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtbx_AutoTickCountdownMinutes.Text) != 0 ||
                    int.Parse(txtbx_AutoTickCountdownSeconds.Text) != 0)
                {
                    if (int.Parse(txtbx_AutoTickCountdownSeconds.Text) == 0)
                    {
                        txtbx_AutoTickCountdownMinutes.Text =
                            (int.Parse(txtbx_AutoTickCountdownMinutes.Text) - 1).ToString();
                        txtbx_AutoTickCountdownSeconds.Text = "60";
                    }

                    txtbx_AutoTickCountdownSeconds.Text =
                        (int.Parse(txtbx_AutoTickCountdownSeconds.Text) - 1).ToString();
                }
                else
                {
                    BringToFront();
                    RaidTickTimer.Stop();
                    Task.Run(() =>
                    {
                        AutoTickReminder.RunWorkerAsync();
                        return Task.CompletedTask;
                    });
                    new ToastContentBuilder()
                        .AddText("Auto Tick Completed.")
                        .AddText("Please type /output RaidList in game!")
                        .Show();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[{nameof(timer1_Tick)}] {ex.InnerException}");
            }
        }

        private void AutoTickReminder_DoWork(object sender, DoWorkEventArgs e)
        {
            int increaseTimer = 0;
            while (!AutoTickReminder.CancellationPending)
            {
                Thread.Sleep(5000 + increaseTimer);
                using var soundPlayer = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()

                for (int i = 0; i < 10; i++)
                {
                    UpdateTextBoxBackgroundColor(txtbx_AutoTickCountdownMinutes, Color.Red);
                    UpdateTextBoxBackgroundColor(txtbx_AutoTickCountdownSeconds, Color.Red);
                    Thread.Sleep(500);
                    UpdateTextBoxBackgroundColor(txtbx_AutoTickCountdownMinutes, Color.White);
                    UpdateTextBoxBackgroundColor(txtbx_AutoTickCountdownSeconds, Color.White);
                    Thread.Sleep(500);
                }

                increaseTimer += 5000;
            }
        }

        private void btn_SubmitRaid_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_SubmitRaid_Click)}]");
            CurrentRaid.Name = txtbx_RaidName.Text;
            CurrentRaid.Timestamp = DateTime.Now.ToString("MM-dd-yyyyTHH:mm:ss.fffZ");
            CurrentRaid.Pool = new Pool
            {
                Id = 19,
                Description = "Kunark",
                Name = "Kunark",
                Order = 0
            };
            CurrentRaid.Attendance = 1;

            SaveCurrentRaid();

            var result = MessageBox.Show("Are you sure you want to submit this raid to OpenDkp?",
                "Confirmation", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    Task.Run(async () => await _openDkp.SubmitRaid(CurrentRaid));
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void dgv_LootWinners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Log.Debug($"[{nameof(dgv_LootWinners_CellClick)}]");
            if (e.RowIndex < 0)
            {
                return;
            }

            var selectedRow = dgv_LootWinners.Rows[e.RowIndex];

            txtbx_DkpBidderName.Text = selectedRow.Cells[0].Value.ToString();
            txtbx_DkpBidderValue.Text = selectedRow.Cells[1].Value.ToString();
            txtbx_DkpBidderItem.Text = selectedRow.Cells[2].Value.ToString();
        }

        private void btn_ClearDkpWinner_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_ClearDkpWinner_Click)}]");
            txtbx_DkpBidderName.Text = string.Empty;
            txtbx_DkpBidderValue.Text = string.Empty;
            txtbx_DkpBidderItem.Text = string.Empty;
        }

        private void btn_RemoveDkpWinner_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_RemoveDkpWinner_Click)}]");
            var dkpWinner = _dkpWinners.FirstOrDefault(x =>
                x.Player == txtbx_DkpBidderName.Text &&
                x.Bid == Convert.ToInt32(txtbx_DkpBidderValue.Text) &&
                x.Item == txtbx_DkpBidderItem.Text);
            if (dkpWinner != null)
                _dkpWinners.Remove(dkpWinner);

            var itemWinner = CurrentRaid?.Items.FirstOrDefault(x =>
                x.CharacterName == txtbx_DkpBidderName.Text &&
                x.Dkp == Convert.ToInt32(txtbx_DkpBidderValue.Text) &&
                x.ItemName == txtbx_DkpBidderItem.Text);
            if (itemWinner != null)
                CurrentRaid?.Items.Remove(itemWinner);
            UpdateRaidInformation();
        }

        private void btn_AddDkpWinner_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_AddDkpWinner_Click)}]");
            var dkpWinner = new DkpWinner(txtbx_DkpBidderName.Text, Convert.ToInt32(txtbx_DkpBidderValue.Text),
                txtbx_DkpBidderItem.Text);
            _dkpWinners.Add(dkpWinner);

            CurrentRaid?.Items.Add(new Item
            {
                CharacterName = dkpWinner.Player,
                Dkp = dkpWinner.Bid,
                GameItemId = GetItemIdFromName(dkpWinner.Item),
                ItemId = GetItemIdFromName(dkpWinner.Item),
                ItemName = dkpWinner.Item,
                Notes = txtbx_RaidName.Text
            });
            UpdateRaidInformation();
        }

        private bool _isMonitoringLog = false;

        private void btn_LogMonitor_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_LogMonitor_Click)}]");
            if (string.IsNullOrEmpty(LootGoblin.Default.LogLocation))
            {
                MessageBox.Show(@"Please set the raid name.");
                Log.Warning($"[{nameof(btn_LogMonitor_Click)}] No raid name set.");
                return;
            }
            if (string.IsNullOrEmpty(LootGoblin.Default.LogLocation))
            {
                MessageBox.Show(@"Please set the log location");
                Log.Warning($"[{nameof(btn_LogMonitor_Click)}] No log location set.");
                return;
            }
            _logMonitor ??= new LogMonitor(LootGoblin.Default.LogLocation);
            if (!_isMonitoringLog)
            {
                _logMonitor.MessageReceived += MessageMonitor;
                _isMonitoringLog = true;
                btn_LogMonitor.Text = "Stop Monitoring Log";
                if (!_logMonitor.IsMonitoring)
                    _logMonitor.BeginMonitoring();
            }
            else
            {
                _logMonitor.MessageReceived -= MessageMonitor;
                btn_LogMonitor.Text = "Start Monitoring Log";
                if (_logMonitor.IsMonitoring)
                    _logMonitor.StopMonitoring();
                _isMonitoringLog = false;
            }
        }

        private void btn_RefreshCurrentRaid_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_RefreshCurrentRaid_Click)}]");
            UpdateRaidInformation();
        }

        private void btn_RemoveRaidTick_Click(object sender, EventArgs e)
        {
            Log.Debug($"[{nameof(btn_RemoveRaidTick_Click)}]");
            var raidTick = _raidTicks.FirstOrDefault(x => x.Description == dgv_RaidTicks.SelectedRows[0].Cells[0].Value.ToString());
            if (raidTick != null)
                _raidTicks.Remove(raidTick);

            raidTick = CurrentRaid?.Ticks.FirstOrDefault(x => x.Description == dgv_RaidTicks.SelectedRows[0].Cells[0].Value.ToString());
            if (raidTick != null)
                CurrentRaid?.Ticks.Remove(raidTick);
            UpdateRaidInformation();
        }

        #endregion Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Debug($"[{nameof(MainForm_FormClosing)}]");
            SaveCurrentRaid();
        }
    }
}