using UnityEngine;
using System.Collections;

public class TempoIngredientController : MonoBehaviour {

	public GameObject tempoPrefab;
	public GameObject tempoIngredientStart;
	public int numIngredients;
	[HideInInspector]
	public GameObject[] tempoIngredients;
	public int speed;


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
			if (tempoIngredients [i] != null) {
				Vector3 newPosition = new Vector3 (-1, 0, 0) * speed * Time.deltaTime;
				tempoIngredients [i].transform.position += newPosition;
			}
		}

	}
}
