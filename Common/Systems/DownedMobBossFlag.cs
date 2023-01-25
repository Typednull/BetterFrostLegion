using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace BetterFrostLegion.Common.Systems
{
    public class DownedMobBossFlag : ModSystem
    {
        public static bool DownedMobBoss = false;

        public override void OnWorldLoad()
        {
            DownedMobBoss = false;
        }

        public override void OnWorldUnload()
        {
            DownedMobBoss = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            if (DownedMobBoss)
            {
                tag["DownedSnowmanPrime"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            DownedMobBoss = tag.ContainsKey("DownedSnowmanPrime");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = DownedMobBoss;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            DownedMobBoss = flags[0];
        }
    }
}
