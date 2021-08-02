using IndustrialPickaxes.Helpers;
using IndustrialPickaxes.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Developer
{
	public class AvaliManipulator : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/AvaliManipulator");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(246, 255, 255), new Color(255, 106, 0) };

		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("A.C.D.E.");
			Tooltip.SetDefault("Pickaxe and axe power adapts to your other tools\nSmelts all ores!\n'Apparatus for Construction and Destruction of Elements'\n'Or simply, in layman's terms, a Matter Manipulator'");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.width = 20;
			item.height = 20;
			item.useTime = 2;
			item.useAnimation = 10;
			item.pick = 35;
			item.axe = 7;
            item.tileBoost += 5;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.rare = ItemRarityID.Cyan;
			item.autoReuse = true;
            item.channel = true;
            item.useTurn = false;
			item.shoot = ModContent.ProjectileType<OtherworldlyForces>();
			item.shootSpeed = 2f;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = mod.GetTexture("Items/Developer/AvaliManipulatorIcon");
            spriteBatch.Draw(texture, position, null, Color.White, 0, origin, scale / 2, SpriteEffects.None, 0f);
            return false;
        }

        public override void UpdateInventory(Player player)
		{
			//Set the pickaxe power to the highest pickaxe power pickaxe in the inventory
			item.pick = player.inventory.Where(i => i.type != ModContent.ItemType<AvaliManipulator>() && i.type != ModContent.ItemType<VioletThaumaturgy>()).Select(i => i.pick).DefaultIfEmpty()?.Max() ?? 0;

			if (item.pick < 65 && NPC.downedBoss2) //If that highest pickaxe power is below 65, and EoW or BoC is defeated, set the pickaxe power to 65
				item.pick = 65;
			else if (item.pick < 35) //If that highest pickaxe power is below 35 and BoC or EoW has not been defeated, set pickaxe power to 35
				item.pick = 35;

            item.axe = player.inventory.Where(i => i.type != ModContent.ItemType<AvaliManipulator>()).Select(i => i.axe).DefaultIfEmpty()?.Max() ?? 0;
            
            if (item.axe < 7)
                item.axe = 7;
        }

		/*public override bool UseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
				player.PickTile(Player.tileTargetX, Player.tileTargetY, item.pick);
			return true;
		}*/
	}
}