using UnityEngine;

public class MissileLauncher : Turret
{
    public override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bulletGO.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.speed = bullet.speed / 2;
        bullet.damage = bullet.damage * 3;

        if (bullet != null)

            bullet.Seek(target);
    }
}
