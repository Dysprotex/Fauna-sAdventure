using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputReceiver
{
    void OnFireDown();
    float HInput { set; }
    float VInput { set; }
}
