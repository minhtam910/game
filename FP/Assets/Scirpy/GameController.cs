using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject barQ;
    private CooldownHandler cdQ;
    private GameObject barW;
    private CooldownHandler cdW;
    private GameObject barE;
    private CooldownHandler cdE;
    public GameObject booms;
    
    private float destroyTime;
    private bool cooldownW;
    private bool cooldownQ;
    private bool cooldownE;
    private bool cooldownR;
    private float cooldownBoom;
    
    
    private void Start()
    {
        destroyTime = 1.2f;
        cooldownW = false;
        cooldownQ = false;
        cooldownE = false;
        cooldownR = false;
        cooldownBoom = 3.5f;        
        barQ = GameObject.Find("BarQ");
        cdQ = barQ.GetComponent<CooldownHandler>();
        barW = GameObject.Find("BarW");
        cdW = barW.GetComponent<CooldownHandler>();
        barE = GameObject.Find("BarE");
        cdE = barE.GetComponent<CooldownHandler>();

    }

    void Update ()
    {
        Player1Controller(); 
        //Player2Controller();
    }

    /*void Player2Controller()
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
    }*/

    void Player1Controller()
    {
        if (Input.GetKey("w") && cooldownW == false)
        {
            GameObject a = Instantiate(booms) as GameObject;
            a.transform.position = new Vector2(-1, (float)-3.35);
            Destroy(a, destroyTime);
            Invoke("resetCooldownW", cooldownBoom);
            cooldownW = true;
            Debug.Log("W position completed");
            cdW.isHit(cooldownBoom);
        }

        if (Input.GetKey("q") && cooldownQ == false)
        {
            GameObject a = Instantiate(booms) as GameObject;
            a.transform.position = new Vector2(-6, (float)-3.35);
            Destroy(a, destroyTime);
            Invoke("resetCooldownQ", cooldownBoom);
            cooldownQ = true;
            Debug.Log("Q position completed");
            cdQ.isHit(cooldownBoom);
        }

        if (Input.GetKey("e") && cooldownE == false)
        {
            GameObject a = Instantiate(booms) as GameObject;
            a.transform.position = new Vector2(4, (float)-3.35);
            Destroy(a, destroyTime);
            Invoke("resetCooldownE", cooldownBoom);
            cooldownE = true;
            Debug.Log("E posistion completed");
            cdE.isHit(cooldownBoom);
        }

        if (Input.GetKey("r") && cooldownR == false && (cooldownE == true || cooldownQ == true || cooldownW == true))
        {
            resetCooldownE();
            resetCooldownQ();
            resetCooldownW();
            //Invoke("resetCooldownR", 8f);
            cooldownR = true;
            Debug.Log("Cooldown all booms");
            cdE.cooldownNow();
            cdQ.cooldownNow();
            cdW.cooldownNow();
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

    void resetCooldownR()
    {
        cooldownR = false;
    }


}
