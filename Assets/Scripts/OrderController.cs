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

	public bool finishedOrdering;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	public void GenerateOrder() { //66
		finishedOrdering = false;
		foreach (var item in orderIngredients) {
			Destroy (item);
		}
		numberIngredientsOrder = gameController.numIngredientsOrder;
		orderIngredients = new GameObject[numberIngredientsOrder];


		// MEGA GENERATOR
		Vector3 newVec = new Vector3(0f, -(topHamburger.GetComponent<Transform>().position.y - bottomHamburger.GetComponent<Transform>().position.y), 0f);
		if (gameController.numIngredientsOrder == 1) {
			orderIngredients [0] = (GameObject)Instantiate (ingredients [Random.Range (0, ingredients.Length)], topHamburger.GetComponent<Transform> ().position + newVec / 2f, Quaternion.identity);
			orderIngredients[0].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
			orderIngredients [0].SetActive (false);
		} else if (gameController.numIngredientsOrder == 2) {
			orderIngredients [0] = (GameObject)Instantiate (ingredients [Random.Range (0, ingredients.Length / 2)], topHamburger.GetComponent<Transform> ().position + newVec / 3f, Quaternion.identity);
			orderIngredients[0].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
			orderIngredients [0].SetActive (false);
			orderIngredients [1] = (GameObject)Instantiate (ingredients [Random.Range ((ingredients.Length / 2) + 1, ingredients.Length)], topHamburger.GetComponent<Transform> ().position + 2 * newVec / 3f, Quaternion.identity);
			orderIngredients[1].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
			orderIngredients [1].SetActive (false);
		} else {
			for (int i = 0; i < numberIngredientsOrder - 1; i++) {
				orderIngredients[i] = (GameObject) Instantiate(ingredients[Random.Range(0, ingredients.Length)], topHamburger.GetComponent<Transform>().position + (i+1) * newVec / ((float)numberIngredientsOrder + 1), Quaternion.identity);
				orderIngredients[i].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
				orderIngredients [i].SetActive (false);
			}
			orderIngredients[numberIngredientsOrder - 1] = (GameObject) Instantiate(ingredients[Random.Range(0, ingredients.Length)], topHamburger.GetComponent<Transform>().position + (numberIngredientsOrder) *newVec / ((float)numberIngredientsOrder+1), Quaternion.identity);
			orderIngredients[numberIngredientsOrder - 1].GetComponent<Transform> ().SetParent (topHamburger.GetComponent<Transform>());
			orderIngredients[numberIngredientsOrder - 1].SetActive (false);
		}


		// DALEK: EXPLLAAIIIIIINNNNNNNN
		StartCoroutine ("CustomerOrder");
	}

		IEnumerator CustomerOrder(){
		
			for (int i = 0; i < orderIngredients.Length; i++) {
				GameObject.Find ("Customer").GetComponent<SpriteRenderer> ().sortingLayerName = "Default";
				GameObject.Find ("CustomerTalk1").GetComponent<SpriteRenderer> ().sortingLayerName = "Client";
				orderIngredients [i].SetActive (true);
				orderIngredients [i].GetComponent<AudioSource> ().Play ();
				yield return new WaitForSeconds (0.2f);
				GameObject.Find ("CustomerTalk1").GetComponent<SpriteRenderer> ().sortingLayerName = "Default";
				GameObject.Find ("CustomerTalk2").GetComponent<SpriteRenderer> ().sortingLayerName = "Client";
				yield return new WaitForSeconds (0.2f);
				GameObject.Find ("CustomerTalk2").GetComponent<SpriteRenderer> ().sortingLayerName = "Default";
				GameObject.Find ("Customer").GetComponent<SpriteRenderer> ().sortingLayerName = "Client";
				yield return new WaitForSeconds(0.5f);
			}
		finishedOrdering = true;
			yield return null;
		}


}
