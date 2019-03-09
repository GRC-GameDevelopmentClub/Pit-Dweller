using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class machineGun : MonoBehaviour {
    public Transform shootingPoint, muzzleflashpoint;
    public Transform bulletTrailPrefab, muzzleFlashPrefab;
    public float fireRate = 0.2f;
    public AudioSource shootingSound;

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
        Transform clone = Instantiate(muzzleFlashPrefab, muzzleflashpoint.position, muzzleflashpoint.rotation);
        clone.parent = shootingPoint;
        float size = Random.Range(0.4f, 0.6f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.09f);
        Instantiate(bulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
        GetComponentInParent<playerStat>().currentMAmmo--;
        PlaySound(shootingSound);
    }

    void PlaySound(AudioSource sound)
    {
        sound.volume = Random.Range(0.3f, 0.5f);
        sound.pitch = Random.Range(1.5f, 2f);
        sound.Play();
    }
}
