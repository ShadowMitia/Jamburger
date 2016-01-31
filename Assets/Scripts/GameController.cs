using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public ScoreController scoreController;
	public OrderController orderController;
	public HealthController healthController;
	public TempoIngredientController tempoIngredientController;
	public GameObject tempoBar;
	public KeyAidVisualizer keyAid;

	public Text scoreText;

	public int numIngredientsOrder;
	public int numKeys;
	public int playerLives;
	public string[] keys;


	[HideInInspector]
	public int timestampCurrentTempoToken;
	[HideInInspector]
	public int currentTempoToken;

	// Use this for initialization
	void Start () {
		if (numIngredientsOrder < 4) {
			numKeys = numIngredientsOrder;
		} else {
			numKeys = 4;
		}

		keys = new string[numKeys];
		RandomizeIngredientKeyAssociation ();
		foreach (var el in keys){
			Debug.Log(el + " ");
		}
		currentTempoToken = 0;

		NewLevel ();

	}

	void NewLevel(){
		orderController.GenerateOrder ();
		keyAid.LoadVisualiser ();
	}
	
	// Update is called once per frame
	void Update () {
		Bounds bounds = tempoBar.GetComponent<Renderer> ().bounds;
		Vector3 pos = tempoBar.GetComponent<Transform> ().position;
		try 
		{
			GameObject currentToken = tempoIngredientController.tempoIngredients [currentTempoToken];
		} catch (IndexOutOfRangeException e){
			Debug.Log ("error");
		}

		Vector3 currentPos = currentToken.GetComponent<Transform> ().position;

		if (tempoIngredientController.tempoIngredients.Length == 0 || tempoIngredientController.tempoIngredients.Length == 1 && currentPos.x < tempoBar.GetComponent<Transform> ().position.x) {
			Debug.Log ("Level finished");
			return;
		}

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

		if (currentToken.GetComponent<Transform> ().position.x < (pos.x + bounds.extents.x) && currentToken.GetComponent<Transform> ().position.x > (pos.x - bounds.extents.x) ) {
			
		} else {
			currentToken.GetComponent<SpriteRenderer> ().color = Color.white;
		}

		if (pressed && currentTempoToken < numIngredientsOrder) {
			//Debug.Log ("pressed");
			for (int i = 0; i < keys.Length; i++) {
				if (keys [i] == button) {
					//Debug.Log ("key");
					//Debug.Log (orderController.ingredients[i].name);
					//Debug.Log (orderController.orderIngredients[currentTempoToken].name);
					if (orderController.ingredients [i].name+"(Clone)" == orderController.orderIngredients[currentTempoToken].name) {
						//Debug.Log ("yup");
						if (currentPos.x < (pos.x + bounds.extents.x) && currentPos.x > (pos.x - bounds.extents.x) ) {
							scoreController.AddScore (100);
							orderController.orderIngredients [currentTempoToken].GetComponent<AudioSource> ().Play ();
							Destroy (currentToken);
							currentTempoToken++;
						} else {
							healthController.LoseLife();
							Destroy (currentToken);
							currentTempoToken++;

							//orderController.orderIngredients[currentTempoToken].GetComponent<AudioSource>().
							orderController.orderIngredients [currentTempoToken].GetComponent<AudioSource> ().Play ();
						}

					} else {
						healthController.LoseLife();
					}
				}
			}
		}


		if (currentPos.x < pos.x - bounds.extents.x) {
			currentToken.GetComponent<SpriteRenderer> ().color = Color.blue;
			Destroy (currentToken, 1f);
			currentTempoToken++;
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
		/*
		for (int i = 0; i < ingredients.Length; i++) {
			ingredients[i] = orderController.ingredients [i].name;
		}
		*/

		//Knuth shuffle
		for (int i = 0; i < orderController.ingredients.Length; i++) {
			int rand = Random.Range (0, i + 1);
			GameObject temp = orderController.ingredients [i];
			orderController.ingredients [i] = orderController.ingredients [rand];
			orderController.ingredients [rand] = temp;
		}

		for (int i = 0; i < keys.Length; i++) {
			keys [i] = _keys [i];
		}



	}
}
