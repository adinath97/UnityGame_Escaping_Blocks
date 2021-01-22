using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int hits;
    public GameObject scoreBox;
    public GameObject highScoreBox;
    public static bool newHighScore = false;
    public static bool standardPaddleBlueUnlocked = false;
    public static bool largePaddleUnlocked = false;

    void Start()
    {
        hits = 0;
        newHighScore = false;
        standardPaddleBlueUnlocked = false;
        largePaddleUnlocked = false;
        scoreBox.GetComponent<Text>().text = "Hits: 0";
        highScoreBox.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetFloat("HighScore", 0f).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreBox.GetComponent<Text>().text = "Hits: " + hits;
        if(hits > PlayerPrefs.GetFloat("HighScore", 0f))
        {
            PlayerPrefs.SetFloat("HighScore", hits);
            newHighScore = true;
        }
        if(hits > 100)
        {
            standardPaddleBlueUnlocked = true;
        }
        if (hits > 200)
        {
            largePaddleUnlocked = true;
        }
        highScoreBox.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetFloat("HighScore", 0f).ToString();
    }
}
