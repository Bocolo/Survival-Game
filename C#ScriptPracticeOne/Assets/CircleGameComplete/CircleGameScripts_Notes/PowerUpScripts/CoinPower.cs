using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPower : MonoBehaviour
{
    // [SerializeField]
    private Spawner spawner;
    private FollowPlayer fp;
    public GameObject enemy;
    public float coinInstTimer = 4;
    private float coinTime;
    private float coinPauseCount;


        
    private void Start()
    {
       coinInstTimer= 4;

    }
    
    //NOTSURE if DELAYCOINSPAWN is working
   
    public void Initialize(FollowPlayer fp)
    {
        this.fp = fp;
    }
    
    IEnumerator DelayForActivEnem()
    {
       
        GetComponent<SpriteRenderer>().enabled=false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(coinInstTimer);
        EnemyManager.instance.OnlyActivateEnemy();
       Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(EnemyManager.instance.enemyIsMoving)
        {
           
         //   Debug.Log("en enem move in coin power trigger");
            if (collision.gameObject.CompareTag("Player"))
            {
                //    EnemyManager.instance.ActivateEnemy();
                EnemyManager.instance.OnlyDeactivateEnemy();
                ///Cannot get it to reset and acticate enemy, will creat decative
                ///
               StartCoroutine(DelayForActivEnem());
            
            // DelayCoinSpawn();
            }
        }
    }

    //not in use
    public void DelayCoinSpawn()
    {

        coinPauseCount = CoinSpawner.instance.coinPauseCountdown;
        Debug.Log("Delay CoinSpawne - coinPCount is .. " + coinPauseCount);
        coinInstTimer -= Time.deltaTime;
        if( coinInstTimer <= 0)
        {
            Debug.Log("TIME LESS THAN ZERO.. coinTIME is , and coininstis " + coinTime + "......" + coinPauseCount);
            coinInstTimer = 4;
            EnemyManager.instance.ActivateEnemy();
            return;
        }
        else
        {
            DelayCoinSpawn();
            Debug.Log("COIN DELAYYYYYY TIM");

        }

    }
}
