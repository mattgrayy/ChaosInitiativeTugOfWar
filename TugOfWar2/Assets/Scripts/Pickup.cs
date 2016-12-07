using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    float spawnTimer = 3f;
    bool spawned = false;

	// Use this for initialization
	void Start ()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else if (!spawned)
        {
            spawn();
            spawned = true;
        }
	}

    void spawn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Destroy (gameObject);

		}
	}
}
