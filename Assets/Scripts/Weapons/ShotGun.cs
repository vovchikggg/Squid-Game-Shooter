using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    [SerializeField] private WeaponOwner weaponOwner;

    public bool isFireShotGun;
    private float timeBtwShots;
    public float startTimeBtwShot;

    void FixedUpdate()
    {
        if (timeBtwShots <= 0)
        {
            if (!gameObject.GetComponent<Pickup>().itemPickedUp) return;
            
            if (!Input.GetMouseButton(0)) return;
            
            Instantiate(bullet, shotPoint.position, transform.rotation);
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
