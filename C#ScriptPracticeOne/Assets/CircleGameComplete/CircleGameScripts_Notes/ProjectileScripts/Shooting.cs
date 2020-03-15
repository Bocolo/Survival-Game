
using UnityEngine;

public class Shooting : MonoBehaviour
{
   
        
    public Transform firePoint;
    public Transform firePointTwo;
    [System.Serializable]
    public class Firepoints
    {
        public Transform fireFrom;
    }
    public Firepoints[] fireFromArray;

    public GameObject bulletPrefab;
    public float bulletForce = 2f;
  
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
    
            foreach (Firepoints fp in fireFromArray)
            { 
                ShootBullet(fp);
            }
        }
    }
   
    void ShootBullet(Firepoints t)

    {
       // GameObject bulleta = Instantiate(bulletPrefab, t.fireFrom.position, t.fireFrom.rotation);


        GameObject bulleta = BulletManager.instance.GetPooledBullet();
        if (bulleta != null)
        {
            bulleta.transform.position = t.fireFrom.position;
            bulleta.transform.rotation = t.fireFrom.rotation;
            bulleta.SetActive(true);
      //      Debug.Log("Set active to true using instantiEMPool; ");
        }
        Rigidbody2D rba = bulleta.GetComponent<Rigidbody2D>();
        rba.AddForce(t.fireFrom.up * bulletForce, ForceMode2D.Impulse);
    }
  
}

