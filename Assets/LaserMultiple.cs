using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMultiple : MonoBehaviour
{
    [SerializeField]private int _maxBounces = 40;

    public void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 dir = transform.right;
        Ray ray = new Ray(origin, dir);

        for (int i = 0; i < _maxBounces; i++)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(ray.origin, hit.point);

                Gizmos.DrawSphere(hit.point, 0.1f);
                Vector2 reflected = Reflect(ray.direction, hit.normal);
                Gizmos.color = Color.white;
                Gizmos.DrawLine(hit.point, (Vector2)hit.point+reflected);
                ray.direction = reflected;
                ray.origin = hit.point;
            }
            else
            {
                break;
            }
        }


        
    }

    Vector2 Reflect(Vector2 inDir, Vector2 n)
    {
        float proj = Vector2.Dot(inDir, n);
        return inDir - 2 * proj * n;
    }
}
