using UnityEngine;
using System.Collections.Generic;
using Stats;

namespace Item
{
    public class ItemBase : IModifierSource //TODO: remove Monobehavior and create items as pure data classes
    {
        [SerializeField] private ItemData itemData;
        private List<StatModifier> currentStatModifiers = new();
        private int currentLevel = 1;
        private Rarity currentRarity = Rarity.UNCOMMON;
        public void SetLevel(int level)
        {
            currentLevel = level;
            UpdateStatModifiers();
        }
        public void SetRarity(Rarity rarity)
        {
            currentRarity = rarity;
            UpdateStatModifiers();
        }
        /// <summary>
        /// Sets the active stat modifiers based on the item's rarity.
        /// </summary>
        private void SetActiveModifiers()
        {
            if (itemData == null)
            {
                return;
            }

            currentStatModifiers.Clear();
            for (int i = 0; i < itemData.BaseStatModifiers.Count; i++)
            {
                if (itemData.BaseStatModifiers[i].IsActive || itemData.BaseStatModifiers[i].IsDefaultStat)
                {
                    currentStatModifiers.Add(itemData.BaseStatModifiers[i]);
                }
            }
        }
        /// <summary>
        /// Updates the stat modifiers based on current level.
        /// </summary>
        public void UpdateStatModifiers() //TODO: Optimize, ask Mattia if we should use BaseStats or CurrentStats for exponential growth
        {
            for (int i = 0; i < itemData.BaseStatModifiers.Count; i++)
            {
                if (itemData.BaseStatModifiers[i].Type == ModifierType.PERCENT_ADD)
                    continue; // Skip percentage modifiers

                var modifier = itemData.BaseStatModifiers[i];
                // Increase the value of the modifier based on level
                int newValue = modifier.Value + (currentLevel * 2);
                currentStatModifiers[i].SetValue(() => newValue);
            }
        }
        public IEnumerable<StatModifier> GetModifiers()
        {
            Debug.Log("GetModifiers called, returning " + currentStatModifiers.Count + " modifiers.");
            // upgrade level determines how many elements of the list are active
            return currentStatModifiers.GetRange(0, Mathf.Min((int)currentRarity, currentStatModifiers.Count));
        }
    }
}
