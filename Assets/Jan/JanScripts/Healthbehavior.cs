using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbehavior : MonoBehaviour, IDamagable
{
    public int initialHp;
    public int numOfHearts;

    int currentHp;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    void Start()
    {
        currentHp = initialHp;
    }
    
    void Update()
    {
        if(currentHp > numOfHearts)
        {
            currentHp = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHp)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }


            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void DoDamage(int amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        CancelInvoke("DisableSelf");
        gameObject.SetActive(false);
    }

}
