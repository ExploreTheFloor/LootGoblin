using LootGoblin.Structure;

namespace LootGoblin.Services
{
    public class Tools
    {
        public class UserItems
        {
            public UserItems(string user, List<CharacterItem> items)
            {
                User = user;
                Items = items;
            }

            public string User { get; set; }
            public List<CharacterItem> Items { get; set; }
        }
        public class UserItem
        {
            public UserItem(string user, CharacterItem item)
            {
                User = user;
                Item = item;
            }

            public string User { get; set; }
            public CharacterItem Item { get; set; }
        }

        public async Task<List<UserItem>> FindDuplicateLoots()
        {
            var dkpBidders = await GetAllUserLoot();
            var userItems = new List<UserItems>();
            var foundDupe = new List<UserItem>();
            foreach (var dkpBidder in dkpBidders.Where(x=> x.Character.Active == 1))
            {
                if (string.IsNullOrEmpty(dkpBidder.Character.User))
                    continue;
                var foundUser = userItems.FirstOrDefault(x => x.User == dkpBidder.Character.User);
                if (foundUser != null)
                {
                    foreach (var dkpBidderCharacterItem in dkpBidder.CharacterItems)
                    {
                        var foundUserItem =
                            foundUser.Items.FirstOrDefault(x => x.ItemName == dkpBidderCharacterItem.ItemName);
                        if (foundUserItem != null)
                        {
                            foundDupe.Add(new UserItem(foundUser.User, foundUserItem));
                            foundDupe.Add(new UserItem(foundUser.User, dkpBidderCharacterItem));
                        }
                    }
                    foundUser.Items.AddRange(dkpBidder.CharacterItems);
                    continue;
                }

                userItems.Add(new UserItems(dkpBidder.Character.User, dkpBidder.CharacterItems));
            }

            return foundDupe;
        }

        public async Task<List<DkpBidder>> GetAllUserLoot()
        {
            var openDkp = new OpenDkp.OpenDkp();
            var characters = await openDkp.GetCharacters();
            List<Task> taskList = new List<Task>();
            List<DkpBidder> charactersAndItems = new List<DkpBidder>();

            foreach (var character in characters)
            {
                taskList.Add(Task.Run(async () =>
                {
                    if (charactersAndItems.All(x => x.Character.CharacterId != character.CharacterId))
                    {
                        var characterItems = await openDkp.GetCharacterItems(character.CharacterId);
                        charactersAndItems.Add(new DkpBidder(character, character.CharacterId, characterItems));
                    }
                }));
                await Task.WhenAll(taskList);
            }

            return charactersAndItems;
        }
    }
}