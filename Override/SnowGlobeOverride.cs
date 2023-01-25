using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Override
{
    public class TmGlobalItem : GlobalItem
    {
        public override void AddRecipes()
        {

            //Pre boss
            //  Mod.AddRecipes();
            base.AddRecipes();
            Recipe recipe = Recipe.Create(ItemID.SnowGlobe);
            recipe.AddIngredient(ItemID.SnowBlock, 25);
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddIngredient(ItemID.HallowedBar, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            base.AddRecipes();
            Recipe recipe2 = Recipe.Create(ItemID.SnowGlobe);
            recipe2.AddIngredient(ItemID.SnowBlock, 25);
            recipe2.AddIngredient(ItemID.Glass, 5);
            recipe2.AddIngredient(ModContent.ItemType<Items.IceSoul>(), 5);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();
        }
    }
}