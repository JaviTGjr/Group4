using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunTurret : Turret
{
    public override void Shoot()
    {
        StartCoroutine(ShootRay());
    }

    private IEnumerator ShootRay()
    {
        float size = 0.1f;
        for (int i = 0; i < 10; ++i)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.transform.localScale = new Vector3(size, size, size);
            bullet.damage = bullet.damage * 0.12f;
            size += 0.05f;

            if (bullet != null)

                bullet.Seek(target);

            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < 10; ++i)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.transform.localScale = new Vector3(size, size, size);
            bullet.damage = bullet.damage * 0.12f;
            size -= 0.05f;

            if (bullet != null)

                bullet.Seek(target);

            yield return new WaitForSeconds(0.05f);
        }
    }
}
