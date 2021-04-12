using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class ViridescentBlossomPickaxe : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/ViridescentBlossomPickaxe");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(0, 255, 200) };

		public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'The blessing of Mother Nature herself'");

		public override void SetDefaults()
        {
            base.SetDefaults();

            if (!IndustrialPickaxes.CalamityLoaded)
				return;

			item.damage = 90;
			item.width = 82;
			item.height = 78;
			item.useTime = 10;
			item.useAnimation = 14;
			item.pick = 275;
			item.knockBack = 7.5f;
			item.value = Item.sellPrice(0, 24, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.CalamityLoaded)
				return;

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("UeliaceBar"), 11);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class ProfanedShardPickaxe : ViridescentBlossomPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/ProfanedShardPickaxe");

		public override string Texture => mod.Name + "/Items/Reskins/ProfanedShardPickaxe";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Profaned Shard Pickaxe");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'It radiates immense amounts of divine heat'");
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.CalamityLoaded)
				return;
			
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<ViridescentBlossomPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ViridescentBlossomPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}