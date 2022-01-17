using System.Collections;
using UnityEngine;

public class TripleTurret : Turret
{
    public override void Shoot()
    {
        StartCoroutine(TripleShoot());
    }

    private IEnumerator TripleShoot()
    {
        for (int i = 0; i < 3; ++i)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)

                bullet.Seek(target);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
