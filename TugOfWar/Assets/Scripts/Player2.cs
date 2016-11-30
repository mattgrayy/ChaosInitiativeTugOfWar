using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal_1") / 10);

        if ((Input.GetAxis("Vertical_1") > 0) && (Input.GetButtonDown("NES B_1")))
        {
            //Throw bomb
            transform.Translate(Vector3.right / 10);
        }
        else if (Input.GetButtonDown("NES B_1"))
        {
            //place bomb
            transform.Translate(Vector3.up / 10);
        }
        if (Input.GetButtonDown("NES A_1"))
        {
            //nudge
            transform.Translate(Vector3.down / 10);
        }
    }
}
