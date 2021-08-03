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
		public override Color[] ItemNameCycleColors => new Color[] { Color.Black, new Color(255, 170, 0) };

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
			item.value = Item.sellPrice(30, 0, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.tileBoost += 10;
            item.UseSound = SoundID.Item71;
            item.autoReuse = false;
		}

		public override bool AltFunctionUse(Player player) => true;

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.autoReuse = false;
				item.pick = 0;
				item.axe = 0;
				item.hammer = 200;
                item.useAnimation = 3;
                item.noMelee = true;
			}
			else
			{
				item.pick = 1000;
				item.axe = 150;
				item.hammer = 0;
                item.useAnimation = 7;
                item.noMelee = false;
				item.autoReuse = true;
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

            recipe.AddIngredient(ModContent.ItemType<EclipsiumEviscerator>());
            recipe.AddIngredient(ModContent.ItemType<EclipsiumBar>(), 35);
            if (IndustrialPickaxes.EALoaded || IndustrialPickaxes.ThoriumLoaded || IndustrialPickaxes.SoALoaded || IndustrialPickaxes.RedemptionLoaded || IndustrialPickaxes.CalamityLoaded)
                recipe.AddIngredient(ModContent.ItemType<IndustrialSingularity>());

			recipe.AddRecipeGroup("IndustrialPickaxes:EnchantedPickaxe");
			recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialMolten");
			recipe.AddRecipeGroup("IndustrialPickaxes:SteampunkExcavator");
			recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialChlorophyte");
            recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialPicksaw");
            recipe.AddRecipeGroup("IndustrialPickaxes:IndustrialLunar");

			if (IndustrialPickaxes.CalamityLoaded)
				recipe.AddTile(IndustrialPickaxes.Calamity.TileType("DraedonsForge"));
            else if (IndustrialPickaxes.SoALoaded)
				recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("LunarAltar"));
            else
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
            Tooltip.SetDefault("Serves as an excellent weapon\nHas a sweeping edge, inflicting extra AoE damage\n<right> to use as a hammer\nCan't be used as a weapon while hammering\nSmelts all ores!\n'Get good, get TerrariaBox!'");
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

    public class DraconicStaffOfPowerStellar : DraconicStaffOfPower
    {
        public override string Texture => mod.Name + "/Items/Reskins/DraconicStaffOfPowerStellar";

        public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/DraconicStaffOfPowerStellar");

        public override Color GlowColor => Main.DiscoColor;

        public override Color[] ItemNameCycleColors => new Color[] { new Color(255, 255, 255), Main.DiscoColor, new Color(0, 0, 0), Main.DiscoColor };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stellar Horizon");
            Tooltip.SetDefault("Serves as an excellent weapon\nHas a sweeping edge, inflicting extra AoE damage\n<right> to use as a hammer\nCan't be used as a weapon while hammering\nSmelts all ores!\n'Per ardua ad astra'\n'You feel an unusual sense of peace when holding this'");
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Glowmasks/Reskins/DraconicStaffOfPowerStellar");
            Vector2 position = item.position - Main.screenPosition + new Vector2(item.width / 2, item.height - texture.Height * 0.5f + 2f);
            spriteBatch.Draw(texture, position, null, Main.DiscoColor, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = mod.GetTexture("Glowmasks/Reskins/DraconicStaffOfPowerStellar");
            spriteBatch.Draw(texture, position, null, Main.DiscoColor, 0, origin, scale, SpriteEffects.None, 0f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPower>());
            recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerAsiimov>());
            recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerDemonic>());
            recipe.AddIngredient(ModContent.ItemType<DraconicStaffOfPowerGlacier>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}