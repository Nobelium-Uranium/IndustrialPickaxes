using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	// TODO: Clean up and fix smelting for SoA behavior
	public class MasterManipulator : IndustrialPickaxe
	{
		private string PickaxePower = string.Empty;

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/MasterManipulator"); // TODO: Figure out why glowmask isn't showing up while being used

		public override Color[] ItemNameCycleColors => new Color[] { new Color(186, 0, 67) };

		public override void SetStaticDefaults()
		{
			if (IndustrialPickaxes.SoALoaded) // Had to get a little creative since pickaxe power is irrelevant for the SoA version
				PickaxePower = "300% pickaxe power\n";

			Tooltip.SetDefault(PickaxePower + "Manipulates matter precisely to smelt bars from ores, slow as a result\n'The Cultivator's gift that can manipulate everything that matters'");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			if (IndustrialPickaxes.SoALoaded)
			{
				item.noMelee = true;
				item.useTime = 10;
				item.useAnimation = 10;
				item.rare = ItemRarityID.Purple;
				item.autoReuse = true;
				item.shoot = IndustrialPickaxes.SacredTools.ProjectileType("AAAA");
				item.shootSpeed = 1f;
				item.useStyle = ItemUseStyleID.HoldingOut;
			}
			else if (IndustrialPickaxes.EALoaded)
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
			Texture2D texture = mod.GetTexture("Items/MasterManipulatorINV");
			spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale / 2, SpriteEffects.None, 0f);
			return false;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.noBuilding)
				return false;
			
			if (IndustrialPickaxes.SoALoaded)
			{
				float distance = Vector2.Distance(player.Center, Main.MouseWorld);

				if (distance > 160) 
					return false;

				int i = (int)(Main.MouseWorld.X / 16);
				int j = (int)(Main.MouseWorld.Y / 16);
				int tileX, tileY;

				for (int y = -2; y <= 2; y++)
				{
					for (int x = -2; x <= 2; x++)
					{
						tileX = i + x;
						tileY = j + y;

						if (!Main.tile[tileX, tileY].active() || !WorldGen.InWorld(tileX, tileY, 0))
							continue;

						player.PickTile(tileX, tileY, 300);
					}
				}
			}

			return true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (IndustrialPickaxes.SoALoaded)
			{
				TooltipLine line = new TooltipLine(mod, "MatterManipulator", "[Industrial Sacred Tool]")
				{
					overrideColor = new Color(186, 0, 67)
				};

				tooltips.Add(line);
			}
		}

		public override void AddRecipes()
		{
			if (IndustrialPickaxes.SoALoaded)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(IndustrialPickaxes.SacredTools.ItemType("MatterManipulator"));
				recipe.AddIngredient(IndustrialPickaxes.SacredTools.ItemType("TabletOfWeaponMastery"));
				recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("LunarAltar"));
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
			else if (IndustrialPickaxes.EALoaded)
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