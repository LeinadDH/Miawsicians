using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagger : MonoBehaviour
{
    public static ScoreManagger Instance;
    //public AudioSource hitSFX;
    //public AudioSource missSFX;
    public TMPro.TMP_Text scoreText;
    static int comboScore;

    void Start()
    {
        Instance = this;
        comboScore = 0;
    }

    public static void Hit()
    {
        comboScore += 1;
        //Instance.hitSFX.Play();
    }

    public static void Miss()
    {
        comboScore = 0;
        //Instance.missSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + comboScore.ToString();
    }
}
