using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public ScoreController scoreController;
	public OrderController orderController;
	public TempoEndZoneController tempoEndZoneController;
	public HealthController healthController;

	public int numIngredientsOrder;
	public int numKeys;

	public int playerLives;

	public Text scoreText;

	public string[] keys;
	public string[] ingredients;

	[HideInInspector]
	public int timestampCurrentTempoToken;
	[HideInInspector]
	public int currentTempoToken;

	// Use this for initialization
	void Start () {
		ingredients = new string[numIngredientsOrder];
		keys = new string[numKeys];
		RandomizeIngredientKeyAssociation ();
		foreach (var el in keys){
			Debug.Log(el);
		}
		currentTempoToken = 0;
	}
	
	// Update is called once per frame
	void Update () {
		string button = null;
		bool pressed = false;
		if (Input.GetKeyDown ("left")) {
			button = "left";
			pressed = true;
		} else if (Input.GetKeyDown ("right")) {
			button = "right";
			pressed = true;
		} else if (Input.GetKeyDown ("up")) {
			button = "up";
			pressed = true;
		} else if (Input.GetKeyDown ("down")) {
			button = "down";
			pressed = true;
		}

		if (pressed && currentTempoToken < numIngredientsOrder) {
			string currentTempo = orderController.ingredients [currentTempoToken].name;
			for (int i = 0; i < ingredients.Length; i++) {
				if (ingredients [i] == currentTempo) {
					if (keys [i] == button) {
						tempoEndZoneController.TapTempo ();
					} else {
						healthController.LoseLife ();
					}
					currentTempoToken++;
					break;
				}
			}

			if (currentTempoToken == numIngredientsOrder) {
				Debug.Log ("Gagné");
			}
		}
	}


	void RandomizeIngredientKeyAssociation (){
		string[] _keys = {"up", "down", "left", "right"};

		//Knuth shuffle
		for (int i = 0; i < _keys.Length - 1; i++) {
			int rand = Random.Range (0, i+1);
			string temp = _keys [i];
			_keys [i] = _keys [rand];
			_keys [rand] = temp;
		}

		for (int i = 0; i < orderController.ingredients.Length; i++) {
			ingredients[i] = orderController.ingredients [i].name;
		}

		//Knuth shuffle
		for (int i = 0; i < ingredients.Length; i++) {
			int rand = Random.Range (0, i + 1);
			string temp = ingredients [i];
			ingredients [i] = ingredients [rand];
			ingredients [rand] = temp;
		}

		for (int i = 0; i < keys.Length; i++) {
			keys [i] = _keys [i];
		}

	}
}
