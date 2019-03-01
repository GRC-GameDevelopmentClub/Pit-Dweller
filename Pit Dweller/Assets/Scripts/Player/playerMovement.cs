using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float moveSpeed;
    public float jumpH;

    private Rigidbody2D rb;
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update () {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            rb.AddForce(new Vector2(0, jumpH), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
