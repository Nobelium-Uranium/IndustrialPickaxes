using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Projectiles
{
	public class SweepingEdge : ModProjectile
	{
        private bool FirstTick;

		public override void SetDefaults()
		{
            projectile.Size = new Vector2(200);
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.alpha = 255;
            projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 5;
		}

        public override bool PreAI()
        {
            if (!FirstTick && projectile.ai[0] != 0)
            {
                FirstTick = true;
                projectile.Size = new Vector2(200) * (1 + projectile.ai[0]);
                projectile.position += new Vector2(200) * (.5f + projectile.ai[0] / 2);
            }
            return base.PreAI();
        }

        public override void AI()
		{
			for (int k = 0; k < 10; k++)
			{
				SpawnDust(259);
				SpawnDust(DustID.AmberBolt);
			}
		}

		private void SpawnDust(int type)
		{
			int index = Dust.NewDust(projectile.Center, 0, 0, type);
			Main.dust[index].noGravity = true;
			Main.dust[index].velocity *= 10 * (1 + projectile.ai[0]);
		}
	}
}