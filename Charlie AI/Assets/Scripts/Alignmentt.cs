using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignmentt : MonoBehaviour
{
    public float alignmentStrength = 1.0f;

    private Rigidbody rb;
    private NeighboursRaycast neighboursScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        neighboursScript = GetComponent<NeighboursRaycast>();
    }

    void FixedUpdate()
    {
        Vector3 alignmentForce = AlignmentForce(neighboursScript.neighbours);
        rb.AddForce(alignmentForce * alignmentStrength);
    }

    Vector3 AlignmentForce(List<GameObject> neighbors)
    {
        Vector3 averageNeighborVelocity = Vector3.zero;
        int neighborCount = neighbors.Count;

        foreach (GameObject neighbor in neighbors)
        {
            Rigidbody neighborRigidbody = neighbor.GetComponent<Rigidbody>();
            if (neighborRigidbody != null)
            {
                averageNeighborVelocity += neighborRigidbody.velocity;
            }
        }

        if (neighborCount > 0)
        {
            averageNeighborVelocity /= neighborCount;
            Vector3 desiredVelocity = averageNeighborVelocity.normalized;
            Vector3 alignmentForce = (desiredVelocity - rb.velocity).normalized;
            return alignmentForce;
        }

        return Vector3.zero;
    }
}