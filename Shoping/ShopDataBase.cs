using game_in_console.crafting;
using game_in_console.Shoping;
using game_in_console.NPC.Name;
using game_in_console.dun;
using game_in_console.dun.enemys;
using game_in_console.data.items;
using game_in_console;
using game_in_console.otherSystem;
using game_in_console.enums;
using game_in_console.player;
using System;
using game_in_console.Shoping.Class;

namespace game_in_console.Shoping
{
    public class ShopDataBase
    {
        private const int itemslistL = 3;
        public bool GetInFrist = true;
        public bool _exit = false;
        public int item1 = 0;
        public int item2 = 0;
        public int item3 = 0;
        public NPCNames S_NPC;
        public Player S_player;
        public Converter converter;

        /// <summary>
        /// a taple for all the items you can get!
        /// </summary>
        public ShopItemsList[] itemsList = new ShopItemsList[itemslistL];
        public int ItemsListIndex;
        public Items[] ItemTaple { get; } = { Items.none, Items.stick, Items.stone, Items.ironore, Items.flint, Items.coal, Items.IronSword };
        public int[] Con { get; } = { 0, 2, 3, 2, 2, 2, 1 };
        public int[] Cost { get; } = { 0, 10, 15, 20, 10, 15, 100 };
        public int[] Chance { get; } = { 0, 25, 20, 15, 25, 20, 10 };
        /// <summary>
        /// gets the item in numbers
        /// </summary>
        /// <param name="RNG"></param>
        public void SetNumbers(Random RNG)
        {
            for (int i = 0; i < 3; i++)
            {
                int perCent = RNG.Next(0, 25);
                if (perCent < 10)
                {
                    if (item3 == 0 && item2 != 0 && item1 != 0)
                        item3 = 6;
                    if (item2 == 0 && item1 != 0)
                        item2 = 6;
                    if (item1 == 0)
                        item1 = 6;
                }
                else if (perCent < 10 + 5)
                {
                    if (item3 == 0 && item2 != 0 && item1 != 0)
                        item3 = 3;
                    if (item2 == 0 && item1 != 0)
                        item2 = 3;
                    if (item1 == 0)
                        item1 = 3;
                }
                else if (perCent < 10 + 10)
                {
                    int ff = RNG.Next(0, 100);
                    if (ff < 50)
                    {
                        if (item3 == 0 && item2 != 0 && item1 != 0)
                            item3 = 5;
                        if (item2 == 0 && item1 != 0)
                            item2 = 5;
                        if (item1 == 0)
                            item1 = 5;
                    }
                    else if (ff < 50 + 50)
                    {
                        if (item3 == 0 && item2 != 0 && item1 != 0)
                            item3 = 2;
                        if (item2 == 0 && item1 != 0)
                            item2 = 2;
                        if (item1 == 0)
                            item1 = 2;
                    }
                }
                else if (perCent < 10 + 10 + 5)
                {
                    int ff = RNG.Next(0, 100);
                    if (ff < 50)
                    {
                        if (item3 == 0 && item2 != 0 && item1 != 0)
                            item3 = 1;
                        if (item2 == 0 && item1 != 0)
                            item2 = 1;
                        if (item1 == 0)
                            item1 = 1;
                    }
                    else if (ff < 50 + 50)
                    {
                        if (item3 == 0 && item2 != 0 && item1 != 0)
                            item3 = 4;
                        if (item2 == 0 && item1 != 0)
                            item2 = 4;
                        if (item1 == 0)
                            item1 = 4;
                    }
                }
            }
            if (item1 == item2 || item2 == item3 || item3 == item1)
            {
                int perCent = RNG.Next(0, 25);
                if (perCent < 10)
                {
                    if (item1 == item2)
                        item2 = 6;
                    if (item2 == item3)
                        item3 = 6;
                    if (item3 == item1)
                        item1 = 6;
                }
                else if (perCent < 10 + 5)
                {
                    if (item1 == item2)
                        item2 = 3;
                    if (item2 == item3)
                        item3 = 3;
                    if (item3 == item1)
                        item1 = 3;
                }
                else if (perCent < 10 + 10)
                {
                    int ff = RNG.Next(0, 100);
                    if (ff < 50)
                    {
                        if (item1 == item2)
                            item2 = 5;
                        if (item2 == item3)
                            item3 = 5;
                        if (item3 == item1)
                            item1 = 5;
                    }
                    else if (ff < 50 + 50)
                    {
                        if (item1 == item2)
                            item2 = 2;
                        if (item2 == item3)
                            item3 = 2;
                        if (item3 == item1)
                            item1 = 2;
                    }
                }
                else if (perCent < 10 + 10 + 5)
                {
                    int ff = RNG.Next(0, 100);
                    if (ff < 50)
                    {
                        if (item1 == item2)
                            item2 = 1;
                        if (item2 == item3)
                            item3 = 1;
                        if (item3 == item1)
                            item1 = 1;
                    }
                    else if (ff < 50 + 50)
                    {
                        if (item1 == item2)
                            item2 = 4;
                        if (item2 == item3)
                            item3 = 4;
                        if (item3 == item1)
                            item1 = 4;
                    }
                }
            }
        }
        /// <summary>
        /// sets all items to there item index in the array
        /// </summary>
        /// <param name="Index"></param>
        public void SetAllItems(int Index)
        {
            itemsList[ItemsListIndex].name = ItemTaple[Index];
            itemsList[ItemsListIndex].S_Con = Con[Index];
            itemsList[ItemsListIndex].S_cost = Cost[Index];
        }

        public void SetupShop(Random RNG)
        {
            if(GetInFrist == true)
            {
                Console.WriteLine(S_NPC.ShopKeeperName + ": " + S_NPC.Dia_ShopKeeperIn[RNG.Next(0, S_NPC.Dia_ShopKeeperIn.Length)]);
                SetNumbers(RNG);
                SetAllItems(item1);
                ItemsListIndex++;
                SetAllItems(item2);
                ItemsListIndex++;
                SetAllItems(item3);
            }
        }
        public void BuyItem(int Index, bool buy)
        {
            int NeedCoins = S_player.Coins - Cost[Index];
            switch (buy)
            {
                case true:
                    Console.WriteLine(S_NPC.ShopKeeperName + ": " + "thank you for purchaseing " + Con[Index] + " " + ItemTaple[Index] + " for " + Cost[Index]);
                    break;
                case false:
                    Console.WriteLine(S_NPC.ShopKeeperName + ": " + "Sorry but you do not have enough coins you need " + Cost[Index] + " coins and you have " + S_player.Coins + " coins you need " + NeedCoins + " coins");
                    break;
            }
        }
        public void DeleteingItems(int Index)
        {
            ItemTaple[Index] = Items.none;
            Con[Index] = 0;
            Cost[Index] = 0;
        }
        public void Bye(Random RNG)
        {
            Console.WriteLine(S_NPC.ShopKeeperName + ": " + S_NPC.Dia_ShopKeeperOut[RNG.Next(0, S_NPC.Dia_ShopKeeperOut.Length)]);
        }
    }
}
