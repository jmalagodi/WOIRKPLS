using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesCounterp1 : MonoBehaviour
{
    public static LivesCounterp1 instance;
    public TextMeshProUGUI livesText; // Reference to the UI Text
    private int lives = 3;
    public bool gameOver;
    public GameObject player;

    private void Awake()
    {
        instance = this;
        gameOver = false;
    }
    void Start()
    {
        UpdateScoreDisplay();
    }

    // Call this method whenever a pin is hit
    public void DecreaseLives()
    {
        lives -= 1;
        UpdateScoreDisplay();
    }

    // Update the score display text
    private void UpdateScoreDisplay()
    {
        livesText.text = "Player 1 Lives: " + lives;
    }
    public void Update()
    {
        if (lives <= 0)
        {
            gameOver = true;
            Debug.Log("Game Over");
            StartCoroutine(GameRestart());
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private IEnumerator GameRestart()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        player.gameObject.SetActive(true);
        SceneManager.LoadScene(0);
        
    }


}

