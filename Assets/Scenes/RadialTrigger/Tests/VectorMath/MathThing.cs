using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathThing : MonoBehaviour
{

    public Transform Avec;
    public Transform Bvec;

    public float scProj;
    void OnDrawGizmos()
    {
        Vector2 a = Avec.position;
        Vector2 b = Bvec.position;
        
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(default, a);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, b);

        float aLen = a.magnitude;

        Vector2 aNorm = a.normalized;
        
        Gizmos.DrawSphere(aNorm, 0.05f);

        scProj = Vector2.Dot(aNorm, b);

        Vector2 vecProj = aNorm * scProj;

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(vecProj, 0.05f);
    }
}

public static class VectorsOpearionDescription
{
    public static Vector2 vec;

    //TODO - расчёт длинны векторов
    private static float aLen = vec.magnitude;
    private static float aLen_calc = Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);

    //TODO - расчёт нормализованных векторов
    private static Vector2 aNorm = vec.normalized;
    private static Vector2 aNorm_calc = vec/aLen_calc;

}
