using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    private static List<Vector3> directions = new List<Vector3>(){Vector3.right, Vector3.left, Vector3.forward, Vector3.back };

    public static Vector3 GetRandomDirectionForTankMovement(Vector3 _currentDirecton)
    {
        List<Vector3> _temp = new List<Vector3>(directions);
        _temp.Remove(_currentDirecton);
        int _rand = Random.Range(0, _temp.Count);
        return _temp[_rand];
    }
}
