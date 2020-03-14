using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class OreRejuvenator : GlowmaskItem
	{
		public override void SetStaticDefaults() => Tooltip.SetDefault("Makes for a decent weapon\nPoofs slain enemies into gems\nEmbedded gems drop triple the amount, also sometimes dropping a different random gem as a bonus\n'Lives on the line, winner takes all, ready or not, let's begin!'");

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/OreRejuvenator");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(255, 75, 255) };

		public override void SetDefaults()
		{
			base.SetDefaults();

			item.damage = 75;
			item.melee = true;
			item.width = 82;
			item.height = 78;
			item.useTime = 8;
			item.useAnimation = 30;
			item.pick = 200;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 2, 75, 0);
			item.rare = 11;
			item.tileBoost--;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.DeathSickle);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.CrystalShard, 5);

			recipe.AddRecipeGroup("IndustrialPickaxes:LargeGem");

			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddTile(TileID.GemLocks);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}