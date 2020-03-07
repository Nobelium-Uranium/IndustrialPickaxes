namespace IndustrialPickaxes
{
	public abstract class IndustrialPickaxe : GlowmaskItem
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			item.maxStack = 1;
			item.useStyle = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.melee = true;
		}
	}
}