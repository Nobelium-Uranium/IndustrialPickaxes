using IndustrialPickaxes.Items;
using Terraria;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Prefixes
{
    public class IndustrialPrefix : ModPrefix
    {
        public override bool Autoload(ref string name)
        {
            if (!base.Autoload(ref name))
                return false;
            mod.AddPrefix("Industrial", this);
            return false;
        }
        public override PrefixCategory Category => PrefixCategory.AnyWeapon;
        public override void ModifyValue(ref float valueMult) => valueMult *= 1.45f;
        public override bool CanRoll(Item item) => false; //item.pick > 0 && !(item.modItem is Helpers.IndustrialPickaxe);
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) => useTimeMult = 1.3f;
    }
}
