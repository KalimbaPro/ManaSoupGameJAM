using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            print("go to menu");
    }
}
