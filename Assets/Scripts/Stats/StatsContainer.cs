using UnityEngine;

namespace Stats
{

    public class StatsContainer : MonoBehaviour
    {
        [SerializeField] private Health health;
        public Health Health => health;

        [SerializeField] private Attack attack;
        public Attack Attack => attack;

        [SerializeField] private Defense defense;
        public Defense Defense => defense;

        [SerializeField] private DodgeChance dodgeChance;
        public DodgeChance DodgeChance => dodgeChance;

        public void AssignSources(IModifierSource source)
        {
            foreach (var modifier in source.GetModifiers())
            {
                switch (modifier.Stat)
                {
                    case StatType.HEALTH:
                        health.AddModifier(modifier);
                        break;
                    case StatType.ATTACK:
                        attack.AddModifier(modifier);
                        break;
                    case StatType.DEFENSE:
                        defense.AddModifier(modifier);
                        break;
                    case StatType.DODGE_CHANCE:
                        dodgeChance.AddModifier(modifier);
                        break;
                }
            }
        }
        public void Start()
        {
            Debug.Log("StatsContainer Start called,\n Health: " + health.CurrentValue + ",\n Attack: " + attack.CurrentValue + ",\n Defense: " + defense.CurrentValue + ",\n DodgeChance: " + dodgeChance.CurrentValue);
        }
    }
}
