using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthScore : MonoBehaviour
{

    public CircleCharCont00 circleChar;

    public Text healthText;
   // int healthscore;
    // Update is called once per frame
    void Update()
    {
        healthText.text = circleChar.playerHealth.ToString();
    }
}
