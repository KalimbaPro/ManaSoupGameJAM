using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayableDirector director;

    public GameObject[] objectToDesactivate;
    public CountDownTime timer;
    public moveCameraBed cam;
    public GameObject kid;

    public float decaySpeed;

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
        if (slider.value >= slider.maxValue)
        {
            director.Play();
            foreach (GameObject obj in objectToDesactivate)
                obj.SetActive(false);
            timer.setState(true);
            cam.setFollow(kid);
        }

        slider.value -= decaySpeed * Time.deltaTime;
    }
}
