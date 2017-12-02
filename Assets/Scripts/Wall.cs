using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    List<Color32> colors;
    Color32 defaultColor;
    Material mat;
    Color otherColor;
    float lerp = 0;
    public bool lowNotes = false;
    AudioSource audio;
    //TrailRenderer ballTrail;

	// Use this for initialization
	void Start () {
        defaultColor = new Color32(171, 171, 171, 255);
        Color32 red = new Color32(255, 118, 118, 255);
        Color32 yellow = new Color32(255, 255, 118, 255);
        Color32 green = new Color32(118, 255, 118, 255);
        Color32 blue = new Color32(118, 118, 255, 255);
        Color32 pink = new Color32(255, 118, 255, 255);

        colors = new List<Color32>();
        colors.Add(red);
        colors.Add(yellow);
        colors.Add(green);
        colors.Add(blue);
        colors.Add(pink);

        mat = GetComponent<MeshRenderer>().material;
        audio = GetComponent<AudioSource>();

        //ballTrail = GameObject.Find("Ball").GetComponent<TrailRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        // when ball touches this wall, change the wall to a different color and back
        if (collision.gameObject.CompareTag("Ball"))
        {
            StopAllCoroutines();
            int index = Random.Range(0, colors.Count);
            mat.color = colors[index];
            otherColor = mat.color;
            lerp = 0;
            StartCoroutine("fadeToDefault");

            AudioClip note;
            if (lowNotes)
            {
                index = Random.Range(0, AudioManager.inst.lowNotes.Count);
                note = AudioManager.inst.lowNotes[index];
            }
            else
            {
                index = Random.Range(0, AudioManager.inst.notes.Count);
                note = AudioManager.inst.notes[index];
            }
            audio.clip = note;
            audio.Play();
        }
    }

    IEnumerator fadeToDefault()
    {
        while (mat.color != defaultColor)
        {
            mat.color = Color.Lerp(otherColor, defaultColor, lerp += Time.deltaTime);
            yield return null;
        }
        yield break;
    }
}
