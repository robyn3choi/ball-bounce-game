using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    ParticleSystem wallParticles;
    ParticleSystem cubeParticles;
    public AudioClip[] scoreSounds;
    AudioSource aud;
    int scoreSoundIndex = 0;
    Vector3 startPos = new Vector3(0, -0.5f, -4.78f);
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        wallParticles = GameObject.Find("WallParticles").GetComponent<ParticleSystem>();
        cubeParticles = GameObject.Find("CubeParticles").GetComponent<ParticleSystem>();
        aud = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            aud.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // play particles at wall when ball bounces off that point
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 hitPoint = collision.contacts[0].point;
            wallParticles.transform.position = hitPoint;
            wallParticles.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            GameManager.inst.IncrementScore();
            cubeParticles.transform.position = other.transform.position;
            cubeParticles.Play();
            other.transform.parent.gameObject.SetActive(false);
            aud.clip = scoreSounds[scoreSoundIndex];
            if (scoreSoundIndex == scoreSounds.Length)
            {
                scoreSoundIndex = 0;
            }
            else
            {
                scoreSoundIndex++;
            }
            aud.Play();
        }
        else if (other.CompareTag("ScreenBottom")) {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            GameManager.inst.Lose();
        }
    }

    public void Restart() {
        transform.position = startPos;
        rb.useGravity = true;
    }

    
}
