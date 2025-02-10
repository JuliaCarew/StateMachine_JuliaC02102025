using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameManager _gameManager;

    // Enum representing different game states
    public enum GameState
    {
        MainMenu_State,   // The game is at the main menu
        Gameplay_State,   // The game is actively being played
        Paused_State      // The game is paused
    }

    // Property to store the current game state, accessible publicly but modifiable only within this class
    public GameState currentState { get; private set; }

    // Debugging variables to store the current and last game state as strings for easier debugging in the Inspector
    [SerializeField] private string currentStateDebug;
    [SerializeField] private string lastStateDebug;

    private void Start()
    {
        // Set the initial state of the game to Main Menu when the game starts
        ChangeState(GameState.MainMenu_State);
        MainMenuState();
    }
    
    public void ChangeState(GameState newState) // Method to change the current game state
    {        
        lastStateDebug = currentState.ToString();
        currentState = newState;

        HandleStateChange(newState);
        currentStateDebug = currentState.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) 
            && currentState == GameState.Gameplay_State)
        {
            Debug.Log("Switched to pause State");
            PauseState();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && currentState == GameState.Paused_State)
        {
            Debug.Log("Switched to gameplay State");
            GameplayState();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Switched to MainMenu State");
            MainMenuState();
        }
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    Debug.Log("Switched to Gameplay State");
        //    GameplayState();
        //}
    }

    // Handles any specific actions that need to occur when switching to a new state
    private void HandleStateChange(GameState state)
    {
        //_uiManager.ClearUI();
        switch (state)
        {            
            case GameState.MainMenu_State:
                _gameManager._uiManager.DisplayMainMenuUI();


                Time.timeScale = 0;
                break;

            case GameState.Gameplay_State:
                _gameManager._uiManager.DisplayGameplayUI();

                Time.timeScale = 1;
                break;

            case GameState.Paused_State:
                _gameManager._uiManager.DisplayPausedUI();

                Time.timeScale = 0;
                break;            
        }
    }

    public void MainMenuState()
    {
        ChangeState(GameState.MainMenu_State);
    }
    public void GameplayState()
    {
        ChangeState(GameState.Gameplay_State);
    }
    public void PauseState()
    { 
        ChangeState(GameState.Paused_State);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
