using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	float timer;
	[SerializeField] Transform explosion;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 3f) {
			Instantiate (explosion, transform.position, explosion.rotation);
			Destroy (gameObject);

		}
	}
}
