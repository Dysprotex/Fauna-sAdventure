using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressbarDash : MonoBehaviour
{
    private Slider slider;

    public float fillSpeed = 1f;
    private float targetProgress = 0;
    // Start is called before the first frame update
    void Awake()
    {
        slider = gameObject.GetComponentInChildren<Slider>();
    }
    void Start()
    {
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(slider.value == 1)
            {
                targetProgress = 0;
                slider.value = 0;
            }
        }
        IncrementProgress(1);
    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
