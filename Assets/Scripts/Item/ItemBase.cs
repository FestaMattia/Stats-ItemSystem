using Item;
using Stats;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : IModifierSource
{
    private ItemData itemData;
    private int currentLevel = 1;
    private Rarity currentRarity = Rarity.COMMON;

    public void SetLevel(int level) => currentLevel = level;
    public void SetRarity(Rarity rarity) => currentRarity = rarity;
    public void SetItemData(ItemData data) => itemData = data;
    public IEnumerable<StatModifier> GetModifiers()
    {
        if (itemData == null) yield break;

        foreach (var slot in itemData.ModifierSlots)
        {
            if (!slot.IsUnlockedAt(currentRarity)) continue;

            var modifier = slot.Modifier;

            // Flat modifiers scale with level; percent modifiers don't
            if (modifier.Type == ModifierType.FLAT)
            {
                int scaledValue = modifier.Value + ((currentLevel - 1) * 2);
                yield return modifier.WithValue(scaledValue);
            }
            else
            {
                yield return modifier;
            }
        }
    }
}