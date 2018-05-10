using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSlider : MonoBehaviour {
    public Slider healthSlider;
    public Text healthText;
    
    public void Setup(int maxHP)
    {
        healthSlider.maxValue = maxHP;
        healthSlider.value = maxHP;
    }

    public void OnHealthChange()
    {
        healthText.text = healthSlider.value + "/" + healthSlider.maxValue;
    }

    public void SetHealth(int hp)
    {
        healthSlider.value = hp;
    }
}
