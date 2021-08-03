using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class SteampunkExcavator : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/SteampunkExcavator");

		public override void SetStaticDefaults() => Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Highly experimental'\n'Will likely blow up in your face if you strike a surface too hard'");

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.damage = 20;
			item.width = 42;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 30;
			item.pick = 180;
			item.knockBack = 5;
			item.value = Item.buyPrice(gold: 10);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
		}
	}

	public class MechanicalExcavator : SteampunkExcavator
	{
		public override string Texture => mod.Name + "/Items/Reskins/MechanicalExcavator";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/MechanicalExcavator");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Excavator");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Causes minor tremors... and mayhem'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<SteampunkExcavator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SteampunkExcavator>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}