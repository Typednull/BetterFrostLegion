using BetterFrostLegion.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Items
{
    internal class IceForge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Forge");
            Tooltip.SetDefault("Used for special crafting"); // The (English) text shown below your item's name
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; // How many items are needed in order to research duplication of this item in Journey mode. See https://terraria.gamepedia.com/Journey_Mode/Research_list for a list of commonly used research amounts depending on item type.
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = 21;
            Item.placeStyle = 1;
            Item.width = 26;
            Item.height = 22;
            Item.value = 5000;
            Item.rare = ItemRarityID.Pink;
            Item.createTile = ModContent.TileType<IceForgeTile>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IceMachine)
                .AddIngredient(ItemID.IronAnvil)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.IceMachine)
                .AddIngredient(ItemID.LeadAnvil)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
