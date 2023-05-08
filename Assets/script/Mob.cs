using UnityEngine;

public class Mob : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int rewardMoney = 50;
    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];

    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.money += rewardMoney;
        GameObject deathParticles = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles, 2f);
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }

    }

    private void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void EndPath()
    {
       PlayerStats.lives--;
       Destroy(gameObject);
    }

}
