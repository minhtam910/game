using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomWalk : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0.45f * speed, 0, 0);
	}
}
