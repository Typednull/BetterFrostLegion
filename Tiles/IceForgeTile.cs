using BetterFrostLegion.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BetterFrostLegion.Tiles
{
    public class IceForgeTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.addTile(Type);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            AddMapEntry(new Color(75, 139, 166));
            AnimationFrameHeight = 54;

        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter > 5)
            {
                frameCounter = 0;
                if (++frame > 10)
                {
                    frame = 0;

                }
            }
        }


        //public override void AnimateTile(ref int frame, ref int frameCounter)
        ///{
        //	frame = Main.tileFrame[TileID.IceMachine];
        //	frameCounter = Main.tileFrameCounter[TileID.IceMachine];
        //}


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<IceForge>());
        }
    }
}
