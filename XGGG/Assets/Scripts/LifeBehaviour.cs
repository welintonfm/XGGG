﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class LifeBehaviour : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private Slider slider = null;

    [SerializeField]
    private int currentHealth = 0;


    public UnityEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {

    }

    public void OnLifeGain(int amount)
    {
        currentHealth = (amount + currentHealth > maxHealth) ? maxHealth : currentHealth + amount;
        if (slider != null)
            slider.value = currentHealth;
    }


    public void OnLifeLoss(int amount)
    {
        currentHealth = (currentHealth - amount > 0) ? currentHealth - amount : 0;

        if (slider != null)
            slider.value = currentHealth;

        if (currentHealth == 0)
        {
            if (OnDeath != null)
            {
                OnDeath.Invoke();
            }
        }
    }


    public int GetHealth()
    {
        return this.currentHealth;
    }


}
