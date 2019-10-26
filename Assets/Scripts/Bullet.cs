using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage;
    public GameObject impactEffect;
    

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            
        }

        else
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(20);
            }
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 0.3f);
           
        }
        
    }

}
    
