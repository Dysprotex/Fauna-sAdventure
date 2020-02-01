using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    IInputReceiver[] inputReceivers;

    private void OnEnable()
    {
        inputReceivers = GetComponentsInChildren<IInputReceiver>();
    }

    void Update()
    {
        foreach (var inputReceiver in inputReceivers)
        {
            inputReceiver.OnFireDown();
        }
    }
}
