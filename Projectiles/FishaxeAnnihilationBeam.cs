using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ModLoader;
using Terraria.ID;

namespace IndustrialPickaxes.Projectiles
{
	//SupremeNeoBlockDestroyerEXPrime
	public class FishaxeAnnihilationBeam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.Size = new Vector2(5);
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.alpha = 255;
			projectile.extraUpdates = 20;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.boss)
			{
				for (int i = 0; i < 49; i++)
					target.StrikeNPC(Main.DamageVar(damage), knockback, hitDirection, true);
			}
			else
			{
				for (int i = 0; i < 50; i++)
					Dust.NewDust(target.Center, target.width, target.height, 240);

				target.StrikeNPC(target.life + 2, knockback, hitDirection, true);
			}
		}

		public override void AI()
		{
			int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 0, 0, 107);
			Main.dust[dustIndex].noGravity = true;

			int explosionRadius = 3;

			int minTileX = (int)(projectile.position.X / 16f - explosionRadius);
			int maxTileX = (int)(projectile.position.X / 16f + explosionRadius);
			int minTileY = (int)(projectile.position.Y / 16f - explosionRadius);
			int maxTileY = (int)(projectile.position.Y / 16f + explosionRadius);

			if (minTileX < 0)
			{
				minTileX = 0;
			}
			if (maxTileX > Main.maxTilesX)
			{
				maxTileX = Main.maxTilesX;
			}
			if (minTileY < 0)
			{
				minTileY = 0;
			}
			if (maxTileY > Main.maxTilesY)
			{
				maxTileY = Main.maxTilesY;
			}

			bool canKillWalls = false;

			for (int x = minTileX; x <= maxTileX; x++)
			{
				for (int y = minTileY; y <= maxTileY; y++)
				{
					float diffX = Math.Abs(x - projectile.position.X / 16f);
					float diffY = Math.Abs(y - projectile.position.Y / 16f);

					double distance = Math.Sqrt(diffX * diffX + diffY * diffY);

					if (distance < explosionRadius && Main.tile[x, y]?.wall == 0)
					{
						canKillWalls = true;
						break;
					}
				}
			}

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
						bool canKillTile = true;

						if (Main.tile[i, j]?.active() == true)
						{
							canKillTile = true;
							if (canKillTile)
							{
								WorldGen.KillTile(i, j, false, false, true);

								if (!Main.tile[i, j].active() && Main.netMode != NetmodeID.SinglePlayer)
									NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, i, j);
							}
						}

						if (canKillTile)
						{
							for (int x = i - 1; x <= i + 1; x++)
							{
								for (int y = j - 1; y <= j + 1; y++)
								{
									if (Main.tile[x, y]?.wall > 0 && canKillWalls && WallLoader.CanExplode(x, y, Main.tile[x, y].wall))
									{
										WorldGen.KillWall(x, y, false);

										if (Main.tile[x, y]?.wall == 0 && Main.netMode != NetmodeID.SinglePlayer)
											NetMessage.SendData(MessageID.TileChange, -1, -1, null, 2, x, y);
									}
								}
							}
						}
					}
				}
			}

			AchievementsHelper.CurrentlyMining = false;
		}
	}
}