using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Materials
{
	public class EclipsiumBar : GlowmaskItem
	{
		public override void SetStaticDefaults() => Tooltip.SetDefault("Only craftable during a Solar Eclipse\n'A brilliant alloy of the dark sun'");

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/EclipsiumBar");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(0, 0, 0), new Color(255, 170, 0) };

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 9;
		}

		public override void AddRecipes()
		{
			EclipseRecipe recipe = new EclipseRecipe(mod);

			if (IndustrialPickaxes.RedemptionLoaded)
				recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("XeniumBar"));

			if (IndustrialPickaxes.AALoaded)
			{
				recipe.AddIngredient(IndustrialPickaxes.AncientsAwakened.ItemType("DaybreakIncinerite"));
				recipe.AddIngredient(IndustrialPickaxes.AncientsAwakened.ItemType("EventideAbyssium"));
			}

			if (IndustrialPickaxes.CalamityLoaded)
			{
				if (IndustrialPickaxes.Calamity.GetItem("AuricBar") != null)
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("AuricBar"));
				else
				{
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("BarofLife"));
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("Phantoplasm"));
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("NightmareFuel"));
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("EndothermicEnergy"));
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("DarksunFragment"));
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("HellcasterFragment"));
				}
			}

			if (IndustrialPickaxes.SoALoaded)
				recipe.AddIngredient(IndustrialPickaxes.SacredTools.ItemType("MoonstoneBar"));

			if (IndustrialPickaxes.ThoriumLoaded)
				recipe.AddIngredient(IndustrialPickaxes.Thorium.ItemType("TerrariumCore"));
			else
			{
				recipe.AddIngredient(ItemID.HallowedBar);
				recipe.AddIngredient(ItemID.ChlorophyteBar);
			}

			recipe.AddIngredient(ItemID.LunarBar);

			if (IndustrialPickaxes.CalamityLoaded)
				recipe.AddTile(IndustrialPickaxes.Calamity.TileType("DraedonsForge"));
			else if (IndustrialPickaxes.SoALoaded)
				recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("LunarAltar"));
			else
				recipe.AddTile(TileID.LunarCraftingStation);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		private class EclipseRecipe : ModRecipe
		{
			public EclipseRecipe(Mod mod) : base(mod)
			{
			}

			public override bool RecipeAvailable() => Main.eclipse;
		}
	}
}