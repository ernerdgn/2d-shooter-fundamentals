using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2;
    public float moveSpeed;
    private Vector2 playerPosition;
    public int health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            player.transform.position, moveSpeed * Time.fixedDeltaTime);

        playerPosition = player.transform.position;
        Vector2 lookDir = playerPosition - rb2.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb2.rotation = angle - 90;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}
