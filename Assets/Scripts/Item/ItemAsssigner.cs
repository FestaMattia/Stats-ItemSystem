using UnityEngine;
using Stats;
namespace Item
{
    public class ItemAsssigner : MonoBehaviour
    {
        [SerializeField] private ItemBase item;

        [SerializeField] private StatsContainer statsContainer;

        private void Awake()
        {
            if (item == null)
            {
                Debug.LogError("Item is not assigned in the inspector.");
                return;
            }
            if (statsContainer == null)
            {
                Debug.LogError("StatsContainer is not assigned in the inspector.");
                return;
            }
            // Assign item stats to the StatsContainer
            statsContainer.AssignSources(item);
        }
    }
}
