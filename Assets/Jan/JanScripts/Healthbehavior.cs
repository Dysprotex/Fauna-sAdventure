using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbehavior : MonoBehaviour, IDamagable
{
    public static int healthIndex = 5;
    public int numOfHearts;
    float timer;
    public int currentHp;
    public int counter;

    public Animator animator;
    GameObject obj;

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
        healthIndex = 5;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F))
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

        if (currentHp == 0)
        {
            EnemyCounter.enemyCounter += 1;
            Die();
        }
    }

    void Die()
    {

        if (gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("OnDeath");
            healthIndex = 0;
        }
        else
        {
            gameObject.SetActive(false);

        }
            CancelInvoke("DisableSelf");
    }
    void WinCondition()
    {
        if(counter >= 30)
        {
            SceneManager.LoadScene(0);
        }
    }
}
