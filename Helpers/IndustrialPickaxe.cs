using Terraria.ID;
using Terraria.Utilities;

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

        public override bool? PrefixChance(int pre, UnifiedRandom rand)
        {
            if (pre == -1)
                return false;
            return base.PrefixChance(pre, rand);
        }
    }
}