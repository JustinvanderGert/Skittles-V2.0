using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anxietybar : MonoBehaviour
{
    public Slider anxietyBar;
    public float gameTime;

    private bool stopTimer; 
    void Start()
    {
        stopTimer = false;
        anxietyBar.maxValue = gameTime;
        anxietyBar.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime + Time.time;

        
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        if (time >= 100)
        {
            stopTimer = true;
            //move to ending screen still needs to be done 
        }

        if (stopTimer == false)
        {
            anxietyBar.value = time;
        }
    }
}