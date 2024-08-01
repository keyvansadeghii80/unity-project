using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    [SerializeField]
    private float deactivateWautTime = 0.1f;
    private float deactivateTimer;

    [SerializeField]
    private LayerMask playerLayer;
    private bool canDealDamage;
    //[SerializeField]
    private float damageAmount = 50f;

    //player health
    private PlayerHealth playerHealth;
    private void Awake()
    {
        playerHealth = GameObject.FindWithTag(TagManager.PLAYER_TAG).GetComponent<PlayerHealth>();//پیدا کردن تگ پلیر

        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 1f, playerLayer))
        {
            if (canDealDamage)
            {
                canDealDamage = false;
                //deal damage to player
                //Debug.Log("a");
                playerHealth.TakeDamage(damageAmount);  
            }
        }
        DeactivateDamageArea();
    }
    void DeactivateDamageArea()    //اگر بازیکم رفن دیگرر دمیج ندهذ
    {
        if (Time.time > deactivateTimer)                           //برای اینکه پشتس سرهم زربه نزنه
            gameObject.SetActive(false);
    }
    public void ResetDeactivateTimer()
    {
        canDealDamage = true;
        deactivateTimer = Time.time + deactivateWautTime;
    }
}
