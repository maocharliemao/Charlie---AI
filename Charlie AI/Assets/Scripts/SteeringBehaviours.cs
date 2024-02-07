using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{

    public GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SpawnObject()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(prefab);
        }
    }
    
    
    
}
