using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    public static BallManager inst = null;
    List<Ball> balls;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        balls = new List<Ball>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
