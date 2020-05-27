using IndustrialPickaxes.Helpers;
using IndustrialPickaxes.Items;
using IndustrialPickaxes.Items.Reskins;
using IndustrialPickaxes.Items.Developer;
using IndustrialPickaxes.Items.Fishaxe;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Globals
{
	//OOP plz
	public class IndustrialTile : GlobalTile
	{
		private void SpawnSyncedItem(int i, int j, int type, int stack = 1)
		{
			int item = Item.NewItem(i * 16, j * 16, 16, 16, type, stack, false);

			if (item >= 0 && Main.netMode == NetmodeID.MultiplayerClient)
				NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
		}

		private void Smelt(int chanceSubtraction, int i, int j, int itemType, ref int chanceCounter)
		{
			if (Main.rand.NextBool(chanceSubtraction - chanceCounter))
			{
				Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
				SpawnSyncedItem(i, j, itemType);
				chanceCounter = 0;
			}
			else
				chanceCounter++;
		}

		#region Chance Varibles

		private int chanceCopperTin;
		private int chanceIronLead;
		private int chanceSilverTungsten;
		private int chanceGoldPlatinum;
		private int chanceMeteorite;
		private int chanceDemoniteCrimtane;
		private int chanceHellstone;
		private int chanceCobaltPalladium;
		private int chanceMythrilOrichalcum;
		private int chanceAdamantiteTitanium;
		private int chanceChlorophyte;
		private int chanceLuminite;

		private int chanceLapis;
		private int chanceBismuth;
		private int chanceOblivion;

		private int chanceAerialite;
		private int chanceCryonic;
		private int chanceCharred;
		private int chancePerennial;
		private int chanceAstral;
		private int chanceChaotic;
		private int chanceUelibloom;
		private int chanceAuric;

		private int chanceThorium;
		private int chanceMagma;
		private int chanceAquaite;
		private int chanceLodestone;
		private int chanceValadium;
		private int chanceIllumite;

		private int chanceKanite;
		private int chanceDragonLead;
		private int chanceSapphiron;
		private int chanceScarlion;

		private int chanceIncinerite;
		private int chanceAbyssium;
		private int chanceYtrium;
		private int chanceUranium;
		private int chanceHallowed;
		private int chanceTechnecium;
		private int chanceRadium;
		private int chanceApocalyptite;
		private int chanceDaybreakIncinerite;
		private int chanceEventideAbyssium;

		private int chanceFloran;
		private int chanceCryolite;
		private int chanceSpirit;
		private int chanceThermite;

		#endregion Chance Varibles

		private bool SmeltVanillaBars(int i, int j, int type)
		{
			switch (type)
			{
				case TileID.Copper:
					Smelt(4, i, j, ItemID.CopperBar, ref chanceCopperTin);
					break;

				case TileID.Tin:
					Smelt(4, i, j, ItemID.TinBar, ref chanceCopperTin);
					break;

				case TileID.Iron:
					Smelt(4, i, j, ItemID.IronBar, ref chanceIronLead);
					break;

				case TileID.Lead:
					Smelt(4, i, j, ItemID.LeadBar, ref chanceIronLead);
					break;

				case TileID.Silver:
					Smelt(5, i, j, ItemID.SilverBar, ref chanceSilverTungsten);
					break;

				case TileID.Tungsten:
					Smelt(5, i, j, ItemID.TungstenBar, ref chanceSilverTungsten);
					break;

				case TileID.Gold:
					Smelt(5, i, j, ItemID.GoldBar, ref chanceGoldPlatinum);
					break;

				case TileID.Platinum:
					Smelt(5, i, j, ItemID.PlatinumBar, ref chanceGoldPlatinum);
					break;

				case TileID.Meteorite:
					Smelt(4, i, j, ItemID.Meteorite, ref chanceMeteorite);
					break;

				case TileID.Crimtane:
					Smelt(4, i, j, ItemID.CrimtaneBar, ref chanceDemoniteCrimtane);
					break;

				case TileID.Demonite:
					Smelt(4, i, j, ItemID.DemoniteBar, ref chanceDemoniteCrimtane);
					break;

				case TileID.Hellstone:
					Smelt(4, i, j, ItemID.HellstoneBar, ref chanceHellstone);
					break;

				case TileID.Cobalt:
					Smelt(4, i, j, ItemID.CobaltBar, ref chanceCobaltPalladium);
					break;

				case TileID.Palladium:
					Smelt(4, i, j, ItemID.PalladiumBar, ref chanceCobaltPalladium);
					break;

				case TileID.Mythril:
					Smelt(5, i, j, ItemID.MythrilBar, ref chanceMythrilOrichalcum);
					break;

				case TileID.Orichalcum:
					Smelt(5, i, j, ItemID.OrichalcumBar, ref chanceMythrilOrichalcum);
					break;

				case TileID.Adamantite:
					Smelt(6, i, j, ItemID.AdamantiteBar, ref chanceAdamantiteTitanium);
					break;

				case TileID.Titanium:
					Smelt(6, i, j, ItemID.TitaniumBar, ref chanceAdamantiteTitanium);
					break;

				case TileID.Chlorophyte:
					Smelt(7, i, j, ItemID.ChlorophyteBar, ref chanceChlorophyte);
					break;

				case TileID.LunarOre:
					Smelt(5, i, j, ItemID.LunarBar, ref chanceLuminite);
					break;

				default:
					return true;
			}

			return false;
		}

		private bool SmeltSoABars(int i, int j, int type)
		{
			if (IndustrialPickaxes.SoALoaded)
			{
				if (type == IndustrialPickaxes.SacredTools.TileType("LapisOre"))
				{
					if (Main.rand.NextBool(3 - chanceLapis))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, IndustrialPickaxes.SacredTools.ItemType("RefinedLapis"));
						chanceLapis = 0;
						return false;
					}
					else
						chanceLapis++;
				}
				else if (type == IndustrialPickaxes.SacredTools.TileType("BismuthOre"))
				{
					if (Main.rand.NextBool(3 - chanceBismuth))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, IndustrialPickaxes.SacredTools.ItemType("RefinedBismuth"));
						chanceBismuth = 0;
						return false;
					}
					else
						chanceBismuth++;
				}
				else if (type == IndustrialPickaxes.SacredTools.TileType("OblivionOreBlock"))
				{
					if (Main.rand.NextBool(5 - chanceOblivion))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, IndustrialPickaxes.SacredTools.ItemType("OblivionBar"));
						chanceOblivion = 0;
						return false;
					}
					else
						chanceOblivion++;
				}
			}

			return true;
		}

		private bool SmeltCalamityBars(int i, int j, int type)
		{
			if (Mods.Calamity != null)
			{
				if (type == Mods.Calamity.TileType("AerialiteOre"))
				{
					if (Main.rand.NextBool(5 - chanceAerialite))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Calamity.ItemType("AerialiteBar"));
						chanceAerialite = 0;
						return false;
					}
					else
						chanceAerialite++;
				}
				else if (type == Mods.Calamity.TileType("CryonicOre"))
				{
					if (Main.rand.NextBool(6 - chanceCryonic))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Calamity.ItemType("VerstaltiteBar"));
						chanceCryonic = 0;
						return false;
					}
					else
						chanceCryonic++;
				}
				else if (type == Mods.Calamity.TileType("CharredOre"))
				{
					if (Main.rand.NextBool(5 - chanceCharred))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Calamity.ItemType("UnholyCore"));
						chanceCharred = 0;
						return false;
					}
					else
						chanceCharred++;
				}
				else if (type == IndustrialPickaxes.Calamity.TileType("PerennialOre"))
				{
					if (Main.rand.NextBool(6 - chancePerennial))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, IndustrialPickaxes.Calamity.ItemType("DraedonBar"));
						chancePerennial = 0;
						return false;
					}
					else
						chancePerennial++;
				}
				else if (type == Mods.Calamity.TileType("AstralOre"))
				{
					if (Main.rand.NextBool(3 - chanceAstral))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Calamity.ItemType("AstralBar"));
						chanceAstral = 0;
						return false;
					}
					else
						chanceAstral++;
				}
				else if (type == Mods.Calamity.TileType("ChaoticOre"))
				{
					if (Main.rand.NextBool(6 - chanceChaotic))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Calamity.ItemType("CruptixBar"));
						chanceChaotic = 0;
						return false;
					}
					else
						chanceChaotic++;
				}
				else if (type == Mods.Calamity.TileType("UelibloomOre"))
				{
					if (Main.rand.NextBool(5 - chanceUelibloom))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Calamity.ItemType("UeliaceBar"));
						chanceUelibloom = 0;
						return false;
					}
					else
						chanceUelibloom++;
				}
				else if (type == Mods.Calamity.TileType("AuricOre"))
				{
					if (Main.rand.NextBool(20 - chanceAuric))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Calamity.ItemType("AuricBar"));
						chanceAuric = 0;
						return false;
					}
					else
						chanceAuric++;
				}
			}

			return true;
		}

		private bool SmeltThoriumBars(int i, int j, int type)
		{
			if (Mods.Thorium != null)
			{
				if (type == Mods.Thorium.TileType("ThoriumOre"))
				{
					if (Main.rand.NextBool(5 - chanceThorium))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Thorium.ItemType("ThoriumBar"));
						chanceThorium = 0;
						return false;
					}
					else
						chanceThorium++;
				}
				else if (type == Mods.Thorium.TileType("MagmaOre"))
				{
					if (Main.rand.NextBool(6 - chanceMagma))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Thorium.ItemType("MagmaCore"));
						chanceMagma = 0;
						return false;
					}
					else
						chanceMagma++;
				}
				else if (type == Mods.Thorium.TileType("AquaiteBare"))
				{
					if (Main.rand.NextBool(6 - chanceAquaite))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Thorium.ItemType("AquaiteBar"));
						chanceAquaite = 0;
						return false;
					}
					else
						chanceAquaite++;
				}
				else if (type == Mods.Thorium.TileType("LodeStone"))
				{
					if (Main.rand.NextBool(5 - chanceLodestone))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Thorium.ItemType("LodeStoneIngot"));
						chanceLodestone = 0;
						return false;
					}
					else
						chanceLodestone++;
				}
				else if (type == Mods.Thorium.TileType("ValadiumChunk"))
				{
					if (Main.rand.NextBool(5 - chanceValadium))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Thorium.ItemType("ValadiumIngot"));
						chanceValadium = 0;
						return false;
					}
					else
						chanceValadium++;
				}
				else if (type == Mods.Thorium.TileType("IllumiteChunk"))
				{
					if (Main.rand.NextBool(5 - chanceIllumite))
					{
						Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
						SpawnSyncedItem(i, j, Mods.Thorium.ItemType("IllumiteIngot"));
						chanceIllumite = 0;
						return false;
					}
					else
						chanceIllumite++;
				}
			}

			return true;
		}

		private bool SmeltRedemptionBars(int i, int j, int type)
		{
			if (!IndustrialPickaxes.RedemptionLoaded)
				return true;

			if (type == IndustrialPickaxes.Redemption.TileType("KaniteOreTile"))
			{
				if (Main.rand.NextBool(3 - chanceKanite))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.Redemption.ItemType("KaniteBar"));
					chanceKanite = 0;
					return false;
				}
				else
					chanceKanite++;
			}
			else if (type == IndustrialPickaxes.Redemption.TileType("DragonLeadOreTile"))
			{
				if (Main.rand.NextBool(4 - chanceDragonLead))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.Redemption.ItemType("DragonLeadBar"));
					chanceDragonLead = 0;
					return false;
				}
				else
					chanceDragonLead++;
			}
			else if (type == IndustrialPickaxes.Redemption.TileType("SapphironOreTile"))
			{
				if (Main.rand.NextBool(4 - chanceSapphiron))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.Redemption.ItemType("SapphireBar"));
					chanceSapphiron = 0;
					return false;
				}
				else
					chanceKanite++;
			}
			else if (type == IndustrialPickaxes.Redemption.TileType("ScarlionOreTile"))
			{
				if (Main.rand.NextBool(4 - chanceScarlion))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.Redemption.ItemType("ScarletBar"));
					chanceScarlion = 0;
					return false;
				}
				else
					chanceScarlion++;
			}

			return true;
		}

		private bool SmeltAncientsAwakenedBars(int i, int j, int type)
		{
			if (!IndustrialPickaxes.AALoaded)
				return true;

			if (type == IndustrialPickaxes.AncientsAwakened.TileType("IncineriteOre"))
			{
				if (Main.rand.NextBool(4 - chanceIncinerite))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("IncineriteBar"));
					chanceIncinerite = 0;
					return false;
				}
				else
					chanceIncinerite++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("AbyssiumOre"))
			{
				if (Main.rand.NextBool(4 - chanceAbyssium))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("AbyssiumBar"));
					chanceAbyssium = 0;
					return false;
				}
				else
					chanceAbyssium++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("YtriumOre"))
			{
				if (Main.rand.NextBool(4 - chanceYtrium))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("YtriumBar"));
					chanceYtrium = 0;
					return false;
				}
				else
					chanceYtrium++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("UraniumOre"))
			{
				if (Main.rand.NextBool(5 - chanceUranium))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("UraniumBar"));
					chanceUranium = 0;
					return false;
				}
				else
					chanceUranium++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("HallowedOre"))
			{
				if (Main.rand.NextBool(5 - chanceHallowed))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, ItemID.HallowedBar);
					chanceHallowed = 0;
					return false;
				}
				else
					chanceHallowed++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("TechneciumOre"))
			{
				if (Main.rand.NextBool(4 - chanceTechnecium))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("TechneciumBar"));
					chanceTechnecium = 0;
					return false;
				}
				else
					chanceTechnecium++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("RadiumOre"))
			{
				if (Main.rand.NextBool(6 - chanceRadium))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					if (Main.dayTime)
						SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("RadiumBar"));
					else
						SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("DarkMatter"));
					chanceRadium = 0;
					return false;
				}
				else
					chanceRadium++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("Apocalyptite"))
			{
				if (Main.rand.NextBool(6 - chanceApocalyptite))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("ApocalyptitePlate"));
					chanceApocalyptite = 0;
					return false;
				}
				else
					chanceApocalyptite++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("DaybreakIncineriteOre"))
			{
				if (Main.rand.NextBool(6 - chanceDaybreakIncinerite))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("DaybreakIncinerite"));
					chanceDaybreakIncinerite = 0;
					return false;
				}
				else
					chanceDaybreakIncinerite++;
			}
			else if (type == IndustrialPickaxes.AncientsAwakened.TileType("EventideAbyssiumOre"))
			{
				if (Main.rand.NextBool(6 - chanceEventideAbyssium))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, IndustrialPickaxes.AncientsAwakened.ItemType("EventideAbyssium"));
					chanceEventideAbyssium = 0;
					return false;
				}
				else
					chanceEventideAbyssium++;
			}

			return true;
		}

		private bool SmeltSpiritBars(int i, int j, int type)
		{
			if (Mods.Spirit == null)
				return true;

			if (type == Mods.Spirit.TileType("FloranOreTile"))
			{
				if (Main.rand.NextBool(4 - chanceFloran))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, Mods.Spirit.ItemType("FloranBar"));
					chanceFloran = 0;
					return false;
				}
				else
					chanceFloran++;
			}
			else if (type == Mods.Spirit.TileType("CryoliteOreTile"))
			{
				if (Main.rand.NextBool(4 - chanceCryolite))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, Mods.Spirit.ItemType("CryoliteBar"));
					chanceCryolite = 0;
					return false;
				}
				else
					chanceCryolite++;
			}
			else if (type == Mods.Spirit.TileType("SpiritOreTile"))
			{
				if (Main.rand.NextBool(5 - chanceSpirit))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, Mods.Spirit.ItemType("SpiritBar"));
					chanceSpirit = 0;
					return false;
				}
				else
					chanceSpirit++;
			}
			else if (type == Mods.Spirit.TileType("ThermiteOre"))
			{
				if (Main.rand.NextBool(5 - chanceThermite))
				{
					Main.PlaySound(SoundID.LiquidsWaterLava, i * 16, j * 16);
					SpawnSyncedItem(i, j, Mods.Spirit.ItemType("ThermiteBar"));
					chanceThermite = 0;
					return false;
				}
				else
					chanceThermite++;
			}

			return true;
		}

		public override bool Drop(int i, int j, int type)
		{
			if (Main.netMode != NetmodeID.MultiplayerClient && !WorldGen.noTileActions && !WorldGen.gen)
			{
				for (int playerIndex = 0; playerIndex < Main.maxPlayers; playerIndex++)
				{
					Player player = Main.player[playerIndex];

					if (player == null || !player.active)
						continue;

					int usedTool = player.HeldItem.type;

					if (!player.HasBuff(BuffID.DrillMount))
					{
						if (usedTool == ModContent.ItemType<AvaliManipulator>() || usedTool == ModContent.ItemType<AscendedFishaxe>() || usedTool == ModContent.ItemType<DraconicStaffOfPower>() || usedTool == ModContent.ItemType<DraconicStaffOfPowerAsiimov>() || usedTool == ModContent.ItemType<DraconicStaffOfPowerDemonic>() || usedTool == ModContent.ItemType<DraconicStaffOfPowerGlacier>())
						{
							bool ret = SmeltVanillaBars(i, j, type) || SmeltSoABars(i, j, type) || SmeltCalamityBars(i, j, type) || SmeltThoriumBars(i, j, type) || SmeltRedemptionBars(i, j, type) || SmeltAncientsAwakenedBars(i, j, type) || SmeltSpiritBars(i, j, type);
							return ret;
						}

						if (usedTool == ModContent.ItemType<IndustrialMoltenPickaxe>() || usedTool == ModContent.ItemType<IndustrialMoltenPickaxeFrostburn>())
						{
							switch (type)
							{
								case TileID.Copper:
								case TileID.Tin:
								case TileID.Iron:
								case TileID.Lead:
								case TileID.Silver:
								case TileID.Tungsten:
								case TileID.Gold:
								case TileID.Platinum:
								case TileID.Meteorite:
								case TileID.Demonite:
								case TileID.Crimtane:
								case TileID.Hellstone:
								case TileID.Cobalt:
								case TileID.Palladium:
									bool ret = SmeltVanillaBars(i, j, type);
									return ret;
							}

							if (type == IndustrialPickaxes.SacredTools?.TileType("LapisOre") || type == IndustrialPickaxes.SacredTools?.TileType("BismuthOre"))
							{
								SmeltSoABars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.Calamity?.TileType("AerialiteOre"))
							{
								SmeltCalamityBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.Thorium?.TileType("ThoriumOre") || type == IndustrialPickaxes.Thorium?.TileType("MagmaOre") || type == IndustrialPickaxes.Thorium?.TileType("AquaiteBare"))
							{
								SmeltThoriumBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.Redemption?.TileType("KaniteOreTile"))
							{
								SmeltRedemptionBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.AncientsAwakened?.TileType("IncineriteOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("AbyssiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("YtriumOre"))
							{
								SmeltAncientsAwakenedBars(i, j, type);
								return false;
							}

							if (type == Mods.Spirit?.TileType("FloranOreTile") || type == Mods.Spirit?.TileType("CryoliteOreTile"))
							{
								SmeltSpiritBars(i, j, type);
								return false;
							}
						}

						if (usedTool == ModContent.ItemType<GracefulChlorophytePickaxe>() || usedTool == ModContent.ItemType<GracefulChlorophytePickaxePlantera>())
						{
							if (type != TileID.LunarOre) {
								return SmeltVanillaBars(i, j, type);}

							if (type == IndustrialPickaxes.SacredTools?.TileType("LapisOre") || type == IndustrialPickaxes.SacredTools?.TileType("BismuthOre"))
							{
								return SmeltSoABars(i, j, type);
							}

							if (type == Mods.Calamity?.TileType("AerialiteOre") || type == Mods.Calamity?.TileType("CryonicOre") || type == Mods.Calamity?.TileType("CharredOre") || type == Mods.Calamity?.TileType("PerennialOre"))
							{
								SmeltCalamityBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.AncientsAwakened?.TileType("IncineriteOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("AbyssiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("YtriumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("UraniumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("HallowedOre"))
							{
								SmeltAncientsAwakenedBars(i, j, type);
								return false;
							}

							bool ret = SmeltThoriumBars(i, j, type) || SmeltRedemptionBars(i, j, type) || SmeltSpiritBars(i, j, type);
							return ret;
						}

						if (usedTool == ModContent.ItemType<IndustrialPicksaw>() || usedTool == ModContent.ItemType<IndustrialPicksawBysmal>() || usedTool == ModContent.ItemType<IndustrialPicksawMartian>())
						{
							if (type == IndustrialPickaxes.SacredTools?.TileType("LapisOre") || type == IndustrialPickaxes.SacredTools?.TileType("BismuthOre"))
							{
								SmeltSoABars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.Calamity?.TileType("AerialiteOre") || type == IndustrialPickaxes.Calamity?.TileType("CryonicOre") || type == IndustrialPickaxes.Calamity?.TileType("CharredOre") || type == IndustrialPickaxes.Calamity?.TileType("PerennialOre") || type == IndustrialPickaxes.Calamity?.TileType("ChaoticOre"))
							{
								SmeltCalamityBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.AncientsAwakened?.TileType("IncineriteOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("AbyssiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("YtriumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("UraniumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("HallowedOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("TechneciumOre"))
							{
								SmeltAncientsAwakenedBars(i, j, type);
								return false;
							}

							bool ret = SmeltVanillaBars(i, j, type) || SmeltThoriumBars(i, j, type) || SmeltRedemptionBars(i, j, type) || SmeltSpiritBars(i, j, type);
							return ret;
						}

						if (usedTool == ModContent.ItemType<IndustrialLunarPickaxe>() || usedTool == ModContent.ItemType<IndustrialLunarPickaxeRagnarok>())
						{
							switch (type)
							{
								case TileID.Copper:
								case TileID.Tin:
								case TileID.Iron:
								case TileID.Lead:
								case TileID.Silver:
								case TileID.Tungsten:
								case TileID.Gold:
								case TileID.Platinum:
								case TileID.Meteorite:
								case TileID.Demonite:
								case TileID.Crimtane:
								case TileID.Hellstone:
								case TileID.Cobalt:
								case TileID.Palladium:
								case TileID.Mythril:
								case TileID.Orichalcum:
								case TileID.Adamantite:
								case TileID.Titanium:
								case TileID.Chlorophyte:
								case TileID.LunarOre:
									SmeltVanillaBars(i, j, type);
									return false;
							}

							if (type == IndustrialPickaxes.SacredTools?.TileType("LapisOre") || type == IndustrialPickaxes.SacredTools?.TileType("BismuthOre"))
							{
								SmeltSoABars(i, j, type);
								return false;
							}

							if (type == Mods.Calamity?.TileType("AerialiteOre") || type == Mods.Calamity?.TileType("CryonicOre") || type == Mods.Calamity?.TileType("CharredOre") || type == Mods.Calamity?.TileType("PerennialOre") || type == Mods.Calamity?.TileType("AstralOre") || type == Mods.Calamity?.TileType("ChaoticOre"))
							{
								SmeltCalamityBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.AncientsAwakened?.TileType("IncineriteOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("AbyssiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("YtriumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("UraniumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("HallowedOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("TechneciumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("RadiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("Apocalyptite"))
							{
								SmeltAncientsAwakenedBars(i, j, type);
								return false;
							}

							bool ret = SmeltSpiritBars(i, j, type) || SmeltThoriumBars(i, j, type) || SmeltRedemptionBars(i, j, type);
							return ret;
						}

						if (usedTool == ModContent.ItemType<SolusFlariumPickaxe>() || usedTool == ModContent.ItemType<SolusFlariumPickaxeCernium>() || usedTool == ModContent.ItemType<SolusFlariumPickaxeAsthraltite>())
						{
							if (type == Mods.Calamity?.TileType("AerialiteOre") || type == Mods.Calamity?.TileType("CryonicOre") || type == Mods.Calamity?.TileType("CharredOre") || type == Mods.Calamity?.TileType("PerennialOre") || type == Mods.Calamity?.TileType("AstralOre") || type == Mods.Calamity?.TileType("ChaoticOre") || type == Mods.Calamity?.TileType("Uelibloom"))
							{
								SmeltCalamityBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.AncientsAwakened?.TileType("IncineriteOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("AbyssiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("YtriumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("UraniumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("HallowedOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("TechneciumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("RadiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("Apocalyptite"))
							{
								SmeltAncientsAwakenedBars(i, j, type);
								return false;
							}

							//bool ret = SmeltVanillaBars(i, j, type) || SmeltSoABars(i, j, type) || SmeltThoriumBars(i, j, type) && SmeltRedemptionBars(i, j, type) && SmeltSpiritBars(i, j, type);
							return false;
						}

						if (usedTool == ModContent.ItemType<ViridescentBlossomPickaxe>() || usedTool == ModContent.ItemType<IndustrialBlossomPickaxeProvidence>())
						{
							if (type == IndustrialPickaxes.Calamity?.TileType("AerialiteOre") || type == IndustrialPickaxes.Calamity?.TileType("CryonicOre") || type == IndustrialPickaxes.Calamity?.TileType("CharredOre") || type == IndustrialPickaxes.Calamity?.TileType("PerennialOre") || type == IndustrialPickaxes.Calamity?.TileType("AstralOre") || type == IndustrialPickaxes.Calamity?.TileType("ChaoticOre") || type == IndustrialPickaxes.Calamity?.TileType("Uelibloom"))
							{
								SmeltCalamityBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.AncientsAwakened?.TileType("IncineriteOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("AbyssiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("YtriumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("UraniumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("HallowedOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("TechneciumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("RadiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("Apocalyptite"))
							{
								SmeltAncientsAwakenedBars(i, j, type);
								return false;
							}

							bool ret = SmeltVanillaBars(i, j, type) || SmeltSoABars(i, j, type) || SmeltThoriumBars(i, j, type) || SmeltRedemptionBars(i, j, type) || SmeltSpiritBars(i, j, type);
							return ret;
						}

						if (usedTool == ModContent.ItemType<ExperimentalNanoPickaxe>() || usedTool == ModContent.ItemType<ExperimentalNanoPickaxeCreative>())
						{
							if (type == IndustrialPickaxes.Calamity?.TileType("AerialiteOre") || type == IndustrialPickaxes.Calamity?.TileType("CryonicOre") || type == IndustrialPickaxes.Calamity?.TileType("CharredOre") || type == IndustrialPickaxes.Calamity?.TileType("PerennialOre") || type == IndustrialPickaxes.Calamity?.TileType("AstralOre") || type == IndustrialPickaxes.Calamity?.TileType("ChaoticOre") || type == IndustrialPickaxes.Calamity?.TileType("Uelibloom"))
							{
								SmeltCalamityBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.AncientsAwakened?.TileType("IncineriteOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("AbyssiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("YtriumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("UraniumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("HallowedOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("TechneciumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("RadiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("Apocalyptite"))
							{
								SmeltAncientsAwakenedBars(i, j, type);
								return false;
							}

							bool ret = SmeltVanillaBars(i, j, type) || SmeltSoABars(i, j, type) || SmeltThoriumBars(i, j, type) || SmeltRedemptionBars(i, j, type) || SmeltSpiritBars(i, j, type);
							return ret;
						}

						if (usedTool == ModContent.ItemType<MasterManipulator>())
						{
							if (type == IndustrialPickaxes.Calamity?.TileType("AerialiteOre") || type == IndustrialPickaxes.Calamity?.TileType("CryonicOre") || type == IndustrialPickaxes.Calamity?.TileType("CharredOre") || type == IndustrialPickaxes.Calamity?.TileType("PerennialOre") || type == IndustrialPickaxes.Calamity?.TileType("AstralOre") || type == IndustrialPickaxes.Calamity?.TileType("ChaoticOre") || type == IndustrialPickaxes.Calamity?.TileType("Uelibloom"))
							{
								SmeltCalamityBars(i, j, type);
								return false;
							}

							if (type == IndustrialPickaxes.AncientsAwakened?.TileType("IncineriteOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("AbyssiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("YtriumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("UraniumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("HallowedOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("TechneciumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("RadiumOre") || type == IndustrialPickaxes.AncientsAwakened?.TileType("Apocalyptite"))
							{
								SmeltAncientsAwakenedBars(i, j, type);
								return false;
							}

							bool ret = SmeltVanillaBars(i, j, type) || SmeltSoABars(i, j, type) || SmeltThoriumBars(i, j, type) || SmeltRedemptionBars(i, j, type) || SmeltSpiritBars(i, j, type);
							return ret;
						}

						if (usedTool == ModContent.ItemType<OreRejuvenator>())
						{
							int droppedGem = Main.rand.Next(6);

							switch (type)
							{
								case TileID.Diamond:
									if (Main.rand.Next(8) == 0)
									{
										switch (droppedGem)
										{
											case 0:
												SpawnSyncedItem(i, j, ItemID.Ruby);
												break;

											case 1:
												SpawnSyncedItem(i, j, ItemID.Emerald);
												break;

											case 2:
												SpawnSyncedItem(i, j, ItemID.Sapphire);
												break;

											case 3:
												SpawnSyncedItem(i, j, ItemID.Amethyst);
												break;

											case 4:
												SpawnSyncedItem(i, j, ItemID.Topaz);
												break;

											case 5:
												SpawnSyncedItem(i, j, ItemID.Amber);
												break;
										}
									}

									SpawnSyncedItem(i, j, ItemID.Diamond, 2);
									return false;

								case TileID.Ruby:
									if (Main.rand.Next(8) == 0)
									{
										switch (droppedGem)
										{
											case 0:
												SpawnSyncedItem(i, j, ItemID.Diamond);
												break;

											case 1:
												SpawnSyncedItem(i, j, ItemID.Emerald);
												break;

											case 2:
												SpawnSyncedItem(i, j, ItemID.Sapphire);
												break;

											case 3:
												SpawnSyncedItem(i, j, ItemID.Amethyst);
												break;

											case 4:
												SpawnSyncedItem(i, j, ItemID.Topaz);
												break;

											case 5:
												SpawnSyncedItem(i, j, ItemID.Amber);
												break;
										}
									}

									SpawnSyncedItem(i, j, ItemID.Ruby, 2);
									return false;

								case TileID.Emerald:
									if (Main.rand.Next(8) == 0)
									{
										switch (droppedGem)
										{
											case 0:
												SpawnSyncedItem(i, j, ItemID.Diamond);
												break;

											case 1:
												SpawnSyncedItem(i, j, ItemID.Ruby);
												break;

											case 2:
												SpawnSyncedItem(i, j, ItemID.Sapphire);
												break;

											case 3:
												SpawnSyncedItem(i, j, ItemID.Amethyst);
												break;

											case 4:
												SpawnSyncedItem(i, j, ItemID.Topaz);
												break;

											case 5:
												SpawnSyncedItem(i, j, ItemID.Amber);
												break;
										}
									}

									SpawnSyncedItem(i, j, ItemID.Emerald, 2);
									return false;

								case TileID.Sapphire:
									if (Main.rand.Next(8) == 0)
									{
										switch (droppedGem)
										{
											case 0:
												SpawnSyncedItem(i, j, ItemID.Diamond);
												break;

											case 1:
												SpawnSyncedItem(i, j, ItemID.Ruby);
												break;

											case 2:
												SpawnSyncedItem(i, j, ItemID.Emerald);
												break;

											case 3:
												SpawnSyncedItem(i, j, ItemID.Amethyst);
												break;

											case 4:
												SpawnSyncedItem(i, j, ItemID.Topaz);
												break;

											case 5:
												SpawnSyncedItem(i, j, ItemID.Amber);
												break;
										}
									}

									SpawnSyncedItem(i, j, ItemID.Sapphire, 2);
									return false;

								case TileID.Amethyst:
									if (Main.rand.Next(8) == 0)
									{
										switch (droppedGem)
										{
											case 0:
												SpawnSyncedItem(i, j, ItemID.Diamond);
												break;

											case 1:
												SpawnSyncedItem(i, j, ItemID.Ruby);
												break;

											case 2:
												SpawnSyncedItem(i, j, ItemID.Emerald);
												break;

											case 3:
												SpawnSyncedItem(i, j, ItemID.Sapphire);
												break;

											case 4:
												SpawnSyncedItem(i, j, ItemID.Topaz);
												break;

											case 5:
												SpawnSyncedItem(i, j, ItemID.Amber);
												break;
										}
									}

									SpawnSyncedItem(i, j, ItemID.Amethyst, 2);
									return false;

								case TileID.Topaz:
									if (Main.rand.Next(8) == 0)
									{
										switch (droppedGem)
										{
											case 0:
												SpawnSyncedItem(i, j, ItemID.Diamond);
												break;

											case 1:
												SpawnSyncedItem(i, j, ItemID.Ruby);
												break;

											case 2:
												SpawnSyncedItem(i, j, ItemID.Emerald);
												break;

											case 3:
												SpawnSyncedItem(i, j, ItemID.Sapphire);
												break;

											case 4:
												SpawnSyncedItem(i, j, ItemID.Amethyst);
												break;

											case 5:
												SpawnSyncedItem(i, j, ItemID.Amber);
												break;
										}
									}

									SpawnSyncedItem(i, j, ItemID.Topaz, 2);
									return false;
							}
						}

						if (usedTool == ModContent.ItemType<VioletThaumaturgy>())
						{
							switch (type)
							{
								case TileID.Copper:
									SpawnSyncedItem(i, j, ItemID.TinOre);
									return false;

								case TileID.Tin:
									SpawnSyncedItem(i, j, ItemID.CopperOre);
									return false;

								case TileID.Iron:
									SpawnSyncedItem(i, j, ItemID.LeadOre);
									return false;

								case TileID.Lead:
									SpawnSyncedItem(i, j, ItemID.IronOre);
									return false;

								case TileID.Silver:
									SpawnSyncedItem(i, j, ItemID.TungstenOre);
									return false;

								case TileID.Tungsten:
									SpawnSyncedItem(i, j, ItemID.SilverOre);
									return false;

								case TileID.Gold:
									SpawnSyncedItem(i, j, ItemID.PlatinumOre);
									return false;

								case TileID.Platinum:
									SpawnSyncedItem(i, j, ItemID.GoldOre);
									return false;

								case TileID.Demonite:
									SpawnSyncedItem(i, j, ItemID.CrimtaneOre);
									return false;

								case TileID.Crimtane:
									SpawnSyncedItem(i, j, ItemID.DemoniteOre);
									return false;

								case TileID.Cobalt:
									SpawnSyncedItem(i, j, ItemID.PalladiumOre);
									return false;

								case TileID.Palladium:
									SpawnSyncedItem(i, j, ItemID.CobaltOre);
									return false;

								case TileID.Mythril:
									SpawnSyncedItem(i, j, ItemID.OrichalcumOre);
									return false;

								case TileID.Orichalcum:
									SpawnSyncedItem(i, j, ItemID.MythrilOre);
									return false;

								case TileID.Adamantite:
									SpawnSyncedItem(i, j, ItemID.TitaniumOre);
									return false;

								case TileID.Titanium:
									SpawnSyncedItem(i, j, ItemID.AdamantiteOre);
									return false;
							}
						}
					}
				}
			}

			return base.Drop(i, j, type);
		}
	}
}