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
    }
}
