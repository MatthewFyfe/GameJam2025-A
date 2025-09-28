using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Host()
    {
        SceneManager.LoadScene("GS_Level");
    }

    public void Join()
    {
        SceneManager.LoadScene("GS_Level");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        UnPause();
        ControlPointSP.playerHP = 10;
        ControlPointSP.dragonHP = 3;
        SceneManager.LoadScene("GS_MainMenu");
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }
}
