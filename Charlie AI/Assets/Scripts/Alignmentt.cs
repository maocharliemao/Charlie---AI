using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignmentt : MonoBehaviour
{
    public float alignmentStrength = 1.0f;


    private NeighboursRaycast neighboursScript;

    void Start()
    {
        neighboursScript = GetComponent<NeighboursRaycast>();
    }

    void FixedUpdate()
    {
        Vector3 alignmentForce = AlignmentForce(neighboursScript.neighbours);

        Vector3 cross = Vector3.Cross(transform.forward, alignmentForce);

        GetComponent<Rigidbody>().AddTorque(cross * alignmentStrength);
    }

    public Vector3 AlignmentForce(List<GameObject> neighbors)
    {
        if (neighbors.Count == 0)
            return Vector3.zero;
        
        Vector3 alignmentMove = Vector3.zero;
        
        foreach (GameObject neighbor in neighbors)
        {
            Rigidbody neighborRigidbody = neighbor.GetComponent<Rigidbody>();
            if (neighborRigidbody != null)
            {
                alignmentMove += neighborRigidbody.velocity;
            }
            
            alignmentMove /= neighbors.Count;
        }
        return Vector3.zero;

        
        //     Vector3 averageNeighborVelocity = Vector3.zero;
        //     int neighborCount = neighbors.Count;
        //
        //     if (neighborCount > 0)
        //     {
        //        
        //         Vector3 desiredVelocity = averageNeighborVelocity.normalized;
        //         Vector3 alignmentForce = (desiredVelocity - rb.velocity).normalized;
        //         return alignmentForce;
        //     }
        //
        //     return Vector3.zero;
    }
}