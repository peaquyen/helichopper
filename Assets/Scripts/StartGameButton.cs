using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartScene;
    public int gamePauseScene;
    public int gameOpenScene;

    public void StartGame()
    {
        // Find the GameManager GameObject and call its Play method
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.Play();
        }
        else
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        // Load the specified scene (if needed)
        SceneManager.LoadScene(gameStartScene);
    }
}