using UnityEngine;

public class ButtonPeck : MonoBehaviour, IPeckable
{
    public void OnPeck()
    {
        Debug.Log("Button pressed by peck!");
        // Trigger mechanism
        GetComponent<Animator>()?.SetTrigger("Press");
    }
}
