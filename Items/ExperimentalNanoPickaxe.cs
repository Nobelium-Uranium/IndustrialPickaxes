using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class ExperimentalNanoPickaxe : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/ExperimentalNanoPickaxe");

		public override void SetStaticDefaults() => Tooltip.SetDefault("Can mine Black Hardened Sludge\nUses precise strikes to smelt bars from ores, slow as a result\n'Overcharged with cybertech'");

		public override void SetDefaults()
		{
			base.SetDefaults();

			if (!IndustrialPickaxes.RedemptionLoaded)
				return;

			item.damage = 150;
			item.width = 56;
			item.height = 74;
			item.useTime = 9;
			item.useAnimation = 16;
			item.scale = 1.15f;
			item.pick = 300;
			item.knockBack = 4f;
			item.value = Item.sellPrice(5, 0, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.tileBoost += 3;
			item.UseSound = SoundID.Item15;
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.RedemptionLoaded)
				return;

			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("XeniumBar"));
			recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("KingCore"));
			recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("CyberPlating"), 20);
			recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("Cyberscrap"), 30);
			recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("Plutonium"), 25);
			recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("Mk3Capacitator"), 10);

			recipe.AddTile(IndustrialPickaxes.Redemption.TileType("SlayerFabricatorTile"));
			recipe.AddTile(IndustrialPickaxes.Redemption.TileType("XenoForgeTile"));

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class ExperimentalNanoPickaxeCreative : ExperimentalNanoPickaxe
	{
		public override string Texture => mod.Name + "/Items/Reskins/ExperimentalNanoPickaxeCreative";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/ExperimentalNanoPickaxeCreative");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Experimental Nano Pickaxe (Creative)");
			Tooltip.SetDefault("Can mine Black Hardened Sludge\nUses precise strikes to smelt bars from ores, slow as a result\n'Unfortunately, it can't mine lab tiles'");
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.RedemptionLoaded)
				return;

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<ExperimentalNanoPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExperimentalNanoPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExperimentalNanoPickaxeXenium>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class ExperimentalNanoPickaxeXenium : ExperimentalNanoPickaxe
	{
		public override string Texture => mod.Name + "/Items/Reskins/ExperimentalNanoPickaxeXenium";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/ExperimentalNanoPickaxeXenium");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prototype Xenium Pickaxe");
			Tooltip.SetDefault("Can mine Black Hardened Sludge\nUses precise strikes to smelt bars from ores, slow as a result\n'Purified Xenomite crystals power this prototype pickaxe, don't ask me how that works'");
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.RedemptionLoaded)
				return;

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<ExperimentalNanoPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExperimentalNanoPickaxeCreative>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExperimentalNanoPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}