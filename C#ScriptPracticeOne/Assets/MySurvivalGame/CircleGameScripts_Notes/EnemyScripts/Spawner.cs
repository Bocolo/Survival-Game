using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// <summary>
    /// ----------------> annoying questions for john...
    /// ----------------> a.) why does unity debuglog so a value maintained gloabally(?) for enemycount etc?
    /// ----------------> b.) what is the best way to check if GO Enemy exists in scene? 
    /// ----------------> ------> b.a.) how do you check through list of GO and compare to scene/check if destroyed?
    /// ----------------> d.) enenmyCD -- on collision die not called if in second if statement
    /// 
    /// 
    /// 
    /// ----------------> Things to figure out..
    /// ----------------> a.) create function callable in ECD to delete list of go>>??
    /// ----------------> B.) Conside object pooling
    /// ----------------> ----------------> a.) ListNAme.Remove(gameob); gameob.SetActive(false); 
    /// ----------------> ---------------->             instead of
    /// ----------------> ---------------->     Destroy(gameob)
    /// 
    /// ----------------> ---------------->      TODO     <---------------- <----------------
    /// ----------------> A.) check spawner.. need to cycle to next and  stop... see looping
    /// ----------------> B.)  create AI to follow player
    /// ----------------> C.) add enemy weapon.. targer player
    /// ----------------> D.) add on contact --- destroy / damage / reduce size.
    /// ----------------> E.) implement powerups .  extra speed/ better weapons... time/score sensitive
    /// ----------------> F.) 
    /// </summary>


    public float radius = 8;
    public GameObject player;
    public enum SpState { SPAWNING, COUNTING, WAITING };
    private SpState state = SpState.COUNTING;
    public static List<Transform> enemyTransformList = new List<Transform>();
    public int maxEnemyCount=50;
    public int minDistFromPlayer = 15;
    public int maxDistFromPlayer = 35;

 
    void Update()
    {

        if (state != SpState.SPAWNING)
        {
            state = SpState.SPAWNING;
             SpawnCircleEnemyPool();
            state = SpState.WAITING;
        }
    }
    public static Vector2 GetPointOnRing(float aMinRadius, float aMaxRadius)
    {
        var v = Random.insideUnitCircle;
        return v.normalized * aMinRadius + v * (aMaxRadius - aMinRadius);
    }
    
    void SpawnCircleEnemyPool()
    {
        //    var circleUnit = Random.insideUnitCircle * radius;
        var circleUnit = GetPointOnRing(minDistFromPlayer, maxDistFromPlayer);
        var newPosition = new Vector3(circleUnit.x, circleUnit.y, 0) + player.transform.position;// + extraDist;
        InstantiateUsingEnemyPool(newPosition);
    }

    void InstantiateUsingEnemyPool(Vector3 newPos)
    {
        GameObject enemy = EnemyManager.instance.GetPooledEnemy();
        if(enemy != null)
        {
            enemy.transform.position = newPos;
            enemy.transform.rotation = transform.rotation;
            enemy.SetActive(true);
         //   Debug.Log("Set active to true using instantiEMPool; ");
        }
    }
 
    public void EnemyLifeHasBegun()
    {
        EnemyManager.instance.enemiesRemaining++;
//    Debug.Log("ELHB Enemies remaining =  " + EnemyManager.instance.enemiesRemaining);
    }
    public void EnemyHasDied()
    {
        EnemyManager.instance.enemiesRemaining--;
//        Debug.Log("EHD Enemies remaining from EM =  " + EnemyManager.instance.enemiesRemaining);// + ":   EHD Enemies DEAD =  " + enemiesDead + ".   New addition, enemy count : ==" + enemyCount);
    }



    //BELOW CODE NOT CURRENTLY IN USE: REF ONLY

}


