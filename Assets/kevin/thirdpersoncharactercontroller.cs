using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersoncharactercontroller : MonoBehaviour
{
    public float Speed;
   
    void Update()
    {
        Playermovement();
    }

    void Playermovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playermovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playermovement, Space.Self);
    }
}
