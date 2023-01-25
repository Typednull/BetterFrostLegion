using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Items.InscribedTablets
{
    internal class InscribedTabletHardmode : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inscribed Tablet Hardmode");
            Tooltip.SetDefault("They have a stronger foe than usual. Be wary. They also seem to drop new items, perhaps you can use them to your advantage." +
                "\n Ask the guide! Come back after you defeated the mangled machines");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.rare = ItemRarityID.Pink;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(gold: -1);
        }
    }
}
