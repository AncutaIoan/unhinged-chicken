using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject pickupPrefab;  // The prefab you want to drop
    public Vector3 dropOffset = new Vector3(0, 0, 1f);

    void Update()
    {
        // Check for drop key press every frame
        if (Input.GetKeyDown(KeyCode.G))  // Press G to drop
        {
            DropItem();
        }
    }

    void DropItem()
    {
        Vector3 dropPos = transform.position + transform.forward * dropOffset.z + Vector3.up * dropOffset.y;
        Instantiate(pickupPrefab, dropPos, Quaternion.identity);
    }
}
