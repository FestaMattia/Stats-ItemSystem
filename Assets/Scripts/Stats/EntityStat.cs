using UnityEngine;
using System.Linq; //TODO: Remove Linq

namespace Stats
{
    public class EntityStat : StatBase
    {
        public override int CurrentValue
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
