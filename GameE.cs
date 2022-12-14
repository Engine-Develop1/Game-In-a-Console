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
namespace GameEMain
{
    public class GameE
    {
        public string TownMap { get; } =
          @"    Shop             Craft                          " + "\n" +
           " ___________      ___________                       " + "\n" +
          @"/###########\    /###########\                      " + "\n" +
           "|###########|    |###########|                      " + "\n" +
           "|#####()####|    |#####()####|                      " + "\n" +
           "____________________________________________________" + "\n" +
           "____________________________________________________" + "\n" +
           "____________________________________________________" + "\n";
        public string WorldMap { get; } =
          @"Strombard   IronMake  Firestromb " + "\n" +
           "######    ####          ##       " + "\n" +
           "#####    ####          ###       " + "\n" +
           "####     ////       ////         " + "\n" +
          @"\\\\    ////       ////          " + "\n" +
          @" \\\\|||||||||||\////            " + "\n" +
          @"  \\||||||||||\\\\               " + "\n" +
          @" the wild   \\\\_____            " + "\n";
        public int Password { get; } = 3479;
        public Converter converter;
        public Player Player = new Player();
        public Dun Dun;
        public CraftItems craft;
        public Gear gear;
        public Shop Shop { get; set; }
        public NPCNames NPCNames { get; set; }
        public OtherSystem OtherSystem { get; set; }
        public save save { get; set; }
        public void Start()
        {
            #region Get Stuff
            //converter
            converter = new Converter();
            //gear
            gear = new Gear{
                Player = Player
            };
            //player
            Player.gear = gear;
            Player.SetPLayerD();
            //npc
            NPCNames = new NPCNames{
                player = Player
            };
            //craft
            craft = new CraftItems{
                C_Player = Player
            };
            //shop
            Shop = new Shop {
                S_player = Player,
                S_NPC = NPCNames,
                converter = converter
            };
            //dun
            Dun = new Dun{
                player = Player,
                nPCNames = NPCNames
            };
            //mine
            OtherSystem = new OtherSystem {
                player = Player,
                NPCNames = NPCNames
            };
            //save
            save = new save
            {
                NPC = NPCNames,
                PlayerSave = Player
            };
            save.start();
            #endregion
        }
    }
}
