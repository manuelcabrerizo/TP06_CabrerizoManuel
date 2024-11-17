using System;
using UnityEngine;
using static UnityEngine.UI.Image;

public static class Utils
{
    static public bool CheckCollisionLayer(GameObject gameObject, LayerMask layer)
    {
        return ((1 << gameObject.layer) & layer.value) > 0;
    }

    static public float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;
        return dB;
    }

    static public float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);
        return linear;
    }

    static public void DrawDebugCircle(Vector2 origin, float radio, float segments)
    {
        float increment = (Mathf.PI * 2) / (float)segments;
        float angle = 0;
        for (int i = 0; i < segments; i++)
        {
            Vector2 a = origin + (Utils.RotateVector2(Vector2.right, angle) * radio);
            Vector2 b = origin + (Utils.RotateVector2(Vector2.right, angle + increment) * radio);
            Debug.DrawLine(a, b, Color.cyan);
            angle += increment;
        }
    }

    private static Vector2 RotateVector2(Vector2 v, float a)
    {
        return new Vector2(
            v.x * Mathf.Cos(a) - v.y * Mathf.Sin(a),
            v.x * Mathf.Sin(a) + v.y * Mathf.Cos(a));
    }
}