using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {


	[SerializeField] Transform bomb, squash, dud;
    public BlockMove block;
	public bool hasBomb, isDead, onGround, nudging;
	float deathTimer;
	public SpriteRenderer renderer, bombRenderer;
	public Rigidbody2D rb2d;

    public LevelManager lvlMan;

    public AudioSource sound;
    

    // Use this for initialization
    void Start() 
	{
        nudging = false;
		hasBomb = false;
		isDead = false;
		renderer = GetComponent<SpriteRenderer>();
		rb2d = GetComponent<Rigidbody2D>();
        deathTimer = 0F;
	}
	
	// Update is called once per frame
	void Update() 
	{

		if (isDead == true)
		{
			deathTimer += Time.deltaTime;
			if (deathTimer >= 4f)
			{
				renderer.enabled = true;
                if (hasBomb)
                {
                    bombRenderer.enabled = true;

                }
                //collider2D.enabled = true;


                isDead = false;
			}
		}

		if (isDead == false)
		{
			transform.Translate(Vector3.right * Input.GetAxis ("Horizontal_0") / 100);

            //if ((Input.GetAxis("Vertical_0") > 0) && (Input.GetButtonDown ("NES B_0")) && (hasBomb == true))
        
            //arcade booth mapping
            if ((Input.GetAxis("Vertical_0") > 0) && (Input.GetButtonDown("Cab_red_P0")) && (hasBomb == true))
			{
                //Throw bomb
                bombRenderer.enabled = false;
                Transform clone = Instantiate (bomb, transform.position, transform.rotation) as Transform;
				Vector2 Direction = clone.transform.right + (clone.transform.up)*2;
				clone.GetComponent<Rigidbody2D> ().AddForce ((Direction) * 80);
				hasBomb = false;
			} 
			//else if ((Input.GetButtonDown("NES B_0")) && (hasBomb == true))
				//arcade booth mapping
			else if (Input.GetButtonDown("Cab_red_P0") && (hasBomb == true))
			{
                //place bomb
                bombRenderer.enabled = false;
                Instantiate (bomb, transform.position, bomb.rotation);
				hasBomb = false;
			}
			//if (Input.GetButtonDown("NES A_0"))
				//arcade booth mapping
			if (Input.GetButtonDown("Cab_white_P0"))
			{
                //nudge

                if (nudging)
                {
                    block.nudgeRight();
                    lvlMan.AddScore(1, 1);
                }
                else if(onGround)
                {
                    rb2d.AddForce(Vector2.up * 10f);
                    onGround = false;
                }
            }
		}
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "pickup")
		{
            sound.Play();
			hasBomb = true;
            
            if (!isDead)
            {
                bombRenderer.enabled = true;
            }
        }

		if (col.gameObject.tag == "Explosion")
		{
			PlayerDeath();
		}

        if (col.gameObject.tag == "Nudge_Area")
        {
            nudging = true;
        }
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Explosion")
		{
			PlayerDeath();
		}
	}
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Nudge_Area")
        {
            nudging = false;
        }
    }

    void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			onGround = true;
		}
        if (col.gameObject.tag == "Block" && (col.transform.GetComponent<BlockMove>().rotating))
        {
            Instantiate(squash, transform.position, transform.rotation);
            PlayerDeath();
        }
    }

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			onGround = false;
		}
	}

	void PlayerDeath()
	{

        if (hasBomb)
        {
            GameObject a = Instantiate(dud, new Vector2(100, 100), dud.rotation) as GameObject;
        }

    

        lvlMan.AddScore(5, 2);
        isDead = true;
		renderer.enabled = false;
        bombRenderer.enabled = false;
        hasBomb = false;
		deathTimer = 0f;
		transform.position = new Vector2 (-1.1f, -0.3f);
	}
}
