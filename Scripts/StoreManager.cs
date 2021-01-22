using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public static bool redPaddleActive;
    public static bool bluePaddleActive;
    public static bool largePaddleActive;
    public static bool activateAlert1;
    public static bool activateAlert2;
    public static bool inStore;
    public static bool coroutineComplete1;
    public static bool coroutineComplete2;

    public GameObject redPaddleText;
    public GameObject bluePaddleText;
    public GameObject largePaddleText;
    public GameObject alertBox1;
    public GameObject alertBox2;


    private void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore", 0f) == 0 || (largePaddleActive == false && bluePaddleActive == false))
        {
            redPaddleActive = true;
            largePaddleActive = false;
            bluePaddleActive = false;
            activateAlert1 = false;
            activateAlert2 = false;
        }
        coroutineComplete1 = true;
        coroutineComplete2 = true;
        alertBox1.gameObject.SetActive(false);
        alertBox2.gameObject.SetActive(false);
    }

    private void Update()
    {
        EvaluateRed();
        EvaluateBlue();
        EvaluateLarge();
        EvaluateAlerts();
    }

    private void EvaluateAlerts()
    {
        if(activateAlert1 == true && coroutineComplete1 == true)
        {
            coroutineComplete1 = false;
            //ensure alertBox2 is disabled but ready for use
            alertBox2.gameObject.SetActive(false);
            alertBox1.GetComponent<Text>().text = "You do not have enough hits to use this paddle. You need at least 100 hits.";
            alertBox1.gameObject.SetActive(true);
            StartCoroutine(WaitAndDisableRoutine1());
        }
        if (activateAlert2 == true && coroutineComplete2 == true)
        {
            coroutineComplete2 = false;
            alertBox1.gameObject.SetActive(false);
            alertBox2.GetComponent<Text>().text = "You do not have enough hits to use this paddle. You need at least 200 hits.";
            alertBox2.gameObject.SetActive(true);
            StartCoroutine(WaitAndDisableRoutine2());
        }
    }

    IEnumerator WaitAndDisableRoutine1()
    {
        yield return new WaitForSeconds(3f);
        alertBox1.gameObject.SetActive(false);
        coroutineComplete1 = true;
        activateAlert1 = false;
    }

    IEnumerator WaitAndDisableRoutine2()
    {
        yield return new WaitForSeconds(3f);
        alertBox2.gameObject.SetActive(false);
        coroutineComplete2 = true;
        activateAlert2 = false;
    }

    private void EvaluateRed()
    {
        if (redPaddleActive == true)
        {
            redPaddleText.GetComponent<Text>().text = "ACTIVE";
        }
        else
        {
            redPaddleText.GetComponent<Text>().text = "INACTIVE";
        }
    }

    private void EvaluateBlue()
    {
        if(PlayerPrefs.GetFloat("HighScore", 0f) < 100)
        {
            bluePaddleText.GetComponent<Text>().text = "LOCKED";
        }
        if(PlayerPrefs.GetFloat("HighScore", 0f) >= 100 && bluePaddleActive == true)
        {
            bluePaddleText.GetComponent<Text>().text = "ACTIVE";
        }
        if (PlayerPrefs.GetFloat("HighScore", 0f) >= 100 && bluePaddleActive == false)
        {
            bluePaddleText.GetComponent<Text>().text = "INACTIVE";
        }
    }

    private void EvaluateLarge()
    {
        if (PlayerPrefs.GetFloat("HighScore", 0f) < 200)
        {
            largePaddleText.GetComponent<Text>().text = "LOCKED";
        }
        if (PlayerPrefs.GetFloat("HighScore", 0f) >= 200 && largePaddleActive == true)
        {
            largePaddleText.GetComponent<Text>().text = "ACTIVE";
        }
        if (PlayerPrefs.GetFloat("HighScore", 0f) >= 200 && largePaddleActive == false)
        {
            largePaddleText.GetComponent<Text>().text = "INACTIVE";
        }
    }
}
