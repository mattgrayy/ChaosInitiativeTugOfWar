using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{

    public bool StartYN;
    public Image cover;
    private float Timer, blinkTimer;
    public Text StartText;

    public bool On, Off;
    

    

    //spawn points
    private Vector2 Spawn1 = new Vector2(-0.9386668f, -0.5448409f);
    private Vector2 Spawn2 = new Vector2(0.949f, -0.5448409f);
    public bool GameOver;

    //ref to the 2 bombs
    public GameObject elBomb;
    public GameObject elPickUp;



    public GameObject Player1, Player2, Cube;


    //player refs

    //Player 1 score
    public int player1sco = 0;
    //Player2 score
    public int player2sco = 0;
    //score texts 
    public Text Score2Text;
    public Text Score1Text;
    // Use this for initialization


    public AudioSource sound;

    private float timer;



    void Start()
    {

        Timer = 50f;
        blinkTimer = 0;
        On = true;
        Off = false;


        Score1Text.CrossFadeAlpha(0, 0, false);
        Score2Text.CrossFadeAlpha(0, 0, false);

        Score1Text.text = "0";
        Score2Text.text = "0";

        Instantiate(elPickUp, Spawn1, Quaternion.identity);
        Instantiate(elPickUp, Spawn2, Quaternion.identity);

    }



    public void AddScore(int number, int playernumber)
    {

        switch (playernumber)
        {
            case 1:
                player1sco += number;
                break;

            case 2:
                player2sco += number;
                break;
        }

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        { 
            GameOver = true;

        }



        if (GameOver)
        {

            //kill the players

            sound.Play();
            cover.CrossFadeAlpha(1, 1f, false);
            StartText.CrossFadeAlpha(1, 1f, false);

            if (player1sco > player2sco)
            {
                StartText.text = "Player 1 Wins";
            }
            else if (player2sco > player1sco)
            {
                StartText.text = "Player 2 Wins";

            }
            else
            {

                StartText.text = "Draw";

            }


            timer += Time.deltaTime;

            if (timer >= 5f)
            {
                StartYN = false;
                timer = 0f;
                GameOver = false;
            }
        }



        if (!StartYN)
        {

            StartText.text = "Press START";
            Score1Text.CrossFadeAlpha(0, .1f, false);
            Score2Text.CrossFadeAlpha(0, .1f, false);

            blinkTimer += 1 * Time.deltaTime;
            if (blinkTimer >= .5f && On)
            {
                StartText.CrossFadeAlpha(0, 0.1f, false);
                blinkTimer = 0;
                Off = true;
                On = false;
            }

            if (blinkTimer >= .5f  && Off)
            {
                StartText.CrossFadeAlpha(1, 0.1f, false);
                blinkTimer = 0;
                On = true;
                Off = false;
            }

        }
        
        //when start is pressed remove start text
        //if ! startYN
      //  if (Input.GetButtonDown("Start") && !StartYN)
		//arcade mappings
		if (Input.GetButtonDown("Cab_red_P0")||Input.GetButtonDown("Cab_red_P1"))
        {
			if (!StartYN) 
			{
				player1sco = 0;
				player2sco = 0;

				//remove black cover
				cover.CrossFadeAlpha (0, 1f, false);
				StartText.CrossFadeAlpha (0, 1f, false);
				StartYN = true;

				Score1Text.CrossFadeAlpha (1, 1f, false);
				Score2Text.CrossFadeAlpha (1, 1f, false);

				//spawn players
				//activate player and change locations to playerspawn
				Player1.GetComponent<Player1> ().isDead = true;
				Player2.GetComponent<Player2> ().isDead = true;
				Cube.transform.position = new Vector2 (0, -0.414f);
				Player1.transform.position = new Vector2 (-1.1f, -0.3f);
				Player2.transform.position = new Vector2 (1.1f, -0.3f);
			}
        }

       

        //player1sco++;
        Score1Text.text = player1sco.ToString();

        //player2sco += 5;
        Score2Text.text = player2sco.ToString();



    }
}
