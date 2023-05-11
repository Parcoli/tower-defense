using UnityEngine;
using UnityEngine.UI;

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

    public void Start()
    {
        speed = startSpeed;
        health = starthealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health/starthealth;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    { 
        speed = startSpeed * (1f - amount);
    }
    private void Die()
    {
        PlayerStats.money += rewardMoney;
        GameObject deathParticles = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles, 2f);
        WaveSpawner._mobAlive--;
        Destroy(gameObject);
    }



}
