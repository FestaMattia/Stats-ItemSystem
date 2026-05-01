using UnityEngine;

namespace Item
{
    [System.Serializable]
    public class ModifierSlot
    {
        [SerializeField] private StatModifier modifier;
        [Tooltip("This slot is always active regardless of rarity.")]
        [SerializeField] private bool isCore;
        [SerializeField] private Rarity minimumRarity;

        public StatModifier Modifier => modifier;
        public bool IsCore => isCore;
        public Rarity MinimumRarity => minimumRarity;
        /// <summary>
        /// Unlocked if it's a core slot or if the item's rarity meets the minimum requirement.
        /// </summary>
        /// <param name="rarity">The rarity of the item to check against.</param>
        /// <returns>True if the slot is unlocked at the given rarity or if it's a core slot, false otherwise.</returns>
        public bool IsUnlockedAt(Rarity rarity) => isCore || rarity >= minimumRarity;
    }
}
