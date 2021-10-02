using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace IndustrialPickaxes.Globals
{
    public class IndustrialItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!item.social && item.prefix == ModContent.PrefixType<Prefixes.IndustrialPrefix>())
            {
                int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(ModContent.GetInstance<IndustrialPickaxes>().Name))
                && (tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Material") || tt.Name.StartsWith("TileBoost") || tt.Name.StartsWith("PickPower")));
                if (index != -1)
                {
                    TooltipLine line = new TooltipLine(ModContent.GetInstance<IndustrialPickaxes>(), "PrefixIndustrial", "+Autosmelt") { isModifier = true };
                    tooltips.Insert(index + 1, line);
                }
            }
        }
    }
}
