using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickupItem : MonoBehaviour, IPickup
{
    public string itemName;

    public void OnPickup()
    {
        Debug.Log($"Picked up: {itemName}");
        // Add item to inventory or similar logic
        Destroy(gameObject);
    }
}
