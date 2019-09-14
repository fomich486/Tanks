using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Plane))]
    public class Level : MonoBehaviour
    {
        [SerializeField]
        [Range(4,8)]
        private int width = 3;
        [SerializeField]
        [Range(4, 8)]
        private int height = 3;
        // Temp
        [SerializeField]
        private GameObject testPlayer;

        private void Awake()
        {
            int _width = 2 * width + 1;
            int _height = 2 * height + 1;
            Vector2 _levelScale = new Vector2(_width, _height);
            transform.localScale = (Vector3)_levelScale + Vector3.forward;
            Renderer _renderer = GetComponent<Renderer>();
            _renderer.sharedMaterial.mainTextureScale = _levelScale;
            
            //Temp
            Instantiate(testPlayer, Vector3.up * 0.5f, Quaternion.identity);
        }
    }
}
