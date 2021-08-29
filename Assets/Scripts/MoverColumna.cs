using UnityEngine;
using System.Collections;

public class MoverColumna : MonoBehaviour {

	public int cantidadColumnas = 5;
	public GameObject PreFabColumna; // Referencia al objeto (en este caso la columna)
	public float tiempoNuevaColumna = 4f;

	public float minColumna = -2.9f;
	public float maxColumna = 1.4f;
	private float posColumnaX = 10;

	private GameObject[] columnas;
	private Vector2 posicionColumna = new Vector2(-14, 0);
	private float tiempoUltimaColumna;
	private int columnaActual;

	// Use this for initialization
	void Start () {
		columnas = new GameObject[cantidadColumnas];

		// Se instancia un nuevo objeto de acuerdo a la cantidad de Columnas que se requiera
		for (int i = 0; i < cantidadColumnas; i++) {
			columnas[i] = Instantiate(PreFabColumna, posicionColumna, Quaternion.identity) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// El tiempo que ha pasado
		tiempoUltimaColumna += Time.deltaTime;

		// Si todavia no ha perdido y el tiempo que ha pasado es >= al que se debe esperar para mover la columna
		if (!GameController.instancia.gameOver && tiempoUltimaColumna >= tiempoNuevaColumna) {
			tiempoUltimaColumna = 0;

			// Se genera un numero aleatorio para la posicion Y de las columnas
			float rndPosicionY = Random.Range(minColumna, maxColumna);

			// Se mueve las columnas de posicion
			columnas[columnaActual].transform.position = new Vector2(posColumnaX, rndPosicionY);
			columnaActual++;

			if (columnaActual >= cantidadColumnas) {
				columnaActual = 0;
			}
		}
	}
}
