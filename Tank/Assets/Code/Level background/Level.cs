using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class Level : MonoBehaviour
    {
        public void Init(Vector2 _MapSize)
        {
            transform.position = Vector3.zero;
            Vector2 _levelScale = _MapSize;
            transform.localScale = (Vector3)_levelScale + Vector3.forward;
            Renderer _renderer = GetComponent<Renderer>();
            _renderer.sharedMaterial.mainTextureScale = _levelScale;
        }
    }
}
