using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class SolusFlariumPickaxe : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/SolusFlariumPickaxe");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(253, 143, 76), new Color(253, 143, 76) };

		public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\nThis isn't a scythe I swear\n'Furiously forged with the blaze of a thousand flames'");

		public override void SetDefaults()
		{
			if (!IndustrialPickaxes.SoALoaded)
				return;

			item.damage = 100;
			item.width = 82;
			item.height = 78;
			item.useTime = 9;
			item.useAnimation = 14;
			item.pick = 270;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.tileBoost += 8;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.SoALoaded)
				return;

			ModRecipe recipe = new ModRecipe(mod); // TODO dont use string overloads
			recipe.AddIngredient(IndustrialPickaxes.SacredTools.ItemType("FlariumItem"), 75);
			recipe.AddIngredient(IndustrialPickaxes.SacredTools.ItemType("DraconiumAlloy"), 15);
			recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("FlameAnvil"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class SolusFlariumPickaxeCernium : SolusFlariumPickaxe
	{
		public override string Texture => mod.Name + "/Items/Reskins/SolusFlariumPickaxeCernium";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/SolusFlariumPickaxeCernium");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(115, 204, 219), new Color(115, 204, 219) };

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryo Cernium Pickaxe");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'A remnant of a frozen wasteland'");
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.SoALoaded)
				return;

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<SolusFlariumPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SolusFlariumPickaxeAsthraltite>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SolusFlariumPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class SolusFlariumPickaxeAsthraltite : SolusFlariumPickaxe
	{
		public override string Texture => mod.Name + "/Items/Reskins/SolusFlariumPickaxeAsthraltite";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/SolusFlariumPickaxeAsthraltite");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(185, 0, 67), new Color(185, 0, 67) };

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mirage Asthraltite Pickaxe");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Lore friendly? As if! ...Well, it's actually just illusion magic.' -Neil");
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.SoALoaded)
				return;

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<SolusFlariumPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SolusFlariumPickaxeCernium>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SolusFlariumPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}