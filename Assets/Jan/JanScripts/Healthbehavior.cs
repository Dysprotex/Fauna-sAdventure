using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbehavior : MonoBehaviour, IDamagable
{
    public int numOfHearts;
    float timer;
    public int currentHp;
    public int counter;

    Rigidbody rb;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHp = numOfHearts;
        if (currentHp > numOfHearts)
        {
            currentHp = numOfHearts;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(timer >= 5)
            {
                currentHp++;
                timer = 0;
            }
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < currentHp)
                {
                    hearts[i].sprite = fullHearts;
                }
                else
                {
                    hearts[i].sprite = emptyHearts;
                }

                if (i < numOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }
    }
    public void DoDamage(int amount)
    {
        currentHp -= amount;
        rb.AddRelativeForce(Vector3.forward * -100);

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHp)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (currentHp <= 0)
        {
            counter++;
            Die();
        }
    }

    void Die()
    {
        CancelInvoke("DisableSelf");
        gameObject.SetActive(false);
    }
}
