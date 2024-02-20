using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    public float perceptionAmount = 0f;
    public AIEyes aiEyes;
    public float maxPerceptionDistance = 10f; 
    public float minPerceptionAmount = 0.1f; 
    public float maxPerceptionAmount = 1f;    
    private void Start()
    {
        aiEyes = GetComponent<AIEyes>();
    }
    void Update()
    {
        perceptionAmount = CalculatePerception();
    }
    float CalculatePerception()
    {
        float closestDistance = float.MaxValue;
        
        foreach (Transform detectedObject in aiEyes.detectedObjects)
        {
            float distanceToDetected = Vector3.Distance(transform.position, detectedObject.position);
            closestDistance = Mathf.Min(closestDistance, distanceToDetected);
        }
        float perception = 1f - Mathf.Clamp01(closestDistance / maxPerceptionDistance);
        
        perception = Mathf.Lerp(minPerceptionAmount, maxPerceptionAmount, perception);
        
        return perception;
    }
}
