using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{

    public static int enemyCounter;
    public static bool complete = false;
    TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
        score.text = "" + enemyCounter;
        if(enemyCounter >= 30)
        {
            complete = true;
        }
    }
}
