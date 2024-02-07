using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wander : MonoBehaviour
{
    public float offset;
    public Rigidbody rb;
    public float speed;
    
    float minValue = -999f;
    float maxValue = 999f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = Random.Range(minValue, maxValue);
    }
    
    
        
    // Update is called once per frame
    void FixedUpdate()
    {
        float rotate = Mathf.PerlinNoise1D(Time.time + offset);
        rotate -= .5f;
        rb.AddRelativeTorque(0,rotate * speed,0);

    }
}
