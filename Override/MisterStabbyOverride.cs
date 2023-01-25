using BetterFrostLegion.Items;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Override
{
    public class MyGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(Terraria.NPC npc, NPCLoot npcLoot)
        {
            // First, we need to check the npc.type to see if the code is running for the vanilla NPCwe want to change
            if (npc.type == NPCID.MisterStabby)
            {
                // This is where we add item drop rules for VampireBat, here is a simple example:
                //npcLoot.Add(ItemDropRule.Common(ItemID.DirtBlock, 1, 3, 5));
                npcLoot.Add(ItemDropRule.Common(ItemID.Coal, 3, 1, 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IceSoul>(), 5, 5, 10));
                //npcLoot.Add(ItemDropRule.Common(ItemID.DirtBlock, 1, 3, 5)); drops three to five 1(100% smaller the number higher the chance.) 3(minimum three drop) 5(maximum five drop)
                //npcLoot.Add(ItemDropRule.Common(ItemID.DirtBlock, 1)); (drops 1 onehundred precent of the time)
            }
            // We can use other if statements here to adjust the drop rules of other vanilla NPC

            if (npc.type == NPCID.SnowBalla)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Coal, 3, 1, 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IceSoul>(), 5, 5, 10));
            }

            if (npc.type == NPCID.SnowmanGangsta)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.Coal, 3, 1, 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IceSoul>(), 5, 5, 10));
            }

        }
    }
}