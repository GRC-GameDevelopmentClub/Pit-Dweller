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
    [SerializeField]
    private ParticleSystem rain;
    [SerializeField]
    private Transform cloudRain;
    private bool isRaining;
    [SerializeField]
    private float rainCountdown;
    [SerializeField]
    private float rainDurationAmount;
    [SerializeField]
    private float rainDuration;

    public GameObject rainingText;

    void Start()
    {
        posA = pitWater.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;    
    }

    void Update()
    {
        if (rainDuration <= 0)
        {
            cloudRain.gameObject.SetActive(false);
            rain.Stop();
            isRaining = false;
            rainingText.SetActive(false);
            rainCountdown -= Time.deltaTime;
            if (rainCountdown <= 0)
            {
                rainDuration = rainDurationAmount;
                rainDurationAmount += 10;
                if (nextPos == posA) ChangePos();
            }
        }
        else
        {
            cloudRain.gameObject.SetActive(true);
            rainDuration -= Time.deltaTime;
            isRaining = true;
            rainingText.SetActive(true);
            rain.Play();
            if (rainDuration <= 0)
            {
                rainCountdown = 30;
                ChangePos();
            }
        }

        if (!isRaining && nextPos == posA)
        {
            Move();
        }

        if (isRaining)
        {
            Move();
        }
    }

    private void Move()
    {
        pitWater.localPosition = Vector3.MoveTowards(pitWater.localPosition,nextPos,speed*Time.deltaTime);
    }

    private void ChangePos()
    {
        nextPos = nextPos != posA ? posA : posB;
    }

}
