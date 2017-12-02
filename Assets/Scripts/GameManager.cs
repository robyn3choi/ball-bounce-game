using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager inst = null;
    public Text scoreText;
    int score = 0;

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
        scoreText.text = "0";
	}

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
