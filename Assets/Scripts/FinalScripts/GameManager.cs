using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Coroutine courtineName;
    [SerializeField] private StandardEnemy standardEnemy;
    [SerializeField] private ShooterTieEnemy shooterEnemy;
    [SerializeField] private MachineGunEnemy machineEnemy;
    [SerializeField] private ExplodeEnemyFinal explodeEnemy;
    [SerializeField] private BossEnemy bossEnemy;
    [SerializeField] private Transform[] spawnPoints;
    public static GameManager singleton;
    public ScoreManager scoreManager;
    SampleObject obj;

    private void Awake()
    {
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(standardEnemy);
        //Instantiate(shooterEnemy);
        //Instantiate(machineEnemy);
        //Instantiate(explodeEnemy);
        //Instantiate(bossEnemy);
        //courtineName = StartCoroutine(SpawnEnemy());
        //JsonTestLearn();
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

        
    }

    public void EndGame()
    {
        //StopCoroutine(courtineName);
        scoreManager.RegisterHighScore();
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {

        yield return new WaitForSeconds(3f);

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(standardEnemy, randomSpawnPoint.position, Quaternion.identity);
    
        }

    }
}
