﻿using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int Health = 1;

    [SerializeField]
    protected float speed;

    SpriteRenderer spriteRenderer;

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);


            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Health -= 1;

        if (Health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(FlashOnHit());
        }
    }

    IEnumerator FlashOnHit()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
