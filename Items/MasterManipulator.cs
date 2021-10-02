using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class MasterManipulator : IndustrialPickaxe
	{
		//public override bool Autoload(ref string name) => IndustrialPickaxes.EALoaded;
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/MasterManipulator");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(186, 0, 67) };

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Manipulates matter precisely to smelt bars from ores, slow as a result\n'The Cultivator's gift that can manipulate everything that matters'");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.width = 20;
			item.height = 20;
			if (IndustrialPickaxes.EALoaded)
			{
				item.CloneDefaults(ItemID.LaserDrill);
				item.pick = 300;
				item.damage = 40;
				item.useTime = 9;
				item.axe = 0;
				item.knockBack = 6f;
				item.value = Item.sellPrice(0, 20, 0, 0);
				item.rare = ItemRarityID.Lime;
				item.tileBoost += 20;
				item.shoot = IndustrialPickaxes.ElementsAwoken.ProjectileType("MatterManipulator");
				item.glowMask = -1;
			}
		}

		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			Texture2D texture = mod.GetTexture("Items/MasterManipulatorIcon");
			spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale / 2, SpriteEffects.None, 0f);
			return false;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.noBuilding)
				return false;
			return true;
		}

		public override void AddRecipes()
		{
			if (IndustrialPickaxes.EALoaded)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(IndustrialPickaxes.ElementsAwoken.ItemType("DiscordantBar"), 23);
				recipe.AddIngredient(IndustrialPickaxes.ElementsAwoken.ItemType("ChaoticFlare"), 12);
				recipe.AddIngredient(ItemID.LaserDrill);
				recipe.AddTile(IndustrialPickaxes.ElementsAwoken.TileType("ChaoticCrucible"));
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}