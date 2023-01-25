using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Items.InscribedTablets
{
    internal class InscribedTabletPostMoonLord : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inscribed Tablet Post Moon Lord");
            Tooltip.SetDefault("Thank you for defeating the one keeping us here, but im afraid the frost legion hasn't let up. Your.. how should we say, corpse littering.. helped them." +
                "\n They used the corpse of the Moon Lord. Defeat them.");
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
