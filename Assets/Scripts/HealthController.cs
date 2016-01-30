using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthController : MonoBehaviour {

	GameController gameController;

	public int numberlives;
	GameObject[] lives;
	public GameObject uiLife;

	public Material mat;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		numberlives = gameController.playerLives;
		lives = new GameObject[numberlives];
		for (int i = 0; i < numberlives; i++) {
			lives[i] = (GameObject)Instantiate (uiLife, GetComponent<Transform>().transform.position + new Vector3(0f, i * -90f, 0f), Quaternion.identity);
			lives[i].GetComponent<Transform> ().SetParent (GetComponent<Transform> ());
		}
	}
	

	public void LoseLife(){

		//Destroy (lives [numberlives - 1].gameObject);
		lives[numberlives - 1].gameObject.GetComponent<Image>().material = null;
		numberlives -= 1;
		if (numberlives == 0) {
			Debug.Log("GAME OVER");	
		}
	}
}
