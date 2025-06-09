using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlayerPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    private List<PickupItem> nearbyItems = new List<PickupItem>();

    void Update()
    {
        if (Input.GetKeyDown(pickupKey) && nearbyItems.Count > 0)
        {
            PickupItem closest = nearbyItems.OrderBy(i => Vector3.Distance(transform.position, i.transform.position)).FirstOrDefault();
            if (closest != null)
            {
                closest.OnPickup();
                nearbyItems.Remove(closest);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PickupItem>(out var item))
        {
            nearbyItems.Add(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PickupItem>(out var item))
        {
            nearbyItems.Remove(item);
        }
    }
}
