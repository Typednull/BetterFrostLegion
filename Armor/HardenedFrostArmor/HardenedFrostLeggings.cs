using BetterFrostLegion.Items;
using BetterFrostLegion.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFrostLegion.Armor.HardenedFrostArmor
{
    [AutoloadEquip(EquipType.Legs)]
    internal class HardenedFrostLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hardened Frost Leggings");
            Tooltip.SetDefault("Icreases all damage by 18%, 20% chance to not consume ammo" +
                "\n Increases Maximum mana by 40 and reduces mana cost by 18%");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 6);
            Item.rare = ItemRarityID.Pink;
            Item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
            player.GetCritChance(DamageClass.Generic) += 0.80f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<HardenedFrostChestplate>() && legs.type == ModContent.ItemType<HardenedFrostHelmet>();
        }

         public override void UpdateArmorSet(Player player)
         {
            player.setBonus = "Inflicts Frost Burn and makes the player imune to fire";
            player.frostBurn = true;
            player.buffImmune[BuffID.OnFire] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                    .AddIngredient(ItemID.FrostHelmet)
                    .AddIngredient<HardenedSnow>(10)
                    // .AddIngredient<BlackIce>(5)
                    .AddIngredient<FrostHeart>()
                    .AddTile<IceForgeTile>()
                    .Register();
        }
    }
}