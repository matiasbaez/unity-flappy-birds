using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Se define como estatica para "decir" que no pertenece a este componente en concreto si no que pertenece a la clase
	// (No se necesita una instancia de este objeto en otro script para poder usarlo)
	public static GameController instancia;

	public GameObject gameOverText; // Referencia al objeto
	public bool gameOver;
	public float scrollSpeed = -1.5f;
	public Text txtPuntos;

	private int puntos;

	// Use this for initialization
	void Awake () {
		/* Se hace la instancia de si mismo y se guarda en la variable instancia para poder ser usado desde cualquier otro
		script */
		if (GameController.instancia == null) { // Si no tiene ninguna referencia
			GameController.instancia = this; // Se guarda la referencia en la variable
		} else if (GameController.instancia != this) { // Si ya estaba asignada
			Destroy(gameObject); // Se destruye
			Debug.LogWarning("GameController ha sido instanciado por segunda vez, esto no deberia de pasar");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver && Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name); // El nombre de la escena activa
		}
	}

	public void PuntosBird() {
		if (gameOver) return;

		puntos++;
		txtPuntos.text = "PUNTOS: " + puntos;
	}

	public void PersonajeMuerto() {
		gameOverText.SetActive(true);
		gameOver = true;
	}

	private void OnDestroy() {
		// Si el objeto que va a ser destruido tiene una instancia a si misma se vacia esa instancia
		if (GameController.instancia == this) {
			GameController.instancia = null;
		}
	}
}
