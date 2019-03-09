using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormBehavior : MonoBehaviour {
    public int health = 20;
    public float attackRange;
    public int damage = 3;
    public float attackDelay = 1;

    private float timeElapsedColor;
    private bool isColorChanged;
    private float lastAttack;
    private float speed = 3f;
    private Transform playerTarget;
    // Use this for initialization
    void Start () {
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerTarget != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);
            if (distanceToPlayer < attackRange)
            {
                if (Time.time > lastAttack + attackDelay)
                {
                    playerTarget.SendMessage("TakeDamage", damage);
                    lastAttack = Time.time;
                }
            }
        }

        if (isColorChanged)
        {
            timeElapsedColor += Time.deltaTime;
            if (timeElapsedColor >= .25f)
            {
                timeElapsedColor = 0;
                isColorChanged = false;
                ResetColor();
            }
        }
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTarget.position.x, transform.position.y), speed * Time.deltaTime);
            if (playerTarget.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-2, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(2, transform.localScale.y);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        ChangeColor();
        if (health <= 0) Die();
    }

    private void ChangeColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 0, 0, .7f);
        isColorChanged = true;
    }

    private void ResetColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
