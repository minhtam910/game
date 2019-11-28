using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomWalk : MonoBehaviour {
    public double speed;
	// Use this for initialization
	public double getSpeed()
    {
        return speed;
    }
	public void setSpeed(double n)
    {
        this.speed = n;
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(0.45f * (float)speed, 0, 0);
	}
}
