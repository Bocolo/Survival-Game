using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayTwo : MonoBehaviour
{/*
    public float speed = 2f;
    public float rotateSpeed = 400f;
    // public Transform targetPos;
    private Transform targetPos;
    private Rigidbody2D rb;
    private List<Transform> EnemyTransforms = new List<Transform>();
    Spawner spawner;
    private float repelAmount;
    // 4.2f;
    private float repelRange;
    public bool isActive; //true;   //false;//
    private SpriteRenderer sprite;
    //  private GameObject gm;
    private int deathCounter;
    public float repelForceTest = 4;
    public float rayDistance = 0.4f;


    Vector2 movement;
    Vector2 repel = Vector2.zero;
    //or do as game object enemy.transform.position
    private void Awake()
    {
       
        repelAmount = EnemyManager.instance.repelAmountEM;
        repelRange = EnemyManager.instance.repelRangeEM;



        //
    }
    void Start()
    {
        
        speed = Random.Range(.29f, 4.00f);

        rb = GetComponent<Rigidbody2D>();
        targetPos = GameObject.FindWithTag("Player").transform;
        EnemyTransforms = Spawner.enemyTransformList; ///. is this bad pracitec CAP Spawner
        sprite = GetComponent<SpriteRenderer>();
      
    }


    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            EnemyManager.instance.enemyIsMoving = true;
        }
        else if (Input.GetKeyDown("n"))
        {
            EnemyManager.instance.enemyIsMoving = false;
        }
        //  transform.position = Vector2.MoveTowards(transform.position, player.transform.position , speed * Time.deltaTime);
        if (!EnemyManager.instance.enemyIsMoving)
        {
            ChangeSprite();
        }
        else
        {
            ChangeBack();
        }
         
    }
    private void Move()
    {
        if(Vector2.Distance(transform.position, targetPos.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        Vector3 direction = targetPos.position - transform.position; //same
        direction.Normalize();
      
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;//same
        rb.rotation = angle;
        movement = direction;
        Vector2 repel = Vector2.zero;
        float count = 0f;
        float seperateSpeed = speed / 2f; 
        float seperateRadius = 1f;
        var hits = Physics2D.OverlapCircleAll(transform.position, seperateRadius);//repelamount is radius set to one in exammple
        foreach(var hit in hits)
        {
            if(hit.GetComponent<Enemy_ContDam>() !=null && hit.transform != transform)
            {
                //diference so you know which way to go
                Vector2 difference = transform.position - hit.transform.position;
                //weight by distance so closer == moving more
                difference = difference.normalized / Mathf.Abs(difference.magnitude);

                /*
              ADD TTO GET GROUP AVERAGER.. THIS ALLOWS THOSE AT EDGE TO MOVE OUT
              while center enemies dont move mcuh
             *
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

        foreach (Transform t in EnemyTransforms)
        {

float currentDistance = Vector2.Distance(t.position, rb.position);
            if (currentDistance <= repelRange)
            {
                Debug.Log("Repeling");

                repel += (rb.position - (Vector2)t.position);//.normalized; //normalised keep in range of one

            }
        }

        if (EnemyManager.instance.enemyIsMoving)
        {
            MoveCharacter(movement);
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        Vector2 newPos = (Vector2)transform.position + (direction * speed * Time.deltaTime);
        newPos -= repel * Time.fixedDeltaTime * repelAmount;
        rb.MovePosition(newPos);
    }
    void ChangeSprite()
    {

        //  sprite.color = new Color(46,183,46)36CB26; Color.blue;
        //  while (!isActive) { }
        sprite.color = new Color(46, 183, 46);
        //36CB26= color code

    }
    void ChangeBack()
    {
        sprite.color = new Color(0, 0, 0);
    }
    public void SetActivee()
    {
        if (isActive)
        {
            isActive = false;
            Debug.Log("isActivated");
            //   CoinSpawner.instance.Enable
        }
        else
        {
            isActive = true;
            Debug.Log("isNotActivated");
        }

    }

*/}
