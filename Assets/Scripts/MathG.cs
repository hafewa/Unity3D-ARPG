using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class MathG
{
    static public float Distance(Vector2 v1, Vector2 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v2.x - v1.x, 2) + Mathf.Pow(v2.y - v1.y, 2));
    }

    static public float Distance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v2.x - v1.x, 2) + Mathf.Pow(v2.y - v1.y, 2) + Mathf.Pow(v2.z - v1.z, 2));
    }

    static public float Magnitude(Vector2 v)
    {
        return Mathf.Sqrt((Mathf.Pow(v.x, 2)) + (Mathf.Pow(v.y, 2)));
    }
    static public float Magnitude(Vector3 v)
    {
        return Mathf.Sqrt((Mathf.Pow(v.x, 2)) + (Mathf.Pow(v.y, 2)) + (Mathf.Pow(v.z, 2)));
    }

    static public Vector2 NormalVector(Vector2 v)
    {
        if(v.x == 0 && v.y == 0)
        {
            return new Vector2(0,0);
        }

        v = v / Magnitude(v);
        return v;
    }

    static public Vector3 NormalVector(Vector3 v)
    {
        if(v.x == 0 && v.y == 0 && v.z == 0)
        {
            return new Vector3(0,0);
        }

        v = v / Magnitude(v);
        return v;
    }

    static public float cubicBezier(float t,float p0,float p1, float p2, float p3)
    {
        return Mathf.Pow(1 - t, 3) * p0 + 3 * Mathf.Pow(1 - t, 2) * t * p1 + 3 * (1 - t) * Mathf.Pow(t, 2) * p2 + Mathf.Pow(t, 3) * p3;
    }

    //d = degrees
    //m = magnitude of the resulting vector
    static public Vector2 DegreeToVector2D(float d, float m)
    {
        return new Vector2(m * Mathf.Cos(d * Mathf.Deg2Rad), m * Mathf.Sin(d * Mathf.Deg2Rad));
    }

    static public float VectorToDegrees2D(Vector2 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }
}