﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame1 : MonoBehaviour
{
    public GameObject tutorial;
    public void SceneChange()
    {
        SceneManager.LoadScene("Game1");
    }

    public void DoExitGame()
    {
        Debug.Log("EXID");
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowTutorial()
    {
        tutorial.SetActive(true);
    }
}
