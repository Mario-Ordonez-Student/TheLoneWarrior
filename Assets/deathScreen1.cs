using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Retry()
    {
        Debug.Log("Game should restart");
        SceneManager.LoadScene("Main Game Scene");
    }

    public void RetryTurtorial()
    {
        SceneManager.LoadScene("Turtorial");
    }

    public void MainMenu()
    {
        Debug.Log("Title screen should show now");
        SceneManager.LoadScene("Title");
    }
}
