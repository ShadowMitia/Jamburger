using UnityEngine;
using System.Collections;

public class TempoIngredientController : MonoBehaviour {

	public GameController gameController;

	public GameObject tempoPrefab;
	public GameObject tempoIngredientStart;
	[HideInInspector]
	public GameObject[] tempoIngredients;
	public int speed;

	private int numIngredients;


	// Use this for initialization
	void Start () {
		Generate ();

	}
		
	
	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < numIngredients; i++) {
			if (tempoIngredients [i] != null) {
				Vector3 newPosition = new Vector3 (-1, 0, 0) * speed * Time.deltaTime;
				tempoIngredients [i].transform.position += newPosition;
			}
		}

	}

	public void Generate(){
		numIngredients = gameController.numIngredientsOrder;
		tempoIngredients = new GameObject[numIngredients];
		for (int i = 0; i < numIngredients; i++) {
			Vector3 newPosition = tempoIngredientStart.transform.position + new Vector3 (i * 2.5f, 0f, 0f);
			tempoIngredients[i] = (GameObject) Instantiate (tempoPrefab, newPosition, Quaternion.identity);
		}
	}
}
