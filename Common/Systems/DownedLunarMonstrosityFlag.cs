using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace BetterFrostLegion.Common.Systems
{
    public class DownedLunarMonstrosityFlag : ModSystem
    {
        public static bool DownedLunarMonstrosity = false;

        public override void OnWorldLoad()
        {
            DownedLunarMonstrosity = false;
        }

        public override void OnWorldUnload()
        {
            DownedLunarMonstrosity = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            if (DownedLunarMonstrosity)
            {
                tag["DownedSnowmanPrime"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            DownedLunarMonstrosity = tag.ContainsKey("DownedSnowmanPrime");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = DownedLunarMonstrosity;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            DownedLunarMonstrosity = flags[0];
        }
    }
}
