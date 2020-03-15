using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Enemy_ContDam : MonoBehaviour


{

    /// <summary>
    /// NEED eddits 
    /// </summary>
    public static Enemy_ContDam instance = null;
    public int health = 100;
    public int damage = BulletScript.bulletDamage;
    public int extraHealth = 20;
    public  bool isDead = false;
    public Spawner spawner;
    private FollowPlayer follow;
    private bool isFollowing;
    private Color color;
    /// <summary>
    /// /-------------> for the life of me cant figure out why counters called from spawner
    /// --------------> keep increasing in size even after stop restart of game
    /// 
    /// 
    /// --------------> --------------> WHAT I NEED TO DO <-------------- <-------------- 
    /// 
    /// --------------> A.) Find out how to getcomponent of object... to check list in spawner... or how else
    /// </summary>
    

       
      private void OnEnable()
      {
          spawner.EnemyLifeHasBegun();
          follow = GetComponent<FollowPlayer>();
          health = 100;
   }

    private void Update()
    {
        isFollowing = EnemyManager.instance.enemyIsMoving;
    }
  
    
    void OnCollisionEnter2D(Collision2D collider)
    {
      //  Debug.Log("ColEnemy Collision withing ECD - " + collider.gameObject.name+isFollowing);
        if (collider.gameObject.CompareTag("Player"))
        {
          CircleCharCont00 circleChar = collider.gameObject.GetComponent<CircleCharCont00>();
            if (!isFollowing)
            {
                circleChar.playerHealth += (extraHealth);// *2);
                PlayerHealthBar.instance.SetSliderHealth(circleChar.playerHealth);
              //  Debug.Log($"ECD __ ISFOLLOWING LOOP player health is {circleChar.playerHealth} ");
                EnemyManager.instance.killTotalScore++;
                Die();
            }
            else
            {
                circleChar.playerHealth -= extraHealth;
                PlayerHealthBar.instance.SetSliderHealth(circleChar.playerHealth);
                Die();
            }
        }

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
   
        if (hitInfo.gameObject.CompareTag("Bullet"))
        {
            Enemy_ContDam enemy = GetComponent<Enemy_ContDam>();
            enemy.TakeBulletDamage(damage);
        }
      
    }
    

    public void TakeBulletDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            EnemyManager.instance.killTotalScore++;
            EnemyManager.instance.shotKillScore++;
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            EnemyManager.instance.killTotalScore++;
            Die();
        }
    }
    public void Die()
    {
       isDead = true;
        EnemyManager.instance.DeregisterEnemyAsFP(this);
        spawner.EnemyHasDied();
        gameObject.SetActive(false);
    }
    /* void OnDestroy()
     {
         spawner.EnemyHasDied();

     }*/
   
}


