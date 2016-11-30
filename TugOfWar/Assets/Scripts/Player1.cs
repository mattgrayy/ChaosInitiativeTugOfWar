using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	[SerializeField] Transform bomb;
	bool hasBomb;
	float deathTimer;
	void PlayerDeath();

	// Use this for initialization
	void Start () {
		hasBomb = false;
	
	}
	
	// Update is called once per frame
	void Update () {
      transform.Translate(Vector3.right * Input.GetAxis("Horizontal_0")/10);

		if((Input.GetAxis("Vertical_0")>0)&&(Input.GetButtonDown("NES B_0"))&&(hasBomb==true))
        {
            //Throw bomb
			Transform clone = Instantiate(bomb, transform.position, transform.rotation) as Transform;
			Vector2 Direction = clone.transform.right + clone.transform.up;
			clone.GetComponent<Rigidbody2D> ().AddForce ((Direction) * 400);
			hasBomb = false;
        }
		else if((Input.GetButtonDown("NES B_0"))&&(hasBomb == true))
        {
            //place bomb
			Instantiate(bomb, transform.position, bomb.rotation);
			hasBomb = false;
        }
        if (Input.GetButtonDown("NES A_0"))
        {
            //nudge
            transform.Translate(Vector3.down / 10);
        }
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "pickup") {
			hasBomb = true;
		}
	}

	void PlayerDeath()
	{
		Renderer.enabled = false;
		BoxCollider2D.enabled = false;
		hasBomb = false;
		deathTimer = 0f;
		deathTimer += Time.deltaTime;
		if (deathTimer >= 4f) {
			transform.position = Vector2 (-6.5, -3.5);
			Renderer.enabled = true;
			BoxCollider2D.enabled = true;
		}
	}
}
