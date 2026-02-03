using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class healtmanager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 1)
        {
            gameObject.SetActive(false);
        }

    }
}
