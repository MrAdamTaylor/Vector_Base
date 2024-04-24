using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 dir = transform.right;
        Ray ray = new Ray(origin, dir);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + dir);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Gizmos.DrawSphere(hit.point, 0.1f);
            Vector2 reflected = Reflect(ray.direction, hit.normal);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(hit.point, (Vector2)hit.point+reflected);
        }
    }

    Vector2 Reflect(Vector2 inDir, Vector2 n)
    {
        float proj = Vector2.Dot(inDir, n);
        return inDir - 2 * proj * n;
    }
}
