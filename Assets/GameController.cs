using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You Won the Game");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You Won the Game");
    }
}
