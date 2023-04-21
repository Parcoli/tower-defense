using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public float range = 15f;
    public string mobTag = "Mob";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] mobs = GameObject.FindGameObjectsWithTag(mobTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestMob = null;

        foreach(GameObject mob in mobs)
        {
            float distanceToMob = Vector3.Distance(transform.position, mob.transform.position);
            if(distanceToMob < shortestDistance) {
                shortestDistance = distanceToMob;
                nearestMob = mob;
            }

           // if(nearestMob )

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
