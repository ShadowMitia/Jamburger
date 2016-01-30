using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private ScoreController scoreController;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreController = scoreText.GetComponent<ScoreController> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreController.AddScore (10);
	}
}
