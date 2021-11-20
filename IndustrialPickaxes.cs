using IndustrialPickaxes.Items;
using IndustrialPickaxes.Items.Fishaxe;
using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using System.IO;

namespace IndustrialPickaxes
{
	public class IndustrialPickaxes : Mod
	{
		public static Mod SacredTools;
		public static bool SoALoaded;

		public static Mod Calamity;
		public static bool CalamityLoaded;

		public static Mod Thorium;
		public static bool ThoriumLoaded;

		public static Mod Redemption;
		public static bool RedemptionLoaded;

		public static Mod ElementsAwoken;
		public static bool EALoaded;

		public static Mod SpiritMod;
		public static bool SpiritLoaded;

        public static Mod Qwertys;
        public static bool QwertysLoaded;

        public static Mod Ultranium;
        public static bool UltraniumLoaded;

        public static Mod Veinminer;

		internal static PropertyInfo SteamID = null;

		public static string GithubUserName => "Nobelium-Uranium";

		public static string GithubProjectName => "IndustrialPickaxes";

		public override void Load()
		{
			try
			{
				SteamID = typeof(ModLoader).GetProperty("SteamID64", BindingFlags.Static | BindingFlags.NonPublic);
			}
			catch { }

			SacredTools = ModLoader.GetMod("SacredTools");
			SoALoaded = SacredTools != null;

			Calamity = ModLoader.GetMod("CalamityMod");
			CalamityLoaded = Calamity != null;

			Thorium = ModLoader.GetMod("ThoriumMod");
			ThoriumLoaded = Thorium != null;

			Redemption = ModLoader.GetMod("Redemption");
			RedemptionLoaded = Redemption != null;

			ElementsAwoken = ModLoader.GetMod("ElementsAwoken");
			EALoaded = ElementsAwoken != null;

			SpiritMod = ModLoader.GetMod("SpiritMod");
			SpiritLoaded = SpiritMod != null;

            Qwertys = ModLoader.GetMod("QwertysRandomContent");
            QwertysLoaded = Qwertys != null;

            Ultranium = ModLoader.GetMod("Ultranium");
            UltraniumLoaded = Ultranium != null;

			Veinminer = ModLoader.GetMod("VeinMiner");
		}

