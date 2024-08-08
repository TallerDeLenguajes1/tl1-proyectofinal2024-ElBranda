using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SaveStats {
    public class Player {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public List<string> UsedTanks { get; set; }
        public List<string> DestroyedTanks { get; set; }

        public Player() {
            Kills=0;
            Deaths=0;
            UsedTanks = new List<string>();
            DestroyedTanks = new List<string>();
        }
    }


    public class PlayerStats {
        public void Show() {

        }

        public void Save(Player player) {
            Player stats = Load();

            stats.Kills += player.Kills;
            stats.Deaths += player.Deaths;
            
            stats.UsedTanks.Add(player.UsedTanks[0]);

            foreach (var item in player.DestroyedTanks) {
                stats.DestroyedTanks.Add(item);
            }

            string jsonFile = JsonSerializer.Serialize(stats, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("PlayerStats.json", jsonFile);
        }

        public Player Load() {
            try {
                string jsonFile = File.ReadAllText("PlayerStats.json");
                if (string.IsNullOrWhiteSpace(jsonFile)) {
                    return new Player();
                }
                return JsonSerializer.Deserialize<Player>(jsonFile) ?? new Player();
            } catch (FileNotFoundException) {
                return new Player();
            }
        }
    }
}