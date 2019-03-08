using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour {
    [SerializeField]
    private float speed = 20f;
    private float lifetime = 0.7f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () { 
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.up * speed;
    }
}
