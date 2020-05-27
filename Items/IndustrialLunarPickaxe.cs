using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class IndustrialLunarPickaxe : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/IndustrialLunarPickaxe");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunatic's Celestial Pick");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'You'd have to be crazy to think this was an axe'");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.damage = 80;
			item.width = 50;
			item.height = 50;
			item.useTime = 11;
			item.useAnimation = 17;
			item.scale = 1.15f;
			item.pick = 225;
			item.knockBack = 5.5f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Red;
			item.tileBoost += 4;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.FragmentNebula, 9);
			recipe.AddIngredient(ItemID.FragmentSolar, 9);
			recipe.AddIngredient(ItemID.FragmentStardust, 9);
			recipe.AddIngredient(ItemID.FragmentVortex, 9);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class IndustrialLunarPickaxeRagnarok : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/IndustrialLunarPickaxeRagnarok");

		public override string Texture => mod.Name + "/Items/Reskins/IndustrialLunarPickaxeRagnarok";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reality Breaker Pickaxe");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'The earth trembles...'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<IndustrialLunarPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<IndustrialLunarPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}