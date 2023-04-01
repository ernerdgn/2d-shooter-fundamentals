using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb2;
    public Camera cam;
    Vector2 movementPos;
    Vector2 mousePos;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        movementPos.x = Input.GetAxisRaw("Horizontal");
        movementPos.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + movementPos * moveSpeed * Time.fixedDeltaTime);
        
        Vector2 lookDir = mousePos - rb2.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb2.rotation = angle;
    }
}
