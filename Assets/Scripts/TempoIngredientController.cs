using UnityEngine;
using System.Collections;

public class TempoIngredientController : MonoBehaviour {

	public GameObject tempoPrefab;
	public GameObject tempoIngredientStart;
	public int numIngredients;
	private GameObject[] tempoIngredients;


	// Use this for initialization
	void Start () {
		tempoIngredients = new GameObject[numIngredients];
		for (int i = 0; i < numIngredients; i++) {
			tempoIngredients[i] = (GameObject) Instantiate (tempoPrefab, tempoIngredientStart.transform.position + new Vector3(i * 2.5f, 0f, 0f), Quaternion.identity);
		}
	}
		
	
	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < numIngredients; i++) {
			Vector3 newPosition = new Vector3 (-10, 0, 0) * Time.deltaTime;
			tempoIngredients [i].transform.position += newPosition;
		}

	}
}
