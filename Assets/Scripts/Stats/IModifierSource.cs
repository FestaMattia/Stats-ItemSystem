using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public interface IModifierSource
    {
        IEnumerable<StatModifier> GetModifiers();
    }
}
