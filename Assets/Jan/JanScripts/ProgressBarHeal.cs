using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHeal : MonoBehaviour
{
    private Slider slider;

    public Image[] dash;
    public Sprite fullDash;
    public Sprite emptyDash;

    public float fillSpeed = 0.2f;
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
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (slider.value == 1)
            {
                targetProgress = 0;
                slider.value = 0;
            }
        }
        if (slider.value == 1f)
        {
            dash[0].sprite = fullDash;
        }
        else
        {
            dash[0].sprite = emptyDash;
        }
        IncrementProgress(1);
    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
