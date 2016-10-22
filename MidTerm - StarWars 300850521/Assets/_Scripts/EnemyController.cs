using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}
//Michael Auric Madrigal 300850521. Last Modified 10/22/2016 Control for Enemies

public class EnemyController : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES
    public Speed speed;
    public Boundary boundary;


    // PRIVATE INSTANCE VARIABLES
    private float _CurrentSpeed;
    private float _CurrentDrift;
    private GameController _gameController;

    // Use this for initialization
    void Start()
    {
        this._gameController = GameObject.FindWithTag("GameController").GetComponent("GameController") as GameController;
        this._Reset();
    }

    // Update is called once per frame
    void Update() {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.y -= this._CurrentSpeed;
        gameObject.GetComponent<Transform>().position = currentPosition;

        // Check bottom boundary
        if (currentPosition.y <= boundary.yMin) {
            this._Reset();
            this._gameController.ScoreValue += 10; //Adds to score.
        }
    }

    // resets the gameObject
    private void _Reset() {
        this._CurrentSpeed = Random.Range(speed.minSpeed, speed.maxSpeed);
        Vector2 resetPosition = new Vector2(Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
        gameObject.GetComponent<Transform>().position = resetPosition;
    }
    //Collision function for when the player inevitably collides with their foe.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            this._Reset();

        }

    }


}
