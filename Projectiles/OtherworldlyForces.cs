using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Projectiles
{
	public class OtherworldlyForces : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.melee = true;
			projectile.damage = 100;
			projectile.knockBack = 5f;
			projectile.penetrate = -1;
			projectile.Size = new Vector2(50);
			projectile.timeLeft = 15;
			projectile.alpha = 255;

			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;

			projectile.extraUpdates = 20;
			projectile.ownerHitCheck = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 0;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.immune[projectile.owner] = 0;

			/*crit = (projectile.ai[1]) switch
			{
				0 => false,
				_ => true,
			};*/
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.immuneTime = 0;

			/*crit = (projectile.ai[1]) switch
			{
				0 => false,
				_ => true,
			};*/
		}

		public override void ModifyHitPvp(Player target, ref int damage, ref bool crit)
		{
			target.immuneTime = 0;

			/*crit = (projectile.ai[1]) switch
			{
				0 => false,
				_ => true,
			};*/
		}
	}
}