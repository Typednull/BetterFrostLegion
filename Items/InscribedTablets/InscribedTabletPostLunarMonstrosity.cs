using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Items.InscribedTablets
{
    internal class InscribedTabletPostLunarMonstrosity : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inscribed Tablet Post Lunar Monstrosity");
            Tooltip.SetDefault("Congrats to you. The one beyond the fourth wall. Or rather, the wall infront of our two dimensional universe. I played you for a fool." +
                "\n Now I have more power than you can imagine. Yes, you may use the power. For a small price. Im selling it in a new shop. Can't be a god without money.");
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
