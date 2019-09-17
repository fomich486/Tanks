using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Environment;
using FactorySpace;
using Tanks;
using UnityEngine.Events;

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

    [Header("GameSettings")]
    private int attemp = 3;
    public int Attemp {
        get => attemp;
        set
        {
            PlayerComunicator = null;
            attemp = value;
            HUD.Instance.SetAttemp(attemp);
            if (attemp > 0)
            {
                PlayerComunicator = tankFactory.GetProduct((int)TankTypes.Player).Type.GetComponent<IPlayerComunicator>();
            }
            else
            {
                GameoverEvent.Invoke();
            }
        }
    }

    private int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score += value;
            HUD.Instance.SetScore(score);
        }
    }
    [Header("Events")]
    public UnityEvent GameoverEvent;


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

        GameoverEvent.AddListener(() => HUD.Instance.ShowGameoverScreen(score));

        Attemp=attemp;

        for (int _tanksToSpawn = 2; _tanksToSpawn > 0; _tanksToSpawn--)
            tankFactory.GetProduct((int)TankTypes.GreenEnemy);
    }

    protected void SpawnEnemyTank()
    {
    }

}
