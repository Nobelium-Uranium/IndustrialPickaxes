using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Projectiles
{
	public class SweepingEdge : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 200;
			projectile.height = 200;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.alpha = 255; // Makes projectile invisible
			projectile.localNPCHitCooldown = -1;
		}

		public override void AI()
		{
			for (int k = 0; k < 10; k++)
			{
				SpawnDust(259); //TODO use DustID
				SpawnDust(DustID.AmberBolt);
			}
		}

		private void SpawnDust(int type)
		{
			int index = Dust.NewDust(projectile.Center, 0, 0, type);
			Main.dust[index].noGravity = true;
			Main.dust[index].velocity *= 10;
		}
	}
}