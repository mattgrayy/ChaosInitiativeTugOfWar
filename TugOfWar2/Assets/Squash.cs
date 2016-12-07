﻿using UnityEngine;
using System.Collections;

public class Squash : MonoBehaviour
{

    float timer;
    // Use this for initialization
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 0.8f)
        {
            Destroy(gameObject);
        }

    }
}