using UnityEngine;
using System.Collections;

public class Dud_Bomb : MonoBehaviour {
	float timer;

	public GameObject pickup;
	public Vector2 spawn;


	// Use this for initialization
	void Start () {
		timer = 0.0f;

	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 3f) {
			
			Instantiate(pickup, spawn, Quaternion.identity);
			Destroy (gameObject);

		}
	}
}
