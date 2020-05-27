using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	//TODO use new system
	public class IndustrialMoltenPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing Molten Pickaxe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Feel the heat!'");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.width = 40;
			item.height = 38;
			item.useTime = 24;
			item.useAnimation = 28;
			item.scale = 1.15f;
			item.pick = 100;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2;
			item.value = 27000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			if (!Main.dedServ)
			{
				item.GetGlobalItem<GlowmaskHelper>().glowTexture = mod.GetTexture("Glowmasks/IndustrialMoltenPickaxe");
			}
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Glowmasks/IndustrialMoltenPickaxe");
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
			recipe.AddIngredient(ItemID.HellstoneBar, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (Main.rand.Next(10) == 0)
			{
				target.AddBuff(BuffID.OnFire, 180);
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			base.MeleeEffects(player, hitbox);
			if (Main.rand.NextBool(1))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6, 0f, 0f, 100, default, 2f);
				Main.dust[dust].noGravity = true;
			}
		}
	}
}