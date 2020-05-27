using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class IndustrialPicksaw : IndustrialPickaxe
	{
		public class PicksawRecipeHelper : ModRecipe
		{
			public PicksawRecipeHelper(Mod mod) : base(mod) { }

			public override bool RecipeAvailable() => NPC.downedGolemBoss;
		}

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/IndustrialPicksaw");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lihzahrdian Picksaw");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'An ancient masterpiece'");
		}

		public override void SetDefaults()
		{
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

			if (!Main.dedServ)
				item.GetGlobalItem<GlowmaskHelper>().glowTexture = mod.GetTexture("Glowmasks/IndustrialPicksaw");
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
}