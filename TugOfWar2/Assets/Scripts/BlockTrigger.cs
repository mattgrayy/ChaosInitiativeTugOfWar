using UnityEngine;
using System.Collections;

public class BlockTrigger : MonoBehaviour {

    public Transform block;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = block.position;
	}
}
