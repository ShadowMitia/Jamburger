using UnityEngine;
using System.Collections;

public class OrderController : MonoBehaviour {
	GameController gameController;
	public GameObject topHamburger;
	public GameObject bottomHamburger;
	[HideInInspector]
	public GameObject[] orderIngredients;
	int numberIngredientsOrder;
	public GameObject[] ingredients;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		numberIngredientsOrder = gameController.numIngredientsOrder;
		orderIngredients = new GameObject[numberIngredientsOrder];
	}

	public void GenerateOrder() { //66
		Vector3 newVec = new Vector3(0f, -(topHamburger.GetComponent<Transform>().position.y - bottomHamburger.GetComponent<Transform>().position.y), 0f);
		if (gameController.numIngredientsOrder == 1) {
			orderIngredients [0] = (GameObject)Instantiate (ingredients [Random.Range (0, ingredients.Length)], topHamburger.GetComponent<Transform> ().position + newVec / 2f, Quaternion.identity);
			orderIngredients[0].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
		} else if (gameController.numIngredientsOrder == 2) {
			orderIngredients [0] = (GameObject)Instantiate (ingredients [Random.Range (0, ingredients.Length / 2)], topHamburger.GetComponent<Transform> ().position + newVec / 3f, Quaternion.identity);
			orderIngredients[0].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
			orderIngredients [1] = (GameObject)Instantiate (ingredients [Random.Range ((ingredients.Length / 2) + 1, ingredients.Length)], topHamburger.GetComponent<Transform> ().position + 2 * newVec / 3f, Quaternion.identity);
			orderIngredients[1].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
		} else {
			for (int i = 0; i < numberIngredientsOrder - 1; i++) {
				orderIngredients[i] = (GameObject) Instantiate(ingredients[Random.Range(0, ingredients.Length)], topHamburger.GetComponent<Transform>().position + (i+1) * newVec / ((float)numberIngredientsOrder + 1), Quaternion.identity);
				orderIngredients[i].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
			}
			orderIngredients[numberIngredientsOrder - 1] = (GameObject) Instantiate(ingredients[Random.Range(0, ingredients.Length)], topHamburger.GetComponent<Transform>().position + (numberIngredientsOrder) *newVec / ((float)numberIngredientsOrder+1), Quaternion.identity);
			orderIngredients[numberIngredientsOrder - 1].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
		}
	}
}
