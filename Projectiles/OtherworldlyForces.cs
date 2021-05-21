using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Projectiles
{
	public class OtherworldlyForces : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.penetrate = -1;
			projectile.Size = new Vector2(20);
			projectile.timeLeft = 15;
			projectile.alpha = 255;

			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;

			projectile.extraUpdates = 20;
			projectile.ownerHitCheck = true;
		}
        public override bool? CanCutTiles()
        {
            return true;
        }
    }
}