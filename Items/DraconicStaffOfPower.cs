using IndustrialPickaxes.Helpers;
using IndustrialPickaxes.Items.Materials;
using IndustrialPickaxes.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items
{
	public class DraconicStaffOfPower : IndustrialPickaxe
	{
		public override Color[] ItemNameCycleColors => new Color[] { new Color(0, 0, 0), new Color(255, 170, 0) };

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/DraconicStaffOfPower");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Means to an End");
			Tooltip.SetDefault("Serves as an excellent weapon\n"
					  + "Has a sweeping edge, inflicting extra AoE damage\n"
					  + "<right> to use as a hammer\n"
					  + "Can't be used as a weapon while hammering\n"
					  + "Smelts all ores!\n'The final evolution of the Industrial Pickaxe, thank you for your support'");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.damage = 300;
			item.width = 102;
			item.height = 102;
			item.useTime = 3;
			item.useAnimation = 7;
			item.pick = 1000;
			item.axe = 150;
			item.knockBack = 10;
			item.value = Item.sellPrice(5, 0, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.tileBoost += 10;
			item.UseSound = SoundID.Item1;
		}

		public override bool AltFunctionUse(Player player) => true;

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.pick = 0;
				item.axe = 0;
				item.hammer = 200;
				item.useAnimation = 4;
				item.noMelee = true;
			}
			else
			{
				item.pick = 1000;
				item.axe = 150;
				item.hammer = 0;
				item.useAnimation = 7;
				item.noMelee = false;
			}

			return base.CanUseItem(player);
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			Projectile.NewProjectileDirect(target.Center, default, ModContent.ProjectileType<SweepingEdge>(), item.damage / 3, 5, player.whoAmI);
			Main.PlaySound(SoundID.Item117, target.position);

			base.ModifyHitNPC(player, target, ref damage, ref knockBack, ref crit);
		}

		public override void ModifyHitPvp(Player player, Player target, ref int damage, ref bool crit)
		{
			Projectile.NewProjectileDirect(target.Center, default, ModContent.ProjectileType<SweepingEdge>(), item.damage, 5, player.whoAmI);
			Main.PlaySound(SoundID.Item117, target.position);

			base.ModifyHitPvp(player, target, ref damage, ref crit);
		}

		public override void AddRecipes()
		{
			//DraconicStaffOfPowerRecipeAchievement recipe = new DraconicStaffOfPowerRecipeAchievement(mod);
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ModContent.ItemType<IndustrialSingularity>());
			recipe.AddIngredient(ModContent.ItemType<EclipsiumBar>(), 24);

			if (IndustrialPickaxes.EALoaded)
				recipe.AddIngredient(ModContent.ItemType<MasterManipulator>());

			if (IndustrialPickaxes.ThoriumLoaded)
				recipe.AddIngredient(IndustrialPickaxes.Thorium.ItemType("TerrariumCanyonSplitter"));

			if (IndustrialPickaxes.SoALoaded)
				recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialFlarium");

			if (IndustrialPickaxes.RedemptionLoaded)
				recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialNano");

			if (IndustrialPickaxes.CalamityLoaded)
			{
				recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialBlossom");
				recipe.AddTile(IndustrialPickaxes.Calamity.TileType("DraedonsForge"));
			}

			if (IndustrialPickaxes.SoALoaded)
				recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("LunarAltar"));

			recipe.AddTile(TileID.LunarCraftingStation);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		/*private class DraconicStaffOfPowerRecipeAchievement : ModRecipe
		{
			public DraconicStaffOfPowerRecipeAchievement(Mod mod) : base(mod) { }

			public override void OnCraft(Item item) => ModAchievement.CompleteFlag<DraconicEvolution>(Main.LocalPlayer);
		}*/
	}

	public class DraconicStaffOfPowerAsiimov : DraconicStaffOfPower
	{
		public override string Texture => mod.Name + "/Items/Reskins/DraconicStaffOfPowerAsiimov";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/DraconicStaffOfPowerAsiimov");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(255, 255, 255), new Color(255, 128, 0) };

		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Means to an End (Asiimov)");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<DraconicStaffOfPower>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPower>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerDemonic>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerGlacier>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class DraconicStaffOfPowerDemonic : DraconicStaffOfPower
	{
		public override string Texture => mod.Name + "/Items/Reskins/DraconicStaffOfPowerDemonic";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/DraconicStaffOfPowerDemonic");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(0, 0, 0), new Color(255, 0, 0) };

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonic Staff of Power");
			Tooltip.SetDefault("Serves as an excellent weapon\nHas a sweeping edge, inflicting extra AoE damage\n<right> to use as a hammer\nCan't be used as a weapon while hammering\nSmelts all ores!\n'Revel in the power of darkness!'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<DraconicStaffOfPower>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPower>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerAsiimov>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerGlacier>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	public class DraconicStaffOfPowerGlacier : DraconicStaffOfPower
	{
		public override string Texture => mod.Name + "/Items/Reskins/DraconicStaffOfPowerGlacier";

		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/DraconicStaffOfPowerGlacier");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(255, 255, 255), new Color(0, 255, 255) };

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glaciation Catalyst");
			Tooltip.SetDefault("Serves as an excellent weapon\nHas a sweeping edge, inflicting extra AoE damage\n<right> to use as a hammer\nCan't be used as a weapon while hammering\nSmelts all ores!\n'When the blue moon rises upon the landscape, all shall be frozen by your might'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<DraconicStaffOfPower>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPower>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerAsiimov>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerDemonic>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}