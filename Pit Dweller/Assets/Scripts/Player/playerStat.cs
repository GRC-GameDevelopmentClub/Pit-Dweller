using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerStat : MonoBehaviour {
    public float currentHealth;
    public float health = 50f;
    public int gunDamage = 10;
    public int ammoMCapcity = 100;
    public int currentMAmmo = 100;
    public int ammoLCapcity = 200;
    public int currentLAmmo = 200;

    [Header("Unity CHARSTAT!")]
    public Text healthText;

    private float regenRates;
    [SerializeField]
    private int regenAmount;
    private float timeElapsedColor;
    private bool isColorChanged;
    private float timeShotCounter;

    private float timeLShotCounter;
    private float regenLRates;
    [SerializeField]
    private int regenLAmount;

    public float TimeShotCounter
    {
        get
        {
            return timeShotCounter;
        }

        set
        {
            timeShotCounter = value;
        }
    }

    public float TimeLShotCounter
    {
        get
        {
            return timeLShotCounter;
        }

        set
        {
            timeLShotCounter = value;
        }
    }

    void Update()
    {
        timeLShotCounter += Time.deltaTime;
        timeShotCounter += Time.deltaTime;
        healthText.text = "Health: "+currentHealth + "/" + health;
        if (isColorChanged)
        {
            timeElapsedColor += Time.deltaTime;
            if (timeElapsedColor >= .25f)
            {
                timeElapsedColor = 0;
                isColorChanged = false;
                ResetColor();
            }
        }

        if (timeShotCounter >= 5)
        {
            regenRates += Time.deltaTime;
            if (regenRates > 1.5)
            {
                regenRates = 0;
                currentMAmmo += regenAmount;
                if (currentMAmmo > ammoMCapcity)
                {
                    currentMAmmo = ammoMCapcity;
                }
            }
        }

        if (timeLShotCounter >= 5)
        {
            regenLRates += Time.deltaTime;
            if (regenLRates > 1.5)
            {
                regenLRates = 0;
                currentLAmmo += regenLAmount;
                if (currentLAmmo > ammoLCapcity)
                {
                    currentLAmmo = ammoLCapcity;
                }
            }
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ChangeColor();
    }

    private void ChangeColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 0, 0, .7f);
        isColorChanged = true;
    }

    private void ResetColor()
    {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }
}
