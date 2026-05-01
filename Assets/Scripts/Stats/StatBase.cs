using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public abstract class StatBase : MonoBehaviour
    {
        //protected List<StatModifier> statModifiers = new List<StatModifier>();
        [SerializeField] protected int baseValue;
        private readonly List<IModifierSource> sources = new();

        public void AddSource(IModifierSource source)
        {
            if (!sources.Contains(source))
            {
                sources.Add(source);
            }
        }
        public void RemoveSource(IModifierSource source)
        {
            if (sources.Contains(source))
            {
                sources.Remove(source);
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
            foreach (var source in sources)
            {
                foreach (var modifier in source.GetModifiers())
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
            }
            finalValue *= 1 + (int)(percentAdd / 100f);
            return finalValue;
        }

    }
}

