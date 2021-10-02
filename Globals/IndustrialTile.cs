using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using IndustrialPickaxes.Helpers;

namespace IndustrialPickaxes.Items
{
    class IndustrialTile : GlobalTile
    {
        private int lastTile = -1;
        private int currChance = 0;

        public void SmeltOres(int i, int j, int type)
        {
            if (type != lastTile)
                currChance = 0;
            for (int k = 0; k < OreList.oreType.Count; k++)
            {
                if (type == OreList.oreType[k])
                {
                    if (Main.rand.Next(OreList.smeltChance[k]) - currChance <= 0)
                    {
                        Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                        Item.NewItem(i * 16, j * 16, 16, 16, OreList.barType[k]);
                        currChance = 0;
                    }
                    else
                        currChance++;
                    break;
                }
            }
        }

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            bool dummy = true;
            if (Main.gameMenu || fail || !CanKillTile(i, j, type, ref dummy))
                return;
            if (Main.netMode == NetmodeID.Server)
            {
                for (int t = 0; t < OreList.oreType.Count; t++)
                {
                    if (type == OreList.oreType[t])
                    {
                        noItem = true;
                        lastTile = type;
                    }
                }
                return;
            }
            Player myPlayer = Main.player[Main.myPlayer];
            if (Main.LocalPlayer == myPlayer && !myPlayer.CCed && !myPlayer.noBuilding && !myPlayer.noItems && !myPlayer.HasBuff(BuffID.DrillMount))
            {
                if (myPlayer.HeldItem.modItem is IndustrialPickaxe || myPlayer.HeldItem.prefix == ModContent.PrefixType<Prefixes.IndustrialPrefix>())
                {
                    for (int t = 0; t < OreList.oreType.Count; t++)
                    {
                        if (type == OreList.oreType[t])
                        {
                            noItem = true;
                            HandleOres(i, j, type);
                            lastTile = type;
                            break;
                        }
                    }
                }

                #region Ore Rejuvenator
                if (myPlayer.HeldItem.type == mod.ItemType("OreRejuvenator"))
                {
                    int DroppedGem = Main.rand.Next(6);
                    if (type == TileID.Diamond)
                    {
                        if (Main.rand.Next(8) == 0)
                        {
                            if (DroppedGem == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Ruby);
                            }
                            else if (DroppedGem == 1)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Emerald);
                            }
                            else if (DroppedGem == 2)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Sapphire);
                            }
                            else if (DroppedGem == 3)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amethyst);
                            }
                            else if (DroppedGem == 4)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Topaz);
                            }
                            else if (DroppedGem == 5)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amber);
                            }
                        }
                        Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Diamond, 2);
                    }
                    if (type == TileID.Ruby)
                    {
                        if (Main.rand.Next(8) == 0)
                        {
                            if (DroppedGem == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Diamond);
                            }
                            else if (DroppedGem == 1)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Emerald);
                            }
                            else if (DroppedGem == 2)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Sapphire);
                            }
                            else if (DroppedGem == 3)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amethyst);
                            }
                            else if (DroppedGem == 4)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Topaz);
                            }
                            else if (DroppedGem == 5)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amber);
                            }
                        }
                        Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Ruby, 2);
                    }
                    if (type == TileID.Emerald)
                    {
                        if (Main.rand.Next(8) == 0)
                        {
                            if (DroppedGem == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Diamond);
                            }
                            else if (DroppedGem == 1)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Ruby);
                            }
                            else if (DroppedGem == 2)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Sapphire);
                            }
                            else if (DroppedGem == 3)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amethyst);
                            }
                            else if (DroppedGem == 4)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Topaz);
                            }
                            else if (DroppedGem == 5)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amber);
                            }
                        }
                        Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Emerald, 2);
                    }
                    if (type == TileID.Sapphire)
                    {
                        if (Main.rand.Next(8) == 0)
                        {
                            if (DroppedGem == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Diamond);
                            }
                            else if (DroppedGem == 1)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Ruby);
                            }
                            else if (DroppedGem == 2)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Emerald);
                            }
                            else if (DroppedGem == 3)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amethyst);
                            }
                            else if (DroppedGem == 4)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Topaz);
                            }
                            else if (DroppedGem == 5)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amber);
                            }
                        }
                        Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Sapphire, 2);
                    }
                    if (type == TileID.Amethyst)
                    {
                        if (Main.rand.Next(8) == 0)
                        {
                            if (DroppedGem == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Diamond);
                            }
                            else if (DroppedGem == 1)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Ruby);
                            }
                            else if (DroppedGem == 2)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Emerald);
                            }
                            else if (DroppedGem == 3)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Sapphire);
                            }
                            else if (DroppedGem == 4)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Topaz);
                            }
                            else if (DroppedGem == 5)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amber);
                            }
                        }
                        Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amethyst, 2);
                    }
                    if (type == TileID.Topaz)
                    {
                        if (Main.rand.Next(8) == 0)
                        {
                            if (DroppedGem == 0)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Diamond);
                            }
                            else if (DroppedGem == 1)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Ruby);
                            }
                            else if (DroppedGem == 2)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Emerald);
                            }
                            else if (DroppedGem == 3)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Sapphire);
                            }
                            else if (DroppedGem == 4)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amethyst);
                            }
                            else if (DroppedGem == 5)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Amber);
                            }
                        }
                        Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Topaz, 2);
                    }
                }
                #endregion
            }
        }

        public void HandleOres(int i, int j, int type)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket packet = ModContent.GetInstance<IndustrialPickaxes>().GetPacket();
                packet.Write((ushort)i);
                packet.Write((ushort)j);
                packet.Write((ushort)type);
                packet.Send();
            }
            else if (Main.netMode == NetmodeID.SinglePlayer)
            {
                SmeltOres(i, j, type);
            }
        }
    }
}
