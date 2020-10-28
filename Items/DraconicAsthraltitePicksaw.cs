using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
    public class DraconicAsthraltitePicksaw : IndustrialPickaxe
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

    public class LeechingShadowflarePicksaw : DraconicAsthraltitePicksaw
    {
        public override string Texture => mod.Name + "/Items/Reskins/LeechingShadowflarePicksaw";

        public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/LeechingShadowflarePicksaw");

        public override Color[] ItemNameCycleColors => new Color[] { new Color(185, 0, 67), new Color(185, 0, 67) };

        public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'You can feel your lifeforce being sucked into this thing, at least it's not as bad as the real deal'");

        public override void AddRecipes()
        {
            if (!IndustrialPickaxes.SoALoaded)
                return;

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ModContent.ItemType<DraconicAsthraltitePicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<JudgementalFlamePicksaw>());
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DraconicAsthraltitePicksaw>());
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class JudgementalFlamePicksaw : DraconicAsthraltitePicksaw
    {
        public override string Texture => mod.Name + "/Items/Reskins/JudgementalFlamePicksaw";

        public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/JudgementalFlamePicksaw");

        public override Color[] ItemNameCycleColors => new Color[] { new Color(211, 8, 93), new Color(211, 8, 93) };

        public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'A demonic energy formed in shape of a... pickaxe?'\n'It seems that only those that are accepted as its true master can unlock its true potential'");

        public override void AddRecipes()
        {
            if (!IndustrialPickaxes.SoALoaded)
                return;

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ModContent.ItemType<DraconicAsthraltitePicksaw>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LeechingShadowflarePicksaw>());
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DraconicAsthraltitePicksaw>());
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
