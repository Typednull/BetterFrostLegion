using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Override
{
    internal class CoalOverride : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Coal) ;
            {
                item.maxStack = 999;
            }
        }
    }
}