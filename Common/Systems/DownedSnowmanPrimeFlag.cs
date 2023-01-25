using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace BetterFrostLegion.Common.Systems
{
    public class DownedSnowmanPrimeFlag : ModSystem
    {
        public static bool DownedSnowmanPrime = false;

        public override void OnWorldLoad()
        {
            DownedSnowmanPrime = false;
        }

        public override void OnWorldUnload()
        {
            DownedSnowmanPrime = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            if (DownedSnowmanPrime)
            {
                tag["DownedSnowmanPrime"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            DownedSnowmanPrime = tag.ContainsKey("DownedSnowmanPrime");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = DownedSnowmanPrime;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            DownedSnowmanPrime = flags[0];
        }
    }
}
