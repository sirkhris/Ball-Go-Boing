using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameObject hitEffect;

    public int health = 3;
    public float startHitStun = 0.6f;

    public float speed = 5;

    private float hitStun;

    //private Animator anim;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
    }

    private void Update()
    {
        if (hitStun <= 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            hitStun -= Time.deltaTime;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        hitStun = startHitStun;
        //play a hurt sound
        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage taken");
    }
}
