using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private GameController gameController;
	private Text text;
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ();
		text = gameObject.GetComponent(typeof(Text)) as Text;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = gameController.score.ToString();
	}
}
