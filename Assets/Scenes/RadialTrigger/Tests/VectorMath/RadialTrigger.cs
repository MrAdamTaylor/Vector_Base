using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RadialTrigger : MonoBehaviour
{
    public float Radius = 2f;
    public Transform Provocateur;
    public float PorogDistance = 2f;
    
    #if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Vector2 center = transform.position;
        
        if(Provocateur == null)
            return;

        Vector2 provoceuterPos = Provocateur.position;
        Vector2 delta = center - provoceuterPos;

        float sqrDistance = delta.x * delta.x + delta.y * delta.y;

        bool isInside = sqrDistance <= Radius * Radius && (Provocateur.position.z - transform.position.z) < PorogDistance && (transform.position.z - Provocateur.position.z) < PorogDistance;

        Handles.color = isInside ? Color.green : Color.red;
        
        Handles.DrawWireDisc(center, Vector3.forward, Radius);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, Mathf.Sqrt(transform.position.y + PorogDistance)));
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.y - PorogDistance));
    }

#endif
}
