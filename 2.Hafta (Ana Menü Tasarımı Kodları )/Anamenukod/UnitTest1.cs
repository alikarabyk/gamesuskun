using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : MonoBehaviour
{

    [Header("UIPages")]
    public GameObject settingsScreen;
    public GameObject creditsScreen;
    public GameObject mainScreen;

    public void StartGame()
    {
        //Oyunu baþlatacak kýsým.
        Application.LoadLevel("levelÝsmi");
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    public void set2Menu()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void Credits()
    {
        mainScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
    public void cre2Menu()
    {
        mainScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}