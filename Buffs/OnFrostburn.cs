using Terraria;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Buffs
{
	// Used for Blazing Molten Pickaxe reskin. it's supposed to be On Fire! but disguised as Frostburn
	public class OnFrostburn : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Frostburn?");
			Description.SetDefault("It's blazing hot or frigid. Either way it agonizing but not as much as it should be.");

			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) => player.onFrostBurn = true;

		public override void Update(NPC npc, ref int buffIndex) => npc.GetGlobalNPC<IndustrialNPC>().OnFrostburn = true;
	}
}