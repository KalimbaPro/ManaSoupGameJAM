using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animStarter : MonoBehaviour
{
    public Animator[] animators;
    public AnimationClip[] animationsForDelay;
    public string[] anims;
    public bool[] oneTime;
    public bool animating = false;
    private List<int> alreadyDone = new List<int>();
    public List<string> keys;

    // fear
    public List<int> fearValue;
    public HealthBar fearBar;

    void Start()
    {

    }

    void Update()
    {
        if (animating) return;

        foreach (string key in keys)
        {
            if (Input.GetKeyUp((KeyCode)System.Enum.Parse(typeof(KeyCode), key)))
            {
                int animIndex = keys.IndexOf(key);

                if (oneTime[animIndex] == true && alreadyDone.Contains(animIndex))
                    continue;
                bool tmp = true;
                foreach (Animator animator in animators)
                {
                    animator.Play(anims[animIndex]);
                    if (tmp)
                    {
                        StartCoroutine(animDelay(animationsForDelay[animIndex].length, fearValue[animIndex]));
                        tmp = false;
                    }
                }
                if (oneTime[animIndex] == true && !alreadyDone.Contains(animIndex))
                    alreadyDone.Add(animIndex);
            }
        }

        return;
        // if (Input.GetKeyUp(KeyCode.Space))
        // {
           // if (oneTime[animIndex] == true && alreadyDone.Contains(animIndex))
            // {
               // animIndex = (animIndex + 1) % anims.Length;
            //}
            //bool tmp = true;
            //reach (Animator animator in animators)
            //
              //animator.Play(anims[animIndex]);
                //if (tmp)
                //{
                  //  StartCoroutine(animDelay(animationsForDelay[animIndex].length));
                    //tmp = false;
                //}
            //}
            //if (oneTime[animIndex] == true && !alreadyDone.Contains(animIndex))
                //alreadyDone.Add(animIndex);
            //animIndex = (animIndex + 1) % anims.Length;
        //}
    }

    IEnumerator animDelay(float delay, int value)
    {
        animating = true;
        yield return new WaitForSeconds(delay);
        animating = false;
        fearBar.addHealth(value);
    }
}
