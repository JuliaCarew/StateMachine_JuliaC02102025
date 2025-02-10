using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager _gameManager;

    public GameObject menuUI;
    public GameObject gameplayUI;
    public GameObject pausedUI;

    public void DisplayMainMenuUI()
    {
        ClearUI();
        menuUI.SetActive(true);
    }
    public void DisplayGameplayUI()
    {
        ClearUI();
        gameplayUI.SetActive(true);
    }
    public void DisplayPausedUI()
    {
        ClearUI();
        pausedUI.SetActive(true);
    }
    public void ClearUI()
    {
        menuUI.SetActive(false);
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
    }
}
