using Stats;
using UnityEngine;

[System.Serializable]
public class StatModifier
{
    [SerializeField] private StatType stat;
    [SerializeField] private ModifierType type;
    [SerializeField] private int value;
    public StatType Stat => stat;
    public ModifierType Type => type;
    public int Value => value;

    public StatModifier(StatType stat, ModifierType type, int value)
    {
        this.stat = stat;
        this.type = type;
        this.value = value;
    }

    // Non-destructive scaling — returns a new instance
    public StatModifier WithValue(int newValue) => new(stat, type, newValue);
}