using UnityEngine;

public class SingleTurret : Turret
{
    public override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bulletGO.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.speed = bullet.speed * 0.8f;
        bullet.damage = bullet.damage;

        if (bullet != null)

            bullet.Seek(target);
    }
}
