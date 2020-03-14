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
		public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'The blessing of Mother Nature herself'");

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/IndustrialBlossomPickaxe");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(0, 255, 200) };

		public override void SetDefaults()
		{
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
			item.rare = 11;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			if (!IndustrialPickaxes.CalamityLoaded)
				return;

			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("UeliaceBar"), 11); //TODO no string overloads
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}