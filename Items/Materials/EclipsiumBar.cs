using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Materials
{
	public class EclipsiumBar : GlowmaskItem
	{
		private class EclipseRecipe : ModRecipe
		{
			public EclipseRecipe(Mod mod) : base(mod)
			{
			}

			public override bool RecipeAvailable() => Main.eclipse;
		}

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/EclipsiumBar");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(0, 0, 0), new Color(255, 170, 0) };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eclipsium Catalyst");
            Tooltip.SetDefault("Only craftable during a Solar Eclipse\n'A brilliant alloy of the dark sun'");
        }
		public override void SetDefaults()
		{
			base.SetDefaults();
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.rare = ItemRarityID.Cyan;
		}

		public override void AddRecipes()
		{
			EclipseRecipe recipe = new EclipseRecipe(mod);

			if (IndustrialPickaxes.RedemptionLoaded)
				recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("XeniumBar"), 20);

			if (IndustrialPickaxes.AALoaded)
			{
				recipe.AddIngredient(IndustrialPickaxes.AncientsAwakened.ItemType("DaybreakIncinerite"), 20);
				recipe.AddIngredient(IndustrialPickaxes.AncientsAwakened.ItemType("EventideAbyssium"), 20);
			}

			if (IndustrialPickaxes.CalamityLoaded)
			{
				if (IndustrialPickaxes.Calamity.GetItem("AuricBar") != null)
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("AuricBar"), 20);
				else
				{
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("BarofLife"), 20);
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("Phantoplasm"), 20);
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("NightmareFuel"), 20);
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("EndothermicEnergy"), 20);
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("DarksunFragment"), 20);
					recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("HellcasterFragment"), 20);
				}
			}

			if (IndustrialPickaxes.SoALoaded)
				recipe.AddIngredient(IndustrialPickaxes.SacredTools.ItemType("MoonstoneBar"), 20);

			if (IndustrialPickaxes.ThoriumLoaded)
				recipe.AddIngredient(IndustrialPickaxes.Thorium.ItemType("TerrariumCore"), 20);
			else
			{
				recipe.AddIngredient(ItemID.HallowedBar, 20);
				recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
			}

			recipe.AddIngredient(ItemID.LunarBar, 20);

			if (IndustrialPickaxes.CalamityLoaded)
				recipe.AddTile(IndustrialPickaxes.Calamity.TileType("DraedonsForge"));
			else if (IndustrialPickaxes.SoALoaded)
				recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("LunarAltar"));
			else
				recipe.AddTile(TileID.LunarCraftingStation);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}