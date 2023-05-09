using UnityEngine;

public class Mob : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100f;
    public int rewardMoney = 50;
    public GameObject deathEffect;

    public void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

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
        Destroy(gameObject);
    }



}
