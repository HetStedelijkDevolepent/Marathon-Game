﻿using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    int maxHealth = 10;

    int health;


    public static Player instance;

    private void Awake()
    {
        instance = this;
        health = maxHealth;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.3f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Destroy(collision.gameObject);
            health -= 1;
        }
    }

}
