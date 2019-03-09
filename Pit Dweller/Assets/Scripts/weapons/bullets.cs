using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour {
    public int damage;
    [SerializeField]
    private float speed = 20f;
    private float lifetime = 0.7f;
    private Rigidbody2D rb;

    private Transform targetPlayer;
    // Use this for initialization
    void Start () { 
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        damage = targetPlayer.GetComponent<playerStat>().gunDamage;
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wormBehavior worm = collision.GetComponent<wormBehavior>();

        if (worm != null)
        {
            worm.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
