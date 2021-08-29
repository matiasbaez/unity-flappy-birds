using UnityEngine;
using System.Collections;

public class Colums : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D colision) {
		// Cuando atraviese la columna se ejecuta la funcion que aumenta el puntaje
		if (colision.CompareTag("Player")) {
			GameController.instancia.PuntosBird ();
		}
	}
}
