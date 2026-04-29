using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace Stats
{
    public abstract class StatsBase : MonoBehaviour
    {
        private List<StatModifier> statModifiers = new List<StatModifier>();
        [SerializeField] private int baseValue;

        public int BaseValue => baseValue;

        //private int currentValue;

        public int CurrentValue
        {
            get
            {
                int flat = statModifiers.Where(x => x.Type == ModifierType.FLAT).Sum(x => x.Value);
                int percentAdd = statModifiers.Where(x => x.Type == ModifierType.PERCENT_ADD).Sum(x => x.Value);
                return (int)(baseValue + flat) * (1 + percentAdd / 100);
            }
        }


    }
}

