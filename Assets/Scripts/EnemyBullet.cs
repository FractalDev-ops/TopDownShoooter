using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ennemy")
        {

        }

        else
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(20);
                GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(effect, 0.3f);
            }
            

        }
    }
}
