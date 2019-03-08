using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineGun : MonoBehaviour {
    public Transform shootingPoint;
    public Transform bulletTrailPrefab;
    public float fireRate = 0.2f;
    public int ammoCapcity = 20;
    public int currentAmmo = 20;
    public float reloadTime;

    private float firecounter;
    private bool justShot;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            if (!justShot)
            {
                Shoot();
                justShot = true;
            }
        }

        if (justShot)
        {
            firecounter += Time.deltaTime;
            if (firecounter >= fireRate)
            {
                firecounter = 0f;
                justShot = false;
            }
        }
    }
    void Shoot()
    {
        Instantiate(bulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
