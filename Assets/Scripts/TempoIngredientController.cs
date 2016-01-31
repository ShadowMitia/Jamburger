using UnityEngine;
using System.Collections;

public class TempoIngredientController : MonoBehaviour {

	public GameController gameController;

	public GameObject tempoPrefab;
	public GameObject tempoIngredientStart;
	[HideInInspector]
	public GameObject[] tempoIngredients;
	public OrderController orderController;
	public int speed;

	private int numIngredients;


	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();

		//Generate ();

	}
		
	
	// Update is called once per frame
	void Update () {
		if (!orderController.finishedOrdering || gameController.levelDelayed) {
			tempoIngredientStart.GetComponent<AudioSource> ().Stop ();
			return;
		}
		StartCoroutine ("PlayTick", 1f);

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
			Vector3 newPosition = tempoIngredientStart.transform.position + new Vector3 (i * ((speed * gameController.levelTotalTime) / numIngredients), 0f, 0f);
			tempoIngredients[i] = (GameObject) Instantiate (tempoPrefab, newPosition, Quaternion.identity);
			tempoIngredients[i].GetComponent<Transform>().SetParent (GetComponent<Transform>());
			tempoIngredients[i].GetComponent<SpriteRenderer> ().sortingOrder = numIngredients - i;
		}
	}


	IEnumerator PlayTick(float delay){
		while (true) {
			//Debug.Log (tempoIngredientStart.GetComponent<AudioSource> ().time);
			//tempoIngredientStart.GetComponent<AudioSource> ().time = 0;
			tempoIngredientStart.GetComponent<AudioSource> ().Play();

			yield return new WaitForSeconds (delay + tempoIngredientStart.GetComponent<AudioSource> ().clip.length);
		}
	}
}
