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
            Main.NewTextMultiline("Thank you for using Industrial Pickaxes!\n" +
                "MOTD: A rewrite to fix multiplayer issues is still in the works, please be patient.\n" +
                "If you have a bug to report, use ModHelper's built in report feature!\n" +
                "For further information about Crimsanity's mods, you can join the discord server via the mod hompage.", c: Color.Cyan);
			if (IndustrialPickaxes.Veinminer == null)
				Main.NewText("I highly recommend using the Veinminer mod with this, by the way!", Color.Cyan);
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

			if (liquidType == 0 && worldLayer == 1 && player.ZoneBeach && Main.rand.NextBool(30))
			{
				if (power >= 100 && Main.rand.NextBool(10))
					caughtType = ModContent.ItemType<FishaxeRitual>();
				else
					caughtType = ModContent.ItemType<Fishaxe>();
			}
		}
	}
}