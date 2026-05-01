using UnityEngine;
using Stats;
namespace Item
{
    public class ItemAsssigner : MonoBehaviour
    {
        private ItemBase item;
        [SerializeField] private ItemData itemData;
        [SerializeField] private StatsContainer statsContainer;

        private void Awake()
        {
            item = new ItemBase();
            item.SetItemData(itemData);
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
