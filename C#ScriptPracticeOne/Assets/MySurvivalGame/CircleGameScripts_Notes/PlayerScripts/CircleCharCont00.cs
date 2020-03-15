using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CircleCharCont00 : MonoBehaviour

{
    // Start is called before the first frame update
    /// <summary>
    /// /Create a  roation based on location of nearest enemy and add enemy shooters
    /// / or locked on the x/y.. enemies from above... shooting
    /// /// or add colliders to prevent player movemetn in to zome
    /// create a bounce back on collider
    /// or non moving player  with shooter
    /// </summary>
    /// 
 
       

    public Rigidbody2D rb;
    public float moveSpeed = 50f;
    private float fasterSpeed;
    private float origSpeed;
    public float multiplier=1.2f;
    Vector2 movement;
    Vector2 force;
    public int playerHealth;// = 140;
    public int maxHealth = 100;
    private bool isTurning;
    public float rotateSpeed = 19;
    public Text deathText;
    public PlayerHealthBar healthBar;

    private void Awake()
    {
        origSpeed = moveSpeed;
        playerHealth = maxHealth;
 }
    void Start()
    {
        fasterSpeed = moveSpeed * multiplier;
        PlayerHealthBar.instance.SetMaxForHealthBar(maxHealth);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BBTrigger"))
        {
          //  Debug.Log("Triggered Block");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (EnemyManager.instance.enemyIsMoving)
            {
              //  Debug.Log("Player Taking Damage. Collsion with & RemainingHealth" + collision + playerHealth);
              //  healthBar.SetSliderHealth(playerHealth);
              //when above in place...end screen doesnt work
            }
            if (playerHealth <= 0)
            {
              //  healthBar.SetSliderHealth(0);

                deathText.enabled = true; 
              //  Debug.Log("Player Should DIe. " );

                GManager.instance.GameOver();
                gameObject.SetActive(false);
            }
        }
    }
 
    void Update()
    {
        if (Input.GetKey("."))
        {
            Debug.Log("Rotation key pressed");
            transform.Rotate(new Vector3(0, 0, 20) * Time.deltaTime * -rotateSpeed);
        }
        if (Input.GetKey(","))
        {
            Debug.Log("Rotation key LEFT  pressed");
            transform.Rotate(new Vector3(0, 0, 20) * Time.deltaTime * rotateSpeed);
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
    }
    void FixedUpdate()
     {
        getFaster();
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
     }
    void revertSpeedChange()
    {
        moveSpeed = origSpeed;
    }
    void getFaster()
    {
        if (!EnemyManager.instance.enemyIsMoving)
        {
            moveSpeed = fasterSpeed;
        }
        else
        {
            revertSpeedChange();
        }
    }

}


