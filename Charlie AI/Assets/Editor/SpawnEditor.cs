using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SteeringBehaviours))]
public class SpawnEditor : Editor
{
    public override void OnInspectorGUI()
    {
    

        if (GUILayout.Button("Spawn"))
        {
           
            SteeringBehaviours spawnEditor;
            spawnEditor = target as SteeringBehaviours;
            if(spawnEditor != null)
            {
                spawnEditor .SpawnObject();
            }
        }
    }
}

