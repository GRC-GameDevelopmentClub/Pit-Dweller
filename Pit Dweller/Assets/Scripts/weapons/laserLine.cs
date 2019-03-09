using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserLine : MonoBehaviour {
    public int damage;


    private Transform targetPlayer;
    // Use this for initialization
    void Start () {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        damage = targetPlayer.GetComponent<playerStat>().gunDamage;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wormBehavior worm = collision.GetComponent<wormBehavior>();
        spiderBehavior spider = collision.GetComponent<spiderBehavior>();

        if (worm != null)
        {
            worm.TakeDamage(damage);
        }

        if (spider != null) 
        {
            spider.TakeDamage(damage);
        }
    }
}
