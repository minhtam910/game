using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject booms;
    public GameObject chicken;
    public GameObject bacon;
    public GameObject beer;
    public GameObject whiskey;
    private float destroyTime;
    private bool cooldownW;
    private bool cooldownQ;
    private bool cooldownE;
    private bool cooldown1;
    private bool cooldown2;
    private float cooldownBoom;
    private float cooldownItem;
    
    private void Start()
    {
        destroyTime = 0.5f;
        cooldownW = false;
        cooldownQ = false;
        cooldownE = false;
        cooldown1 = false;
        cooldown2 = false;
        cooldownBoom = 2f;
        cooldownItem = 2.5f;
    }

    void Update ()
    {
        Player1Controller();
        Player2Controller();
    }

    void Player2Controller()
    {
        float n = Random.Range(0, 5);
        if (Input.GetKey("o") && cooldown1 == false)
        {
            if (n >= 3)
            {
                GameObject a = Instantiate(chicken) as GameObject;
                a.transform.position = new Vector2(Random.Range(-7,(float)2.45), (float)-3.35);
                Invoke("resetCooldown1", cooldownItem);
                cooldown1 = true;
            }
            else
            {
                GameObject a = Instantiate(bacon) as GameObject;
                a.transform.position = new Vector2(Random.Range(-7, (float)2.45), (float)-3.35);
                Invoke("resetCooldown1", cooldownItem);
                cooldown1 = true;
            }
        }

        if (Input.GetKey("p") && cooldown2 == false)
        {
            if (n >= 3)
            {
                GameObject a = Instantiate(beer) as GameObject;
                a.transform.position = new Vector2(Random.Range(-7, (float)2.45), (float)-3.35);
                Invoke("resetCooldown2", cooldownItem);
                cooldown2 = true;
            }
            else
            {
                GameObject a = Instantiate(whiskey) as GameObject;
                a.transform.position = new Vector2(Random.Range(-7, (float)2.45), (float)-3.35);
                Invoke("resetCooldown2", cooldownItem);
                cooldown2 = true;
            }
        }
    }

    void Player1Controller()
    {
        if (Input.GetKey("w") && cooldownW == false)
        {
            GameObject a = Instantiate(booms) as GameObject;
            a.transform.position = new Vector2(-1, (float)-3.35);
            Destroy(a, destroyTime);
            Invoke("resetCooldownW", cooldownBoom);
            cooldownW = true;
        }

        if (Input.GetKey("q") && cooldownQ == false)
        {
            GameObject a = Instantiate(booms) as GameObject;
            a.transform.position = new Vector2(-6, (float)-3.35);
            Destroy(a, destroyTime);
            Invoke("resetCooldownQ", cooldownBoom);
            cooldownQ = true;
        }

        if (Input.GetKey("e") && cooldownE == false)
        {
            GameObject a = Instantiate(booms) as GameObject;
            a.transform.position = new Vector2(4, (float)-3.35);
            Destroy(a, destroyTime);
            Invoke("resetCooldownE", cooldownBoom);
            cooldownE = true;
        }
    }

    void resetCooldownW()
    {
        cooldownW = false;
    }

    void resetCooldownQ()
    {
        cooldownQ = false;
    }

    void resetCooldownE()
    {
        cooldownE = false;
    }

    void resetCooldown1()
    {
        cooldown1 = false;
    }

    void resetCooldown2()
    {
        cooldown2 = false;
    }
}
