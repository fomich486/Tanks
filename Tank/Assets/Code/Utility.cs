using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector3 GetRandomDirectionForTankMovement()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        return new Vector3(x, 0f, z).normalized;
    }
}
