using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class LoreholderPickaxe : IndustrialPickaxe
	{
		private int LoreCooldown;

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/IndustrialLoreholder");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Loreholder, Cursed Pickaxe");
			Tooltip.SetDefault("'Your vision is blocked by walls of text'\n<right> on an ore to get some information about it\n[c/FFEA9B:A sentient pickaxe, cursed with infinite knowledge]");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();

			item.damage = 35;
			item.width = 70;
			item.height = 68;
			item.useTime = 12;
			item.useAnimation = 30;
			item.pick = 200;
			item.knockBack = 4.75f;
			item.value = Item.sellPrice(0, 4, 40, 0);
			item.rare = ItemRarityID.LightRed; // TODO use ItemRarityID
			item.UseSound = SoundID.Item1;
		}

		public override bool AltFunctionUse(Player player) => true;

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.pick = 0;
				item.noMelee = true;

				Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];

				if (LoreCooldown <= 0)
				{
					LoreCooldown = 60;

					// Vanilla
					switch (tile.type)
					{
						case TileID.Copper:
							Main.NewText("<Loreholder> A cheap and conductive metal. Your starting tools are made of this stuff.", new Color(184, 134, 11));
							break;

						case TileID.Tin:
							Main.NewText("<Loreholder> Although it's slightly stronger than copper, this metal's still not very remarkable.", new Color(184, 134, 11));
							break;

						case TileID.Iron:
							Main.NewText("<Loreholder> A very versatile metal, you'll need a lot of this.", new Color(184, 134, 11));
							break;

						case TileID.Lead:
							Main.NewText("<Loreholder> Be glad that lead poisoning is not a thing in this world, unless you're some sort of masochist.", new Color(184, 134, 11));
							break;

						case TileID.Silver:
							Main.NewText("<Loreholder> A very conductive and very shiny metal, don't shock or blind yourself!", new Color(184, 134, 11));
							break;

						case TileID.Tungsten:
							Main.NewText("<Loreholder> While tungsten is a rather rare metal in the real world, it's fairly common here. It's quite resistant to heat and is very robust overall.", new Color(184, 134, 11));
							break;

						case TileID.Gold:
							Main.NewText("<Loreholder> Why exactly is gold stronger than iron in this world? Well whatever, it's shiny and it's valuable, but also brittle in the real world. It's often shaped into coins to use as currency, ironic how you can't make them yourself.", new Color(184, 134, 11));
							break;

						case TileID.Platinum:
							Main.NewText("<Loreholder> If you could make coins out of this, you'd be able to break the economy tenfold!", new Color(184, 134, 11));
							break;

						case TileID.Meteorite:
							Main.NewText("<Loreholder> A cluster of space rocks, it seems to have some magical properties...", new Color(184, 134, 11));
							break;

						case TileID.Crimtane:
							Main.NewText("<Loreholder> An unholy ore, originating from the Crimson, or what's left of it I suppose.", new Color(184, 134, 11));
							break;

						case TileID.Demonite:
							Main.NewText("<Loreholder> An unholy ore, originating from the Corruption, or what's left of it I suppose.", new Color(184, 134, 11));
							break;

						case TileID.Hellstone:
							Main.NewText("<Loreholder> Wow, this stuff's hot! It can be alloyed with obsidian to make quite a durable bar.", new Color(184, 134, 11));
							break;

						case TileID.Cobalt:
							Main.NewText("<Loreholder> Realworld cobalt is not blue, but it can be made into a blue dye.", new Color(184, 134, 11));
							break;

						case TileID.Palladium:
							Main.NewText("<Loreholder> A knightly ore, can be used to make powerful equipment.", new Color(184, 134, 11));
							break;

						case TileID.Mythril:
							Main.NewText("<Loreholder> This legendary metal, mythril, is often depicted in varying colors, here it takes on a distinct shade of green.", new Color(184, 134, 11));
							break;

						case TileID.Orichalcum:
							Main.NewText("<Loreholder> Hey, this reminds me of a certain ore... Zanithite, it was called?", new Color(184, 134, 11));
							break;

						case TileID.Adamantite:
							Main.NewText("<Loreholder> A very durable metal, some say it's the mightiest of all.", new Color(184, 134, 11));
							break;

						case TileID.Titanium:
							Main.NewText("<Loreholder> Although titanium's strength is comparable to steel, it's renowned for its inert nature and corrosion resistance.", new Color(184, 134, 11));
							break;

						case TileID.Chlorophyte:
							Main.NewText("<Loreholder> A strange organic metal, it seems to have a leaflike patterned crystalline structure to it.", new Color(184, 134, 11));
							break;

						case TileID.LunarOre:
							Main.NewText("<Loreholder> A metal that some people call moonstone that's out of this world.", new Color(184, 134, 11));
							break;
					}

					ShadowsOfAbaddonTileLore(tile);

					RedemptionTileLore(tile);
				}
			}
			else
			{
				item.pick = 200;
				item.noMelee = false;
			}

			return base.CanUseItem(player);
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Glowmasks/IndustrialLoreholder");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}

		public override void UpdateInventory(Player player)
		{
			if (LoreCooldown > 0)
			{
				LoreCooldown -= 1;
			}
		}

		public override void AddRecipes()
		{
			if (IndustrialPickaxes.RedemptionLoaded)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("CursedGem"));
				recipe.AddIngredient(IndustrialPickaxes.Redemption.ItemType("AncientBrassPickaxe"));
				recipe.AddIngredient(ItemID.SoulofFright, 5);
				recipe.AddIngredient(ItemID.SoulofMight, 5);
				recipe.AddIngredient(ItemID.SoulofSight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}

		private static void ShadowsOfAbaddonTileLore(Tile tile)
		{
			if (IndustrialPickaxes.SoALoaded)
			{
				if (IndustrialPickaxes.SacredTools.GetTile("LapisOre") != null)
					if (tile.type == IndustrialPickaxes.SacredTools.TileType("LapisOre"))
						Main.NewText("<Loreholder> An ore renowned for its blue coloration.", new Color(184, 134, 11));

				if (IndustrialPickaxes.SacredTools.GetTile("BismuthOre") != null)
					if (tile.type == IndustrialPickaxes.SacredTools.TileType("BismuthOre"))
						Main.NewText("<Loreholder> A pretty opalescent ore, sometimes carried by certain elementals.", new Color(184, 134, 11));

				if (IndustrialPickaxes.SacredTools.GetTile("OblivionOreBlock") != null)
					if (tile.type == IndustrialPickaxes.SacredTools.TileType("OblivionOreBlock"))
						Main.NewText("<Loreholder> When you defeated Abaddon, some of his nightmare energy was released and infused itself into deep cavern rock. It's quite spine-chilling, even for me despite lacking a spine.", new Color(184, 134, 11));

				if (IndustrialPickaxes.SacredTools.GetTile("Flarium") != null)
					if (tile.type == IndustrialPickaxes.SacredTools.TileType("Flarium"))
						Main.NewText("<Loreholder> These Flarium crystals are most similar to those that grow in the caves and mountains of Magamantez, they're fueled by the thermal energy flow channeled by giant Flarium cores and their respective guardian. If that guardian dies for any reason, so do the core and any Flarium crystals connected to it. That being said, it is strange to see Flarium crystals being CREATED when Araghur was defeated, but I'm sure that is soon to change.", new Color(184, 134, 11));
			}
		}

		private void RedemptionTileLore(Tile tile)
		{
			if (IndustrialPickaxes.RedemptionLoaded)
			{
				if (IndustrialPickaxes.Redemption.GetTile("KaniteOreTile") != null)
					if (tile.type == IndustrialPickaxes.Redemption.TileType("KaniteOreTile"))
						Main.NewText("<Loreholder> A cold, pale blue metal found in Ithon, it's commonly used as a replacement for iron in Epidotra.", new Color(184, 134, 11));

				if (IndustrialPickaxes.Redemption.GetTile("DragonLeadOreTile") != null)
					if (tile.type == IndustrialPickaxes.Redemption.TileType("DragonLeadOreTile"))
						Main.NewText("<Loreholder> Fossilized dragon bone, amalgamated into a metal due to the intense heat of lava deep underground.", new Color(184, 134, 11));

				if (IndustrialPickaxes.Redemption.GetTile("XenomiteOreBlock") != null)
					if (tile.type == IndustrialPickaxes.Redemption.TileType("XenomiteOreBlock"))
						Main.NewText("<Loreholder> These are not really crystals, but they're actually a fungus. Once infected, the Xenomite will slowly crystallize their victim.", new Color(184, 134, 11));

				if (IndustrialPickaxes.Redemption.GetTile("ScarlionOreTile") != null)
					if (tile.type == IndustrialPickaxes.Redemption.TileType("ScarlionOreTile"))
						Main.NewText("<Loreholder> A vibrant red ore, with a structure similar to ruby.", new Color(184, 134, 11));

				if (IndustrialPickaxes.Redemption.GetTile("SapphironOreTile") != null)
					if (tile.type == IndustrialPickaxes.Redemption.TileType("SapphironOreTile"))
						Main.NewText("<Loreholder> A deep blue ore, it's much like sapphire but this seems a bit more dense in structure comparatively.", new Color(184, 134, 11));

				if (IndustrialPickaxes.Redemption.GetTile("UraniumTile") != null)
					if (tile.type == IndustrialPickaxes.Redemption.TileType("UraniumTile"))
						Main.NewText("<Loreholder> A radioactive isotope. May cause low-level radiation poisoning, make sure you have the proper gear equipped when handling this!", new Color(184, 134, 11));

				if (IndustrialPickaxes.Redemption.GetTile("PlutoniumTile") != null)
					if (tile.type == IndustrialPickaxes.Redemption.TileType("PlutoniumTile"))
						Main.NewText("<Loreholder> A radioactive isotope. Usually used in nuclear arms, can cause mid-level radiation poisoning.", new Color(184, 134, 11));

				if (IndustrialPickaxes.Redemption.GetTile("SolidCoriumTile") != null)
					if (tile.type == IndustrialPickaxes.Redemption.TileType("SolidCoriumTile"))
						Main.NewText("<Loreholder> Nuclear waste, essentially radioactive lava. Causes high-level radiation poisoning, I suggest staying as far away as possible from it.", new Color(184, 134, 11));
			}
		}
	}
}