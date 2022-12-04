using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCameraBed : MonoBehaviour
{
    public Camera cam;
    public Vector3 startingPos;
    public float speed;
    public float limitLeft;
    public float limitRight;
    public GameObject follow;


    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = startingPos;
    }

    // Update is called once per frame
    void Update()
    {
        float height = cam.orthographicSize;
        float width = height * cam.aspect;
        Vector3 tmpPos = Vector3.zero;
        if (follow)
        {
            tmpPos = new Vector3(follow.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            if (tmpPos.x < limitLeft + width)
                tmpPos.x = limitLeft + width;
            if (tmpPos.x > limitRight - width)
                tmpPos.x = limitRight - width;
        } else
        {
            float velocity = Input.GetAxis("Horizontal");
            tmpPos = cam.transform.position + new Vector3(velocity * Time.deltaTime * speed, 0, 0);
        }
        if (tmpPos.x < limitLeft + width)
            tmpPos.x = limitLeft + width;
        if (tmpPos.x > limitRight - width)
            tmpPos.x = limitRight - width;
        cam.transform.position = tmpPos;
        // if (cam.transform)
    }

    public void setFollow(GameObject f)
    {
        follow = f;
    }
}
