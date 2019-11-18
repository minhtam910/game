using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour {

    public GameObject maleZom;
    public GameObject femaleZom;
    private Vector2 screenBounds;
    private float spawnTime = 3.8f;
    private float n;
    // Use this for initialization
    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(zombieWave());
    }
	private void SpawnEnemy(float n)
    {
        if(n >= 1)
        {
            GameObject a = Instantiate(maleZom) as GameObject;
            a.transform.position = new Vector2(-screenBounds.x +2 , Random.Range((float)-3.93, (float)-2.31));
        }
        else
        {
            GameObject a = Instantiate(femaleZom) as GameObject;
            a.transform.position = new Vector2(-screenBounds.x +2 , Random.Range((float)-3.93, (float)-2.31));
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
}
