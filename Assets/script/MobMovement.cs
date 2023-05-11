using UnityEngine;

[RequireComponent (typeof(Mob))]
public class MobMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Mob mob;
    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<Mob>();
        target = Waypoints.points[0];

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * mob.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }

        mob.speed = mob.startSpeed;

    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
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
        WaveSpawner._mobAlive--;
        Destroy(gameObject);
    }
}
