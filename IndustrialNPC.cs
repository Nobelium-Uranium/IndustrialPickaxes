using IndustrialPickaxes.Buffs;
using IndustrialPickaxes.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes
{
	internal class IndustrialNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public override bool CloneNewInstances => true;

		private int LastHitByRejuvenator;
		private int LastHitByFlarium;

		public bool OnFrostburn;

		public override void ResetEffects(NPC npc) => OnFrostburn = false;

		public override void SetDefaults(NPC npc) => npc.buffImmune[ModContent.BuffType<OnFrostburn>()] = npc.buffImmune[BuffID.OnFire];

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (OnFrostburn)
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 135, 0, Main.rand.Next(2, 5), 100, default, 2f);

				if (Main.rand.Next(4) < 5) // 4 out of 5 chance
					Main.dust[dust].noGravity = true;

				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;

				npc.lifeRegen -= 8;
			}

			if (npc.oiled)
			{
				if (OnFrostburn)
					npc.lifeRegen -= 20;
			}
		}

		public override bool PreAI(NPC npc)
		{
			if (npc.HasBuff(BuffID.OnFire) && npc.HasBuff(ModContent.BuffType<OnFrostburn>()))
				npc.DelBuff(ModContent.BuffType<OnFrostburn>());

			return base.PreAI(npc);
		}

		public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			if (item.type == ModContent.ItemType<OreRejuvenator>())
				LastHitByRejuvenator = 10;

			if (item.type == ModContent.ItemType<SolusFlariumPickaxe>())
				LastHitByFlarium = 10;
		}

		public override void AI(NPC npc)
		{
			if (LastHitByRejuvenator > 0)
				LastHitByRejuvenator -= 1;

			if (LastHitByFlarium > 0)
				LastHitByFlarium -= 1;
		}

		public override void NPCLoot(NPC npc)
		{
			int usedWeapon = Main.LocalPlayer.HeldItem.type;

			if (usedWeapon == ModContent.ItemType<OreRejuvenator>() && !npc.friendly && npc.lifeMax > 5 && !npc.SpawnedFromStatue && LastHitByRejuvenator > 0)
			{
				int DroppedGem = Main.rand.Next(7);

				switch (DroppedGem)
				{
					case 0:
						Item.NewItem(npc.getRect(), ItemID.Amber);
						break;

					case 1:
						Item.NewItem(npc.getRect(), ItemID.Diamond);
						break;

					case 2:
						Item.NewItem(npc.getRect(), ItemID.Ruby);
						break;

					case 3:
						Item.NewItem(npc.getRect(), ItemID.Emerald);
						break;

					case 4:
						Item.NewItem(npc.getRect(), ItemID.Sapphire);
						break;

					case 5:
						Item.NewItem(npc.getRect(), ItemID.Topaz);
						break;

					case 6:
						Item.NewItem(npc.getRect(), ItemID.Amethyst);
						break;
				}

				Main.PlaySound(SoundID.NPCDeath6, npc.position);

				int goreIndex = Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);

				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

				goreIndex = Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);

				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

				goreIndex = Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);

				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;

				goreIndex = Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);

				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			}

			if (IndustrialPickaxes.SoALoaded && usedWeapon == ModContent.ItemType<SolusFlariumPickaxe>() && LastHitByFlarium > 0 && (npc.type == IndustrialPickaxes.SacredTools.NPCType("Flarian") || npc.type == IndustrialPickaxes.SacredTools.NPCType("FestiveFuria") || npc.type == IndustrialPickaxes.SacredTools.NPCType("WingedFuria") || npc.type == IndustrialPickaxes.SacredTools.NPCType("FuriousSlime") || npc.type == IndustrialPickaxes.SacredTools.NPCType("FlareElemental")))
			{
				Item.NewItem(npc.getRect(), IndustrialPickaxes.SacredTools.ItemType("FlariumItem"));

				Main.PlaySound(SoundID.NPCDeath6, npc.position);

				int goreIndex = Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default, Main.rand.Next(61, 64), 1f);

				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

				goreIndex = Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default, Main.rand.Next(61, 64), 1f);

				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

				goreIndex = Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default, Main.rand.Next(61, 64), 1f);

				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;

				goreIndex = Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default, Main.rand.Next(61, 64), 1f);

				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			}

			/*if (npc.type == NPCID.SpikedJungleSlime)
			{
				if (Main.rand.Next(20) == 0)
					Item.NewItem(npc.getRect(), ItemID.JungleRose);
			}*/
		}
	}
}