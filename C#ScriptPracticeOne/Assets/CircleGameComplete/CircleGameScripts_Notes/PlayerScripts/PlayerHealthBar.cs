using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    public static PlayerHealthBar instance = null;

    public Slider slider;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    public void SetMaxForHealthBar(int health)
    {
        slider.maxValue = health*4;
        slider.value = health;
    }
    public void SetSliderHealth(int health)
    {
       /* if (health > slider.maxValue)
        {
            slider.value = slider.maxValue;
        }
        else
        {*/
            slider.value = health;
   //     }
    }
}
