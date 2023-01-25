using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace BetterFrostLegion.Common.Systems
{
    public class DownedCelestialAbominationFlag : ModSystem
    {
        public static bool DownedCelestialAbomination = false;

        public override void OnWorldLoad()
        {
            DownedCelestialAbomination = false;
        }

        public override void OnWorldUnload()
        {
            DownedCelestialAbomination = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            if (DownedCelestialAbomination)
            {
                tag["DownedSnowmanPrime"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            DownedCelestialAbomination = tag.ContainsKey("DownedSnowmanPrime");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = DownedCelestialAbomination;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            DownedCelestialAbomination = flags[0];
        }
    }
}
