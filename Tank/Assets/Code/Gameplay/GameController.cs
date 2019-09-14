using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Environment;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("Gameplay field")]
    [SerializeField]
    private Level level;
    [Range(4, 8)]
    [SerializeField]
    private int width = 3;
    [Range(4, 8)]
    [SerializeField]
    private int height = 3;

    public Vector2 MapSize
    {
        get => new Vector2(2 * width + 1, 2 * height + 1);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Level lvl = Instantiate(level) as Level;
        lvl.Init(MapSize);
    }

}
