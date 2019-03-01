using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float moveSpeed;
    public float jumpH;
    public float dashSpeed;
    public float startDash;

    private float dashTime;
    private Rigidbody2D rb;
    private bool grounded;

    void Start()
    {
        dashTime = startDash;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update () {
        //MOVEMENT
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        //JUMP
        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            rb.AddForce(new Vector2(0, jumpH), ForceMode2D.Impulse);
        }
        //DASH
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                dashTime = startDash;
                rb.velocity = Vector2.zero;
            }
            Dash();
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

    void Dash()
    {

        Vector3 playerScreenPoint = GetComponentInParent<Transform>().position;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mousePosition.x < playerScreenPoint.x)
        {
            rb.velocity = Vector2.left * dashSpeed;
        }
        else
        {
            rb.velocity = Vector2.right * dashSpeed;
        }
    }
}
