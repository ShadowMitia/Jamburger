using UnityEngine;
using System.Collections;

public class OrderController : MonoBehaviour {

	public GameObject topHamburger;
	public GameObject bottomHamburger;
	[HideInInspector]
	public GameObject[] orderIngredients;
	public int numberIngredientsOrder;
	public GameObject[] ingredients;

	// Use this for initialization
	void Start () {
		orderIngredients = new GameObject[numberIngredientsOrder];
		GenerateOrder ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateOrder() { //66
		for (int i = 0; i < numberIngredientsOrder; i++) {
			orderIngredients[i] = (GameObject) Instantiate(ingredients[Random.Range(0, ingredients.Length)], topHamburger.GetComponent<Transform>().position + new Vector3(0f, (i+1) * -(ingredients.Length) / 2f, 0f), Quaternion.identity);
			orderIngredients[i].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
		}
	}
}
