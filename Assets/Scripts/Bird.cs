using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public float saltoBird = 250f;
	// public GameController gameController; // Referencia al archivo GameController

	private bool EstaMuerto = false;
	private Rigidbody2D cuerpoRig;
	private Animator animacion;

	void Awake() {
		cuerpoRig = GetComponent<Rigidbody2D>();
		animacion = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (EstaMuerto) return; // Si esta muerto

		if (Input.GetMouseButtonDown(0)) { // Se presiona el boton izquierdo del mouse
			// Para detener la velocidad cuando se esta cayendo
			cuerpoRig.velocity = Vector2.zero;
			//cuerpoRig.AddForce(new Vector2(0, saltoBird));
			cuerpoRig.AddForce(Vector2.up * saltoBird);
			animacion.SetTrigger("Flap"); // Flap es la condicion en el animator
		}
	}

	void OnCollisionEnter2D(Collision2D colision) {
		EstaMuerto = true;
		animacion.SetTrigger("Die");
		// gameController.PersonajeMuerto();
		GameController.instancia.PersonajeMuerto();
	}
}
