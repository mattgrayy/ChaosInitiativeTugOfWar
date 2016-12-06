using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	[SerializeField] Transform bomb;
	public bool hasBomb, isDead, onGround;
	float deathTimer;
	public SpriteRenderer renderer;
	public BoxCollider2D collider2D;
	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		hasBomb = false;
		isDead = false;
		renderer = GetComponent<SpriteRenderer> ();
		collider2D = GetComponent<BoxCollider2D> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isDead == true) {
			deathTimer += Time.deltaTime;
			if (deathTimer >= 4f) {
				renderer.enabled = true;
				//collider2D.enabled = true;


				isDead = false;
			}
		}

		if (isDead == false) {
			transform.Translate (Vector3.right * Input.GetAxis ("Horizontal_0") / 100);

			if ((Input.GetAxis ("Vertical_0") > 0) && (Input.GetButtonDown ("NES B_0")) && (hasBomb == true)) {
				//Throw bomb
				Transform clone = Instantiate (bomb, transform.position, transform.rotation) as Transform;
				Vector2 Direction = clone.transform.right + (clone.transform.up)*2;
				clone.GetComponent<Rigidbody2D> ().AddForce ((Direction) * 80);
				hasBomb = false;
			} else if ((Input.GetButtonDown ("NES B_0")) && (hasBomb == true)) {
                //place bomb
				Instantiate (bomb, transform.position, bomb.rotation);
				hasBomb = false;
			}
			if (Input.GetButtonDown ("NES A_0")) {
				//nudge

				rb2d.AddForce(Vector2.up * 10f);
			}
		}
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "pickup") {
			hasBomb = true;
		}

		if (col.gameObject.tag == "Explosion") {
			PlayerDeath ();
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Explosion") {
			PlayerDeath ();
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			onGround = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			onGround = false;
		}
	}

	void PlayerDeath()
	{
		isDead = true;
		renderer.enabled = false;
		//collider2D.enabled = false;
		hasBomb = false;
		deathTimer = 0f;
		transform.position = new Vector2 (-0.7f, -0.3f);
	}
}
