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
            DisplayName.SetDefault("Eclipsium Alloy");
            Tooltip.SetDefault("Can only be forged under the light of the dark sun");
        }
		public override void SetDefaults()
		{
			base.SetDefaults();
			item.width = 32;
			item.height = 32;
            item.maxStack = 99;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Cyan;
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
                recipe.AddIngredient(IndustrialPickaxes.Calamity.ItemType("AuricBar"));

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
	}
}