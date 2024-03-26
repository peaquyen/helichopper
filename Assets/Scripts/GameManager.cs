using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;

    public int gamePauseScene;
    public int gameOpenScene;
    
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject scoringObject; // Reference to the scoring object
    private int score;

    private float scoreUpdateInterval = 1f; // Interval for updating the score (1 second)
    private bool isScoreUpdate = true;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        player = FindObjectOfType<Player>();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        isScoreUpdate = true;
    }

    private void Update()
    {
        // Start repeating the score update method every second
        if (isScoreUpdate)
        {
            InvokeRepeating("IncreaseScore", 0f, scoreUpdateInterval);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        isScoreUpdate = false;
        Pause();

        // Stop the repeating score update method when the game is over
        CancelInvoke("IncreaseScore");

        // Load the specified scene (gamePauseScene)
        SceneManager.LoadScene(gamePauseScene);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        isScoreUpdate = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        // Check if a scoring object is assigned and adjust its position
        if (scoringObject != null)
        {
            // Get the current position
            Vector3 newPosition = scoringObject.transform.position;

            // Adjust the y-coordinate by +3 units
            newPosition.y += 3f;

            // Set the new position
            scoringObject.transform.position = newPosition;
        }
    }
}
