using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {
    //[SerializeField] private
    public  int Score = 0;
    public Text ScoreText;
   public CameraShake CS;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown("space"))
        {
            Score++;
            ScoreText.text = Score.ToString();
            PlayerPrefs.SetInt("High Score", Score);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CS.ShakeCamera(0.1f,0.1f);
         //Application.LoadLevel(1);

        }

        }
}
