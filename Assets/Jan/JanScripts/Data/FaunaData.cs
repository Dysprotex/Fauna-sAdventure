using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FaunaData : ScriptableObject
{
    [SerializeField]
    float acceleration = 10f;
    [SerializeField]
    float rotationForce = 10f;
    [SerializeField]
    float jumpForce = 10f;

    public float Acceleration => acceleration;
    public float RotationForce => rotationForce;
    public float JumpForce => jumpForce;

    public void OutputData()
    {

    }
}
