using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbehavior : MonoBehaviour, IDamagable
{
    public int initialHp;

    int currentHp;

    void Start()
    {
        currentHp = initialHp;
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
