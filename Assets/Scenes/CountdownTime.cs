using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingtime = 10f;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingtime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        //print (currentTime);
    }
}
