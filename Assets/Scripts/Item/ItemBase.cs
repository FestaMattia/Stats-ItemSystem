using UnityEngine;
using System.Collections.Generic;
using Stats;

namespace Item
{
    public class ItemBase : MonoBehaviour
    {
        [SerializeField] private ItemData itemData;
        public ItemData ItemData => itemData;

        private int currentLevel;
        private int currentRarity;

        private List<StatModifier> activeStatModifiers = new List<StatModifier>();
        private void Awake()
        {
            if (itemData == null)
            {
                Debug.LogError("ItemData is not assigned in the inspector.");
                return;
            }
            activeStatModifiers.AddRange(itemData.BaseStatModifiers);
        }
        public StatModifier ToRuntimeModifier(StatModifier template)
        {
            return new StatModifier(
                template.Type,
                template.BaseValue,
                itemData.ItemName,
                () => ItemScaling.ComputeValue(template.BaseValue, currentLevel, currentRarity)
            );
        }
    }
}
