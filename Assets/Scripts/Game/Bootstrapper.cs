using UnityEngine;
using Core;
using Inventory;
using Inventory.Contracts;
// This class is responsible for initializing the game and registering services. It should live in a bootstrap scene.
public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Instance.Register<IInventoryService>(new InventoryService());
    }
}