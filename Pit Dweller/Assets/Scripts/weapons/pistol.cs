using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pistol : MonoBehaviour {
    public Transform shootingPoint, muzzleflashpoint;
    public Transform bulletTrailPrefab, muzzleFlashPrefab;
    public float fireRate;
    public float reloadTime;
    public Text ammotext;
    public AudioSource shootingSound;

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
        Transform clone = Instantiate(muzzleFlashPrefab, muzzleflashpoint.position, muzzleflashpoint.rotation);
        clone.parent = shootingPoint;
        float size = Random.Range(0.4f, 0.6f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.09f);
        Instantiate(bulletTrailPrefab, shootingPoint.position, shootingPoint.rotation);
        PlaySound(shootingSound);
    }

    void PlaySound(AudioSource sound)
    {
        sound.volume = Random.Range(0.5f, 0.7f);
        sound.pitch = Random.Range(0.8f, 1f);
        sound.Play();
    }
}
