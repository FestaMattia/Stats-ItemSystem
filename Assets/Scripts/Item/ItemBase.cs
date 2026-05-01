using UnityEngine;
using System.Collections.Generic;
using Stats;

namespace Item
{
    public class ItemBase : MonoBehaviour, IModifierSource
    {
        [SerializeField] private ItemData itemData;
        private List<StatModifier> currentStatModifiers = new();
        private int currentLevel = 4;
        private Rarity currentRarity = Rarity.RARE;
        private void Awake()
        {
            if (itemData == null)
            {
                return;
            }

            currentStatModifiers.Clear();
            currentStatModifiers.AddRange(itemData.BaseStatModifiers);
        }
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
        /// Updates the stat modifiers based on current level and rarity.
        /// </summary>
        public void UpdateStatModifiers() //TODO: Optimize, ask Mattia if we should use BaseStats or CurrentStats for exponential growth
        {
            for (int i = 0; i < itemData.BaseStatModifiers.Count; i++)
            {
                if (itemData.BaseStatModifiers[i].Type == ModifierType.PERCENT_ADD)
                    continue; // Skip percentage modifiers

                var modifier = itemData.BaseStatModifiers[i];
                // Increase the value of the modifier based on level and rarity
                int newValue = modifier.Value + (currentLevel * 2) + ((int)currentRarity * 3);
                modifier.SetValue(() => newValue);
            }
        }
        public IEnumerable<StatModifier> GetModifiers()
        {
            Debug.Log("GetModifiers called, returning " + currentStatModifiers.Count + " modifiers.");
            // upgrade level determines how many elements of the list are active
            return currentStatModifiers.GetRange(0, Mathf.Min((int)currentRarity + 1, currentStatModifiers.Count));
        }
    }
}
