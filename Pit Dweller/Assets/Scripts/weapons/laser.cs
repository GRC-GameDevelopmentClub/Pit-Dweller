using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {
    public Transform shootingPoint;
    public float fireRate = 0.2f;
    public float range = 100f;
    public int ammoCapcity = 20;
    public int currentAmmo = 20;
    public float reloadTime;

    public LineRenderer line;

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
                line.enabled = true;
            }
        }

        if (justShot)
        {
            firecounter += Time.deltaTime;
            if (firecounter >= fireRate)
            {
                firecounter = 0f;
                justShot = false;
                line.enabled = false;
            }
        }
    }
    void Shoot()
    {
        line.SetPosition(0, shootingPoint.position);
        line.startWidth = .20f;
        line.endWidth = .20f;
        RaycastHit2D hit = Physics2D.Raycast(shootingPoint.position, shootingPoint.up);
  
        if (hit && hit.transform.tag != "Player")
        {
            Debug.Log(hit.transform.name);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(1, shootingPoint.position + shootingPoint.up * 30);
        }
    }
}
