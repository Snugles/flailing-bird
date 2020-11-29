using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public bool gameStarted = false;
	public Transform Obstacle;
	public float score = 0;

	private float obstacleSpawnLocation;
	private float lastSpawn = 0.0f;
	private float jumpHeight = 0.06f;
	private float gravity = 0.001f;
	private float momentum = 0.0f;
	// Use this for initialization
	void Start () {
		obstacleSpawnLocation = Camera.main.GetComponent<Camera>().orthographicSize* Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted) {
		this.transform.position = this.transform.position + new Vector3(0, momentum, 0);
		momentum -= gravity;
			if (Input.GetKeyDown("space")){Jump();}
			if (Time.time>=lastSpawn+5.0f){
				SpawnObstacle();
				lastSpawn = Time.time;
				score+=1;
			}
		} else if (Input.GetKeyDown("space")) {
			score = 0;
			gameStarted = true;
			lastSpawn = Time.time;
			SpawnObstacle();
			Jump();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		gameStarted=false;
		this.transform.position = new Vector3(0, 0, 0);
	}
	
	void SpawnObstacle () {
		Instantiate(Obstacle, new Vector3(obstacleSpawnLocation+1, Random.Range(-2.0f, 2.0f), 0), Quaternion.identity);
	}

	void Jump () {
		momentum = jumpHeight;
	}
}
