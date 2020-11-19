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
            Main.NewTextMultiline("Thanks for using Industrial Pickaxes!\n" +
                "MOTD: On hiatus for now, you'll know when I'm back.\n" +
                "If you have a bug to report, install ModHelpers if you haven't already!\n" +
                "To report a bug, click the MH icon to the top left of the inventory and look for Industrial Pickaxes.\n" +
                "(NOTE: If you can't find the MH icon, you may have disabled the control panel, check ModHelpers' config to reenable it.)\n" +
                "From there you can title the bug you're reporting and the details associated with it.\n" +
                "Before submitting your bug report, check Industrial Pickaxe's github page to see if there's already a report for it.\n" +
                "For further information, you can join the discord server via the mod hompage.", c: Color.Cyan);
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