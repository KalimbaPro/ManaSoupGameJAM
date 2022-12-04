using UnityEngine;
using System.Collections;

public class MonsterCollision : MonoBehaviour
{
    public GameObject looseText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HealthManager.health--;

            if (HealthManager.health <= 0)
            {
                DreamCountDown.stopTime = true;
                looseText.SetActive(true);
            }
        }
    }
}
