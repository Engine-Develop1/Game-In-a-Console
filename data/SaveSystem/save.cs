using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using settings;
using game_in_console.crafting;
using game_in_console.Shoping;
using game_in_console.NPC.Name;
using game_in_console.dun;
using game_in_console.dun.enemys;
using game_in_console.data.SaveSystem;
using game_in_console.data.items;
using game_in_console;
using game_in_console.otherSystem;
using game_in_console.enums;
using game_in_console.player;
using GameEMain;

namespace game_in_console.data.SaveSystem
{
    public enum savemodes
    {
        Saveall,
        Loadall,
        Qsave,
        Qload,
    }
    public class save
    {
        public Player PlayerSave;
        public NPCNames NPC;
        public string path;
        public bool Dev = Settings.Dev;
        public int DunLevel = Settings.DunLevel;
        public bool IsMetric = Settings.IsMetric;
        public bool HasBukkit = Settings.HasBukkit;
        public string playername;
        public save()
        {
        }
        public void start()
        {
            string text = "PlayerName:" + playername + "\r\n";
            playername = Settings.PlayerName;
            path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Engine_Develop\Game_in_console\private\saves\";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            directoryInfo.Create();
            if(File.Exists(path + playername + ".GNCsave") == false)
            {
            File.Create(path + playername + ".GNCsave");
                File.WriteAllText(path, "");
            }
        }
        public void Save(savemodes savemodes)
        {
            //

        }
        public void load(savemodes savemodes)
        {
            switch (savemodes)
            {
                case savemodes.Loadall:
                    break;
                case savemodes.Qload:
                    break;
            }
        }
    }
}
