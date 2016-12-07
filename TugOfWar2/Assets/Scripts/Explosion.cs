using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
        if (timer >= 0.3f && GetComponent<Collider2D>().enabled)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        if (timer >= 1f) {
			Destroy (gameObject);
		}

	}
}
