using UnityEngine;
using System.Collections;

public class RepeatBackground : MonoBehaviour {

	private BoxCollider2D colliderSuelo;
	private float longitudHorzSuelo;

	void Awake() {
		colliderSuelo = GetComponent<BoxCollider2D>();
	}

	// Use this for initialization
	void Start () {
		longitudHorzSuelo = colliderSuelo.size.x;
	}

	void ReposicionarFondo() {
		transform.Translate (Vector2.right * longitudHorzSuelo * 2);
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < -longitudHorzSuelo) ReposicionarFondo();
	}
}
