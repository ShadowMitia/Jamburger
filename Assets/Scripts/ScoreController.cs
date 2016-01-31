using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	private Text scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
	}

	public void AddScore(int _score){
		score += _score;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
		Debug.Log (score);
	}
}
