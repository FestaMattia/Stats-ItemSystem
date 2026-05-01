using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public abstract class StatBase : MonoBehaviour
    {
        [SerializeField] protected int baseValue;
        private List<StatModifier> modifiers = new();

        public void AddModifier(StatModifier modifier)
        {
            if (!modifiers.Contains(modifier))
            {
                modifiers.Add(modifier);
            }
        }
        public void RemoveModifier(StatModifier modifier)
        {
            if (modifiers.Contains(modifier))
            {
                modifiers.Remove(modifier);
            }
        }
        public int BaseValue => baseValue;
        public int CurrentValue
        {
            get
            {
                return GetStat();
            }
        }
        public int GetStat()
        {
            int finalValue = baseValue;
            float percentAdd = 0;
            foreach (var modifier in modifiers)
            {
                if (modifier.Type == ModifierType.FLAT)
                {
                    finalValue += modifier.Value;
                }
                else if (modifier.Type == ModifierType.PERCENT_ADD)
                {
                    percentAdd += modifier.Value;
                }
            }
            finalValue *= 1 + (int)(percentAdd / 100f);
            return finalValue;
        }

    }
}

