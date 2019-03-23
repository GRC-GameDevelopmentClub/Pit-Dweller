using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunToMouse : MonoBehaviour {
    [SerializeField]
    private Transform leftHand;
    [SerializeField]
    private Transform rightHand;
    [SerializeField]
    private Transform player;

    void Update()
    {
        Vector3 playerScreenPoint = GetComponentInParent<Transform>().position;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

        transform.up = direction;

        if (mousePosition.x < leftHand.position.x)
        {
            player.localScale = new Vector2(-2, 2);
            transform.position = rightHand.position;
        }
        else if (mousePosition.x == playerScreenPoint.x)
        {
            //transform.position = leftHand.position;
        }
        else
        {
            player.localScale = new Vector2(2, 2);
            transform.position = rightHand.position;
        }

    }
}
