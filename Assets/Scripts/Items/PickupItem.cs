using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickupItem : MonoBehaviour, IPickup
{
    public string itemName;

    public void OnPickup()
    {
        Debug.Log($"Picked up: {itemName}");
        // Add item to inventory or similar logic
        // TODO create logic to add to player inventory
        Destroy(gameObject);
    }
}
