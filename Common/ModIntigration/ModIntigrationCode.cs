using BetterFrostLegion.Items;
using Terraria.ModLoader;

namespace BetterFrostLegion.Common.ModIntigration
{
    internal class ModIntigrationCode
    {
        public class ModIntegrationsSystem : ModSystem
        {
            public override void PostSetupContent()
            {
                // Most often, mods require you to use the PostSetupContent hook to call their methods. This guarantees various data is initialized and set up properly

                // Census Mod allows us to add spawn information to the town NPCs UI:
                // https://forums.terraria.org/index.php?threads/.74786/
                DoCensusIntegration();

                // Boss Checklist shows comprehensive information about bosses in its own UI. We can customize it:
                // https://forums.terraria.org/index.php?threads/.50668/
                //DoBossChecklistIntegration();

                // We can integrate with other mods here by following the same pattern. Some modders may prefer a ModSystem for each mod they integrate with, or some other design.
            }

            private void DoCensusIntegration()
            {
                // We figured out how to add support by looking at it's Call method: https://github.com/JavidPack/Census/blob/1.4/Census.cs
                // Census also has a wiki, where the Call methods are better explained: https://github.com/JavidPack/Census/wiki/Support-using-Mod-Call

                if (!ModLoader.TryGetMod("Census", out Mod censusMod))
                {
                    // TryGetMod returns false if the mod is not currently loaded, so if this is the case, we just return early
                    return;
                }

                // The "TownNPCCondition" method allows us to write out the spawn condition (which is coded via CanTownNPCSpawn), it requires an NPC type and a message
                int npcType = ModContent.NPCType<NPC.Snowman>();

                // The message makes use of chat tags to make the item appear directly, making it more fancy
                string message = $"Use [i:{ModContent.ItemType<SnowmanCallingCard>()}] to summon. Requires a house in the Snow Biome";

                // Finally, call the desired method
                censusMod.Call("TownNPCCondition", npcType, message);

                // Additional calls can be made here for other Town NPCs in our mod
            }
        }
    }
}
