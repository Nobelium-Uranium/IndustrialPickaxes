using IndustrialPickaxes.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Fishaxe
{
	public class Fishaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fishaxe"); // Not needed because of internal name but needed because of deriving types
			Tooltip.SetDefault("'Just an ordinary fish pickaxe'");
		}

		public override void SetDefaults()
		{
			item.damage = 1;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 30;
			item.pick = 5;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1;
			item.value = 1;
			item.rare = -1;
			item.tileBoost -= 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            if (item.lavaWet)
            {
                Item.NewItem(item.getRect(), ModContent.ItemType<DeadFishaxe>());

                item.active = false;
            }
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IndustrialPickaxes:Fishaxe");
			recipe.AddTile(TileID.CookingPots);
			recipe.SetResult(ItemID.CookedFish);
			recipe.AddRecipe();
		}
	}

	public class FishaxeRitual : Fishaxe
	{
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			if (item.lavaWet)
            {
                Item.NewItem(item.getRect(), ModContent.ItemType<ExaltedFishaxe>());

                item.active = false;
            }
		}

		public override void AddRecipes()
		{
			return;
		}
	}

    public class DeadFishaxe : Fishaxe
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dead Fishaxe");
            Tooltip.SetDefault("'You monster'");
        }

        public override void AddRecipes()
        {
            return;
        }
    }

    public class ExaltedFishaxe : Fishaxe
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exalted Fishaxe");
            Tooltip.SetDefault("'It is ready'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = ItemRarityID.Quest;
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            for (int i = 0; i < Main.maxItems; i++)
            {
                Item item = Main.item[i];

                if (item.active && item.type == ModContent.ItemType<EclipsiumBar>() && item.stack >= 99)
                {
                    if (base.item.getRect().Intersects(item.getRect()) && base.item.lavaWet == item.lavaWet == true && Main.eclipse)
                    {
                        Item.NewItem(base.item.getRect(), ModContent.ItemType<AscendedFishaxe>());
                        Main.PlaySound(SoundID.Item119, base.item.position);

                        base.item.active = false;
                        item.active = false;
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            return;
        }
    }
}