using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Projectiles
{
	public class LaserDrillBolt : ModProjectile
	{
		public override void SetStaticDefaults() => DisplayName.SetDefault("hax"); // TODO rename plz

		public override void SetDefaults()
		{
			projectile.width = 1;
			projectile.height = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.alpha = 255; // makes projectile invisible
			projectile.extraUpdates = 20;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			MineTiles(Main.player[projectile.owner]);

			//Spawn 10 dusts
			for (int k = 0; k < 10; k++)
				Dust.NewDust(projectile.Center, 0, 0, 226); // TODO use DustID

			SpawnGore();

			projectile.Kill();

			return base.OnTileCollide(oldVelocity);
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (!target.boss)
			{
				// Spawn 50 dusts
				for (int k = 0; k < 50; k++)
					Dust.NewDust(target.Center, target.width, target.height, 240); // TODO use DustID

				// Play a sound
				Main.PlaySound(SoundID.NPCDeath15, target.position);

				// Strike the npc to deal the amount of damage as its life
				target.StrikeNPC(target.life, 0, 0, true);
			}
		}

		public override void AI()
		{
			int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 0, 0, 107); // TODO use DustID
			Main.dust[dustIndex].noGravity = true;
		}

		private void MineTiles(Player player)
		{
			int explosionRadius = 2;

			int minTileX = (int)(projectile.position.X / 16f - explosionRadius);
			int maxTileX = (int)(projectile.position.X / 16f + explosionRadius);
			int minTileY = (int)(projectile.position.Y / 16f - explosionRadius);
			int maxTileY = (int)(projectile.position.Y / 16f + explosionRadius);

			if (minTileX < 0)
				minTileX = 0;

			if (maxTileX > Main.maxTilesX)
				maxTileX = Main.maxTilesX;

			if (minTileY < 0)
				minTileY = 0;

			if (maxTileY > Main.maxTilesY)
				maxTileY = Main.maxTilesY;

			AchievementsHelper.CurrentlyMining = true;

			for (int i = minTileX; i <= maxTileX; i++)
			{
				for (int j = minTileY; j <= maxTileY; j++)
				{
					float diffX = Math.Abs(i - projectile.position.X / 16f);
					float diffY = Math.Abs(j - projectile.position.Y / 16f);
					double distanceToTile = Math.Sqrt(diffX * diffX + diffY * diffY);

					if (distanceToTile < explosionRadius)
					{
						if (Main.tile[i, j]?.active() == true)
						{
							player.PickTile(i, j, 230);

							if (Main.netMode != 0)
								NetMessage.SendData(17, -1, -1, null, 0, i, j);
						}
					}
				}
			}

			AchievementsHelper.CurrentlyMining = false;
		}

		private void SpawnGore()
		{
			Vector2 gorePosition = new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f);
			int gore = Gore.NewGore(gorePosition, default, Main.rand.Next(61, 64), 1f);

			int goreIndex = gore;
			Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
			Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

			goreIndex = gore;
			Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
			Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

			goreIndex = gore;
			Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
			Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;

			goreIndex = gore;
			Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
			Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
		}
	}
}