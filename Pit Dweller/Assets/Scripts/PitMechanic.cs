using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitMechanic : MonoBehaviour {
    [SerializeField]
    private Transform pitWater;
    [SerializeField]
    private Vector3 posA;
    [SerializeField]
    private Vector3 posB;
    [SerializeField]
    private Vector3 nextPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform transformB;

    void Start()
    {
        posA = pitWater.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;    
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        pitWater.localPosition = Vector3.MoveTowards(pitWater.localPosition,nextPos,speed*Time.deltaTime);
    }
}
