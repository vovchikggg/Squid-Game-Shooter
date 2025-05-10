using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;


    private bool isFireShotGun;
    private float timeBtwShots;
    public float startTimeBtwShot;

    void FixedUpdate()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShot;
            }
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
