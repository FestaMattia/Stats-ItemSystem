using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    public string ItemName => itemName;

    [SerializeField] private List<StatModifier> baseStatModifiers = new();
    public IReadOnlyList<StatModifier> BaseStatModifiers => baseStatModifiers;
}