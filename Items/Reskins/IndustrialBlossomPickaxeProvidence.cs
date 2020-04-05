using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Reskins
{
	public class IndustrialBlossomPickaxeProvidence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Profaned Shard Pickaxe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'It radiates immense amounts of divine heat'");
		}

		public override void SetDefaults()
		{
			if (IndustrialPickaxes.CalamityLoaded)
			{
				item.damage = 90;
				item.melee = true;
				item.width = 82;
				item.height = 78;
				item.useTime = 10;
				item.useAnimation = 14;
				item.pick = 275;
				item.useStyle = 1;
				item.knockBack = 7.5f;
				item.value = Item.sellPrice(0, 24, 0, 0);
				item.rare = 11;
				item.UseSound = SoundID.Item1;
				item.autoReuse = true;
				item.useTurn = true;
				if (!Main.dedServ)
				{
					item.GetGlobalItem<GlowmaskHelper>().glowTexture = mod.GetTexture("Glowmasks/Reskins/IndustrialBlossomPickaxeProvidence");
				}
			}
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Glowmasks/Reskins/IndustrialBlossomPickaxeProvidence");
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

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					line2.overrideColor = new Color(0, 255, 200);
				}
			}
		}

		public override void AddRecipes()
		{
			if (IndustrialPickaxes.CalamityLoaded)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddTile(TileID.DyeVat);
				recipe.SetResult(ModContent.ItemType<ViridescentBlossomPickaxe>());
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<ViridescentBlossomPickaxe>());
				recipe.AddTile(TileID.DyeVat);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}