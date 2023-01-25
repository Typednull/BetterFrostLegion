using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Items
{
    internal class FrostHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Heart");
            Tooltip.SetDefault("It beats in your hand, but it's cold as death itself."); // The (English) text shown below your item's name
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3; // How many items are needed in order to research duplication of this item in Journey mode. See https://terraria.gamepedia.com/Journey_Mode/Research_list for a list of commonly used research amounts depending on item type.
        }

        public override void SetDefaults()
        {
            Item.width = 20; // The item texture's width
            Item.height = 20; // The item texture's height
            Item.rare = ItemRarityID.Pink;
            Item.maxStack = 999; // The item' max stack value
            Item.value = Item.buyPrice(gold: 7); // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
        }
    }
}
