using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb2;
    public int damage;
    public GameObject bloodEffect;
    public GameObject wallEffect;
    private void FixedUpdate()
    {
        rb2.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "duvar")
        {
            GameObject effect = Instantiate(wallEffect, transform.position, transform.rotation);
            Destroy(effect, 0.41f);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "enemy")
        {
            GameObject effect = Instantiate(bloodEffect, transform.position, transform.rotation);
            Destroy(effect, 0.25f);
            collision.gameObject.GetComponent<enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
