using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class LihzahrdianPicksaw : IndustrialPickaxe
	{
		private class PicksawRecipeHelper : ModRecipe
		{
			public PicksawRecipeHelper(Mod mod) : base(mod) { }

			public override bool RecipeAvailable() => NPC.downedGolemBoss;
		}

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/LihzahrdianPicksaw");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lihzahrdian Picksaw");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'An ancient masterpiece'");
		}

		public override void SetDefaults()
        {
            base.SetDefaults();
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

	public class BysmalPicksaw : LihzahrdianPicksaw
    {
		public override string Texture => mod.Name + "/Items/Reskins/BysmalPicksaw";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/BysmalPicksaw");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bysmal Picksaw"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Schrodinger's pickaxe'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<LihzahrdianPicksaw>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MartianPicksaw>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LihzahrdianPicksaw>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class MartianPicksaw : LihzahrdianPicksaw
    {
		public override string Texture => mod.Name + "/Items/Reskins/MartianPicksaw";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/MartianPicksaw");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Martian Picksaw");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Far out, man!'");
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<LihzahrdianPicksaw>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<BysmalPicksaw>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LihzahrdianPicksaw>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}