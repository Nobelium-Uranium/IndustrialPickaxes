using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class IndustrialPicksaw : IndustrialPickaxe
	{
		private class PicksawRecipeHelper : ModRecipe
		{
			public PicksawRecipeHelper(Mod mod) : base(mod) { }

			public override bool RecipeAvailable() => NPC.downedGolemBoss;
		}

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/IndustrialPicksaw");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lihzahrdian Picksaw");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'An ancient masterpiece'");
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			item.width = 44;
			item.height = 46;
			item.useTime = 11;
			item.useAnimation = 21;
			item.scale = 1.15f;
			item.pick = 210;
			item.axe = 25;
			item.knockBack = 5.5f;
			item.value = 216000;
			item.rare = ItemRarityID.Lime;
			item.tileBoost++;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			PicksawRecipeHelper recipe = new PicksawRecipeHelper(mod);
			recipe.AddIngredient(ItemID.LihzahrdBrick, 60);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class IndustrialPicksawBysmal : IndustrialPicksaw
	{
		public override string Texture => mod.Name + "/Items/Reskins/IndustrialPicksawBysmal";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/IndustrialPicksawBysmal");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Etherial Picksaw"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Schrodinger's pickaxe'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<IndustrialPicksaw>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<IndustrialPicksawMartian>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<IndustrialPicksaw>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class IndustrialPicksawMartian : IndustrialPicksaw
	{
		public override string Texture => mod.Name + "/Items/Reskins/IndustrialPicksawMartian";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/IndustrialPicksawMartian");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alien Picksaw");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Far out, man!'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<IndustrialPicksaw>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<IndustrialPicksawBysmal>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<IndustrialPicksaw>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}