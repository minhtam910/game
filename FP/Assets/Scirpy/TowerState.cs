using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TowerState : MonoBehaviour {
    private Highscore highscore;
    private GameObject canvas;
    private static int score = 0;
    public static int max = 5;
    public Text scoreText;
    public Text hpText;
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
        canvas = GameObject.Find("CanvasScore");
        highscore = canvas.GetComponent<Highscore>();
        
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
        hpText.text = "Hit remain: " + HP;
		if (HP >= 0)
        {
            if (HP == warningHP)
                this.setSprite(maybeOk);
            else if(HP == goingToLoseHP)
            {
                this.setSprite(notSoOk);
                this.setTransformY((float)-2.14);
            }

            if (HP == 0)
            {
                highscore.addHighscoreEntry(score, System.DateTime.Now.ToString());
                SceneManager.LoadScene("Highscore");
            }     
        }
	}
    public void killZombie()
    {
        score += 1;
        Debug.Log("Score:" + score);
    }
    public int getScore()
    {
        return score;
    }
}
