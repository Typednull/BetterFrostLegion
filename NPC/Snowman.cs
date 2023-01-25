using BetterFrostLegion.Common.Systems;
using BetterFrostLegion.Items;
using BetterFrostLegion.Items.InscribedTablets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace BetterFrostLegion.NPC
{

    [AutoloadHead]
    public class Snowman : ModNPC
    {
        private static bool prehardmodeShop;
        private static bool hardmodeShop;
        private static bool help;
        private static bool test;
        private static int shopNum = 1;

        public int NumberOfTimesTalkedTo = 0;

        public override void SetStaticDefaults()
        {



            Main.npcFrameCount[Type] = 25;

            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 1;
            NPCID.Sets.AttackTime[Type] = 90;
            NPCID.Sets.AttackAverageChance[Type] = 30;
            NPCID.Sets.HatOffsetY[Type] = 4;


            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = 1

            };


            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);


            NPC.Happiness
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate)
                .SetNPCAffection(NPCID.Pirate, AffectionLevel.Love)
                .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.SantaClaus, AffectionLevel.Hate)
                //	.SetNPCAffection(ModContent.NPCType<VanityCreator>(), AffectionLevel.Like)
                ;
        }

        public override void SetDefaults()
        {
            Player player = new Player();
            player.Center = NPC.Center;
            player.UpdateBiomes();
            if (!player.ZoneSnow)
            {
                NPC.StrikeNPC(999999, 10f, -1);
            }

            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 30;
            NPC.height = 36;
            NPC.aiStyle = -1;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit11;
            NPC.DeathSound = SoundID.NPCDeath15;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }
        public static SpawnConditionBestiaryOverlayInfoElement FrostLegion = new SpawnConditionBestiaryOverlayInfoElement("Bestiary_Invasions.FrostLegion", 54, "Images/MapBG12")
        {
            DisplayTextPriority = 1,
            HideInPortraitInfo = true,
            OrderPriority = -2f
        };

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {

                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostLegion,



                new FlavorTextBestiaryInfoElement("Left the mafia to do good. They help you now! Though, they can't move, or possibly talk."),
            });
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            return true;

            if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(Type, out NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers))
            {
                drawModifiers.Rotation += 0.001f;


                NPCID.Sets.NPCBestiaryDrawOffset.Remove(Type);
                NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);


            }
        }


        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Jerry",
                "Artica",
                "Holly",
                "Polar",
            };
        }


        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (SummonSnowmanSystem.SummonSnowman)
            {
                return true;
            }
            return false;
        }


        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            int BestiaryGirl = Terraria.NPC.FindFirstNPC(NPCID.BestiaryGirl);
            if (BestiaryGirl >= 0 && Main.rand.NextBool(4))
            {
                chat.Add("... " + Main.npc[BestiaryGirl].GivenName + "...");
            }

            chat.Add(Language.GetTextValue("..."));
            chat.Add(Language.GetTextValue("...."));
            chat.Add(Language.GetTextValue("....."));
            chat.Add(Language.GetTextValue("....?"), 1.0);
            chat.Add(Language.GetTextValue("..!!"), 0.1);
            chat.Add(Language.GetTextValue("Meow."), 0.001);
            NumberOfTimesTalkedTo++;
            if (NumberOfTimesTalkedTo >= 25)
            {

                chat.Add(Language.GetTextValue("........!"));
            }

            return chat;
        }



        public override void SetChatButtons(ref string button, ref string button2)
        {
            switch (shopNum)
            {
                case 1:
                    button = "Pre Hardmode";
                    break;

                case 2:
                    button = "Hardmode";
                    break;

                case 3:
                    button = "Legion Help";
                    break;

                default:
                    button = "Post Moon Lord";
                    break;
            }

            if (Main.hardMode)
            {
                button2 = "Cycle Shop";
            }

            if (Terraria.NPC.downedMoonlord)
            {
                if (shopNum >= 5)
                {
                    shopNum = 1;
                }
            }
            else
            {
                if (shopNum >= 4)
                {
                    shopNum = 1;
                }
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;

                switch (shopNum)
                {
                    case 1:
                        prehardmodeShop = true;
                        hardmodeShop = false;
                        help = false;
                        break;
                    case 2:
                        hardmodeShop = true;
                        prehardmodeShop = false;
                        help = false;
                        break;
                    case 3:
                        help = true;
                        prehardmodeShop = false;
                        hardmodeShop = false;
                        break;
                    default:
                        prehardmodeShop = false;
                        hardmodeShop = false;
                        help = false;
                        break;
                }
            }
            else if (!firstButton && Main.hardMode)
            {
                shopNum++;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (prehardmodeShop)
            {
                shop.item[nextSlot].SetDefaults(ItemID.BowlofSoup);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
            }
            if (hardmodeShop)
            {
                shop.item[nextSlot].SetDefaults(ItemID.DirtBlock);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
            }
            if (help)
            {
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<InscribedTabletHardmode>());
                    nextSlot++;
                }
                                                                                                                                                                                                                                          

                if (Terraria.NPC.downedMechBoss1 || Terraria.NPC.downedMechBoss2 || Terraria.NPC.downedMechBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<InscribedTabletPostMechs>());
                    nextSlot++;
                }

                 if (Terraria.NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<InscribedTabletPostPlant>());
                    nextSlot++;
                }

                  if (Terraria.NPC.downedTowers)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<InscribedTabletPostPillars>());
                    nextSlot++;
                }

                     if (Terraria.NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<InscribedTabletPostMoonLord>());
                    nextSlot++;
                }

                    if (DownedLunarMonstrosityFlag.DownedLunarMonstrosity)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<InscribedTabletPostLunarMonstrosity>());
                    nextSlot++;
                }
            }
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void LoadData(TagCompound tag)
        {
            NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
        }

        public override void SaveData(TagCompound tag)
        {
            tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
        }
    }
}
