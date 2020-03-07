using IndustrialPickaxes.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Fishaxe
{
	//CrimsSupremeDimensionObliteratingFishaxeOfYeehawEXV2UltraTimelineDestructionEdition no
	public class AscendedFishaxe : IndustrialPickaxe
	{
		public override void SetStaticDefaults() => Tooltip.SetDefault("admin hax\n<right> to fire a constant annihilation beam\nNon-boss enemies that touch the beam turn into ash\n'NOW you mine laser sharks.'");

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.damage = 99999;
			item.crit = 96;
			item.width = 40;
			item.height = 40;
			item.useTime = 2;
			item.useAnimation = 5;
			item.pick = 1000000;
			item.axe = 200000;
			item.knockBack = 9001;
			item.value = 0;
			item.rare = 11;
			item.shootSpeed = 20f;
			item.tileBoost += 100;
			item.UseSound = SoundID.Item1;
		}

		public override Color? GetAlpha(Color lightColor) => Color.White; // Make the item's sprite not affected by light

		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Glowmasks/FishaxeAura");
			Vector2 position = item.position - Main.screenPosition + new Vector2(item.width / 2, item.height - texture.Height * 0.5f + 2f);
			// We redraw the item's sprite 4 times, each time shifted 2 pixels on each direction, using Main.DiscoColor to give it the color changing effect
			for (int i = 0; i < 4; i++)
			{
				Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
				spriteBatch.Draw(texture, position + offsetPositon, null, Main.DiscoColor, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
			}
			// Return true so the original sprite is drawn right after
			return true;
		}

		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			Texture2D texture = mod.GetTexture("Glowmasks/FishaxeAura");

			for (int i = 0; i < 4; i++)
			{
				Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
				spriteBatch.Draw(texture, position + offsetPositon, null, Main.DiscoColor, 0, origin, scale, SpriteEffects.None, 0f);
			}

			return true;
		}

		public override bool AltFunctionUse(Player player) => true;

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.shoot = ModContent.ProjectileType<FishaxeAnnihilationBeam>();
				item.pick = 0;
				item.axe = 0;
				item.useTime = 1;
				item.UseSound = SoundID.Item33;
				item.noMelee = true;
			}
			else
			{
				item.shoot = 0;
				item.pick = 1000000;
				item.axe = 200000;
				item.useTime = 2;
				item.UseSound = SoundID.Item1;
				item.noMelee = false;
			}
			return base.CanUseItem(player);
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			for (int i = 0; i < 49; i++)
				target.StrikeNPC(Main.DamageVar(damage), knockBack, player.direction, true);
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			//for runs faster than foreach
			for (int tooltip = 0; tooltip < tooltips.Count; tooltip++)
			{
				TooltipLine line = tooltips[tooltip];

				if (line.mod == "Terraria" && line.Name == "ItemName")
					line.overrideColor = Main.DiscoColor;
			}
		}
	}
}