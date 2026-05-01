using Stats;
using UnityEngine;

[System.Serializable]
public class StatModifier
{
    [SerializeField] private StatType stat;
    [SerializeField] private ModifierType type;
    public StatType Stat => stat;
    public ModifierType Type => type;

    [SerializeField] private int value;
    public int Value => value;
    /// <summary>
    /// Sets the value of the stat modifier using a function that provides the value.
    /// </summary>
    /// <param name="valueProvider">A function that returns the value to set.</param>
    public void SetValue(System.Func<int> valueProvider)
    {
        this.value = valueProvider();
    }
}