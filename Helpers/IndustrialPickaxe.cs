using Terraria.ID;

namespace IndustrialPickaxes.Helpers
{
	public abstract class IndustrialPickaxe : GlowmaskItem
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			item.maxStack = 1;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.autoReuse = true;
			item.melee = true;
		}
	}
}