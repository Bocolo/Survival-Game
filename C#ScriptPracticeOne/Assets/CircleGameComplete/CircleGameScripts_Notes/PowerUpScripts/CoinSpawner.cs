using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner instance =null;
    public GameObject coinPrefab;
    public GameObject player;
    public float radius = 8;
    GameObject coin;
    public int startSpawnCap;
    private int shotKillCap;
    public enum spawnStateCoin { SPAWNING, COUNTING, WAITING};
    private spawnStateCoin state = spawnStateCoin.COUNTING;
    List<GameObject> coins = new List<GameObject>();
    int coinsInScene;
    public bool enemyIsEnabled;
    public int enemiesKilledSoFar = 0;
    public float coinPauseCountdown = 4;

    //Need to Reduce coin spawn area/ not in or past bariers

    public int minKilledByBullet = 3;

    private void Start()
    {
        enemyIsEnabled = true;
    }
     

    IEnumerator SpawnCoins()
    {
       startSpawnCap = EnemyManager.instance.numberForCoins;
        shotKillCap = EnemyManager.instance.shotKillScore;

        state = spawnStateCoin.SPAWNING;
     //   Debug.Log("(SPAWNING)Coin spawn state is..." + state);

        if (shotKillCap >= minKilledByBullet)
        {
            
            minKilledByBullet += 4;// minKilledByBullet;
      //      Debug.Log($"Minimum killed by Bullet: {minKilledByBullet} AND SHOT KILL caP {shotKillCap}");
        
     


        SpawnCircleCoin(coinPrefab);
            EnemyManager.instance.ResetNumForCoins();
     //       Debug.Log("check: spawncap if loop " + startSpawnCap + " .  EMan num " + EnemyManager.instance.numberForCoins +" .  SHOTKILLCAP is  " + shotKillCap);
            yield return new WaitForSeconds(.5f);

       
        }
        state = spawnStateCoin.WAITING;
  //      Debug.Log("Coin spawn state is..." + state);

        yield break;
    }
    private void Update()
    {

      //  Debug.Log("spawnCAp =  " + startSpawnCap  );
        if(state!= spawnStateCoin.SPAWNING)
        {
            //dont think needs to be corouting
            StartCoroutine(SpawnCoins());

        }
    }
    void SpawnCircleCoin(GameObject coinPrefab)
    {
        var circleUnit = Random.insideUnitCircle * radius;
        var newPosition = new Vector3(circleUnit.x, circleUnit.y, 0) + player.transform.position;

       
        coin = (GameObject)Instantiate(coinPrefab, newPosition, transform.rotation);
        RegisterCoin(coin);
    }

    public void RegisterCoin(GameObject coin) 
    { 
        coins.Add(coin);
        coinsInScene += 1;

      //  Debug.Log("register coin " + coinsInScene);
 
    }
    public void DeregisterCoin(GameObject coin)

    {
        coins.Remove(coin);
        coinsInScene -= 1;

     //   Debug.Log("Deregister coin " + coinsInScene);
    }
  
    public void EnableCoins()
    {
        enemyIsEnabled = true; 

    }
    public void DisableCoins()
    {
        enemyIsEnabled = false;
    }
}

