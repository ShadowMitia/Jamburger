using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public ScoreController scoreController;
	public OrderController orderController;

	public Text scoreText;

	public Dictionary<KeyCode, GameObject> keyToIngredientTable;

	// Use this for initialization
	void Start () {
		keyToIngredientTable = new Dictionary<KeyCode, GameObject>();
		scoreController = scoreText.GetComponent<ScoreController> ();
		RandomizeIngredientKeyAssociation ();
		foreach (var item in keyToIngredientTable) {
			Debug.Log (item);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RandomizeIngredientKeyAssociation (){
		KeyCode[] keys = {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
		//Knuth shuffle
		for (int i = 0; i < keys.Length - 1; i++) {
			int rand = Random.Range (0, i+1);
			KeyCode temp = keys [i];
			keys [i] = keys [rand];
			keys [rand] = temp;
		}
			
		keyToIngredientTable.Clear ();

		for (int i = 0; i < orderController.ingredients.Length; i++) {
			keyToIngredientTable.Add (keys [i], orderController.ingredients [i]);
		}
	}
}
