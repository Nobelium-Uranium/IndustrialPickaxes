using IndustrialPickaxes.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class BeamExcavator : ModItem
	{
		public override void SetStaticDefaults() => Tooltip.SetDefault("18 range\n230% beam power\nCannot deal damage\n'Sacrificing precision for power'");

		public override void SetDefaults()
		{
			item.noMelee = true;
			item.width = 38;
			item.height = 18;
			item.useTime = item.useAnimation = 7;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item75;
			item.autoReuse = true;
			item.useTurn = false;
			item.shoot = ModContent.ProjectileType<LaserDrillBolt>();
			item.shootSpeed = 5f;
		}
	}
}