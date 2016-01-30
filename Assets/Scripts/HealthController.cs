using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int numberlives;
	GameObject[] lives;
	public GameObject uiLife;

	// Use this for initialization
	void Start () {
		lives = new GameObject[numberlives];
		for (int i = 0; i < numberlives; i++) {
			lives[i] = (GameObject)Instantiate (uiLife, GetComponent<Transform>().transform.position + new Vector3(0f, i * -90f, 0f), Quaternion.identity);
			lives[i].GetComponent<Transform> ().SetParent (GetComponent<Transform> ());
		}
	}
	

	public void LoseLife(){
		Destroy (lives[numberlives-1].gameObject);
		numberlives -= 1;
	}
}
