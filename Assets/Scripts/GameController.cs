using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public ScoreController scoreController;
	public OrderController orderController;

	public Text scoreText;

	public Dictionary<string, GameObject> keyToIngredientTable;

	// Use this for initialization
	void Start () {
		keyToIngredientTable = new Dictionary<string, GameObject>();
		RandomizeIngredientKeyAssociation ();
		foreach (var item in keyToIngredientTable) {
			Debug.Log (item);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("left")) {
			Debug.Log ("weah");
		}
	}

	void RandomizeIngredientKeyAssociation (){
		string[] keys = {"up", "down", "left", "right"};
		//Knuth shuffle
		for (int i = 0; i < keys.Length - 1; i++) {
			int rand = Random.Range (0, i+1);
			string temp = keys [i];
			keys [i] = keys [rand];
			keys [rand] = temp;
		}
			
		keyToIngredientTable.Clear ();

		for (int i = 0; i < orderController.ingredients.Length; i++) {
			keyToIngredientTable.Add (keys [i], orderController.ingredients [i]);
		}
	}
}
