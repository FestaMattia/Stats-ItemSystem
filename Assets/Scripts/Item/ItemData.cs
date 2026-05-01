using System.Collections.Generic;
using UnityEngine;
namespace Item
{
    [CreateAssetMenu(fileName = "New Item Data", menuName = "ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private List<ModifierSlot> modifierSlots = new();
        public IReadOnlyList<ModifierSlot> ModifierSlots => modifierSlots;
    }
}