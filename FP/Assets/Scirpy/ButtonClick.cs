using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {

	public void onBtnPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void onBtnBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void onBtnHighscore()
    {
        SceneManager.LoadScene("Highscore");
    }

    public void onBtnExit()
    {
        Debug.Log("Has quit");
        Application.Quit();
    }

    public void onBtnReset()
    {
        PlayerPrefs.DeleteAll(); 
    }
}
