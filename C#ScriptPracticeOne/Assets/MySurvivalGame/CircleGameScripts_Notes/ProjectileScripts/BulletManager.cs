using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance = null;
    public List<GameObject> pooledBullets;
    public GameObject bulletToPool;
    public int amountToPool = 50;


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
      
    }
    void Start()
    {
        //Attempt to alter to recyle not destrou
        //all in this start is part of test
        pooledBullets = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(bulletToPool);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }
    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
              //  Debug.Log("GetPooledBullet .. returning polled enemy at : " + i);
                return pooledBullets[i];
          }

        }
     //   Debug.Log("GetPooledBullet .. returning null");
        return null;
    }
}
