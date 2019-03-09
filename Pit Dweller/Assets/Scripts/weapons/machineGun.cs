using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class machineGun : MonoBehaviour {
    public Transform shootingPoint;
    public Transform bulletTrailPrefab;
    public float fireRate = 0.2f;

    public float reloadTime;
    public Text ammotext;
    private float firecounter;
    private bool justShot;

    void Start()
    {
        GetComponentInParent<playerStat>().currentMAmmo = GetComponentInParent<playerStat>().ammoMCapcity;
    }
    // Update is called once per frame
    void Update()
    {
        ammotext.text = "Ammo: " + GetComponentInParent<playerStat>().currentMAmmo + "/" + GetComponentInParent<playerStat>().ammoMCapcity;
        if (Input.GetButton("Fire1"))
        {
            if (!justShot && GetComponentInParent<playerStat>().currentMAmmo > 0)
            {
                Shoot();
                justShot = true;
                GetComponentInParent<playerStat>().TimeShotCounter = 0;
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
        GetComponentInParent<playerStat>().currentMAmmo--;
    }
}