		public override void Unload()
		{
			SacredTools = null;
			SoALoaded = false;

			Calamity = null;
			CalamityLoaded = false;

			Thorium = null;
			ThoriumLoaded = false;

			Redemption = null;
			RedemptionLoaded = false;

			ElementsAwoken = null;
			EALoaded = false;

			SpiritMod = null;
			SpiritLoaded = false;

			Qwertys = null;
			QwertysLoaded = false;

			Ultranium = null;
			UltraniumLoaded = false;

			Veinminer = null;
			SteamID = null;

			OreList.defaultOreType = null;
			OreList.defaultSmeltChance = null;
			OreList.defaultBarType = null;

			OreList.oreType = null;
			OreList.smeltChance = null;
			OreList.barType = null;
		}
        public override void PostSetupContent()
        {
			if (OreList.oreType != null && OreList.oreType.Count == 0 && OreList.smeltChance != null && OreList.smeltChance.Count == 0 && OreList.barType != null && OreList.barType.Count == 0)
            {
				for (int i = 0; i < OreList.defaultOreType.Length; i++) //Initialize default ore lists
					OreList.AddOres(OreList.defaultOreType[i], OreList.defaultSmeltChance[i], OreList.defaultBarType[i]);
				//Insert mod-specific ores to the list
				#region Shadows of Abaddon
				if (SoALoaded)
				{
					OreList.AddOres(SacredTools.TileType("LapisOre"), 3, SacredTools.ItemType("RefinedLapis"));
					OreList.AddOres(SacredTools.TileType("BismuthOre"), 3, SacredTools.ItemType("RefinedBismuth"));
					OreList.AddOres(SacredTools.TileType("OblivionOreBlock"), 3, SacredTools.ItemType("OblivionBar"));
				}
				#endregion
				#region Calamity
				if (CalamityLoaded)
				{
					OreList.AddOres(Calamity.TileType("AerialiteOre"), 5, Calamity.ItemType("AerialiteBar"));
					OreList.AddOres(Calamity.TileType("CryonicOre"), 6, Calamity.ItemType("VerstaltiteBar"));
					OreList.AddOres(Calamity.TileType("CharredOre"), 5, Calamity.ItemType("UnholyCore"));
					OreList.AddOres(Calamity.TileType("PerennialOre"), 6, Calamity.ItemType("DraedonBar"));
					OreList.AddOres(Calamity.TileType("AstralOre"), 3, Calamity.ItemType("AstralBar"));
					OreList.AddOres(Calamity.TileType("ChaoticOre"), 6, Calamity.ItemType("CruptixBar"));
					OreList.AddOres(Calamity.TileType("UelibloomOre"), 6, Calamity.ItemType("UeliaceBar"));
					OreList.AddOres(Calamity.TileType("AuricOre"), 12, Calamity.ItemType("AuricBar"));
				}
				#endregion
				#region Thorium
				if (ThoriumLoaded)
				{
					OreList.AddOres(Thorium.TileType("ThoriumOre"), 5, Thorium.ItemType("ThoriumBar"));
					OreList.AddOres(Thorium.TileType("MagmaOre"), 6, Thorium.ItemType("MagmaCore"));
					OreList.AddOres(Thorium.TileType("AquaiteBare"), 6, Thorium.ItemType("AquaiteBar"));
					OreList.AddOres(Thorium.TileType("LodeStone"), 5, Thorium.ItemType("LodeStoneIngot"));
					OreList.AddOres(Thorium.TileType("ValadiumChunk"), 5, Thorium.ItemType("ValadiumIngot"));
					OreList.AddOres(Thorium.TileType("IllumiteChunk"), 5, Thorium.ItemType("IllumiteIngot"));
				}
				#endregion
				#region Mod of Redemption
				if (RedemptionLoaded)
				{
					OreList.AddOres(Redemption.TileType("KaniteOreTile"), 3, Redemption.ItemType("KaniteBar"));
					OreList.AddOres(Redemption.TileType("DragonLeadOreTile"), 4, Redemption.ItemType("DragonLeadBar"));
					OreList.AddOres(Redemption.TileType("SapphironOreTile"), 4, Redemption.ItemType("SapphireBar"));
					OreList.AddOres(Redemption.TileType("ScarlionOreTile"), 4, Redemption.ItemType("ScarletBar"));
				}
				#endregion
				#region Spirit
				if (SpiritLoaded)
				{
					OreList.AddOres(SpiritMod.TileType("FloranOreTile"), 4, SpiritMod.ItemType("FloranBar"));
					OreList.AddOres(SpiritMod.TileType("CryoliteOreTile"), 4, SpiritMod.ItemType("CryoliteBar"));
					OreList.AddOres(SpiritMod.TileType("SpiritOreTile"), 5, SpiritMod.ItemType("SpiritBar"));
					OreList.AddOres(SpiritMod.TileType("ThermiteOre"), 5, SpiritMod.ItemType("ThermiteBar"));
				}
				#endregion
				#region Qwertys
				if (QwertysLoaded)
				{
					OreList.AddOres(Qwertys.TileType("LuneOre"), 4, Qwertys.ItemType("LuneBar"));
					OreList.AddOres(Qwertys.TileType("RhuthiniumOre"), 4, Qwertys.ItemType("RhuthiniumBar"));
				}
				#endregion
				#region Ultranium
				if (UltraniumLoaded)
				{
					OreList.AddOres(Ultranium.TileType("AuroraOre"), 5, Ultranium.ItemType("AuroraBar"));
					OreList.AddOres(Ultranium.TileType("ShadowOreTile"), 3, Ultranium.ItemType("NightmareBar"));
				}
				#endregion
			}
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			ModPacket packet = this.GetPacket();

			if (Main.netMode == NetmodeID.Server)
			{
				ushort x = reader.ReadUInt16(), y = reader.ReadUInt16();
				ushort targetType = reader.ReadUInt16();
				packet.Write((ushort)x);
				packet.Write((ushort)y);
				packet.Send(-1, whoAmI);
				IndustrialTile industrialTile = ModContent.GetInstance<IndustrialTile>();
				industrialTile.SmeltOres(x, y, targetType);
			}
			else
			{
				ushort x = reader.ReadUInt16(), y = reader.ReadUInt16();
				ushort targetType = reader.ReadUInt16();
				IndustrialTile industrialTile = ModContent.GetInstance<IndustrialTile>();
				industrialTile.SmeltOres(x, y, targetType);
			}
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Large Gem", new int[]
			{
				ItemID.LargeDiamond,
				ItemID.LargeTopaz,
				ItemID.LargeRuby,
				ItemID.LargeSapphire,
				ItemID.LargeEmerald,
				ItemID.LargeAmethyst,
				ItemID.LargeAmber,
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:LargeGem", group);

			group = new RecipeGroup(() => "Fishaxe", new int[]
			{
				ModContent.ItemType<Fishaxe>(),
				ModContent.ItemType<FishaxeRitual>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:Fishaxe", group);

			group = new RecipeGroup(() => "Enchanted Pickaxe", new int[]
			{
				ModContent.ItemType<EnchantedPickaxe>(),
				ModContent.ItemType<Pickhalis>(),
				ModContent.ItemType<Pickagrim>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:EnchantedPickaxe", group);

			group = new RecipeGroup(() => "Blazing Molten Pickaxe", new int[]
			{
				ModContent.ItemType<BlazingMoltenPickaxe>(),
				ModContent.ItemType<FrigidFlarePickaxe>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialMolten", group);

			group = new RecipeGroup(() => "Steampunk Excavator", new int[]
			{
				ModContent.ItemType<SteampunkExcavator>(),
				ModContent.ItemType<MechanicalExcavator>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:SteampunkExcavator", group);

			group = new RecipeGroup(() => "Graceful Chlorophyte Pickaxe", new int[]
			{
				ModContent.ItemType<GracefulChlorophytePickaxe>(),
				ModContent.ItemType<BloomingChlorophytePickaxe>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialChlorophyte", group);

			group = new RecipeGroup(() => "Lihzahrdian Picksaw", new int[]
			{
				ModContent.ItemType<LihzahrdianPicksaw>(),
				ModContent.ItemType<BysmalPicksaw>(),
				ModContent.ItemType<MartianPicksaw>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialPicksaw", group);

			group = new RecipeGroup(() => "Lunatic's Celestial Pick", new int[]
			{
				ModContent.ItemType<LunaticsCelestialPick>(),
				ModContent.ItemType<RealityBreakerPickaxe>(),
                ModContent.ItemType<PrimordialGenesisPickaxe>(),
            });

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialLunar", group);

			group = new RecipeGroup(() => "Means to an End", new int[]
			{
				ModContent.ItemType<DraconicStaffOfPower>(),
				ModContent.ItemType<DraconicStaffOfPowerAsiimov>(),
				ModContent.ItemType<DraconicStaffOfPowerDemonic>(),
				ModContent.ItemType<DraconicStaffOfPowerGlacier>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:DraconicEvolution", group);

			group = new RecipeGroup(() => "Solus Flarium Pickaxe", new int[]
			{
				ModContent.ItemType<SolusFlariumPickaxe>(),
				ModContent.ItemType<CryoCerniumPickaxe>(),
				ModContent.ItemType<MirageAsthraltitePickaxe>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialFlarium", group);

            group = new RecipeGroup(() => "Draconic Asthraltite Picksaw", new int[]
            {
                ModContent.ItemType<DraconicAsthraltitePicksaw>(),
                ModContent.ItemType<LeechingShadowflarePicksaw>(),
                ModContent.ItemType<CrimsonFlamePicksaw>(),
            });

            RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialAsthraltite", group);

            group = new RecipeGroup(() => "Viridescent Blossom Pickaxe", new int[]
			{
				ModContent.ItemType<ViridescentBlossomPickaxe>(),
				ModContent.ItemType<ProfanedShardPickaxe>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialBlossom", group);

			group = new RecipeGroup(() => "Experimental Nano Pickaxe", new int[]
			{
				ModContent.ItemType<ExperimentalNanoPickaxe>(),
				ModContent.ItemType<ExperimentalNanoPickaxeCreative>(),
				ModContent.ItemType<PrototypeXeniumPickaxe>(),
                ModContent.ItemType<CorruptedVlitchPickaxe>(),
            });

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialNano", group);
		}
	}
}