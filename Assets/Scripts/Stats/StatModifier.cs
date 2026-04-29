using UnityEngine;

namespace Stats
{
    [System.Serializable]
    public class StatModifier : MonoBehaviour
    {
        [SerializeField] private ModifierType type;
        public ModifierType Type => type;

        [SerializeField] private int value;
        public int Value => value;

        [SerializeField] private string source; //Change in HashSet

        public StatModifier(ModifierType type, int value, string source)
        {
            this.type = type;
            this.value = value;
            this.source = source;
        }
    }
}
