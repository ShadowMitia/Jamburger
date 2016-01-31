using UnityEngine;
using System.Collections;

public class KeyAidVisualizer : MonoBehaviour {

	public OrderController orderController;
	public GameController gameController;
	public GameObject upArrow;
	public GameObject cheese;
	public GameObject salade;
	public GameObject steak;
	public GameObject tomatoes;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();

	}

	public void LoadVisualiser(){
		
		for (int i = 0; i < gameController.numKeys; i++) {
			Vector3 newPos = new Vector3 (-2f, i * -1f, 0f);
			Vector3 newPos2 = new Vector3 (0f, i * -1f, 0f);
			GameObject go;
			GameObject gogo;
			if (gameController.keys [i] == "up") {
				go = (GameObject)Instantiate (upArrow, GetComponent<Transform>().position, Quaternion.identity);
				if (orderController.ingredients [i].name == "Cheese") {
					gogo = (GameObject)Instantiate (cheese, GetComponent<Transform> ().position, Quaternion.identity);
				} else if (orderController.ingredients [i].name == "Salade") {
					gogo = (GameObject)Instantiate (salade, GetComponent<Transform> ().position, Quaternion.identity);
				} else if (orderController.ingredients [i].name == "Steak") {
					gogo = (GameObject)Instantiate (steak, GetComponent<Transform> ().position, Quaternion.identity);
				} else {
					gogo = (GameObject)Instantiate (tomatoes, GetComponent<Transform> ().position, Quaternion.identity);
				}
			} else if (gameController.keys [i] == "down") {
				go = (GameObject)Instantiate (upArrow, GetComponent<Transform>().position, Quaternion.Euler (0, 0,180));
				if (orderController.ingredients [i].name == "Cheese") {
					gogo = (GameObject)Instantiate (cheese, GetComponent<Transform> ().position, Quaternion.identity);
				} else if (orderController.ingredients [i].name == "Salade") {
					gogo = (GameObject)Instantiate (salade, GetComponent<Transform> ().position, Quaternion.identity);
				} else if (orderController.ingredients [i].name == "Steak") {
					gogo = (GameObject)Instantiate (steak, GetComponent<Transform> ().position, Quaternion.identity);
				} else {
					gogo = (GameObject)Instantiate (tomatoes, GetComponent<Transform> ().position, Quaternion.identity);
				}
			} else if (gameController.keys[i] == "left"){
				go = (GameObject)Instantiate (upArrow, GetComponent<Transform>().position, Quaternion.Euler (0,0, 90));
				if (orderController.ingredients [i].name == "Cheese") {
					gogo = (GameObject)Instantiate (cheese, GetComponent<Transform> ().position, Quaternion.identity);
				} else if (orderController.ingredients [i].name == "Salade") {
					gogo = (GameObject)Instantiate (salade, GetComponent<Transform> ().position, Quaternion.identity);
				} else if (orderController.ingredients [i].name == "Steak") {
					gogo = (GameObject)Instantiate (steak, GetComponent<Transform> ().position, Quaternion.identity);
				} else {
					gogo = (GameObject)Instantiate (tomatoes, GetComponent<Transform> ().position, Quaternion.identity);
				}
			} else {
				go = (GameObject)Instantiate (upArrow, GetComponent<Transform>().position, Quaternion.Euler (0,0, -90));
				if (orderController.ingredients [i].name == "Cheese") {
					gogo = (GameObject)Instantiate (cheese, GetComponent<Transform> ().position, Quaternion.identity);
				} else if (orderController.ingredients [i].name == "Salade") {
					gogo = (GameObject)Instantiate (salade, GetComponent<Transform> ().position, Quaternion.identity);
				} else if (orderController.ingredients [i].name == "Steak") {
					gogo = (GameObject)Instantiate (steak, GetComponent<Transform> ().position, Quaternion.identity);
				} else {
					gogo = (GameObject)Instantiate (tomatoes, GetComponent<Transform> ().position, Quaternion.identity);
				}
			}
			go.GetComponent<Transform> ().parent = GameObject.Find ("KeyToIngredientVisual").GetComponent<Transform> ();
			go.GetComponent<Transform> ().position += newPos;
			gogo.GetComponent<Transform> ().parent = GameObject.Find ("KeyToIngredientVisual").GetComponent<Transform> ();
			gogo.GetComponent<Transform> ().position += newPos2;
		}
	}
}
