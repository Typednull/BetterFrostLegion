using BetterFrostLegion.Common.Systems;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Items
{
    internal class SnowmanCallingCard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowman License");
            Tooltip.SetDefault("Whenever you use this card, a snowman is granted its freedom" +
                "\n Requires a house in the Snow Biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.useStyle = 4;
            Item.consumable = true;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.UseSound = SoundID.Item92;
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(gold: 7);
            Item.rare = ItemRarityID.Green;
        }
        public override bool? UseItem(Player player) => SummonSnowmanSystem.SummonSnowman = true;
    }
}
