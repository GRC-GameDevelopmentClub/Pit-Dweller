using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float moveSpeed;
    public float jumpH;
    public float dashSpeed;
    public float startDash;

    [SerializeField]
    private float dashTime;
    private bool isDashing;
    private Rigidbody2D rb;
    [SerializeField]
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
        dashTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashTime = startDash;
        }
        if (dashTime <= 0)
        {
            moveSpeed = 3;
        }
        else
        {
            moveSpeed = 7;
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
