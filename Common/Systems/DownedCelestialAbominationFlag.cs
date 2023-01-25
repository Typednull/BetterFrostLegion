using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace BetterFrostLegion.Common.Systems
{
    public class DownedGigaSnowmanFlag : ModSystem
    {
        public static bool DownedGigaSnowman = false;

        public override void OnWorldLoad()
        {
            DownedGigaSnowman = false;
        }

        public override void OnWorldUnload()
        {
            DownedGigaSnowman = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            if (DownedGigaSnowman)
            {
                tag["DownedSnowmanPrime"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            DownedGigaSnowman = tag.ContainsKey("DownedSnowmanPrime");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = DownedGigaSnowman;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            DownedGigaSnowman = flags[0];
        }
    }
}
