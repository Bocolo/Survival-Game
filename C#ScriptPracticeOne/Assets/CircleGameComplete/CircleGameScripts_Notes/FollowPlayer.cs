using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /// <summary>
    /// --------------> --------------> TODO <-------------- <--------------
    /// 
    /// -------------->  get player transform
    /// -------------->  getTarget();
    /// -------------->  moveDirection();
    /// 
    /// 
    /// COULD I SLOW APPROACH PROGRESSION LIKE WITH CAMERA??
    /// 
    /// </summary>
    // Start is called before the first frame update


    //public GameObject player;
    // public Transform enemy;
    public float speed = 2f;
    public float rotateSpeed = 400f;
    private Transform targetPos;
    private Rigidbody2D rb;
    private List<Transform> EnemyTransforms = new List<Transform>();
    Spawner spawner;
    private float repelAmount ;
    private float repelRange ;
    public bool isActive; 
    private SpriteRenderer sprite;
    private Enemy_ContDam enemCD;
    private int deathCounter;
    public float repelForceTest = 4;
    public float rayDistance = 0.4f;
    public float seperateRadius = 10f;
    public float minSpeed=2.5f;
    public float maxSpeed=5f;
   
    Vector2 movement;
    Vector2 repel = Vector2.zero;
    int enemiesKilledCap;

    int maxDistanceFromPlayer = 45;
    private void Awake()
    {
        RegisterEnemyHere();
        repelAmount = EnemyManager.instance.repelAmountEM;
        repelRange = EnemyManager.instance.repelRangeEM;
        enemiesKilledCap = EnemyManager.instance.amountToPool / 2;




        spawner = FindObjectOfType<Spawner>();

    }

   

    void Start()
    {
        
        speed = Random.Range(minSpeed,maxSpeed
            );
        rb = GetComponent<Rigidbody2D>();
        targetPos = GameObject.FindWithTag("Player").transform;
        EnemyTransforms = Spawner.enemyTransformList; ///. is this bad pracitec CAP Spawner
        sprite = GetComponent<SpriteRenderer>();
        enemCD = GetComponent<Enemy_ContDam>();


    }
   
    void Update()
    {
        DisableFarEnemies();
        if (EnemyManager.instance.killTotalScore < enemiesKilledCap)
        {
          //  Debug.Log($"Kill score is less than enemy kill cap. Killed Cap is : {enemiesKilledCap}");

        }
        else
        {
            enemiesKilledCap += enemiesKilledCap;
            minSpeed++;
            maxSpeed++;
        //    Debug.Log($"kill cap is {enemiesKilledCap} and minSpeed is {minSpeed} and max speed is {maxSpeed}");
        }
        if (Input.GetKeyDown("m"))
        {
            EnemyManager.instance.enemyIsMoving = true;
        }
        else if (Input.GetKeyDown("n"))
        {
            EnemyManager.instance.enemyIsMoving = false;
        }
        //  transform.position = Vector2.MoveTowards(transform.position, player.transform.position , speed * Time.deltaTime);
        if(!EnemyManager.instance.enemyIsMoving)
        {
            ChangeSpriteDisable();
        }
        else
        {
            ChangeColorSprite();
        }
       
    }
    
    private void FixedUpdate()
    {
        Vector3 direction = targetPos.position - transform.position; 
        direction.Normalize();

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = angle;
        movement = direction;
        Vector2 repel = Vector2.zero;
        float count = 0f;
        float seperateSpeed = speed / 2f;
        
        var hits = Physics2D.OverlapCircleAll(transform.position, seperateRadius);
        if (EnemyManager.instance.enemyIsMoving)
        {
            Move();
        }
        foreach (var hit in hits)
        {
            if (hit.GetComponent<Enemy_ContDam>() != null && hit.transform != transform)
            {
                //diference so you know which way to go
                Vector2 difference = transform.position - hit.transform.position;
                //weight by distance so closer == moving more
                difference = difference.normalized / Mathf.Abs(difference.magnitude);

                /*
              ADD TTO GET GROUP AVERAGER.. THIS ALLOWS THOSE AT EDGE TO MOVE OUT
              while center enemies dont move mcuh
             */
                repel += difference;
                count++;
            }
        }
        if (count > 0)
        {
            //average the direction
            repel /= count;
            //set the speed of moverment
            repel = repel.normalized * seperateSpeed;
        
                transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)repel, seperateSpeed * Time.deltaTime);
      
        }

   
        
    }
    private void RegisterEnemyHere()
    {
        EnemyManager.instance.RegisterEnemy(this);
    }
    void DisableFarEnemies()
    {
        if (Vector3.Distance(targetPos.position, transform.position) > maxDistanceFromPlayer)
        {
            enemCD.Die();

        }
    }
    private void Move()
    {
        if (Vector2.Distance(transform.position, targetPos.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        }
    }
    void ChangeSpriteDisable()
    {

 
        sprite.color = new Color(0, 0, 0);
     

    }
    void ChangeColorSprite()
    {

           if (enemCD.health > 60)
           {
            sprite.color = new Color(1,0,0, 1);
        }

        else if (enemCD.health <= 60 && enemCD.health> 20)
           {
            sprite.color = new Color(1, .47f, 0, 1);
        }
        else //(enemCD.health<= 20)
           {
            sprite.color = new Color(0,1, 0, 1);
        }
    }
    public void SetActivee()
    {
        if (isActive)
        {
            isActive = false;
      //      Debug.Log("isActivated");
        }
        else
        {
            isActive = true;
       //     Debug.Log("isNotActivated");
        }
    
    }

}

