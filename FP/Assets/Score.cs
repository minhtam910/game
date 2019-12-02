using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int score;
    private bool isDone;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public Score()
    {
        score = -1;
        isDone = false;
    }


    public void setScore(int n)
    {
        score = n;
    }

    public int getScore()
    {
        return score;
    }

    public void setDone(bool isdone)
    {
        isDone = isdone;
    }

    public bool getDone()
    {
        return isDone;
    }
}
