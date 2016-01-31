using UnityEngine;
using System.Collections;

public class TempoEndZoneController : MonoBehaviour {

	public GameController gameController;

	public TempoIngredientController tempoIController;

	public HealthController healthController;

	public void TapTempo(){
		for (int i = 0; i < gameController.numIngredientsOrder; i++) {
			if (tempoIController.tempoIngredients [i] != null) {
				float objectPos = tempoIController.tempoIngredients [i].transform.position.x;
				if (objectPos < GetComponent<Transform> ().transform.position.x) {
					Destroy (tempoIController.tempoIngredients [i]);
				} else {
					healthController.LoseLife ();

					gameController.StartCoroutine ("Fail");
				}
			}
		}
	}
}
