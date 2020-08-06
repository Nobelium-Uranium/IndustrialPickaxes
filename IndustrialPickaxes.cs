using IndustrialPickaxes.Items;
using IndustrialPickaxes.Items.Fishaxe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

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

		public static Mod AncientsAwakened;

		public static bool AALoaded;

		public static Mod ElementsAwoken;

		public static bool EALoaded;

		public static Mod SpiritMod;

		public static bool SpiritLoaded;

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
			AncientsAwakened = ModLoader.GetMod("AAMod");
			AALoaded = AncientsAwakened != null;
			ElementsAwoken = ModLoader.GetMod("ElementsAwoken");
			EALoaded = ElementsAwoken != null;
			SpiritMod = ModLoader.GetMod("SpiritMod");
			SpiritLoaded = SpiritMod != null;

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
			AncientsAwakened = null;
			AALoaded = false;
			ElementsAwoken = null;
			EALoaded = false;
			SpiritMod = null;
			SpiritLoaded = false;

			Veinminer = null;
			SteamID = null;
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

			group = new RecipeGroup(() => "Blazing Molten Pickaxe", new int[]
			{
				ModContent.ItemType<IndustrialMoltenPickaxe>(),
				ModContent.ItemType<IndustrialMoltenPickaxeFrostburn>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialMolten", group);

			group = new RecipeGroup(() => "Graceful Chlorophyte Pickaxe", new int[]
			{
				ModContent.ItemType<GracefulChlorophytePickaxe>(),
				ModContent.ItemType<GracefulChlorophytePickaxePlantera>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialChlorophyte", group);

			group = new RecipeGroup(() => "Lihzahrdian Picksaw", new int[]
			{
				ModContent.ItemType<IndustrialPicksaw>(),
				ModContent.ItemType<IndustrialPicksawBysmal>(),
				ModContent.ItemType<IndustrialPicksawMartian>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialPicksaw", group);

			group = new RecipeGroup(() => "Lunatic's Celestial Pick", new int[]
			{
				ModContent.ItemType<IndustrialLunarPickaxe>(),
				ModContent.ItemType<IndustrialLunarPickaxeRagnarok>(),
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
				ModContent.ItemType<SolusFlariumPickaxeCernium>(),
				ModContent.ItemType<SolusFlariumPickaxeAsthraltite>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialFlarium", group);

			group = new RecipeGroup(() => "Viridescent Blossom Pickaxe", new int[]
			{
				ModContent.ItemType<ViridescentBlossomPickaxe>(),
				ModContent.ItemType<ViridescentBlossomPickaxeProvidence>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialBlossom", group);

			group = new RecipeGroup(() => "Experimental Nano Pickaxe", new int[]
			{
				ModContent.ItemType<ExperimentalNanoPickaxe>(),
				ModContent.ItemType<ExperimentalNanoPickaxeCreative>(),
				ModContent.ItemType<ExperimentalNanoPickaxeXenium>(),
			});

			RecipeGroup.RegisterGroup("IndustrialPickaxes:IndustrialNano", group);
		}
	}
}