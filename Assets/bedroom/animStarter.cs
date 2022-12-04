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

    float multiplcator = 1;
    int lastIndex = -1;

    public int inrow;

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
                        if (lastIndex == animIndex)
                            multiplcator -= 0.1f;
                        else
                            multiplcator += 0.1f;

                        if (multiplcator < 0.5f)
                            multiplcator = 0.5f;
                        if (multiplcator > 1.5f)
                            multiplcator = 1.5f;
                        lastIndex = animIndex;
                        StartCoroutine(animDelay(animationsForDelay[animIndex].length, fearValue[animIndex] * multiplcator));
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

    IEnumerator animDelay(float delay, float value)
    {
        print(value);
        animating = true;
        yield return new WaitForSeconds(delay);
        animating = false;
        fearBar.addHealth(value);
    }
}
