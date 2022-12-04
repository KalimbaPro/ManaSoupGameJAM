using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animStarter : MonoBehaviour
{
    public Animator[] animators;
    public string[] anims;
    public int animIndex;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (Animator animators in animators)
            {
                animators.Play(anims[animIndex]);
            }
            animIndex += 1;
            if (animIndex >= animators.Length)
                animIndex = 0;
        }
    }
}
