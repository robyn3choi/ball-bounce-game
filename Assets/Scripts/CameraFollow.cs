using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform ball;
    float smoothSpeed = 2.5f;
    float offset = 1.5f;
    float changeOffset = 2f;
    Vector3 currentVelocity;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball").transform;
	}
	
	void Update () {
        //if (ball.position.y > (transform.position.y + changeOffset) || ball.position.y < (transform.position.y - changeOffset)) 
        if (ball.position.y > (transform.position.y + changeOffset))
        {
            Vector3 newPosition = new Vector3(transform.position.x, ball.position.y + offset, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
            //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, smoothSpeed);
            //rb.MovePosition(Vector3.Lerp(transform.position, newPosition, smoothSpeed));
            transform.position = Vector3.MoveTowards(transform.position, newPosition, smoothSpeed * Time.deltaTime);
            //transform.position = newPosition;
        }
	}
}
