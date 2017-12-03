using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager inst = null;
    public Text scoreText;
    public Text gameOverText;
    public Text lostScoreText;
    public Button restartBtn;
    int score = 0;
    bool lost = false;
    Ball ball;


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
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        WallColors.InitColors();
	}

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Lose() {
        if (!lost) { // because the ball may collide with the screen bottom multiple times
            lostScoreText.text = "Your Score: " + score.ToString() + "\nHigh Score: 99";
            gameOverText.gameObject.SetActive(true);
            lostScoreText.gameObject.SetActive(true);
            restartBtn.gameObject.SetActive(true);
        }
    }

    public void Restart() {
        gameOverText.gameObject.SetActive(false);
        lostScoreText.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);
        score = 0;
        scoreText.text = "0";
        bool lost = false;
        Camera.main.transform.position = new Vector3(0, 1, -10);
        ball.Restart();
        // generate level
    }
}
