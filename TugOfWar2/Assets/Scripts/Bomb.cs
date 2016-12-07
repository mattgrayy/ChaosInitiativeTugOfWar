using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	float timer;
	[SerializeField] Transform explosion;
    public GameObject pickup;
    public Vector2 spawn;
    public bool dontEx;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
        dontEx = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 3f) {
            if (!dontEx)
            {
                Instantiate(explosion, transform.position, explosion.rotation);
            }
            Instantiate(pickup, spawn, Quaternion.identity);
            Destroy (gameObject);

		}
	}
}
