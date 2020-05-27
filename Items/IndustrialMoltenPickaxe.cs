using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class IndustrialMoltenPickaxe : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/IndustrialMoltenPickaxe");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing Molten Pickaxe");
			Tooltip.SetDefault("Uses precise strikes to smelt bars from ores, slow as a result\n'Feel the heat!'");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.damage = 12;
			item.width = 40;
			item.height = 38;
			item.useTime = 24;
			item.useAnimation = 28;
			item.scale = 1.15f;
			item.pick = 100;
			item.knockBack = 2;
			item.value = 27000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
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
				target.AddBuff(BuffID.OnFire, 180);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(1))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6, 0f, 0f, 100, default, 2f);
				Main.dust[dust].noGravity = true;
			}
		}
	}
}