using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperation : MonoBehaviour
{
    public float seperationStrength;
    private Rigidbody rb;
    private NeighboursRaycast neighboursScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        neighboursScript = GetComponent<NeighboursRaycast>();
    }

    void FixedUpdate()
    {
        Vector3 seperationForce = SeperationForce(neighboursScript.neighbours);

        rb.AddForce(seperationForce * seperationStrength);
    }

    Vector3 SeperationForce(List<GameObject> neighbors)
    {
        Vector3 avoid = Vector3.zero;
        int avoidCount = 0;
        // Vector3 myPosition = transform.position;

        // if (neighbors.Count == 0)
        //     return Vector3.zero;

        foreach (GameObject neighbor in neighbors)
        {
            float distance = Vector3.Distance(transform.position, neighbor.transform.position);
            if (distance > 0)
            {
                avoid += (transform.position - neighbor.transform.position);
                avoidCount++;
            }
        }

        if (avoidCount > 0)
        {
            avoid /= avoidCount;
        }

        return avoid;
    }

    // if (neighbors.Count > 0)
    // {
    //     targetPosition /= neighbors.Count;
    //     Vector3 directionTowardsTarget = (targetPosition - myPosition).normalized;
    //     return directionTowardsTarget;
    // }
    //
    // return Vector3.zero;
}