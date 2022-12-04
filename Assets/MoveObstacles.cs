using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject player;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when hit the ground, move the object to the left at a constant speed
        if (isGrounded)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

     void OnCollisionStay2D(Collision2D col)
     {
 
        if (col.gameObject.tag == "Ground")
            isGrounded = true;
        if (col.gameObject.tag == "Player")
        {
            // player.getcomponent<player>().health -= 1;
            Destroy(transform.gameObject);
        }
    }
}
