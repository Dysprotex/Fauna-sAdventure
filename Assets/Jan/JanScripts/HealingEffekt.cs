using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEffekt : MonoBehaviour
{
    public GameObject HealEffekt;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && timer >= 5)
        {
            Instantiate(HealEffekt);
            timer = 0;
        }
    }


}
