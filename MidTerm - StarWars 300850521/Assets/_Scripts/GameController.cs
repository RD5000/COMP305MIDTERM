using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Michael Auric Madrigal 300850521. Last Modified 10/22/2016 General Controller for Game.
public class GameController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public int enemyCount;
    public int finalScore;
    public int scoreValue = 0;
    public int livesValue = 100;

    [Header("UI Objects")]
    public Text ScoreLabel;
    public Text LivesLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    [Header("Game Objects")]
    public GameObject player;
    public GameObject enemy;


    //Score Properties
    public int LivesValue
    {
        get
        {
            return this.livesValue;
        }

        set
        {
            this.livesValue = value;
            this.LivesLabel.text = "Hull Strength: " + this.livesValue + "%";
            // Changes color of the Lives Label according to how much health is left.
            if (livesValue == 100)
            {
                LivesLabel.color = Color.green;
            }
            if (livesValue == 60)
            {
                LivesLabel.color = Color.yellow;
            }
            else if (livesValue == 20)
            {
                LivesLabel.color = Color.red;
            }
            else if (livesValue == 0)
            {
                this._gameOver();
            }
        }
    }
    public int ScoreValue
    {
        get
        {
            return this.scoreValue;
        }

        set
        {
            this.scoreValue = value;
            this.ScoreLabel.text = "Rebel Merit: " + this.scoreValue;
        }
    }


    // Use this for initialization
    void Start () {
		this._GenerateEnemies ();
        this.enemy.SetActive(true);
        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds? (This was here when I got it. I don't know why it says clouds, but I'll leave it as is.)
	private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
			Instantiate(enemy);
		}
	}
    //Game Over function for when the player wants to be reminded they are bad at videogames
    private void _gameOver()
    {
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "MERIT SCORE: " + this.scoreValue;
        this.RestartButton.gameObject.SetActive(true);
        this.player.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        this.LivesLabel.gameObject.SetActive(false);
    }
    //Restart function so the player can relive their failures.
    public void OnRestartButton_Click() {
        Debug.Log("Restarting...");
        SceneManager.LoadScene("Main");
    }

}
