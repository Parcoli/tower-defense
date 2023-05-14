using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public GameObject impactEffect;
    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    public bool isFire;
    public float fireMultiplicator;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {

        GameObject effectIns =  (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1.5f);

        if (explosionRadius > 0)
        {
            Explode();
        }
        else if(isFire)
        {
            Damage(target);
            FireDamage(target);
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Mob")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform mob)
    {
        Mob m = mob.GetComponent<Mob>();
        if(m != null)
        {
            m.TakeDamage(damage);
        }
        else
        {
            Debug.LogError("Pas de script Mob sur l'ennemi");
        }

    }

    void FireDamage(Transform mob)
    {
        Mob m = mob.GetComponent<Mob>();
        if (m != null)
        {
            m.TakeDamage(damage);
            StartCoroutine(m.Burn());
        }
        else
        {
            Debug.LogError("Pas de script Mob sur l'ennemi");
        }

    }
    void IceDamage(Transform mob)
    {
        Mob m = mob.GetComponent<Mob>();
        if (m != null)
        {
            m.TakeDamage(damage);
        }
        else
        {
            Debug.LogError("Pas de script Mob sur l'ennemi");
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    
}
