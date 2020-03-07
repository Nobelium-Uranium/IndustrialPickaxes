using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Materials
{
	public class IndustrialSingularity : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Industria Aeterna'");

			ItemID.Sets.ItemIconPulse[item.type] = ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 11; //TODO use ItemRarityID
		}

		public override Color? GetAlpha(Color lightColor) => Color.White;

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialMolten");
			recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialChlorophyte");
			recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialPicksaw");
			recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialLunar");

			recipe.AddTile(TileID.LunarCraftingStation);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}