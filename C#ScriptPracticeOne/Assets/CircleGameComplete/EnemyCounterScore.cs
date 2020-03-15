using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounterScore : MonoBehaviour
{
    public Text enemyCountText;
  
 
    void Update()
    {
        enemyCountText.text = EnemyManager.instance.enemiesRemaining.ToString();
    //    Debug.Log($"EnemyUICounter is {EnemyManager.instance.enemiesRemaining}");
    }
}
