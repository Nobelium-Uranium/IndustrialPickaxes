using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace IndustrialPickaxes.Items
{
    class IndustrialTile : GlobalTile
    {
        bool KillableTile;

        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            if (true)
            {
                KillableTile = true;
            }
            return base.CanKillTile(i, j, type, ref blockDamaged);
        }

        #region Smelt Vanilla Ores
        int ChanceCopperTin;
        int ChanceIronLead;
        int ChanceSilverTungsten;
        int ChanceGoldPlatinum;
        int ChanceMeteorite;
        int ChanceDemoniteCrimtane;
        int ChanceHellstone;
        int ChanceCobaltPalladium;
        int ChanceMythrilOrichalcum;
        int ChanceAdamantiteTitanium;
        int ChanceChlorophyte;
        int ChanceLuminite;

        public void SmeltCopperTin(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Copper)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceCopperTin <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CopperBar);
                    ChanceCopperTin = 0;
                }
                else
                {
                    ChanceCopperTin++;
                }

            }
            else if (type == TileID.Tin)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceCopperTin <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TinBar);
                    ChanceCopperTin = 0;
                }
                else
                {
                    ChanceCopperTin++;
                }

            }
        }
        public void SmeltIronLead(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Iron)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceIronLead <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.IronBar);
                    ChanceIronLead = 0;
                }
                else
                {
                    ChanceIronLead++;
                }

            }
            else if (type == TileID.Lead)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceIronLead <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.LeadBar);
                    ChanceIronLead = 0;
                }
                else
                {
                    ChanceIronLead++;
                }

            }
        }
        public void SmeltSilverTungsten(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Silver)
            {
                noItem = true;
                if (Main.rand.Next(5) - ChanceSilverTungsten <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SilverBar);
                    ChanceSilverTungsten = 0;
                }
                else
                {
                    ChanceSilverTungsten++;
                }

            }
            else if (type == TileID.Tungsten)
            {
                noItem = true;
                if (Main.rand.Next(5) - ChanceSilverTungsten <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TungstenBar);
                    ChanceSilverTungsten = 0;
                }
                else
                {
                    ChanceSilverTungsten++;
                }

            }
        }
        public void SmeltGoldPlatinum(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Gold)
            {
                noItem = true;
                if (Main.rand.Next(5) - ChanceGoldPlatinum <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.GoldBar);
                    ChanceGoldPlatinum = 0;
                }
                else
                {
                    ChanceGoldPlatinum++;
                }

            }
            else if (type == TileID.Platinum)
            {
                noItem = true;
                if (Main.rand.Next(5) - ChanceGoldPlatinum <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.PlatinumBar);
                    ChanceGoldPlatinum = 0;
                }
                else
                {
                    ChanceGoldPlatinum++;
                }

            }
        }
        public void SmeltMeteorite(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Meteorite)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceMeteorite <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MeteoriteBar);
                    ChanceMeteorite = 0;
                }
                else
                {
                    ChanceMeteorite++;
                }

            }
        }
        public void SmeltDemoniteCrimtane(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Demonite)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceDemoniteCrimtane <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.DemoniteBar);
                    ChanceDemoniteCrimtane = 0;
                }
                else
                {
                    ChanceDemoniteCrimtane++;
                }

            }
            else if (type == TileID.Crimtane)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceDemoniteCrimtane <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimtaneBar);
                    ChanceDemoniteCrimtane = 0;
                }
                else
                {
                    ChanceDemoniteCrimtane++;
                }

            }
        }
        public void SmeltHellstone(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Hellstone)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceHellstone <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.HellstoneBar);
                    ChanceHellstone = 0;
                }
                else
                {
                    ChanceHellstone++;
                }

            }
        }
        public void SmeltCobaltPalladium(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Cobalt)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceCobaltPalladium <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CobaltBar);
                    ChanceCobaltPalladium = 0;
                }
                else
                {
                    ChanceCobaltPalladium++;
                }

            }
            else if (type == TileID.Palladium)
            {
                noItem = true;
                if (Main.rand.Next(4) - ChanceCobaltPalladium <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.PalladiumBar);
                    ChanceCobaltPalladium = 0;
                }
                else
                {
                    ChanceCobaltPalladium++;
                }

            }
        }
        public void SmeltMythrilOrichalcum(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Mythril)
            {
                noItem = true;
                if (Main.rand.Next(5) - ChanceMythrilOrichalcum <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MythrilBar);
                    ChanceMythrilOrichalcum = 0;
                }
                else
                {
                    ChanceMythrilOrichalcum++;
                }

            }
            else if (type == TileID.Orichalcum)
            {
                noItem = true;
                if (Main.rand.Next(5) - ChanceMythrilOrichalcum <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.OrichalcumBar);
                    ChanceMythrilOrichalcum = 0;
                }
                else
                {
                    ChanceMythrilOrichalcum++;
                }

            }
        }
        public void SmeltAdamantiteTitanium(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Adamantite)
            {
                noItem = true;
                if (Main.rand.Next(6) - ChanceAdamantiteTitanium <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.AdamantiteBar);
                    ChanceAdamantiteTitanium = 0;
                }
                else
                {
                    ChanceAdamantiteTitanium++;
                }

            }
            else if (type == TileID.Titanium)
            {
                noItem = true;
                if (Main.rand.Next(6) - ChanceAdamantiteTitanium <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TitaniumBar);
                    ChanceAdamantiteTitanium = 0;
                }
                else
                {
                    ChanceAdamantiteTitanium++;
                }

            }
        }
        public void SmeltChlorophyte(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.Chlorophyte)
            {
                noItem = true;
                if (Main.rand.Next(7) - ChanceChlorophyte <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.ChlorophyteBar);
                    ChanceChlorophyte = 0;
                }
                else
                {
                    ChanceChlorophyte++;
                }

            }
        }
        public void SmeltLuminite(int i, int j, int type, ref bool noItem)
        {
            if (type == TileID.LunarOre)
            {
                noItem = true;
                if (Main.rand.Next(5) - ChanceLuminite <= 0)
                {
                    Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemID.LunarBar);
                    ChanceLuminite = 0;
                }
                else
                {
                    ChanceLuminite++;
                }

            }
        }
        #endregion

        #region Smelt Modded Ores

        #region EXAMPLE
        /*  public void Smelt(int i, int j, int type, ref bool noItem)
            {
                if (IndustrialPickaxes.Loaded)
                {
                    if (IndustrialPickaxes.mod.GetTile("Ore") != null && IndustrialPickaxes.mod.GetItem("Bar") != null)
                    {
                        if (type == IndustrialPickaxes.mod.TileType("Ore"))
                        {
                            noItem = true;
                            if (Main.rand.Next(5) - Chance <= 0)
                            {
                                Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                                Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.mod.ItemType("Bar"));
                                Chance = 0;
                            }
                            else
                            {
                                Chance++;
                            }
                            
                        }
                    }
                }
            }
            */
        #endregion

        #region Shadows of Abaddon
        int ChanceLapis;
        int ChanceBismuth;
        int ChanceOblivion;

        public void SmeltLapis(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.SoALoaded)
            {
                if (IndustrialPickaxes.SacredTools.GetTile("LapisOre") != null && IndustrialPickaxes.SacredTools.GetItem("RefinedLapis") != null)
                {
                    if (type == IndustrialPickaxes.SacredTools.TileType("LapisOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(3) - ChanceLapis <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.SacredTools.ItemType("RefinedLapis"));
                            ChanceLapis = 0;
                        }
                        else
                        {
                            ChanceLapis++;
                        }

                    }
                }
            }
        }
        public void SmeltBismuth(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.SoALoaded)
            {
                if (IndustrialPickaxes.SacredTools.GetTile("BismuthOre") != null && IndustrialPickaxes.SacredTools.GetItem("RefinedBismuth") != null)
                {
                    if (type == IndustrialPickaxes.SacredTools.TileType("BismuthOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(3) - ChanceBismuth <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.SacredTools.ItemType("RefinedBismuth"));
                            ChanceBismuth = 0;
                        }
                        else
                        {
                            ChanceBismuth++;
                        }

                    }
                }
            }
        }
        public void SmeltOblivion(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.SoALoaded)
            {
                if (IndustrialPickaxes.SacredTools.GetTile("OblivionOreBlock") != null && IndustrialPickaxes.SacredTools.GetItem("OblivionBar") != null)
                {
                    if (type == IndustrialPickaxes.SacredTools.TileType("OblivionOreBlock"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceOblivion <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.SacredTools.ItemType("OblivionBar"));
                            ChanceOblivion = 0;
                        }
                        else
                        {
                            ChanceOblivion++;
                        }

                    }
                }
            }
        }
        #endregion

        #region Calamity
        int ChanceAerialite;
        int ChanceCryonic;
        int ChanceCharred;
        int ChancePerennial;
        int ChanceAstral;
        int ChanceChaotic;
        int ChanceUelibloom;
        int ChanceAuric;

        public void SmeltAerialite(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.CalamityLoaded)
            {
                if (IndustrialPickaxes.Calamity.GetTile("AerialiteOre") != null && IndustrialPickaxes.Calamity.GetItem("AerialiteBar") != null)
                {
                    if (type == IndustrialPickaxes.Calamity.TileType("AerialiteOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceAerialite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Calamity.ItemType("AerialiteBar"));
                            ChanceAerialite = 0;
                        }
                        else
                        {
                            ChanceAerialite++;
                        }

                    }
                }
            }
        }
        public void SmeltCryonic(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.CalamityLoaded)
            {
                if (IndustrialPickaxes.Calamity.GetTile("CryonicOre") != null && IndustrialPickaxes.Calamity.GetItem("VerstaltiteBar") != null)
                {
                    if (type == IndustrialPickaxes.Calamity.TileType("CryonicOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceCryonic <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Calamity.ItemType("VerstaltiteBar"));
                            ChanceCryonic = 0;
                        }
                        else
                        {
                            ChanceCryonic++;
                        }

                    }
                }
            }
        }
        public void SmeltCharred(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.CalamityLoaded)
            {
                if (IndustrialPickaxes.Calamity.GetTile("CharredOre") != null && IndustrialPickaxes.Calamity.GetItem("UnholyCore") != null)
                {
                    if (type == IndustrialPickaxes.Calamity.TileType("CharredOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceCharred <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Calamity.ItemType("UnholyCore"));
                            ChanceCharred = 0;
                        }
                        else
                        {
                            ChanceCharred++;
                        }

                    }
                }
            }
        }
        public void SmeltPerennial(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.CalamityLoaded)
            {
                if (IndustrialPickaxes.Calamity.GetTile("PerennialOre") != null && IndustrialPickaxes.Calamity.GetItem("DraedonBar") != null)
                {
                    if (type == IndustrialPickaxes.Calamity.TileType("PerennialOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChancePerennial <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Calamity.ItemType("DraedonBar"));
                            ChancePerennial = 0;
                        }
                        else
                        {
                            ChancePerennial++;
                        }

                    }
                }
            }
        }
        public void SmeltAstral(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.CalamityLoaded)
            {
                if (IndustrialPickaxes.Calamity.GetTile("AstralOre") != null && IndustrialPickaxes.Calamity.GetItem("AstralBar") != null)
                {
                    if (type == IndustrialPickaxes.Calamity.TileType("AstralOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(3) - ChanceAstral <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Calamity.ItemType("AstralBar"));
                            ChanceAstral = 0;
                        }
                        else
                        {
                            ChanceAstral++;
                        }

                    }
                }
            }
        }
        public void SmeltChaotic(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.CalamityLoaded)
            {
                if (IndustrialPickaxes.Calamity.GetTile("ChaoticOre") != null && IndustrialPickaxes.Calamity.GetItem("CruptixBar") != null)
                {
                    if (type == IndustrialPickaxes.Calamity.TileType("ChaoticOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceChaotic <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Calamity.ItemType("CruptixBar"));
                            ChanceChaotic = 0;
                        }
                        else
                        {
                            ChanceChaotic++;
                        }

                    }
                }
            }
        }
        public void SmeltUelibloom(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.CalamityLoaded)
            {
                if (IndustrialPickaxes.Calamity.GetTile("UelibloomOre") != null && IndustrialPickaxes.Calamity.GetItem("UeliaceBar") != null)
                {
                    if (type == IndustrialPickaxes.Calamity.TileType("UelibloomOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceUelibloom <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Calamity.ItemType("UeliaceBar"));
                            ChanceUelibloom = 0;
                        }
                        else
                        {
                            ChanceUelibloom++;
                        }

                    }
                }
            }
        }

        public void SmeltAuric(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.CalamityLoaded)
            {
                if (IndustrialPickaxes.Calamity.GetTile("AuricOre") != null && IndustrialPickaxes.Calamity.GetItem("AuricBar") != null)
                {
                    if (type == IndustrialPickaxes.Calamity.TileType("AuricOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(20) - ChanceAuric <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Calamity.ItemType("AuricBar"));
                            ChanceAuric = 0;
                        }
                        else
                        {
                            ChanceAuric++;
                        }

                    }
                }
            }
        }
        #endregion

        #region Thorium
        int ChanceThorium;
        int ChanceMagma;
        int ChanceAquaite;
        int ChanceLodestone;
        int ChanceValadium;
        int ChanceIllumite;

        public void SmeltThorium(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.ThoriumLoaded)
            {
                if (IndustrialPickaxes.Thorium.GetTile("ThoriumOre") != null && IndustrialPickaxes.Thorium.GetItem("ThoriumBar") != null)
                {
                    if (type == IndustrialPickaxes.Thorium.TileType("ThoriumOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceThorium <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Thorium.ItemType("ThoriumBar"));
                            ChanceThorium = 0;
                        }
                        else
                        {
                            ChanceThorium++;
                        }

                    }
                }
            }
        }
        public void SmeltMagma(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.ThoriumLoaded)
            {
                if (IndustrialPickaxes.Thorium.GetTile("MagmaOre") != null && IndustrialPickaxes.Thorium.GetItem("MagmaCore") != null)
                {
                    if (type == IndustrialPickaxes.Thorium.TileType("MagmaOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceMagma <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Thorium.ItemType("MagmaCore"));
                            ChanceMagma = 0;
                        }
                        else
                        {
                            ChanceMagma++;
                        }

                    }
                }
            }
        }
        public void SmeltAquaite(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.ThoriumLoaded)
            {
                if (IndustrialPickaxes.Thorium.GetTile("AquaiteBare") != null && IndustrialPickaxes.Thorium.GetItem("AquaiteBar") != null)
                {
                    if (type == IndustrialPickaxes.Thorium.TileType("AquaiteBare"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceAquaite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Thorium.ItemType("AquaiteBar"));
                            ChanceAquaite = 0;
                        }
                        else
                        {
                            ChanceAquaite++;
                        }

                    }
                }
            }
        }
        public void SmeltLodestone(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.ThoriumLoaded)
            {
                if (IndustrialPickaxes.Thorium.GetTile("LodeStone") != null && IndustrialPickaxes.Thorium.GetItem("LodeStoneIngot") != null)
                {
                    if (type == IndustrialPickaxes.Thorium.TileType("LodeStone"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceLodestone <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Thorium.ItemType("LodeStoneIngot"));
                            ChanceLodestone = 0;
                        }
                        else
                        {
                            ChanceLodestone++;
                        }

                    }
                }
            }
        }
        public void SmeltValadium(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.ThoriumLoaded)
            {
                if (IndustrialPickaxes.Thorium.GetTile("ValadiumChunk") != null && IndustrialPickaxes.Thorium.GetItem("ValadiumIngot") != null)
                {
                    if (type == IndustrialPickaxes.Thorium.TileType("ValadiumChunk"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceValadium <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Thorium.ItemType("ValadiumIngot"));
                            ChanceValadium = 0;
                        }
                        else
                        {
                            ChanceValadium++;
                        }

                    }
                }
            }
        }
        public void SmeltIllumite(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.ThoriumLoaded)
            {
                if (IndustrialPickaxes.Thorium.GetTile("IllumiteChunk") != null && IndustrialPickaxes.Thorium.GetItem("IllumiteIngot") != null)
                {
                    if (type == IndustrialPickaxes.Thorium.TileType("IllumiteChunk"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceIllumite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Thorium.ItemType("IllumiteIngot"));
                            ChanceIllumite = 0;
                        }
                        else
                        {
                            ChanceIllumite++;
                        }

                    }
                }
            }
        }
        #endregion

        #region Redemption
        int ChanceKanite;
        int ChanceDragonLead;
        int ChanceSapphiron;
        int ChanceScarlion;

        public void SmeltKanite(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.RedemptionLoaded)
            {
                if (IndustrialPickaxes.Redemption.GetTile("KaniteOreTile") != null && IndustrialPickaxes.Redemption.GetItem("KaniteBar") != null)
                {
                    if (type == IndustrialPickaxes.Redemption.TileType("KaniteOreTile"))
                    {
                        noItem = true;
                        if (Main.rand.Next(3) - ChanceKanite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Redemption.ItemType("KaniteBar"));
                            ChanceKanite = 0;
                        }
                        else
                        {
                            ChanceKanite++;
                        }

                    }
                }
            }
        }
        public void SmeltDragonLead(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.RedemptionLoaded)
            {
                if (IndustrialPickaxes.Redemption.GetTile("DragonLeadOreTile") != null && IndustrialPickaxes.Redemption.GetItem("DragonLeadBar") != null)
                {
                    if (type == IndustrialPickaxes.Redemption.TileType("DragonLeadOreTile"))
                    {
                        noItem = true;
                        if (Main.rand.Next(4) - ChanceDragonLead <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Redemption.ItemType("DragonLeadBar"));
                            ChanceDragonLead = 0;
                        }
                        else
                        {
                            ChanceDragonLead++;
                        }

                    }
                }
            }
        }
        public void SmeltSapphiron(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.RedemptionLoaded)
            {
                if (IndustrialPickaxes.Redemption.GetTile("SapphironOreTile") != null && IndustrialPickaxes.Redemption.GetItem("SapphireBar") != null)
                {
                    if (type == IndustrialPickaxes.Redemption.TileType("SapphironOreTile"))
                    {
                        noItem = true;
                        if (Main.rand.Next(4) - ChanceSapphiron <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Redemption.ItemType("SapphireBar"));
                            ChanceSapphiron = 0;
                        }
                        else
                        {
                            ChanceSapphiron++;
                        }

                    }
                }
            }
        }
        public void SmeltScarlion(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.RedemptionLoaded)
            {
                if (IndustrialPickaxes.Redemption.GetTile("ScarlionOreTile") != null && IndustrialPickaxes.Redemption.GetItem("ScarletBar") != null)
                {
                    if (type == IndustrialPickaxes.Redemption.TileType("ScarlionOreTile"))
                    {
                        noItem = true;
                        if (Main.rand.Next(3) - ChanceScarlion <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.Redemption.ItemType("ScarletBar"));
                            ChanceScarlion = 0;
                        }
                        else
                        {
                            ChanceScarlion++;
                        }

                    }
                }
            }
        }
        #endregion

        #region Ancients Awakened
        int ChanceIncinerite;
        int ChanceAbyssium;
        int ChanceYtrium;
        int ChanceUranium;
        int ChanceHallowed;
        int ChanceTechnecium;
        int ChanceRadium;
        int ChanceApocalyptite;
        int ChanceDaybreakIncinerite;
        int ChanceEventideAbyssium;

        public void SmeltChaos(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.AALoaded)
            {
                if (IndustrialPickaxes.AncientsAwakened.GetTile("IncineriteOre") != null && IndustrialPickaxes.AncientsAwakened.GetItem("IncineriteBar") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("IncineriteOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(4) - ChanceIncinerite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("IncineriteBar"));
                            ChanceIncinerite = 0;
                        }
                        else
                        {
                            ChanceIncinerite++;
                        }

                    }
                }
                if (IndustrialPickaxes.AncientsAwakened.GetTile("AbyssiumOre") != null && IndustrialPickaxes.AncientsAwakened.GetItem("AbyssiumBar") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("AbyssiumOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(4) - ChanceAbyssium <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("AbyssiumBar"));
                            ChanceAbyssium = 0;
                        }
                        else
                        {
                            ChanceAbyssium++;
                        }

                    }
                }
            }
        }
        public void SmeltYtrium(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.AALoaded)
            {
                if (IndustrialPickaxes.AncientsAwakened.GetTile("YtriumOre") != null && IndustrialPickaxes.AncientsAwakened.GetItem("YtriumBar") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("YtriumOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(4) - ChanceYtrium <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("YtriumBar"));
                            ChanceYtrium = 0;
                        }
                        else
                        {
                            ChanceYtrium++;
                        }

                    }
                }
            }
        }
        public void SmeltUranium(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.AALoaded)
            {
                if (IndustrialPickaxes.AncientsAwakened.GetTile("UraniumOre") != null && IndustrialPickaxes.AncientsAwakened.GetItem("UraniumBar") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("UraniumOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceUranium <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("UraniumBar"));
                            ChanceUranium = 0;
                        }
                        else
                        {
                            ChanceUranium++;
                        }

                    }
                }
            }
        }
        public void SmeltHallowed(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.AALoaded)
            {
                if (IndustrialPickaxes.AncientsAwakened.GetTile("HallowedOre") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("HallowedOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceHallowed <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.HallowedBar);
                            ChanceHallowed = 0;
                        }
                        else
                        {
                            ChanceHallowed++;
                        }

                    }
                }
            }
        }
        public void SmeltTechnecium(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.AALoaded)
            {
                if (IndustrialPickaxes.AncientsAwakened.GetTile("TechneciumOre") != null && IndustrialPickaxes.AncientsAwakened.GetItem("TechneciumBar") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("TechneciumOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(7) - ChanceTechnecium <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("TechneciumBar"));
                            ChanceTechnecium = 0;
                        }
                        else
                        {
                            ChanceTechnecium++;
                        }

                    }
                }
            }
        }
        public void SmeltRadium(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.AALoaded)
            {
                if (IndustrialPickaxes.AncientsAwakened.GetTile("RadiumOre") != null && IndustrialPickaxes.AncientsAwakened.GetItem("RadiumBar") != null && IndustrialPickaxes.AncientsAwakened.GetItem("DarkMatter") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("RadiumOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceRadium <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            if (Main.dayTime)
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("RadiumBar"));
                            }
                            else
                            {
                                Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("DarkMatter"));
                            }
                            ChanceRadium = 0;
                        }
                        else
                        {
                            ChanceRadium++;
                        }

                    }
                }
            }
        }
        public void SmeltApocalyptite(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.AALoaded)
            {
                if (IndustrialPickaxes.AncientsAwakened.GetTile("Apocalyptite") != null && IndustrialPickaxes.AncientsAwakened.GetItem("ApocalyptitePlate") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("Apocalyptite"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceApocalyptite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("ApocalyptitePlate"));
                            ChanceApocalyptite = 0;
                        }
                        else
                        {
                            ChanceApocalyptite++;
                        }

                    }
                }
            }
        }
        public void SmeltAwakenedChaos(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.AALoaded)
            {
                if (IndustrialPickaxes.AncientsAwakened.GetTile("DaybreakIncineriteOre") != null && IndustrialPickaxes.AncientsAwakened.GetItem("DaybreakIncinerite") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("DaybreakIncineriteOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceDaybreakIncinerite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("DaybreakIncinerite"));
                            ChanceDaybreakIncinerite = 0;
                        }
                        else
                        {
                            ChanceDaybreakIncinerite++;
                        }

                    }
                }
                if (IndustrialPickaxes.AncientsAwakened.GetTile("EventideAbyssiumOre") != null && IndustrialPickaxes.AncientsAwakened.GetItem("EventideAbyssium") != null)
                {
                    if (type == IndustrialPickaxes.AncientsAwakened.TileType("EventideAbyssiumOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(6) - ChanceEventideAbyssium <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.AncientsAwakened.ItemType("EventideAbyssium"));
                            ChanceEventideAbyssium = 0;
                        }
                        else
                        {
                            ChanceEventideAbyssium++;
                        }

                    }
                }
            }
        }
        #endregion

        #region Spirit
        int ChanceFloran;
        int ChanceCryolite;
        int ChanceSpirit;
        int ChanceThermite;

        public void SmeltFloran(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.SpiritLoaded)
            {
                if (IndustrialPickaxes.SpiritMod.GetTile("FloranOreTile") != null && IndustrialPickaxes.SpiritMod.GetItem("FloranBar") != null)
                {
                    if (type == IndustrialPickaxes.SpiritMod.TileType("FloranOreTile"))
                    {
                        noItem = true;
                        if (Main.rand.Next(4) - ChanceFloran <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.SpiritMod.ItemType("FloranBar"));
                            ChanceFloran = 0;
                        }
                        else
                        {
                            ChanceFloran++;
                        }

                    }
                }
            }
        }
        public void SmeltCryolite(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.SpiritLoaded)
            {
                if (IndustrialPickaxes.SpiritMod.GetTile("CryoliteOreTile") != null && IndustrialPickaxes.SpiritMod.GetItem("CryoliteBar") != null)
                {
                    if (type == IndustrialPickaxes.SpiritMod.TileType("CryoliteOreTile"))
                    {
                        noItem = true;
                        if (Main.rand.Next(4) - ChanceCryolite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.SpiritMod.ItemType("CryoliteBar"));
                            ChanceCryolite = 0;
                        }
                        else
                        {
                            ChanceCryolite++;
                        }

                    }
                }
            }
        }
        public void SmeltSpirit(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.SpiritLoaded)
            {
                if (IndustrialPickaxes.SpiritMod.GetTile("SpiritOreTile") != null && IndustrialPickaxes.SpiritMod.GetItem("SpiritBar") != null)
                {
                    if (type == IndustrialPickaxes.SpiritMod.TileType("SpiritOreTile"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceSpirit <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.SpiritMod.ItemType("SpiritBar"));
                            ChanceSpirit = 0;
                        }
                        else
                        {
                            ChanceSpirit++;
                        }

                    }
                }
            }
        }
        public void SmeltThermite(int i, int j, int type, ref bool noItem)
        {
            if (IndustrialPickaxes.SpiritLoaded)
            {
                if (IndustrialPickaxes.SpiritMod.GetTile("ThermiteOre") != null && IndustrialPickaxes.SpiritMod.GetItem("ThermiteBar") != null)
                {
                    if (type == IndustrialPickaxes.SpiritMod.TileType("ThermiteOre"))
                    {
                        noItem = true;
                        if (Main.rand.Next(5) - ChanceThermite <= 0)
                        {
                            Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
                            Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.SpiritMod.ItemType("ThermiteBar"));
                            ChanceThermite = 0;
                        }
                        else
                        {
                            ChanceThermite++;
                        }

                    }
                }
            }
        }
        #endregion

        #endregion

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!WorldGen.noTileActions && !WorldGen.gen)
            {
                var p = Main.LocalPlayer.GetModPlayer<IndustrialPlayer>();
                int usedTool = p.holdingItem.type;
                if (!Main.LocalPlayer.HasBuff(BuffID.DrillMount) && Main.netMode == NetmodeID.SinglePlayer && !fail && KillableTile)
                {
                    #region Base Pickaxes
                    if (usedTool == mod.ItemType("AvaliManipulator") || usedTool == mod.ItemType("AscendedFishaxe") || usedTool == mod.ItemType("DraconicStaffOfPower") || usedTool == mod.ItemType("DraconicStaffOfPowerAsiimov") || usedTool == mod.ItemType("DraconicStaffOfPowerDemonic") || usedTool == mod.ItemType("DraconicStaffOfPowerGlacier") || usedTool == mod.ItemType("DraconicStaffOfPowerStellar"))
                    {
                        //Smelt(i, j, type, ref noItem);
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltHellstone(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltMythrilOrichalcum(i, j, type, ref noItem);
                        SmeltAdamantiteTitanium(i, j, type, ref noItem);
                        SmeltChlorophyte(i, j, type, ref noItem);
                        SmeltLuminite(i, j, type, ref noItem);
                        //Shadows of Abaddon
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltOblivion(i, j, type, ref noItem);
                        //Calamity
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltCryonic(i, j, type, ref noItem);
                        SmeltCharred(i, j, type, ref noItem);
                        SmeltPerennial(i, j, type, ref noItem);
                        SmeltAstral(i, j, type, ref noItem);
                        SmeltChaotic(i, j, type, ref noItem);
                        SmeltUelibloom(i, j, type, ref noItem);
                        SmeltAuric(i, j, type, ref noItem);
                        //Thorium
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltLodestone(i, j, type, ref noItem);
                        SmeltValadium(i, j, type, ref noItem);
                        SmeltIllumite(i, j, type, ref noItem);
                        //Redemption
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltDragonLead(i, j, type, ref noItem);
                        SmeltSapphiron(i, j, type, ref noItem);
                        SmeltScarlion(i, j, type, ref noItem);
                        //Ancients Awakened
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltUranium(i, j, type, ref noItem);
                        SmeltHallowed(i, j, type, ref noItem);
                        SmeltTechnecium(i, j, type, ref noItem);
                        SmeltRadium(i, j, type, ref noItem);
                        SmeltApocalyptite(i, j, type, ref noItem);
                        SmeltAwakenedChaos(i, j, type, ref noItem);
                        //Spirit Mod
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                        SmeltSpirit(i, j, type, ref noItem);
                        SmeltThermite(i, j, type, ref noItem);
                    }

                    if (usedTool == mod.ItemType("IndustrialMoltenPickaxe") || usedTool == mod.ItemType("IndustrialMoltenPickaxeFrostburn"))
                    {
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                    }

                    if (usedTool == mod.ItemType("GracefulChlorophytePickaxe") || usedTool == mod.ItemType("GracefulChlorophytePickaxePlantera"))
                    {
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltHellstone(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltMythrilOrichalcum(i, j, type, ref noItem);
                        SmeltAdamantiteTitanium(i, j, type, ref noItem);
                        SmeltChlorophyte(i, j, type, ref noItem);
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltCryonic(i, j, type, ref noItem);
                        SmeltCharred(i, j, type, ref noItem);
                        SmeltPerennial(i, j, type, ref noItem);
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltLodestone(i, j, type, ref noItem);
                        SmeltValadium(i, j, type, ref noItem);
                        SmeltIllumite(i, j, type, ref noItem);
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltDragonLead(i, j, type, ref noItem);
                        SmeltSapphiron(i, j, type, ref noItem);
                        SmeltScarlion(i, j, type, ref noItem);
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltUranium(i, j, type, ref noItem);
                        SmeltHallowed(i, j, type, ref noItem);
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                        SmeltSpirit(i, j, type, ref noItem);
                        SmeltThermite(i, j, type, ref noItem);
                    }

                    if (usedTool == mod.ItemType("IndustrialPicksaw") || usedTool == mod.ItemType("IndustrialPicksawBysmal") || usedTool == mod.ItemType("IndustrialPicksawMartian"))
                    {
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltHellstone(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltMythrilOrichalcum(i, j, type, ref noItem);
                        SmeltAdamantiteTitanium(i, j, type, ref noItem);
                        SmeltChlorophyte(i, j, type, ref noItem);
                        SmeltLuminite(i, j, type, ref noItem);
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltCryonic(i, j, type, ref noItem);
                        SmeltCharred(i, j, type, ref noItem);
                        SmeltPerennial(i, j, type, ref noItem);
                        SmeltChaotic(i, j, type, ref noItem);
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltLodestone(i, j, type, ref noItem);
                        SmeltValadium(i, j, type, ref noItem);
                        SmeltIllumite(i, j, type, ref noItem);
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltDragonLead(i, j, type, ref noItem);
                        SmeltSapphiron(i, j, type, ref noItem);
                        SmeltScarlion(i, j, type, ref noItem);
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltUranium(i, j, type, ref noItem);
                        SmeltHallowed(i, j, type, ref noItem);
                        SmeltTechnecium(i, j, type, ref noItem);
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                        SmeltSpirit(i, j, type, ref noItem);
                        SmeltThermite(i, j, type, ref noItem);
                    }

                    if (usedTool == mod.ItemType("IndustrialLunarPickaxe") || usedTool == mod.ItemType("IndustrialLunarPickaxeRagnarok") || usedTool == mod.ItemType("IndustrialLunarPickaxeGenesis"))
                    {
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltHellstone(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltMythrilOrichalcum(i, j, type, ref noItem);
                        SmeltAdamantiteTitanium(i, j, type, ref noItem);
                        SmeltChlorophyte(i, j, type, ref noItem);
                        SmeltLuminite(i, j, type, ref noItem);
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltCryonic(i, j, type, ref noItem);
                        SmeltCharred(i, j, type, ref noItem);
                        SmeltPerennial(i, j, type, ref noItem);
                        SmeltAstral(i, j, type, ref noItem);
                        SmeltChaotic(i, j, type, ref noItem);
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltLodestone(i, j, type, ref noItem);
                        SmeltValadium(i, j, type, ref noItem);
                        SmeltIllumite(i, j, type, ref noItem);
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltDragonLead(i, j, type, ref noItem);
                        SmeltSapphiron(i, j, type, ref noItem);
                        SmeltScarlion(i, j, type, ref noItem);
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltUranium(i, j, type, ref noItem);
                        SmeltHallowed(i, j, type, ref noItem);
                        SmeltTechnecium(i, j, type, ref noItem);
                        SmeltRadium(i, j, type, ref noItem);
                        SmeltApocalyptite(i, j, type, ref noItem);
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                        SmeltSpirit(i, j, type, ref noItem);
                        SmeltThermite(i, j, type, ref noItem);
                    }
                    #endregion

                    #region Modded Pickaxes
                    // Shadows of Abaddon
                    if (usedTool == mod.ItemType("SolusFlariumPickaxe") || usedTool == mod.ItemType("SolusFlariumPickaxeCernium") || usedTool == mod.ItemType("SolusFlariumPickaxeAsthraltite") || usedTool == mod.ItemType("DraconicAsthraltitePicksaw") || usedTool == mod.ItemType("LeechingShadowflarePicksaw") || usedTool == mod.ItemType("JudgementalFlamePickaxe"))
                    {
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltHellstone(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltMythrilOrichalcum(i, j, type, ref noItem);
                        SmeltAdamantiteTitanium(i, j, type, ref noItem);
                        SmeltChlorophyte(i, j, type, ref noItem);
                        SmeltLuminite(i, j, type, ref noItem);
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltOblivion(i, j, type, ref noItem);
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltCryonic(i, j, type, ref noItem);
                        SmeltCharred(i, j, type, ref noItem);
                        SmeltPerennial(i, j, type, ref noItem);
                        SmeltAstral(i, j, type, ref noItem);
                        SmeltChaotic(i, j, type, ref noItem);
                        SmeltUelibloom(i, j, type, ref noItem);
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltLodestone(i, j, type, ref noItem);
                        SmeltValadium(i, j, type, ref noItem);
                        SmeltIllumite(i, j, type, ref noItem);
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltDragonLead(i, j, type, ref noItem);
                        SmeltSapphiron(i, j, type, ref noItem);
                        SmeltScarlion(i, j, type, ref noItem);
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltUranium(i, j, type, ref noItem);
                        SmeltHallowed(i, j, type, ref noItem);
                        SmeltTechnecium(i, j, type, ref noItem);
                        SmeltRadium(i, j, type, ref noItem);
                        SmeltApocalyptite(i, j, type, ref noItem);
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                        SmeltSpirit(i, j, type, ref noItem);
                        SmeltThermite(i, j, type, ref noItem);
                    }

                    // Calamity
                    if (usedTool == mod.ItemType("ViridescentBlossomPickaxe") || usedTool == mod.ItemType("ViridescentBlossomPickaxeProvidence"))
                    {
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltHellstone(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltMythrilOrichalcum(i, j, type, ref noItem);
                        SmeltAdamantiteTitanium(i, j, type, ref noItem);
                        SmeltChlorophyte(i, j, type, ref noItem);
                        SmeltLuminite(i, j, type, ref noItem);
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltOblivion(i, j, type, ref noItem);
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltCryonic(i, j, type, ref noItem);
                        SmeltCharred(i, j, type, ref noItem);
                        SmeltPerennial(i, j, type, ref noItem);
                        SmeltAstral(i, j, type, ref noItem);
                        SmeltChaotic(i, j, type, ref noItem);
                        SmeltUelibloom(i, j, type, ref noItem);
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltLodestone(i, j, type, ref noItem);
                        SmeltValadium(i, j, type, ref noItem);
                        SmeltIllumite(i, j, type, ref noItem);
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltDragonLead(i, j, type, ref noItem);
                        SmeltSapphiron(i, j, type, ref noItem);
                        SmeltScarlion(i, j, type, ref noItem);
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltUranium(i, j, type, ref noItem);
                        SmeltHallowed(i, j, type, ref noItem);
                        SmeltTechnecium(i, j, type, ref noItem);
                        SmeltRadium(i, j, type, ref noItem);
                        SmeltApocalyptite(i, j, type, ref noItem);
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                        SmeltSpirit(i, j, type, ref noItem);
                        SmeltThermite(i, j, type, ref noItem);
                    }

                    // Redemption
                    if (usedTool == mod.ItemType("ExperimentalNanoPickaxe") || usedTool == mod.ItemType("ExperimentalNanoPickaxeCreative") || usedTool == mod.ItemType("ExperimentalNanoPickaxeXenium") || usedTool == mod.ItemType("ExperimentalNanoPickaxeVlitch"))
                    {
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltHellstone(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltMythrilOrichalcum(i, j, type, ref noItem);
                        SmeltAdamantiteTitanium(i, j, type, ref noItem);
                        SmeltChlorophyte(i, j, type, ref noItem);
                        SmeltLuminite(i, j, type, ref noItem);
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltOblivion(i, j, type, ref noItem);
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltCryonic(i, j, type, ref noItem);
                        SmeltCharred(i, j, type, ref noItem);
                        SmeltPerennial(i, j, type, ref noItem);
                        SmeltAstral(i, j, type, ref noItem);
                        SmeltChaotic(i, j, type, ref noItem);
                        SmeltUelibloom(i, j, type, ref noItem);
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltLodestone(i, j, type, ref noItem);
                        SmeltValadium(i, j, type, ref noItem);
                        SmeltIllumite(i, j, type, ref noItem);
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltDragonLead(i, j, type, ref noItem);
                        SmeltSapphiron(i, j, type, ref noItem);
                        SmeltScarlion(i, j, type, ref noItem);
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltUranium(i, j, type, ref noItem);
                        SmeltHallowed(i, j, type, ref noItem);
                        SmeltTechnecium(i, j, type, ref noItem);
                        SmeltRadium(i, j, type, ref noItem);
                        SmeltApocalyptite(i, j, type, ref noItem);
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                        SmeltSpirit(i, j, type, ref noItem);
                        SmeltThermite(i, j, type, ref noItem);
                    }

                    // Elements Awoken
                    if (usedTool == mod.ItemType("MasterManipulator"))
                    {
                        SmeltCopperTin(i, j, type, ref noItem);
                        SmeltIronLead(i, j, type, ref noItem);
                        SmeltSilverTungsten(i, j, type, ref noItem);
                        SmeltGoldPlatinum(i, j, type, ref noItem);
                        SmeltMeteorite(i, j, type, ref noItem);
                        SmeltDemoniteCrimtane(i, j, type, ref noItem);
                        SmeltHellstone(i, j, type, ref noItem);
                        SmeltCobaltPalladium(i, j, type, ref noItem);
                        SmeltMythrilOrichalcum(i, j, type, ref noItem);
                        SmeltAdamantiteTitanium(i, j, type, ref noItem);
                        SmeltChlorophyte(i, j, type, ref noItem);
                        SmeltLuminite(i, j, type, ref noItem);
                        SmeltLapis(i, j, type, ref noItem);
                        SmeltBismuth(i, j, type, ref noItem);
                        SmeltOblivion(i, j, type, ref noItem);
                        SmeltAerialite(i, j, type, ref noItem);
                        SmeltCryonic(i, j, type, ref noItem);
                        SmeltCharred(i, j, type, ref noItem);
                        SmeltPerennial(i, j, type, ref noItem);
                        SmeltAstral(i, j, type, ref noItem);
                        SmeltChaotic(i, j, type, ref noItem);
                        SmeltUelibloom(i, j, type, ref noItem);
                        SmeltThorium(i, j, type, ref noItem);
                        SmeltMagma(i, j, type, ref noItem);
                        SmeltAquaite(i, j, type, ref noItem);
                        SmeltLodestone(i, j, type, ref noItem);
                        SmeltValadium(i, j, type, ref noItem);
                        SmeltIllumite(i, j, type, ref noItem);
                        SmeltKanite(i, j, type, ref noItem);
                        SmeltDragonLead(i, j, type, ref noItem);
                        SmeltSapphiron(i, j, type, ref noItem);
                        SmeltScarlion(i, j, type, ref noItem);
                        SmeltChaos(i, j, type, ref noItem);
                        SmeltYtrium(i, j, type, ref noItem);
                        SmeltUranium(i, j, type, ref noItem);
                        SmeltHallowed(i, j, type, ref noItem);
                        SmeltTechnecium(i, j, type, ref noItem);
                        SmeltRadium(i, j, type, ref noItem);
                        SmeltApocalyptite(i, j, type, ref noItem);
                        SmeltFloran(i, j, type, ref noItem);
                        SmeltCryolite(i, j, type, ref noItem);
                        SmeltSpirit(i, j, type, ref noItem);
                        SmeltThermite(i, j, type, ref noItem);
                    }
                    #endregion

                    #region Ore Rejuvenator
                    if (usedTool == mod.ItemType("OreRejuvenator"))
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

                    #region Violet Thaumaturgy
                    if (usedTool == mod.ItemType("VioletThaumaturgy"))
                    {
                        #region Vanilla Ore Conversion
                        if (type == TileID.Copper)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TinOre);
                        }
                        else if (type == TileID.Tin)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CopperOre);
                        }
                        else if (type == TileID.Iron)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.LeadOre);
                        }
                        else if (type == TileID.Lead)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.IronOre);
                        }
                        else if (type == TileID.Silver)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TungstenOre);
                        }
                        else if (type == TileID.Tungsten)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.SilverOre);
                        }
                        else if (type == TileID.Gold)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.PlatinumOre);
                        }
                        else if (type == TileID.Platinum)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.GoldOre);
                        }
                        else if (type == TileID.Demonite)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CrimtaneOre);
                        }
                        else if (type == TileID.Crimtane)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.DemoniteOre);
                        }
                        else if (type == TileID.Cobalt)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.PalladiumOre);
                        }
                        else if (type == TileID.Palladium)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.CobaltOre);
                        }
                        else if (type == TileID.Mythril)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.OrichalcumOre);
                        }
                        else if (type == TileID.Orichalcum)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.MythrilOre);
                        }
                        else if (type == TileID.Adamantite)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.TitaniumOre);
                        }
                        else if (type == TileID.Titanium)
                        {
                            noItem = true;
                            Item.NewItem(i * 16, j * 16, 16, 16, ItemID.AdamantiteOre);
                        }
                        #endregion

                        #region Modded Ore Conversion
                        // I'll do this later
                        #region Shadows of Abaddon
                        /*if (IndustrialPickaxes.SoALoaded)
                        {
                            if (IndustrialPickaxes.SacredTools.GetTile("LapisOre") != null && IndustrialPickaxes.SacredTools.GetTile("BismuthOre") != null)
                            {
                                if (type == IndustrialPickaxes.SacredTools.TileType("LapisOre"))
                                {
                                    noItem = true;
                                    Item.NewItem(i * 16, j * 16, 16, 16, IndustrialPickaxes.SacredTools.ItemType("RefinedLapis"));
                                }
                            }
                        }*/
                        #endregion

                        #endregion
                    }
                    #endregion
                }
            }
        }
    }
}
