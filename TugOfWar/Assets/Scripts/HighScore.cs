using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
   // [SerializeField]   private
        public Text HighScoreText;
 //   [SerializeField] private
      private  int HighScorein ;
    score SCORE;
    GameObject Player = GameObject.Find("Player2");
    // Use this for initialization


    void Start () {
        DontDestroyOnLoad(gameObject);
        HighScorein = SCORE.Score;
      
    }
	
	// Update is called once per frame
	void Update () {
        
        HighScoreText.text = HighScorein.ToString();
    }
}
