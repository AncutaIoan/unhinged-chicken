using UnityEngine;

public class FoodItem : MonoBehaviour, IPeckable
{
    public void OnPeck()
    {
        Debug.Log("Chicken stole food!");
        // Optional: Add to inventory or destroy object
        Destroy(gameObject);
    }
}
