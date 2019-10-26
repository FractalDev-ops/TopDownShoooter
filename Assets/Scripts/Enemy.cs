using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 60;
    public GameObject deathEffect;
    public float enemySpeed;
    public float timeBetweenAttack;
    public int damage;

    [HideInInspector]
    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
