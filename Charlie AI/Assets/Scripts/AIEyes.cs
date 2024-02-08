using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEyes : MonoBehaviour
{
    public int rays = 10;
    public float maxAngle = 1f;

    private void FixedUpdate()
    {
        for (int i = -rays/2; i <= rays/2; i++)
        {
     
            float spreadAngle = -maxAngle/(rays-1);
            Vector3 dir = Quaternion.Euler(0, i*spreadAngle, 0) * transform.forward;


            Debug.DrawRay(transform.position, dir * 20f, Color.yellow);
        }
    }

}
