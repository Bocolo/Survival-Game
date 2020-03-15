using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    //TESTER BLOCK
   
    public static EnemyManager instance = null;
    List<FollowPlayer> enemies;
    int enemiesLiving;
    public int numberForCoins = 0;
    public int killTotalScore = 0;
    public int timeDelayCoin = 4;
    public int shotKillScore;
    public int enemiesRemaining;
    public float repelAmountEM =9;
    public float repelRangeEM = 9;

    public bool enemyIsMoving;


    //Items to REcycle rather than destroy
    public List<GameObject> pooledEnemies;
    public GameObject enemyToPool;
    public int amountToPool= 10;
    private int testerNumber = 0;






    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        enemies = new List<FollowPlayer>();
    }
    void Start()
    {
        
        pooledEnemies = new List<GameObject>();
        for (int i = 0; i< amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemyToPool);
            obj.SetActive(false);
            pooledEnemies.Add(obj);
            testerNumber++;
          //  Debug.Log($"tester number is " + testerNumber);
        }
    }

    public GameObject GetPooledEnemy()
    {
        for (int i =0; i< pooledEnemies.Count; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy){
            //    Debug.Log("GetPooledEnmy .. returning polled enemy at : " +i);

                return pooledEnemies[i];
                
              
            }

        }
      //  Debug.Log("GetPooledEnmy .. returning null");
        return null;
    }
    public void RegisterEnemy(FollowPlayer Enemy)
    {
        enemies.Add(Enemy);
        enemiesLiving = enemies.Count;
       // Debug.Log("Registering as FollowP : Count is ... " + enemies.Count + ".. Living is.. " + enemiesLiving);
    }
    public void DeRegisterEnemy(FollowPlayer Enemy)

    {
        enemies.Remove(Enemy);
        enemiesLiving = enemies.Count;
    }
    public void DeregisterEnemyAsFP(Enemy_ContDam enemy)
    {
       // Debug.Log("Pre Deregister as FollowP : Count is ... " + enemies.Count);

        FollowPlayer fpEnem = enemy.GetComponent<FollowPlayer>();
         enemies.Remove(fpEnem);
        enemiesLiving = enemies.Count;
        numberForCoins += 1;
       // Debug.Log("Deregistering as FollowP : Count is ... " + enemies.Count + ".. Living is.. " + enemiesLiving + ".. Numbers for coins " + numberForCoins);
    }
    public IEnumerator ActivateEnemies()


    {
        ActivateEnemy();
        Debug.Log("ActivateEnemIES called " + enemyIsMoving);
        yield return new WaitForSecondsRealtime(4F);
        ActivateEnemy();
        Debug.Log("4 seconds passed ActivateEnemIES called " + enemyIsMoving);

    }
    public void OnlyActivateEnemy()
    {
        enemyIsMoving = true;
    }
    public void OnlyDeactivateEnemy()
    {
        enemyIsMoving = false;
    }
    public void ActivateEnemy()
    {
    //    Debug.Log("eActivate Enemy calledr");

        if (enemies.Count > 0) 
        {
            //consider new func for settingach
            if (enemyIsMoving == false)
            {
                enemyIsMoving = true;
           //     Debug.Log("Activate enemy set to r  "+ enemyIsMoving);

            }
            else
            {
                enemyIsMoving = false;
           //     Debug.Log("deActivate enemy set to r  " + enemyIsMoving);

            }

        }
      
    }
    
    public void ResetNumForCoins()
    {
     //   Debug.Log("PReset; number for coins is " + numberForCoins);
        numberForCoins = 0;
     //   Debug.Log("Reset; number for coins is " + numberForCoins);

    }
    public List<FollowPlayer> ReturnEnemyList()
    {
        return enemies;
    }
    public void RepelOthers(Rigidbody2D rb)
    {

    }
}
