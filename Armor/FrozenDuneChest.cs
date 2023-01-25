using BetterFrostLegion.Items;
using BetterFrostLegion.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterFrostLegion.Armor
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Body)]
    public class FrozenDuneChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Frozen Dune Chestplate");
            Tooltip.SetDefault("");


            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 6); // How many coins the item is worth
            Item.rare = ItemRarityID.LightPurple; // The rarity of the item
            Item.defense = 7; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            // Make the player immune to Fire
            player.statManaMax2 += 20; // Increase how many mana points the player can have by 20
            player.maxMinions++; // Increase how many minions the player can have by one
        }

        ///	public override bool IsArmorSet(Item head, Item body, Item legs)
        //	{
        //		return body.type == ModContent.ItemType<VoidBreastplate>() && legs.type == ModContent.ItemType<VoidLeggings>();
        //	}

        //public override void UpdateArmorSet(Player player)
        //{
        //	player.setBonus = "Increases ranged damage by 20%"; // This is the setbonus tooltip
        //	frostBurn = true;
        //  player.buffImmune[BuffID.OnFire] = true;
        //  meleeDamage += 0.1f;
        //   rangedDamage += 0.1f;
        //}


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<HardenedSnow>(10)
                .AddIngredient<FrostHeart>()
                .AddTile<IceForgeTile>()
                .Register();
        }
    }
}
