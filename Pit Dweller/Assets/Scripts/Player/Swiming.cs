using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiming : MonoBehaviour {

    public Animator player;

    //CHECK WATER TRIGGER
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("TOUCHIE");
            player.SetBool("isSwiming", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.SetBool("isSwiming", false);
        }
    }
}
