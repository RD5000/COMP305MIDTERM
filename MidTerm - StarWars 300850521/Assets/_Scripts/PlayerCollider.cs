using UnityEngine;
using System.Collections;
//Michael Auric Madrigal 300850521. Last Modified 10/22/2016 Controller for player Collisions
public class PlayerCollider : MonoBehaviour {

    //Private Variablerinos
    private GameController _gameController;

    // Use this for initialization
    void Start () {
        this._gameController = GameObject.FindWithTag("GameController").GetComponent("GameController") as GameController;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //For When the Player Collides
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            this._SetScore();
                
        }

    }
    private void _SetScore()
    {
        this._gameController.LivesValue -= 20; //Loss of 20 health
    }

}
