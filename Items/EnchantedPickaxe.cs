using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class EnchantedPickaxe : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/EnchantedPickaxe");

		public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Could this be the pickaxe of legend?'\n'Well, no, it's actually a replica made with a tough alloy, still pretty handy'");

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.damage = 6;
			item.width = 38;
			item.height = 34;
			item.useTime = 20;
			item.useAnimation = 24;
			item.pick = 55;
			item.knockBack = 2;
			item.value = Item.buyPrice(gold: 1);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
		}
	}

	public class Pickhalis : EnchantedPickaxe
	{
		public override string Texture => mod.Name + "/Items/Reskins/Pickhalis";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/Pickhalis");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pickhalis");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Dropped by the rare and threatening Spelunker Schmoo'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<EnchantedPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Pickagrim>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EnchantedPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class Pickagrim : EnchantedPickaxe
	{
		public override string Texture => mod.Name + "/Items/Reskins/Pickagrim";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/Pickagrim");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pickagrim");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Not to be confused with a Crissaegrim'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<EnchantedPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Pickhalis>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EnchantedPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}