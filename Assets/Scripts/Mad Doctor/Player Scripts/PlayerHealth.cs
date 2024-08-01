using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;

    private PlayerMovment playerMovment;

    [SerializeField]
    private Slider healthSlider;

    private void Awake()
    {
        playerMovment = GetComponent < PlayerMovment > ();
    }
    public void TakeDamage(float damageAmount)
    {
        if (health <= 0f)
            return;

        health -= damageAmount;
        if (health <= 0)
        {
            playerMovment.PlayerDied();
        }
        healthSlider.value = health;
    }
}
