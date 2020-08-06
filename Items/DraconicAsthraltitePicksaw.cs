using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
    class DraconicAsthraltitePicksaw : IndustrialPickaxe
    {
        public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/DraconicAsthraltitePicksaw");

        public override Color[] ItemNameCycleColors => new Color[] { new Color(185, 0, 67), new Color(185, 0, 67) };

        public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'NOW you mine with Asthraltite.'");

        public override void SetDefaults()
        {
            base.SetDefaults();

            if (!IndustrialPickaxes.SoALoaded)
                return;

            item.damage = 360;
            item.width = 108;
            item.height = 92;
            item.useTime = 7;
            item.useAnimation = 19;
            item.pick = 340;
            item.axe = 60;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 45, 0, 0);
            item.rare = ItemRarityID.Purple;
            item.tileBoost += 14;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            if (!IndustrialPickaxes.SoALoaded)
                return;

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(IndustrialPickaxes.SacredTools.ItemType("AsthralPick"));
            recipe.AddIngredient(IndustrialPickaxes.SacredTools.ItemType("IDontExist"), 25);
            recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("LunarAltar"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
