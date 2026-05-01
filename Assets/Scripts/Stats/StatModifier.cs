using Stats;
using UnityEngine;

[System.Serializable]
public class StatModifier
{
    [SerializeField] private StatType stat;
    [SerializeField] private ModifierType type;
    [Tooltip("Indicates that this modifier is active by default.")]
    [SerializeField] private bool isDefaultStat; // Indicates that this modifier is active by default
    [SerializeField] private bool isActive; // Indicates whether the modifier is currently active
    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }
    public bool IsDefaultStat => isDefaultStat; // Expose the default stat flag
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