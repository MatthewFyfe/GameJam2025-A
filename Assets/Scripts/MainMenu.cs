using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Host()
    {
        SceneManager.LoadScene("GS_Test");
    }

    public void Join()
    {
        SceneManager.LoadScene("GS_Test");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
