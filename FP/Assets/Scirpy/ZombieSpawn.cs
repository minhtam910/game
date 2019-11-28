using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour {

    private TowerState other;
    private GameObject tower;
    private int score;
    private int tempScore;
    public GameObject maleZom;
    public GameObject femaleZom;
    private Vector2 screenBounds;
    private float spawnTime;
    private Coroutine coroutine;
    private float n;

    public GameObject chicken;
    public GameObject bacon;
    public GameObject beer;
    public GameObject whiskey;
    private float cooldownItem;
    private bool isCooldown = false;
    // Use this for initialization
    void Start () {
        tower = GameObject.Find("Tower");
        other = tower.GetComponent<TowerState>();
        tempScore = other.getScore();
        spawnTime = 3.8f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        coroutine = StartCoroutine(zombieWave());
        cooldownItem = 12f;
    }
    private void Update()
    {
        if(isCooldown == false && score >=1)
        {
            SpawnItem();
            Invoke("resetCooldown", cooldownItem);
            isCooldown = true;
        }
        
        score = other.getScore();
        if (score == 5 + tempScore)
        {
            comeFaster();
            tempScore = score;
            cooldownItem -= 2.5f;
        }
    }

    void SpawnItem()
    {
        float typeOfItem = Random.Range(0, 3);
        float whichOne = Random.Range(0, 3);
        if (typeOfItem == 1)
        {
            if (whichOne == 1)
            {
                GameObject a = Instantiate(chicken) as GameObject;
                a.transform.position = new Vector2(Random.Range(-7, (float)2.45), (float)-3.35);
            }
            else
            {
                GameObject a = Instantiate(bacon) as GameObject;
                a.transform.position = new Vector2(Random.Range(-7, (float)2.45), (float)-3.35);
            }
        }
        else
        {
            if (whichOne == 1)
            {
                GameObject a = Instantiate(beer) as GameObject;
                a.transform.position = new Vector2(Random.Range(-7, (float)2.45), (float)-3.35);
            }
            else
            {
                GameObject a = Instantiate(whiskey) as GameObject;
                a.transform.position = new Vector2(Random.Range(-7, (float)2.45), (float)-3.35);
            }
        }
    }
    void resetCooldown()
    {
        isCooldown = false;
    }

    private void SpawnEnemy(float n)
    {
        if(n >= 1)
        {
            GameObject a = Instantiate(maleZom) as GameObject;
            a.transform.position = new Vector2(-screenBounds.x -2 , Random.Range((float)-3.93, (float)-2.31));
        }
        else
        {
            GameObject a = Instantiate(femaleZom) as GameObject;
            a.transform.position = new Vector2(-screenBounds.x -2 , Random.Range((float)-3.93, (float)-2.31));
        }
    }
	// Update is called once per frame
	IEnumerator zombieWave()
    {
        while(true)
        {
            n = Random.Range(0, 2);
            yield return new WaitForSeconds(spawnTime);
            SpawnEnemy(n);
        }
    }

    void comeFaster()
    {
        spawnTime = Mathf.Max(0.3f, spawnTime - 0.8f);
        Debug.Log("Spawn time: " + spawnTime);
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(zombieWave());
    }
}
