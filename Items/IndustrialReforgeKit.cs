using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
    public class IndustrialReforgeKit : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("<right> while holding a standard pickaxe to industrialize it\n" +
                "Warning: Is consumed without applying the prefix if the pickaxe is held on your cursor");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(20);
            item.value = Item.buyPrice(gold: 2);
            item.rare = ItemRarityID.Blue;
        }
        public override bool CanRightClick()
        {
            Player player = Main.LocalPlayer;
            return player.HeldItem.pick > 0 && !(player.HeldItem.modItem is Helpers.IndustrialPickaxe) && player.HeldItem.prefix != ModContent.PrefixType<Prefixes.IndustrialPrefix>();
        }
        public override void RightClick(Player player)
        {
            player.HeldItem.prefix = ModContent.PrefixType<Prefixes.IndustrialPrefix>();
            player.HeldItem.useTime += (int)(player.HeldItem.useTime * .3f);
            player.HeldItem.useAnimation += (int)(player.HeldItem.useAnimation * .3f);
        }
    }
}
