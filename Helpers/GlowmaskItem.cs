using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Helpers
{
	public abstract class GlowmaskItem : ModItem
	{
		public virtual Texture2D GlowmaskTexture => null;

		public virtual Color[] ItemNameCycleColors => null;

		public override void SetDefaults()
		{
			if (!Main.dedServ && GlowmaskTexture != null)
				item.GetGlobalItem<GlowmaskHelper>().glowTexture = GlowmaskTexture;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			if (GlowmaskTexture != null)
			{
				spriteBatch.Draw
				(
					GlowmaskTexture,
					new Vector2
					(
						item.position.X - Main.screenPosition.X + item.width * 0.5f,
						item.position.Y - Main.screenPosition.Y + item.height - GlowmaskTexture.Height * 0.5f + 2f
					),
					new Rectangle(0, 0, GlowmaskTexture.Width, GlowmaskTexture.Height),
					Color.White,
					rotation,
					GlowmaskTexture.Size() * 0.5f,
					scale,
					SpriteEffects.None,
					0f
				);
			}
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (ItemNameCycleColors != null)
			{
				//foreach (TooltipLine line in tooltips) - for peforms faster
				for (int tooltip = 0; tooltip < tooltips.Count; tooltip++)
				{
					TooltipLine line = tooltips[tooltip];

					if (line.mod == "Terraria" && line.Name == "ItemName")
					{
						float fade = Main.GameUpdateCount % 60 / 60f;
						int index = (int)(Main.GameUpdateCount / 60 % ItemNameCycleColors.Length);
						line.overrideColor = Color.Lerp(ItemNameCycleColors[index], ItemNameCycleColors[(index + 1) % ItemNameCycleColors.Length], fade);
					}
				}
			}
		}
	}
}