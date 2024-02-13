using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesian : MonoBehaviour
{
    public float cohesionStrength = 1.0f;

    private Rigidbody rb;
    private NeighboursRaycast neighboursScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        neighboursScript = GetComponent<NeighboursRaycast>();
    }

    void FixedUpdate()
    {
        Vector3 cohesionForce = CohesionForce(neighboursScript.neighbours);
        rb.AddForce(cohesionForce * cohesionStrength);
    }

    Vector3 CohesionForce(List<GameObject> neighbors)
    {
        Vector3 averageNeighborPosition = Vector3.zero;
        int neighborCount = neighbors.Count;

        foreach (GameObject neighbor in neighbors)
        {
            averageNeighborPosition += neighbor.transform.position;
        }

        if (neighborCount > 0)
        {
            averageNeighborPosition /= neighborCount;
            Vector3 cohesionDirection = (averageNeighborPosition - transform.position).normalized;
            return cohesionDirection;
        }

        return Vector3.zero;
    }
}