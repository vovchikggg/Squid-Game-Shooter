using UnityEngine;

public class ShotGun : Item
{
    public GameObject bullet;
    public Transform shotPoint;
    [SerializeField] private WeaponOwner weaponOwner;

    public bool isFireShotGun;
    private float timeBtwShots;
    public float startTimeBtwShot;

    void FixedUpdate()
    {
        if (!isFireShotGun)
            return;
        if (timeBtwShots <= 0)
        {
            if (!gameObject.GetComponent<Pickup>().itemPickedUp) return;
            
            if (weaponOwner == WeaponOwner.Player)
                if (!Input.GetMouseButton(0))
                    return;
            
            AudioManager.Instance.shotSound.Play();
            var current_bullet = Instantiate(bullet, shotPoint.position, transform.rotation);
            current_bullet.GetComponent<Bullet>().weaponOwner = weaponOwner;
            timeBtwShots = startTimeBtwShot;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void SetFire(bool _isFireShotGun)
    {
        isFireShotGun = _isFireShotGun;
    }

    public bool GetFire()
    {
        return isFireShotGun;
    }
}
