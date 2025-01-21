using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Declare variables 
    public Text scoreText;
    public Text healthText; 

    
    private int playerScore = 0;
    private float playerHealth = 100.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Test if the score is greater than or equal to 100 
        if (playerScore >= 100)
        {
            // Display a message when the score reaches 100 
            scoreText.text = "Score: 100 (You Win!)";
        }

        // Detect a key press (e.g., "W" key) 
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Increase the score when the "W" key is pressed 
            playerScore += 10;
        }

        // Update the Text elements with current values 
        scoreText.text = "Score: " + playerScore.ToString();
        healthText.text = "Health: " + playerHealth.ToString();
    }
}
