using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Environment;
using FactorySpace;
using Tanks;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    enum State { FirstWave,SecondWave, AnyWave}
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
    State state = State.FirstWave;
    int currentEnemyTankCount=0;
    public int CurrentEnemyTankCout
    {
        get => currentEnemyTankCount;
        set
        {
            currentEnemyTankCount = value;
            print("Current enemy tanks is " + currentEnemyTankCount);
            if (state == State.FirstWave && currentEnemyTankCount == 3)
            {
                SecondWave();
                state = State.SecondWave;
            }
            else if (state == State.SecondWave && currentEnemyTankCount == 4)
            {
                AnyNextWave();
                state = State.AnyWave;
            }
            else if (state == State.AnyWave)
            {
                AnyNextWave();
            }
        }
    }

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
        Score = score;

        FirstWave();
    }

    private void FirstWave()
    {
        for (int _tanksToSpawn = 5; _tanksToSpawn > 0; _tanksToSpawn--)
        {
            tankFactory.GetProduct((int)TankTypes.GreenEnemy);
            currentEnemyTankCount++;
        }
    }

    private void SecondWave()
    {
        for (int _tanksToSpawn = 5; _tanksToSpawn > 0; _tanksToSpawn--)
        {
            tankFactory.GetProduct((int)TankTypes.YellowEnemy);
            currentEnemyTankCount++;
        }
    }

    private void AnyNextWave()
    {
        //while (CurrentEnemyTankCout < 2) { 
        //    tankFactory.GetProduct(Random.Range(0,3));
        //    CurrentEnemyTankCout++;
        //}
        int _delta = 7 - CurrentEnemyTankCout;
        for (int _tanksToSpawn = _delta; _tanksToSpawn > 0; _tanksToSpawn--)
        {
            tankFactory.GetProduct(Random.Range(0, 3));
            currentEnemyTankCount++;
        }
    }

}
