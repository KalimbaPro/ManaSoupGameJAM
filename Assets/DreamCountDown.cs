using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamCountDown : MonoBehaviour
{
    public float startingHour = 0f;
    public float startingMinute = 0f;
    public static bool stopTime = false;
    
    public float finalHour = 0f;
    public float finalMinute = 0f;

    float currentHour;
    float currentMinute;
    float Minute = 0.333333333f;

    public GameObject looseText;
    public Text countDownTime;

    // Start is called before the first frame update
    void Start()
    {
        currentHour = startingHour; 
        currentMinute = startingMinute;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHour == finalHour && currentMinute >= finalMinute)
        {
            stopTime = true;
            looseText.SetActive(true);
        }
        if (!stopTime) {
            currentMinute += Time.deltaTime / Minute;
            if (currentMinute > 59)
            {
                currentMinute = 0;
                currentHour += 1;
            }
            if (currentHour > 23)
            {
                currentHour = 0;
            }
        }
        countDownTime.text = currentHour.ToString("00") + ":" + currentMinute.ToString("00");
    }
}
