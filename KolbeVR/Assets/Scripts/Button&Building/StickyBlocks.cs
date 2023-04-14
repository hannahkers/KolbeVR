using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBlocks : MonoBehaviour
{
    public float snapDistance = 0.1f; // distance at which objects snap together
    public LayerMask snapLayerMask; // layers to consider for snapping

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, snapDistance, snapLayerMask);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject) // don't snap to self
            {
                Vector3 snapPosition = collider.ClosestPoint(transform.position);
                float distance = Vector3.Distance(transform.position, snapPosition);
                if (distance <= snapDistance)
                {
                    rb.isKinematic = true; // make object stationary while snapping
                    transform.position = snapPosition;
                    rb.isKinematic = false; // turn physics back on
                }
            }
        }
    }
}
