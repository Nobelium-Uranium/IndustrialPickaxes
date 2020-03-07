using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class MasterManipulator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Master Manipulator"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Manipulates matter precisely to smelt bars from ores, slow as a result\n'The Cultivator's gift that can manipulate everything that matters'");
		}

		public override void SetDefaults()
		{
			if (IndustrialPickaxes.EALoaded)
			{
				item.CloneDefaults(ItemID.LaserDrill);
				item.damage = 40;
				item.width = 34;
				item.height = 40;
				item.useTime = 9;
				item.pick = 300;
				item.axe = 0;
				item.knockBack = 6f;
				item.value = Item.sellPrice(0, 20, 0, 0);
				item.rare = 7;
				item.tileBoost += 20;
				item.shoot = IndustrialPickaxes.ElementsAwoken.ProjectileType("MatterManipulator");
				item.glowMask = -1;
			}
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Glowmasks/MasterManipulator");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}

		public override void AddRecipes()
		{
			if (IndustrialPickaxes.EALoaded)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(IndustrialPickaxes.ElementsAwoken.ItemType("DiscordantBar"), 23);
				recipe.AddIngredient(IndustrialPickaxes.ElementsAwoken.ItemType("ChaoticFlare"), 12);
				recipe.AddIngredient(ItemID.LaserDrill, 2);
				recipe.AddTile(IndustrialPickaxes.ElementsAwoken.TileType("ChaoticCrucible"));
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}