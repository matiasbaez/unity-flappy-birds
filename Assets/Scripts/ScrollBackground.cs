using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

	private Rigidbody2D cuerpoRig;

	void Awake() {
		cuerpoRig = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		cuerpoRig.velocity = Vector2.right * GameController.instancia.scrollSpeed;
	}

	// Update is called once per frame
	void Update () {
		if (GameController.instancia.gameOver) {
			cuerpoRig.velocity = Vector2.zero;
		}
	}
}
