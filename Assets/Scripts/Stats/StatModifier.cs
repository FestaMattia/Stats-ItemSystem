using Stats;
using UnityEngine;

[System.Serializable]
public class StatModifier
{
    [SerializeField] private ModifierType type;
    public ModifierType Type => type;

    [SerializeField] private int baseValue;
    public int BaseValue => baseValue;

    private System.Func<int> valueProvider;
    public int Value => valueProvider != null ? valueProvider() : baseValue;

    private string source;

    // For static modifiers — buffs, debuffs, passives
    public StatModifier(ModifierType type, int baseValue, string source)
    {
        this.type = type;
        this.baseValue = baseValue;
        this.source = source;
    }

    // For item modifiers — value is computed at read time
    public StatModifier(ModifierType type, int baseValue, string source, System.Func<int> valueProvider)
    {
        this.type = type;
        this.baseValue = baseValue;
        this.source = source;
        this.valueProvider = valueProvider;
    }
}