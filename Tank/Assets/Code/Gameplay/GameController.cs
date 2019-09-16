using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Environment;
using FactorySpace;
using Tanks;

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

    [Header("PlayerTank")]
    [SerializeField]
    private Transform playerPrefab;
    public IPlayerComunicator PlayerComunicator;
    

    [Header("Factory")]
    private Factory tankFactory;

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

        tankFactory = FactoryProducer.GetFactory(FactoryProductType.Tanks);

        PlayerComunicator = tankFactory.GetProduct((int)TankTypes.Player).Type.GetComponent<IPlayerComunicator>();

        //for (int _tanksToSpawn = 5; _tanksToSpawn > 0; _tanksToSpawn--)
        //     tankFactory.GetProduct((int)TankTypes.GreenEnemy);
    }

    protected void SpawnEnemyTank()
    {
    }

}
