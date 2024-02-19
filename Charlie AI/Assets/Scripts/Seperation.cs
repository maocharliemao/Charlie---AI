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
        Vector3 separationDirection = Vector3.zero;
        Vector3 myPosition = transform.position;

        if (neighbors.Count == 0)
            return Vector3.zero;
        

        foreach (GameObject neighbor in neighbors)
        {
            Vector3 toNeighbor = myPosition - neighbor.transform.position;
            separationDirection += toNeighbor.normalized / toNeighbor.magnitude; 
        }
        
        separationDirection /= neighbors.Count;
        
        return separationDirection.normalized;

    }


}