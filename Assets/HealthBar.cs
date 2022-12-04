using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayableDirector director;

    public GameObject[] objectToDesactivate;
    public CountDownTime timer;
    public moveCameraBed cam;
    public GameObject kid;

    public GameObject black;

    public float decaySpeed;

    private bool animating = false;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
    public void addHealth(float health)
    {
        slider.value += health;
    }
    private void Update()
    {
        if (animating)
            return;
        if (slider.value >= slider.maxValue)
        {
            animating = true;
            StartCoroutine(animDelay((float)director.duration));

        }
        slider.value -= decaySpeed * Time.deltaTime;

        if (timer.getCurrentHour() == 21 && slider.value >= 75)
        {
            print("wp");
            SceneManager.LoadScene("DreamPhase");
        }
        if (timer.getCurrentHour() == 21 && slider.value < 75)
        {
            foreach (GameObject obj in objectToDesactivate)
                obj.SetActive(false);
            black.SetActive(true);
        }

    }

    IEnumerator animDelay(float delay)
    {
        director.Play();
        timer.setState(true);
        cam.setFollow(kid);
        yield return new WaitForSeconds(delay);
        foreach (GameObject obj in objectToDesactivate)
            obj.SetActive(false);
    }
}