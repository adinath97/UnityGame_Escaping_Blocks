using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneHandler : MonoBehaviour
{
    public GameObject highScoreDisplay;
    public GameObject scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if(ScoreManager.newHighScore == false)
        {
            highScoreDisplay.gameObject.SetActive(false);
        }
        else
        {
            highScoreDisplay.gameObject.SetActive(true);
        }

        scoreDisplay.GetComponent<Text>().text = "Hits: " + ScoreManager.hits;
    }
}
