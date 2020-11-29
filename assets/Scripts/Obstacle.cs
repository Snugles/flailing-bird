using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	private float movementSpeed = 0.02f;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position - new Vector3(movementSpeed, 0, 0);
		if (this.transform.position.x<-10f||!gameController.gameStarted) {
			Destroy(gameObject);
		}
	}
}
