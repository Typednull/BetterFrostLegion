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
    [AutoloadEquip(EquipType.Body)]
    internal class HardenedFrostChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hardened Frost Chestplate");
            Tooltip.SetDefault("Icreases damage by 5%, Ranged and Melee critical strice chance by 15%," +
                "\n and Magic and Summon critical strice chance by 11%.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 6);
            Item.rare = ItemRarityID.Pink;
            Item.defense = 22;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Magic) += 0.11f;
            player.GetCritChance(DamageClass.Summon) += 0.11f;
            player.GetCritChance(DamageClass.Melee) += 0.15f;
            player.GetCritChance(DamageClass.Ranged) += 0.15f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<HardenedFrostLeggings>() && legs.type == ModContent.ItemType<HardenedFrostLeggings>();
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
                    .AddIngredient(ItemID.FrostBreastplate)
                    .AddIngredient<HardenedSnow>(10)
                    // .AddIngredient<BlackIce>(5)
                    .AddIngredient<FrostHeart>()
                    .AddTile<IceForgeTile>()
                    .Register();
        }
    }
}
