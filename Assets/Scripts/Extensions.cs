using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector3 toVector3(this Vector2 v2)
    {
        return new Vector3(v2.x, v2.y);
    }
}