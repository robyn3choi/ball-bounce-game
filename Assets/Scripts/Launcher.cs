using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    Vector2 offset;
    Vector2 origin;
    Rigidbody ballRB;
    float speed = 0.05f;

    Transform arrow;
    float arrowScaleFactor = 0.005f;

	// Use this for initialization
	void Start () {
        ballRB = GetComponent<Rigidbody>();
        ballRB.interpolation = RigidbodyInterpolation.Interpolate;
        origin = new Vector2(999, 999);
        offset = Vector2.zero;

        arrow = GameObject.Find("arrow").transform;
        arrow.gameObject.SetActive(false);
	}

    // Update is called once per frame
    void FixedUpdate() {
  //      if (Input.touchCount == 1 && origin.x != 999)
  //      {
  //          origin = Input.GetTouch(0).position;
  //      }
		//if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
  //      {
  //          offset = origin - Input.GetTouch(0).position;
  //          print(offset);
  //      }
  //      if (Input.touchCount == 0 && offset.magnitude > 0)
  //      {
  //          ballRB.velocity = offset;
  //          offset = Vector2.zero;
  //      }

        if (Input.GetMouseButton(0) && origin.x == 999)
        {
            origin = Input.mousePosition;
            arrow.gameObject.SetActive(true);
            arrow.localScale = new Vector3(arrow.localScale.x, 0, 1);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                arrow.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            offset = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - origin;
            arrow.localScale = new Vector3(arrow.localScale.x, offset.magnitude * arrowScaleFactor, 1);
            // find angle between offset and down vector
            float angle;
            Vector2 down = new Vector2(0, -1);
            angle = Vector2.Angle(down, offset);
            if (offset.x > 0)
            {
                angle = -angle;
            }
            arrow.eulerAngles = new Vector3(0, 0, -angle);
        }
        else if (!Input.GetMouseButton(0) && offset.magnitude > 0)
        {
            ballRB.velocity = -offset * speed;
            //ballRB.AddForce(offset);
            offset = Vector2.zero;
            origin = new Vector2(999, 999);
            arrow.gameObject.SetActive(false);
            arrow.localScale = new Vector3(arrow.localScale.x, 0, 1);
        }
    }
}
