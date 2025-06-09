using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPeck : MonoBehaviour
{
    public float peckRange = 1f;
    public float peckCooldown = 0.5f;
    public LayerMask interactableLayers;
    private float nextPeckTime = 0f;

    public Transform peckOrigin; // Point in front of beak

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && Time.time > nextPeckTime)
        {
            nextPeckTime = Time.time + peckCooldown;

            // Optional: Trigger peck animation
            // animator.SetTrigger("Peck");

            Debug.Log("Peck!");
            TryPeck();
        }
    }

    void TryPeck()
    {
        if (peckOrigin == null)
        {
            Debug.LogWarning("Peck origin not assigned!");
            return;
        }

        Vector3 direction = GetFacingDirection();
        float radius = 0.2f; // Beak "thickness"

        if (Physics.SphereCast(peckOrigin.position, radius, direction, out RaycastHit hit, peckRange, interactableLayers))
        {
            var peckable = hit.collider.GetComponent<IPeckable>();
            if (peckable != null)
            {
                peckable.OnPeck();
            }
        }
    }

    Vector3 GetFacingDirection()
    {
        return peckOrigin.forward;
    }

    void OnDrawGizmosSelected()
    {
        if (peckOrigin == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(peckOrigin.position, GetFacingDirection() * peckRange);
    }
}
