﻿using IndustrialPickaxes.Items.Developer;
using IndustrialPickaxes.Items.Fishaxe;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace IndustrialPickaxes
{
	internal class IndustrialPlayer : ModPlayer
	{
		public override void OnEnterWorld(Player player)
		{
            Main.NewTextMultiline("Thanks for using Industrial Pickaxes!\nMOTD: Optimization Update Part 1 is live, there may be some bugs!\nAlways send suggestions and bug reports to the Discord which you can join by clicking 'Visit Mod Homepage' when looking at the description of the mod.", c: Color.Cyan);
			if (IndustrialPickaxes.Veinminer != null)
				Main.NewText("Since you're using Veinminer, make sure to hold the pickaxe while you veinmine ores, otherwise the rest of the ore will drop as normal.", Color.Cyan);
		}

		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ModContent.ItemType<DevNull>());
			items.Add(item);
		}

		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if (junk)
				return;

			if (worldLayer == 1 && player.ZoneBeach && Main.rand.NextBool(10))
			{
				if (power >= 100 && Main.rand.NextBool(50))
					caughtType = ModContent.ItemType<FishaxeRitual>();
				else
					caughtType = ModContent.ItemType<Fishaxe>();
			}
		}
	}
}