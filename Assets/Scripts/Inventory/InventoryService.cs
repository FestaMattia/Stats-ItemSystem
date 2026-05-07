using UnityEngine;
using Inventory.Contracts;
namespace Inventory
// Service that manages inventory logic. Should be registered in ServiceLocator on start-up.
{
    public class InventoryService : IInventoryService
    {
        public void addItem()
        {
            // Add item to inventory
        }
    }
}
