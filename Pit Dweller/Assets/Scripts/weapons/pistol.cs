using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pistol : MonoBehaviour {
    public Transform shootingPoint;
    public Transform bulletTrailPrefab;
    public float fireRate;
    public float reloadTime;
    public Text ammotext;

    private float firecounter;
    private bool justShot;

    void Start()
    {

    }
    // Update is called once per frame
    void Update () {
        ammotext.text = "Ammo: \u221E";

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
