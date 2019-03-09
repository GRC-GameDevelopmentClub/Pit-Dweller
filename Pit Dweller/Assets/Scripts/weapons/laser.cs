using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laser : MonoBehaviour {
    public int damage;
    public Transform shootingPoint;
    public float fireRate = 0.2f;
    public float range = 100f;
    public int ammoCapcity = 200;
    public int currentAmmo = 200;
    public float reloadTime;
    public LineRenderer line;
    public Text ammotext;
    public Transform lineEnd;
    public AudioSource shootingSound;

    private float firecounter;
    private bool justShot;

    private Transform targetPlayer;
    void Start()
    {
        GetComponentInParent<playerStat>().currentLAmmo = GetComponentInParent<playerStat>().ammoLCapcity;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        damage = targetPlayer.GetComponent<playerStat>().gunDamage;
    }

    // Update is called once per frame
    void Update()
    {
        ammotext.text = "Ammo: " + GetComponentInParent<playerStat>().currentLAmmo + "/" + GetComponentInParent<playerStat>().ammoLCapcity;
        if (Input.GetButton("Fire1"))
        {
            if (!justShot && GetComponentInParent<playerStat>().currentLAmmo > 0)
            {
                Shoot();
                GetComponentInParent<playerStat>().TimeLShotCounter = 0;
                justShot = true;
                line.enabled = true;
                lineEnd.GetComponent<EdgeCollider2D>().enabled = true;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            shootingSound.Stop();
        }


        if (justShot)
        {
            firecounter += Time.deltaTime;
            if (firecounter >= fireRate)
            {
                firecounter = 0f;
                justShot = false;
                line.enabled = false;
                lineEnd.GetComponent<EdgeCollider2D>().enabled = false;
            }
        }
    }
    void Shoot()
    {
        line.SetPosition(0, shootingPoint.position);
        line.startWidth = .20f;
        line.endWidth = .20f;
        RaycastHit2D hit = Physics2D.Raycast(shootingPoint.position, shootingPoint.up);
        
        if (hit)
        {
            Debug.Log(hit.transform.name);
            line.SetPosition(1, hit.point);
            lineEnd.position = hit.point;
        }
        
        else
        {
            line.SetPosition(1, shootingPoint.position + shootingPoint.up * 30);
        }
        GetComponentInParent<playerStat>().currentLAmmo--;
        if (!shootingSound.isPlaying)
        {
            PlaySound(shootingSound);
        }
    }

    void PlaySound(AudioSource sound)
    {
        sound.volume = Random.Range(0.3f, 0.5f);
        sound.pitch = Random.Range(1.5f, 1.8f);
        sound.Play();
    }
}
