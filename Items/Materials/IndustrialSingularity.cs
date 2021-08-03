using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Materials
{
	public class IndustrialSingularity : ModItem
    {
        public override bool Autoload(ref string name) => IndustrialPickaxes.SoALoaded || IndustrialPickaxes.CalamityLoaded || IndustrialPickaxes.ThoriumLoaded || IndustrialPickaxes.RedemptionLoaded || IndustrialPickaxes.EALoaded;
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Industria Aeterna'");

			ItemID.Sets.ItemIconPulse[item.type] = ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 30;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.Purple;
		}

		public override Color? GetAlpha(Color lightColor) => Color.White;

		public override void AddRecipes()
		{
            if (IndustrialPickaxes.EALoaded || IndustrialPickaxes.ThoriumLoaded || IndustrialPickaxes.SoALoaded || IndustrialPickaxes.RedemptionLoaded || IndustrialPickaxes.CalamityLoaded)
            {
                ModRecipe recipe = new ModRecipe(mod);

                if (IndustrialPickaxes.EALoaded)
                    recipe.AddIngredient(ModContent.ItemType<MasterManipulator>());

                if (IndustrialPickaxes.ThoriumLoaded)
                    recipe.AddIngredient(IndustrialPickaxes.Thorium.ItemType("TerrariumCanyonSplitter"));

                if (IndustrialPickaxes.SoALoaded)
                {
                    recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialFlarium");
                    recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialAsthraltite");
                }

                if (IndustrialPickaxes.RedemptionLoaded)
                    recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialNano");

                if (IndustrialPickaxes.CalamityLoaded)
                {
                    recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialBlossom");
                    recipe.AddTile(IndustrialPickaxes.Calamity.TileType("DraedonsForge"));
                }
                else if (IndustrialPickaxes.SoALoaded)
                    recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("LunarAltar"));
                else
                    recipe.AddTile(TileID.LunarCraftingStation);

                recipe.SetResult(this);
                recipe.AddRecipe();
            }
		}
	}
}