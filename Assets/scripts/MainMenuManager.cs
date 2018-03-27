using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameLvl1", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
