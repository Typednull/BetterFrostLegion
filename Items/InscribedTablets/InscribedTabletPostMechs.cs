using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Items.InscribedTablets
{
    internal class InscribedTabletPostMechs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inscribed Tablet Post Mechanical Bosses");
            Tooltip.SetDefault("Craft the armor with the core of the frost and the material of both coal and snow. With that, combine it with your frozen desert varient. " +
                "\n Come back after defeating the plant abomination.");
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
