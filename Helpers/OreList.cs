using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Helpers
{
    public class OreList
    {
        public static List<int> oreType = new List<int>(50);
        public static List<int> smeltChance = new List<int>(50);
        public static List<int> barType = new List<int>(50);
        public static ushort[] defaultOreType = new ushort[] { TileID.Copper, TileID.Tin, TileID.Iron, TileID.Lead, TileID.Silver, TileID.Tungsten, TileID.Gold, TileID.Platinum, TileID.Meteorite, TileID.Demonite, TileID.Crimtane, TileID.Hellstone, TileID.Cobalt, TileID.Palladium, TileID.Mythril, TileID.Orichalcum, TileID.Adamantite, TileID.Titanium, TileID.Chlorophyte, TileID.LunarOre };
        public static ushort[] defaultSmeltChance = new ushort[] { 4, 4, 4, 4, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 5, 5, 6, 6, 7, 5 };
        public static short[] defaultBarType = new short[] { ItemID.CopperBar, ItemID.TinBar, ItemID.IronBar, ItemID.LeadBar, ItemID.SilverBar, ItemID.TungstenBar, ItemID.GoldBar, ItemID.PlatinumBar, ItemID.MeteoriteBar, ItemID.DemoniteBar, ItemID.CrimtaneBar, ItemID.HellstoneBar, ItemID.CobaltBar, ItemID.PalladiumBar, ItemID.MythrilBar, ItemID.OrichalcumBar, ItemID.AdamantiteBar, ItemID.TitaniumBar, ItemID.ChlorophyteBar, ItemID.LunarBar };

        /// <summary>
        /// Adds the specified ores to the ore lists
        /// </summary>
        /// <param name="ore">Ore tile type</param>
        /// <param name="chance">Chance to smelt the tile</param>
        /// <param name="bar">The resulting bar item type</param>
        public static void AddOres(int ore, int chance, int bar)
        {
            oreType.Add(ore);
            smeltChance.Add(chance);
            barType.Add(bar);
        }

        /// <summary>
        /// Regenerates the ore lists, only use this if you know what you're doing!
        /// </summary>
        public static void RegenerateOres()
        {
            ClearOres();
            ModContent.GetInstance<IndustrialPickaxes>().PostSetupContent();
        }

        /// <summary>
        /// Clears the current ore lists, only use this if you know what you're doing!
        /// </summary>
        public static void ClearOres()
        {
            oreType.Clear();
            smeltChance.Clear();
            barType.Clear();
        }
    }
}
