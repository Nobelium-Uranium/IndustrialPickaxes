using GoodProLib.GUtils;
using Terraria;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Developer
{
	public class DevNull : ModItem
	{
		public override void SetStaticDefaults() => DisplayName.SetDefault("/dev/null");

		public override void SetDefaults() => item.rare = -1;

		public override void UpdateInventory(Player player)
		{
			switch (SteamUtils.SteamID()) // TODO SteamID() => SteamID in GPLib 1.0
			{
				case "76561198079106803":
					item.SetDefaults(ModContent.ItemType<AvaliManipulator>());
					break;

				case "76561198278238685":
					item.SetDefaults(ModContent.ItemType<VioletThaumaturgy>());
					break;
			}
		}
	}
}