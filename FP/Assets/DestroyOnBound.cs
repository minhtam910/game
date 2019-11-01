using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBound : MonoBehaviour {

    private Vector2 destroyBound;
	// Use this for initialization
	void Start () {
        destroyBound = new Vector2((float)5, (float) -1.06);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > destroyBound.x + 0.01)
        {
            Destroy(this.gameObject);
        }
	}
}
