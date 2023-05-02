using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    public float range = 15f;
    public string mobTag = "Mob";
    public Transform partToRotate;

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

           if(nearestMob != null && shortestDistance <= range)
            {
                target = nearestMob.transform;
            }
           else
            {
                target = null;
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
