using IndustrialPickaxes.Items.Developer;
using IndustrialPickaxes.Items.Fishaxe;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes
{
	internal class IndustrialPlayer : ModPlayer
	{
        public Item holdingItem;

        public override void PreUpdate()
        {
            holdingItem = player.HeldItem;
        }

        public override void OnEnterWorld(Player player)
		{
            Main.NewTextMultiline("Thanks for using Industrial Pickaxes!\nMOTD: On hiatus for now, you'll know when I'm back.\nAlways send suggestions and bug reports to the Discord which you can join by clicking 'Visit Mod Homepage' when looking at the description of the mod.\nYou can also send bug reports to the github page using ModHelpers, if you've got that installed.", c: Color.Cyan);
			if (IndustrialPickaxes.Veinminer != null)
				Main.NewText("Since you're using Veinminer, make sure to hold the pickaxe while you veinmine ores, otherwise the rest of the ore will drop as normal.", Color.Cyan);
            if (Main.netMode != NetmodeID.SinglePlayer)
                Main.NewTextMultiline("INDUSTRIAL PICKAXES DOES NOT WORK IN MULTIPLAYER!\nHowever, you'll still be able to craft the pickaxes that this mod adds, they just won't be able to smelt anything.", true, Color.Red);
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

			if (liquidType == 0 && worldLayer == 1 && player.ZoneBeach && Main.rand.NextBool(20))
			{
				if (power >= 100 && Main.rand.NextBool(25))
					caughtType = ModContent.ItemType<FishaxeRitual>();
				else
					caughtType = ModContent.ItemType<Fishaxe>();
			}
		}
	}
}