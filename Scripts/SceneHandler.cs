using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadGame()
    {
        if(StoreManager.bluePaddleActive == false && StoreManager.largePaddleActive == false)
        {
            StoreManager.redPaddleActive = true;
        }
        if(StoreManager.bluePaddleActive == false && StoreManager.largePaddleActive == true && StoreManager.inStore == true)
        {
            StoreManager.redPaddleActive = true;
            StoreManager.largePaddleActive = false;
        }
        if (StoreManager.bluePaddleActive == true && StoreManager.largePaddleActive == false && StoreManager.inStore == true)
        {
            StoreManager.redPaddleActive = true;
            StoreManager.bluePaddleActive = false;
        }
        if (StoreManager.redPaddleActive == true)
        {
            SceneManager.LoadScene("GameScene");
            StoreManager.inStore = false;
        }
        else if (StoreManager.bluePaddleActive == true)
        {
            SceneManager.LoadScene("GameSceneBlue");
            StoreManager.inStore = false;
        }
        else if (StoreManager.largePaddleActive == true)
        {
            SceneManager.LoadScene("sceneKeepDiss");
            StoreManager.inStore = false;
        }
    }

    public void LoadBluePaddleGame()
    {
        if(PlayerPrefs.GetFloat("HighScore", 0f) > 100)
        {
            StoreManager.redPaddleActive = false;
            StoreManager.bluePaddleActive = true;
            StoreManager.largePaddleActive = false;
            StoreManager.inStore = false;
            StartCoroutine(WaitAndLoadRoutineBlue());
        }
        else
        {
            StoreManager.activateAlert1 = true;
        }
    }

    public void LoadBluePaddleLarge()
    {
        if (PlayerPrefs.GetFloat("HighScore", 0f) > 200)
        {
            StoreManager.redPaddleActive = false;
            StoreManager.bluePaddleActive = false;
            StoreManager.largePaddleActive = true;
            StoreManager.inStore = false;
            StartCoroutine(WaitAndLoadRoutineLarge());
        }
        else
        {
            StoreManager.activateAlert2 = true;
        }
    }

    public void LoadStore()
    {
        StoreManager.inStore = true;
        SceneManager.LoadScene("Store");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitAndLoadRoutineBlue()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameSceneBlue");
    }

    private IEnumerator WaitAndLoadRoutineLarge()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SceneKeepDiss");
    }
}
