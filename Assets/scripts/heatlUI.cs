using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class heatlUI : MonoBehaviour
{
    private healtmanager healthmanager;
    public Slider healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthmanager = FindFirstObjectByType<healtmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthmanager.maxHealth;
        healthBar.value = healthmanager.currentHealth;
    }
}
