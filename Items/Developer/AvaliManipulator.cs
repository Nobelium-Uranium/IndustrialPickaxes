using IndustrialPickaxes.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Developer
{
	public class AvaliManipulator : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Pickaxe power is dependant on what other industrial pickaxes you have\nShreds foes on contact, cannot critically hit\n'Full of fancy modified matter manipulator tech'");
		}

		public override void SetDefaults()
		{
			item.damage = 100;
			item.crit = -4;
			item.melee = true;
			item.noMelee = true;
			item.knockBack = 5;
			item.width = 44;
			item.height = 56;
			item.useTime = 2;
			item.useAnimation = 10;
			item.pick = 35;
			item.axe = 25;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = Item.sellPrice(platinum: 5);
			item.rare = 9;
			item.UseSound = SoundID.Item75;
			item.autoReuse = true;
			item.channel = true;
			item.shoot = ModContent.ProjectileType<OtherworldlyForces>();
			item.shootSpeed = 2f;
			if (!Main.dedServ)
			{
				item.GetGlobalItem<GlowmaskHelper>().glowTexture = mod.GetTexture("Glowmasks/AvaliManipulator");
			}
		}

		public override void UpdateInventory(Player player)
		{
			//Set the pickaxe power to the highest pickaxe power pickaxe in the inventory
			item.pick = player.inventory.Select(i => i.pick).DefaultIfEmpty()?.Max() ?? 0;

			if (item.pick < 65 && NPC.downedBoss2) //If that highest pickaxe power is below 65, and EoW or BoC is defeated, set the pickaxe power to 65
				item.pick = 65;
			else if (item.pick < 35) //If that highest pickaxe power is below 35 and BoC or EoW has not been defeated, set pickaxe power to 35
				item.pick = 35;
		}

		public override bool UseItem(Player player)
		{
			player.PickTile(Player.tileTargetX, Player.tileTargetY, item.pick);
			return true;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Glowmasks/AvaliManipulator");
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

		private Color[] itemNameCycleColors = new Color[]{
			new Color(246, 255, 255),
			new Color(255, 106, 0),
		};

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					float fade = Main.GameUpdateCount % 60 / 60f;
					int index = (int)(Main.GameUpdateCount / 60 % 2);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 2], fade);
				}
			}
		}
	}
}