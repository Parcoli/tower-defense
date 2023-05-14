using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mob : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float starthealth = 100f;
    [HideInInspector]
    public float health;
    public int rewardMoney = 50;
    public GameObject deathEffect;
    public Image healthBar;
    public bool isFire;
    public float fireDamageAmount = 20f;
    public bool isIce;
    [HideInInspector]
    public bool isDead;

    public void Start()
    {
        speed = startSpeed;
        health = starthealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health/starthealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float amount)
    { 
        speed = startSpeed * (1f - amount);
    }
    public IEnumerator Burn()
    {
        for (int i = 0; i < 5; i++) 
        {
            if (isFire)
            {
                TakeDamage(fireDamageAmount/2);
            }
            else if(isIce)
            {
                TakeDamage(fireDamageAmount*2);
            }
            else
            {
                TakeDamage(fireDamageAmount);
            }
            

            yield return new WaitForSeconds(2f);
        }
        


    }
    private void Die()
    {
        isDead = true;
        PlayerStats.money += rewardMoney;
        GameObject deathParticles = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles, 2f);
        WaveSpawner._mobAlive--;
        Destroy(gameObject);
    }



}
