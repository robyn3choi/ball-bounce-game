using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    protected ParticleSystem wallParticles;
    ParticleSystem cubeParticles;
    public AudioClip[] scoreSounds;
    protected AudioSource aud;
    int scoreSoundIndex = 0;
    Vector3 startPos = new Vector3(0, -0.5f, -4.78f);
    protected Rigidbody rb;
    protected Launcher launcher;

    // Use this for initialization
    protected void Start () {
        wallParticles = transform.GetChild(0).GetComponent<ParticleSystem>();
        cubeParticles = GameObject.Find("CubeParticles").GetComponent<ParticleSystem>();
        aud = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        launcher = GameObject.Find("Launcher").GetComponent<Launcher>();
        // if this is not a ballcopy
        if (GetComponent<BallCopy>() == null)
            launcher.balls.Add(rb);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        // play particles at wall when ball bounces off that point
        if (other.CompareTag("Wall"))
        {
            Vector3 hitPoint = collision.contacts[0].point;
            wallParticles.transform.position = hitPoint;
            wallParticles.Play();
        }
        else if (other.CompareTag("Ball")) {
            BallCopy ballCopy = other.GetComponent<BallCopy>();
            if (ballCopy != null) {
                if (!ballCopy.unlocked) {
                    aud.clip = AudioManager.inst.collectibles[0];
                    aud.Play();
                    ballCopy.Unlock();
                }   
            }
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            GameManager.inst.IncrementScore();
            cubeParticles.transform.position = other.transform.position;
            cubeParticles.Play();
            other.transform.parent.gameObject.SetActive(false);
            aud.clip = AudioManager.inst.collectibles[1];
            aud.Play();
        }

        else if (other.CompareTag("ScreenBottom")) {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            if (GetComponent<BallCopy>() == null)
                GameManager.inst.Lose();
        }
    }

    public virtual void Restart() {
        transform.position = startPos;
        rb.useGravity = true;
    }
}