/*List<GameObject> enemyGOList = new List<GameObject>();

 #
    public void AddEnemy()
    {
      //  enemyCount++;
      //  Debug.Log("add enemy workingg. enemy count is : " + enemyCount);
    }
 
     * 
     * *     public void RemoveFromList()
    {
        //  Debug.Log("About to remove from list().  LIST COUNT IS : " + enemyGOList.Count );
        for (int i = 0; i < enemyGOList.Count; i++)
        {
            if (enemyGOList[i] == null)
            {

                Debug.Log("I ......." + enemyGOList.Count);
                enemyGOList.RemoveAt(i);
                Debug.Log("I have no idea if what im doing is of any use ......." + enemyGOList.Count);

            }
        }
        Debug.Log("Nonkjk" + enemyGOList.Count);
    }
    bool EnemiesAreAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            Debug.Log("search Countdown is one");
            //change to enmemy manger check alive score
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }

        }
        return true;

    }
    void SpawnCircleEnemy(Transform _enem)
    {
        //    var circleUnit = Random.insideUnitCircle * radius;
        var circleUnit = GetPointOnRing(minDistFromPlayer, maxDistFromPlayer);
        var newPosition = new Vector3(circleUnit.x, circleUnit.y, 0) + player.transform.position;// + extraDist;

        enemyTransforms = (Transform)Instantiate(_enem, newPosition, transform.rotation);
        // InstantiateUsingEnemyPool(newPosition);


        AddToEnemyList(enemyTransforms);
        AddToEnemyListAsEnemyContDam(enemyTransforms);
    }
    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning enemy : " + _enemy.name);

        Transform enemyTransform = Instantiate(_enemy, transform.position, transform.rotation) as Transform;
        AddToEnemyList(enemyTransform);
        AddToEnemyListAsEnemyContDam(enemyTransform);
    }
    void AddToEnemyList(Transform _enemy_Transform)
    {
        enemyTransformList.Add(_enemy_Transform);
    }
    void AddToEnemyListAsEnemyContDam(Transform _enemy_Transform)
    {
        GameObject GO_f_Transform = _enemy_Transform.GetComponent<GameObject>();
        enemyGOList.Add(GO_f_Transform);

    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave" + _wave.name);
        state = SpState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnCircleEnemyPool();
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpState.WAITING;
        Debug.Log("SPAWNWAVE: State is WAITING");
        yield break;
    }
    void WaveFinished()
    {
        state = SpState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("all waves complete.. looping...");
        }
        nextWave++;
    }
    bool CheckIsDead()

    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            Debug.Log("search Countdown is one");

            Debug.Log("CHECKISDEAD: Enemy list count: List Size is:" + enemyGOList.Count);

            // bool isDefDead = enemy.GetComponent<Enemy_ContDam>().isDead;
            if (enemyGOList.Count > 0)
            {
                // foreach (Enemy_ContDam enemyObject in enemyGOList)
                /// no for each - returns null refs...
                for (int i = 0; i < enemyGOList.Count; i++)
                {
                   // Debug.Log("CHECK IS DEAD: for loop is running");
                    // This is deleting items regardless of existence
                    if (enemyGOList[i] == null)
                    {
                    //    Debug.Log("CHECKISDEAD: about to remove game object from list: List Size is:" + enemyGOList.Count);


                        //enemyGOList.RemoveAt(i);
                    //f    Debug.Log("cCHECKISDEAD: removing game object from list: List Size is:" + enemyGOList.Count);
                    }

                }
                return false;
            }
            else
            {
                Debug.Log("CHECKISDEAD= ENEMY list is empty... prob a good idea to start calling checks");
                return true;
            }
            //return false;

        }
        return false;
    }
    public bool AreEnemiesAlive(List<Enemy_ContDam> enemyObject)
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            for (int i = 0; i < enemyObject.Count; i++)
            {
                Debug.Log("eChecking For enemies called");
            }
            //func that take s values in a rlists/
            //checks they exists
            // adjusts list accourdeing
            return false;

        }
        return false;
    }
 * 
 * 
 * 
 *    Transform enemyTransforms;
 
 *   [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
      public float timeBetweenWaves = 1f;
    public float waveCountdown; //change to private
    private float searchCountdown = 1f;
   


    public Wave[] waves;
    private int nextWave = 0;
 * 
 * 
 * 
 * 
 * 
if (waveCountdown <= 0)
{
    if (state != SpState.SPAWNING)
    {
        //This if statment prevents no stop spawning
        bool isAlive = EnemiesAreAlive();

        //if (!isAlive)
        if (EnemyManager.instance.enemiesRemaining <  maxEnemyCount)
        {
            SpawnCircleEnemyPool();

           // StartCoroutine(SpawnWave(waves[nextWave]));
            //Debug.Log("POST; List count enemT and enemGO resp,:" + enemyTransformList.Count + ".  GO:  " + enemyGOList.Count);
            //Debug.Log("Coroutine started  " + waves + "  .  NectWave:" + waves[nextWave] + "...");
        }
        else
        {
            return;
        }
    }
}
else
{
    waveCountdown -= Time.deltaTime;
}

*/
/*
 * 
 
     * 
     * 
     
        if (state == SpState.WAITING)
        {

            bool isAlive = EnemiesAreAlive();
            //   Debug.Log("ARE THEY ALIVE:  " + isAlive);
            //Enemycount not reliable in testing. unity keeping over all score

            if (enemyCount == 0)

            {
                WaveFinished();
                //  Debug.Log("Finally Proof... no enemies survived");
            }
            else
            {
                return;

            }

        }*/















