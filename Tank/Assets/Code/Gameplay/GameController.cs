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

    //TODO : Change it all on PlayerTank for information for enemy tanks
    [Header("PlayerTank")]
    [SerializeField]
    private Transform playerPrefab;
    public IPlayerComunicator PlayerComunicator;

    //Move to level
    public Vector2 MapSize
    {
        get => new Vector2(2 * width + 1, 2 * height + 1);
    }

    public float ScreenDiagonal
    {
        get
        {
            return Mathf.Sqrt(Mathf.Pow(width, 2) + Mathf.Pow(height, 2));
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Level lvl = Instantiate(level) as Level;
        lvl.Init(MapSize);

        PlayerComunicator  = (Instantiate(playerPrefab, Vector3.up * 0.5f, Quaternion.identity) as Transform).GetComponent<IPlayerComunicator>();
    }

}
