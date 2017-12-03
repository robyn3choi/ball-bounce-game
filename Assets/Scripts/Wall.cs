using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    Material mat;
    Color otherColor;
    float lerp = 0;
    public bool lowNotes = false;
    AudioSource audiosource;
    TrailRenderer ballTrail;

	// Use this for initialization
	void Start () {
        mat = GetComponent<MeshRenderer>().material;
        audiosource = GetComponent<AudioSource>();

        ballTrail = GameObject.Find("Ball").GetComponent<TrailRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // when ball touches this wall, change the wall to a different color and back
        if (collision.gameObject.CompareTag("Ball"))
        {
            StopAllCoroutines();
            int index = Random.Range(0, WallColors.colors.Count);
            mat.color = WallColors.colors[index];
            otherColor = mat.color;
            lerp = 0;
            StartCoroutine("FadeToDefault");
            ChangeBallTrailColor(WallColors.colors[index]);

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
            audiosource.clip = note;
            audiosource.Play();

        }
    }

    IEnumerator FadeToDefault()
    {
        while (mat.color != WallColors.defaultColor)
        {
            mat.color = Color.Lerp(otherColor, WallColors.defaultColor, lerp += Time.deltaTime);
            yield return null;
        }
        yield break;
    }

    void ChangeBallTrailColor(Color32 color) {
        Color trailColor;
        if (color.Equals(WallColors.red)) { trailColor = Color.red; }
        else if (color.Equals(WallColors.yellow)) { trailColor = Color.yellow; }
        else if (color.Equals(WallColors.green)) { trailColor = Color.green; }
        else if (color.Equals(WallColors.blue)) { trailColor = new Color(0, 0.15f, 1, 1); }
        else if (color.Equals(WallColors.pink)) { trailColor = Color.magenta; }
        else { trailColor = WallColors.defaultColor; }

        ballTrail.endColor = trailColor;
        ballTrail.startColor = trailColor;
        print(ballTrail.startColor);
    }
}
