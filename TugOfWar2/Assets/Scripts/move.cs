using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public bool pressedX, pressedY;


    
	// Use this for initialization
	void Start () {
        pressedX = false;
        pressedY = false;
	}
	

	// Update is called once per frame
	void Update () {

        /*
        NES controls
        NES B
        NES A
        start
        select


        SNES controls
        SNES A
        SNES X
        SNES B
        SNES Y
        start
        select
        Left bumper
        Right bumper




        note: D-pad is the same for both
        

        smooth movment:
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.up * Input.GetAxis("Vertical"));




        step movment:
        if ((Input.GetAxis("Vertical") != 0f) && (pressedY == false))
        {
            pressedY = true;
            transform.Translate(Vector3.up * Input.GetAxis("Vertical"));
        }

        if ((Input.GetAxis("Vertical") == 0f) && (pressedY == true))
        {
            pressedY = false;
        }



        if ((Input.GetAxis("Horizontal") != 0f) && (pressedX == false))
        {
            pressedX = true;
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal"));
        }

        if ((Input.GetAxis("Horizontal") == 0f) && (pressedX == true))
        {
            pressedX = false;
        }

        note: to get continuous step while button down use a timer instead of the bool

        */



        if ((Input.GetButtonDown("SNES A_0")))
            {

            transform.Translate(Vector3.up);

        }
        


        if ((Input.GetAxis("Horizontal_0") != 0f) && (pressedX == false))
        {
            pressedX = true;
            transform.Rotate(new Vector3(0, 0, -20f) * Input.GetAxis("Horizontal_0"));
        }
  
        if ((Input.GetAxis("Horizontal_0") == 0f) && (pressedX == true))
        {
            pressedX = false;
        }

    }
}
