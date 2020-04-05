using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Reskins
{
	public class IndustrialLunarPickaxeRagnarok : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reality Breaker Pickaxe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'The earth trembles...'");
		}

		public override void SetDefaults()
		{
			item.damage = 80;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 11;
			item.useAnimation = 17;
			item.scale = 1.15f;
			item.pick = 225;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.5f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Red;
			item.tileBoost += 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			if (!Main.dedServ)
			{
				item.GetGlobalItem<GlowmaskHelper>().glowTexture = mod.GetTexture("Glowmasks/Reskins/IndustrialLunarPickaxeRagnarok");
			}
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Glowmasks/Reskins/IndustrialLunarPickaxeRagnarok");
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
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<IndustrialLunarPickaxe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<IndustrialLunarPickaxe>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}