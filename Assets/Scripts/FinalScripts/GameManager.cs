using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Coroutine courtineName;
    [SerializeField] private StandardEnemy standardEnemy;
    [SerializeField] private ShooterTieEnemy shooterEnemy;
    [SerializeField] private MachineGunEnemy machineEnemy;
    [SerializeField] private ExplodeEnemyFinal explodeEnemy;
    [SerializeField] private BossEnemy bossEnemy;
    [SerializeField] private Transform[] spawnPoints;
    public static GameManager singleton;
    public ScoreManager scoreManager;
    SampleObject obj;
    [SerializeField] private int gameLevel;
    private int numOfStand;
    private int numOfMach;
    private int numOfShoot;
    private int numOfExpl;
    [SerializeField] private int numOfEnRemain;
    [SerializeField] private int RandomEnemiesToSpawn;
    private int bossChecker;
    [SerializeField] private PracticePickup nukePickup;
    [SerializeField] private PracticePickup2 gunPickup;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Quaternion bossRotate = Quaternion.Euler(0, 0, 90);
        //Instantiate(bossEnemy, spawnPoints[7].position, bossRotate);
        //Instantiate(standardEnemy);
        //Instantiate(shooterEnemy);
        //Instantiate(machineEnemy);
        //Instantiate(explodeEnemy);
        //Instantiate(bossEnemy);
        //courtineName = StartCoroutine(SpawnEnemy());
        //JsonTestLearn();
        gameLevel = 1;
        bossChecker = 1;
        uiManager.UpdateGameLevel(gameLevel);
        //Instantiate(explodeEnemy, transform.position, Quaternion.identity);
        Invoke("EnemySpawnManager", 1f);
    }

    public int GetGameLevel()
    {
        return gameLevel;
    }

    public void IncreaseGameLevel()
    {
        gameLevel++;
        uiManager.UpdateGameLevel(gameLevel);
    }

    private void JsonTestLearn()
    {
        obj = new SampleObject("Sample JSON tester for project", 15, 0.01f);
        Debug.Log(JsonUtility.ToJson(obj));
        PlayerPrefs.SetString("PROGRESS", JsonUtility.ToJson(obj));

        SampleObject loadedobj = JsonUtility.FromJson<SampleObject>(PlayerPrefs.GetString("PROGRESS"));
        Debug.Log(loadedobj.name1);
        Debug.Log(loadedobj.number);
        Debug.Log(loadedobj.decimeal);
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreManager.TotalScore == bossChecker)
        {
            BossSpawner();
        }
        
    }

    public void EndGame()
    {
        //StopCoroutine(courtineName);
        scoreManager.RegisterHighScore();
    }

    public void EnemySpawnManager()
    {
        //Debug.Log("In EnemySpawnManager");
        bossChecker = 50 * (gameLevel - 1) + 49;
        RandomEnemiesToSpawn = Random.Range(0, 3);
        numOfEnRemain = 49;

        if (RandomEnemiesToSpawn == 0)
        {
            //Debug.Log("EnemyGroup 0");
            numOfStand = 13;
            numOfMach = 12;
            numOfShoot = 12;
            numOfExpl = 12;
            
        } else if (RandomEnemiesToSpawn == 1)
        {
            //Debug.Log("EnemyGroup 1");
            numOfStand = 16;
            numOfMach = 11;
            numOfShoot = 11;
            numOfExpl = 11;
        } else
        {
            //Debug.Log("EnemyGroup 2");
            numOfStand = 22;
            numOfMach = 9;
            numOfShoot = 9;
            numOfExpl = 9;
        }

        StartCoroutine(SpawnEnemy());

    }

    IEnumerator SpawnEnemy()
    {
        while (numOfEnRemain != 0)
        {

        yield return new WaitForSeconds(1f);

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
        switch(ChooseEnemy())
            {
                case 1:
                    //Debug.Log("trying to instantiate");
                    Instantiate(standardEnemy, randomSpawnPoint.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(machineEnemy, randomSpawnPoint.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(shooterEnemy, randomSpawnPoint.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(explodeEnemy, randomSpawnPoint.position, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }

    }

    private void BossSpawner()
    {
        bossChecker = 0;
        Quaternion bossRotate = Quaternion.Euler(0, 0, 90);
        Instantiate(bossEnemy, spawnPoints[7].position,bossRotate);
    }

    private int ChooseEnemy()
    {
        if(numOfEnRemain > 46)
        {
            numOfEnRemain--;
            numOfStand--;
            return 1; //first 3 enemies of level are standard enemies
        }

        int randEnChoos = Random.Range(1, numOfEnRemain+1);
        if(randEnChoos < numOfStand)
        {
            numOfEnRemain--;
            numOfStand--;
            return 1;
        } else if (randEnChoos < (numOfStand + numOfMach))
        {
            numOfEnRemain--;
            numOfMach--;
            return 2;
        } else if (randEnChoos < (numOfStand + numOfMach + numOfShoot))
        {
            numOfEnRemain--;
            numOfShoot--;
            return 3;
        } else
        {
            numOfEnRemain--;
            numOfExpl--;
            return 4;
        }

    }

    public void CreatePickUp(Vector3 location)
    {
        Instantiate(nukePickup, location, Quaternion.identity);
    }

    public void CreatePickUp2D(Vector3 location)
    {
        Instantiate(gunPickup, location, Quaternion.identity);
    }

    public void CreateBossPickup(Vector3 location)
    {

    }
}
