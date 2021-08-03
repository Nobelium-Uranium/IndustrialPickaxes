using IndustrialPickaxes.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace IndustrialPickaxes.Items.Developer
{
	public class VioletThaumaturgy : IndustrialPickaxe
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/VioletThaumaturgy");

		public override Color[] ItemNameCycleColors => new Color[] { new Color(24, 28, 33), new Color(98, 0, 198) };

		public override void SetStaticDefaults() => Tooltip.SetDefault("Pickaxe power adapts to your other pickaxes\nAlchemically transmutes ores into their counterpart, if they have one\nCurrently only supports vanilla ores\n'Not at its full potential... for now'");

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.damage = 60;
			item.magic = true;
			item.width = 126;
			item.height = 114;
			item.useTime = 5;
			item.useAnimation = 20;
			item.pick = 35;
			item.knockBack = 3;
			item.value = Item.sellPrice(platinum: 5);
			item.rare = ItemRarityID.Cyan;
			item.tileBoost--;
			item.UseSound = SoundID.Item71;
		}

		public override void UpdateInventory(Player player)
        {
            //Set the pickaxe power to the highest pickaxe power pickaxe in the inventory
            item.pick = player.inventory.Where(i => i.type != ModContent.ItemType<AvaliManipulator>() && i.type != ModContent.ItemType<ChimeraManipulator>() && i.type != ModContent.ItemType<VioletThaumaturgy>() && i.type != ModContent.ItemType<AmberThaumaturgy>()).Select(i => i.pick).DefaultIfEmpty()?.Max() ?? 0;

            if (item.pick < 65 && NPC.downedBoss2) //If that highest pickaxe power is below 65, and EoW or BoC is defeated, set the pickaxe power to 65
                item.pick = 65;
            else if (item.pick < 35) //If that highest pickaxe power is below 35 and BoC or EoW has not been defeated, set pickaxe power to 35
                item.pick = 35;
        }
	}

	public class AmberThaumaturgy : VioletThaumaturgy
	{
		public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/Reskins/AmberThaumaturgy");

		public override string Texture => mod.Name + "/Items/Reskins/AmberThaumaturgy";
		public override Color[] ItemNameCycleColors => new Color[] { new Color(24, 28, 33), new Color(255, 100, 50) };

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Thaumaturgy");
			Tooltip.SetDefault("Pickaxe power adapts to your other pickaxes\nAlchemically transmutes ores into their counterpart, if they have one\nCurrently only supports vanilla ores\n'Reminds you of a nice Autumn sunset...'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ModContent.ItemType<VioletThaumaturgy>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<VioletThaumaturgy>());
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}