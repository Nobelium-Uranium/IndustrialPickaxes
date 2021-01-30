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
    public class EclipsiumEviscerator : IndustrialPickaxe
    {
        public override Color[] ItemNameCycleColors => new Color[] { Color.Black, new Color(255, 170, 0) };

        public override Texture2D GlowmaskTexture => mod.GetTexture("Glowmasks/EclipsiumEviscerator");
        
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Serves as an excellent weapon\n"
                      + "Has a sweeping edge, inflicting extra AoE damage\n"
                      + "'May the dark sun fall on your enemies'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 180;
            item.width = 20;
            item.height = 20;
            item.useTime = 6;
            item.useAnimation = 10;
            item.pick = 300;
            item.knockBack = 4;
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = ItemRarityID.Purple;
            item.tileBoost += 3;
            item.UseSound = SoundID.Item71;
        }
        
        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            Projectile.NewProjectileDirect(target.Center, default, ModContent.ProjectileType<SweepingEdge>(), item.damage / 5, 1, player.whoAmI, -.5f);
            Main.PlaySound(SoundID.Item117, target.position);

            base.ModifyHitNPC(player, target, ref damage, ref knockBack, ref crit);
        }

        public override void ModifyHitPvp(Player player, Player target, ref int damage, ref bool crit)
        {
            Projectile.NewProjectileDirect(target.Center, default, ModContent.ProjectileType<SweepingEdge>(), item.damage / 2, 2.5f, player.whoAmI, -.5f);
            Main.PlaySound(SoundID.Item117, target.position);

            base.ModifyHitPvp(player, target, ref damage, ref crit);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<EclipsiumBar>(), 15);

            if (IndustrialPickaxes.CalamityLoaded)
                recipe.AddTile(IndustrialPickaxes.Calamity.TileType("DraedonsForge"));
            else if (IndustrialPickaxes.SoALoaded)
                recipe.AddTile(IndustrialPickaxes.SacredTools.TileType("LunarAltar"));
            else
                recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
