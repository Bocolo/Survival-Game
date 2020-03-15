using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    public static int bulletDamage = 40;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("BBTrigger"))
        { 
        //parts not req right now.. hit effect add in later.. on trigger enter?
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .95f);
//        Debug.Log("Collision detected " + collision.gameObject.name);
            gameObject.SetActive(false);
     }
        else
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
     //   Debug.Log(hitInfo.gameObject.name + "  +  " + gameObject.name);
        gameObject.SetActive(false);
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        
    }

}



