using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace IndustrialPickaxes
{
    public class IndustrialClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Shorten world entry message")]
        [DefaultValue(false)]
        public bool ShortenEntryMessage { get; set; }
    }
}
