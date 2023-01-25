using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Items.InscribedTablets
{
    internal class InscribedTabletPostPillars : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inscribed Tablet Celestial Towers");
            Tooltip.SetDefault("They have used the remains of the celestial bodies to their advantage. They are stronger and have yet another foe much stronger than the last." +
                "\n  Use everything you can to free us all.");
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
