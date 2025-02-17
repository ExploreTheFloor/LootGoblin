using LootGoblin.Structure;

namespace LootGoblin.Services
{
    public class RaidManagement
    {
        public async Task AddRaidTick()
        {

        }

        public Task BackUpRaidTickFiles()
        {
            var eqDir = Path.GetDirectoryName(LootGoblin.Default.LogLocation);
            var allFiles = Directory.GetFiles(eqDir, "*.txt").ToList();
            var raidTickFiles = allFiles.Where(x => x.Contains("RaidTick"));
            foreach (var raidTickFile in raidTickFiles)
            {
                File.Copy(raidTickFile, $@"{eqDir}\BackUp\{DateTime.Now.ToShortDateString().Replace("/", "-")}\{Path.GetFileName(raidTickFile)}");
            }

            return Task.CompletedTask;
        }

        public Task ClearRaidTickFiles()
        {
            var eqDir = Path.GetDirectoryName(LootGoblin.Default.LogLocation);
            var allFiles = Directory.GetFiles(eqDir, "*.txt").ToList();
            var raidTickFiles = allFiles.Where(x => x.Contains("RaidTick"));
            foreach (var raidTickFile in raidTickFiles)
            {
                File.Delete(raidTickFile);
            }

            return Task.CompletedTask;
        }

        public async Task<List<RaidMember>> GetRaidAttendance()
        {
            List<RaidMember> raidMembers = new List<RaidMember>();
            var eqDir = Path.GetDirectoryName(LootGoblin.Default.LogLocation);
            var allFiles = Directory.GetFiles(eqDir, "*.txt").ToList();
            var raidTickFile = allFiles.FirstOrDefault(x => x.Contains("RaidTick"));
            if (raidTickFile != null)
            {
                string[] lines = await File.ReadAllLinesAsync(raidTickFile);
                raidMembers.AddRange(lines.Select(line => line.Split("\t"))
                    .Select(splitString => new RaidMember
                    {
                        Player = splitString[0],
                        Level = splitString[1],
                        Class = splitString[2],
                        Timestamp = splitString[3],
                        Points = splitString[4]
                    }));
                await BackUpRaidTickFiles();
            }

            return raidMembers.Where(x => x.Level != "Level").ToList();
        }
    }
}
