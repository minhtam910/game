using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerState : MonoBehaviour {

    public static int max = 5;
    private int warningHP = max / 2;
    private int goingToLoseHP = max / 4;
    private int HP = max;
    public Sprite maybeOk;
    public Sprite notSoOk;
    public void setHP(int n)
    {
        this.HP = n;
    }

    public int getHP()
    {
        return this.HP;
    }

    public void setSprite(Sprite s)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = s;
    }

    public void setTransformY(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HP >= 0)
        {
            if (HP == warningHP)
                this.setSprite(maybeOk);
            else if(HP == goingToLoseHP)
            {
                this.setSprite(notSoOk);
                this.setTransformY((float)-2.14);
            }
                
        }
	}
}
