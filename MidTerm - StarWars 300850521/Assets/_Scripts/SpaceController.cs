using UnityEngine;
using System.Collections;

public class SpaceController : MonoBehaviour {

    public double _speed;
    private Transform _transform;

    public double Speed
    {
        get { return this._speed; }
        set { this._speed = value; }
    }

	// Use this for initialization
	void Start () {
        this._transform = this.GetComponent<Transform>();
        this._reset();
	}
	
	// Update is called once per frame
	void Update () {
        this._move();
        this._checkBounds();
	}
    //Movement
    private void _move() {
        Vector2 newPosition = this._transform.position;
        newPosition.y -= (float)this._speed;
        this._transform.position = newPosition;
    }
    //Check bounds
    private void _checkBounds()
    {
        if (this._transform.position.y <= -5f)
        {
            this._reset();
        }
    }
    //reset function
    private void _reset()
    {
        this._speed = .01;
        this._transform.position = new Vector2(0f, 5f);
    }
}
