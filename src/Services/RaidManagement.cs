using LootGoblin.Structure;
using Serilog;

namespace LootGoblin.Services
{
    public class RaidManagement
    {
        public Task BackUpRaidTickFiles()
        {
            try
            {
                Log.Debug($"[{nameof(BackUpRaidTickFiles)}]");
                var eqDir = Path.GetDirectoryName(LootGoblin.Default.LogLocation);
                if (eqDir == null)
                {
                    Log.Warning($"[{nameof(BackUpRaidTickFiles)}] Unable to locate Raid Tick file: {eqDir}.");
                    return Task.CompletedTask;
                }
                var allFiles = Directory.GetFiles(eqDir, "*.txt").ToList();
                var raidTickFiles = allFiles.Where(x => x.ToLower().Contains("raidtick"));
                foreach (var raidTickFile in raidTickFiles)
                {
                    Log.Debug($@"Copying: {raidTickFile} to {AppDomain.CurrentDomain.BaseDirectory}BackUp\{DateTime.Now.ToShortDateString().Replace("/", "-")}\{Path.GetFileName(raidTickFile)}");
                    File.Move(raidTickFile, $@"{AppDomain.CurrentDomain.BaseDirectory}BackUp\{DateTime.Now.ToShortDateString().Replace("/", "-")}\{Path.GetFileName(raidTickFile)}", true);
                }

            }
            catch (Exception e)
            {
                Log.Error($"[{nameof(BackUpRaidTickFiles)}] {e.InnerException}");
            }
            return Task.CompletedTask;
        }

        public async Task<List<RaidMember>> GetRaidAttendance()
        {
            Log.Debug($"[{nameof(GetRaidAttendance)}]");
            List<RaidMember> raidMembers = new List<RaidMember>();
            var eqDir = Path.GetDirectoryName(LootGoblin.Default.LogLocation);
            var allFiles = Directory.GetFiles(eqDir, "*.txt").ToList();
            var raidTickFile = allFiles.FirstOrDefault(x => x.ToLower().Contains("raidtick"));
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
            else
            {
                Log.Warning($"[{nameof(GetRaidAttendance)}] Unable to locate Raid Tick file: {eqDir}.");
            }


            return raidMembers.Where(x => x.Level != "Level").ToList();
        }
    }
}
