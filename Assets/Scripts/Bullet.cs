using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float damage = 10;
    public float speed = 40f;

    public GameObject  impactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }

 
    void Update()
    {
        
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget(target);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }
        
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
       
    }
    
}
