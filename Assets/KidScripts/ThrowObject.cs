using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    // array of objects to throw
    [SerializeField] GameObject[] objectsToThrow;
    [SerializeField] float heightFromPlayer = 10;
    [SerializeField] int xRangeMin = 3;
    [SerializeField] int xRangeMax = 7;
    [SerializeField] int timeRangeMin = 1;
    [SerializeField] int timeRangeMax = 5;
    private float timeToWait;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // throw an object from the sky from the player's position at random intervals
        // get a random time to wait before throwing the object
        
        if (timeToWait > 0)
        {
            timeToWait -= Time.deltaTime;
        }
        else
        {
            // get a random object to throw
            int objectToThrow = Random.Range(0, objectsToThrow.Length);
            // get a random x position to throw the object
            float xPosition = transform.position.x - Random.Range(xRangeMin, xRangeMax);
            float yPosition = transform.position.y + heightFromPlayer;
            // throw the object
            Instantiate(objectsToThrow[objectToThrow], new Vector3(xPosition, yPosition, transform.position.z), Quaternion.identity);
            // reset the time to wait
            timeToWait = Random.Range(timeRangeMin, timeRangeMax);
        }
    }
}
