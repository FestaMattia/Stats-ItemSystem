using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public abstract class StatBase : MonoBehaviour
    {
        protected List<StatModifier> statModifiers = new List<StatModifier>();
        [SerializeField] protected int baseValue;

        public int BaseValue => baseValue;

        public abstract int CurrentValue
        {
            get;
        }


    }
}

