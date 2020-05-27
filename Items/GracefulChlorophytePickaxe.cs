using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class GracefulChlorophytePickaxe : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/GracefulChlorophytePickaxe");

		public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Every rose has its thorn'");

		public override void SetDefaults()
		{
			item.damage = 40;
			item.width = 42;
			item.height = 40;
			item.useTime = 12;
			item.useAnimation = 30;
			item.scale = 1.15f;
			item.pick = 200;
			item.knockBack = 5;
			item.value = 216000;
			item.rare = 7;
			item.tileBoost++;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 27);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class GracefulChlorophytePickaxePlantera : GracefulChlorophytePickaxe
	{
		public override string Texture => mod.Name + "/Items/Reskins/GracefulChlorophytePickaxePlantera";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/GracefulChlorophytePickaxePlantera");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blooming Chlorophyte Pickaxe");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'The ultimate trendkiller'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<GracefulChlorophytePickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GracefulChlorophytePickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}