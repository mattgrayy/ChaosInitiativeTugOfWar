﻿using UnityEngine;
using System.Collections;

public class winTrigger : MonoBehaviour {

    public LevelManager lvlMan;
    public bool right;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Block")
        {
            if (right)
            {
                lvlMan.AddScore(500,1);
            }
            else
            {
                lvlMan.AddScore(500, 2);
            }
            lvlMan.GameOver = true;
        }
    }
}
