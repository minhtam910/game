using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
    
    private TowerState other;
    private GameObject tower;
    private ZomWalk zomwalk;
    private Animator animator;
    public AudioClip drink;
    public AudioClip eat;
    public AudioClip moan;
    AudioSource audioSource;

    private double minSpeed;
    private double maxSpeed;

    void Start()
    {
        tower = GameObject.Find("Tower");
        other = tower.GetComponent<TowerState>();
        zomwalk = gameObject.GetComponent<ZomWalk>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        minSpeed = Convert.ToDouble(0.03);
        maxSpeed = Convert.ToDouble(0.2);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            double temp = zomwalk.getSpeed() + (float)0.07;
            double newSpeed = Convert.ToDouble(temp);
            zomwalk.setSpeed(Math.Min(newSpeed, maxSpeed));
            Destroy(collision.gameObject, 0.2f);
            audioSource.PlayOneShot(eat);
            //Debug.Log("Full energy");           
        }
        else if (collision.gameObject.tag == "Drink")
        {
            double temp = zomwalk.getSpeed() - (float)0.03;
            double newSpeed = Convert.ToDouble(temp);
            zomwalk.setSpeed(Math.Max(newSpeed,minSpeed));
            Destroy(collision.gameObject,0.2f);
            audioSource.PlayOneShot(drink);
            //Debug.Log("Drunk");
        }
        else if (collision.gameObject.tag == "Boom")
        {
            //Debug.Log("Stepped on boom");
            zomwalk.setSpeed((float)0.01);
            animator.SetInteger("HP", 0);
            audioSource.PlayOneShot(moan);
            Destroy(collision.gameObject, 0.3f);
            other.killZombie();
            if (this.gameObject.tag == "Zombie")
                Destroy(this.gameObject, 0.8f);
            else
                Destroy(this.gameObject, 0.75f);
            
        }    
        else if (collision.gameObject.tag == "Player")
        {
            other.setHP(other.getHP() - 1);
            Destroy(this.gameObject);
            //Debug.Log("HP remain:" + other.getHP());
        } 
    }
}
