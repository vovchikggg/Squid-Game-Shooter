using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject shotgunHolder;
    public GameObject knifeHolder;
    private GameObject currentHolder;
    
    public static PlayerWeapon Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (knifeHolder)
            knifeHolder.SetActive(true);
        if (shotgunHolder)
            shotgunHolder.SetActive(false);
        currentHolder = knifeHolder;
    }

    private void Update()
    {
        SetWeapon(Inventory.Instance.weaponSlot.transform.GetChild(0).GetComponent<Icon>().weaponType);
    }

    private void SetWeapon(WeaponType weapon)
    {
        if (currentHolder == knifeHolder)
        {
            if (weapon == WeaponType.Knife)
            {
                return;
            }
        }
        if (currentHolder == shotgunHolder)
        {
            if (weapon == WeaponType.Shotgun)
            {
                return;
            }
        }
        
        if (currentHolder)
            currentHolder.SetActive(false);

        switch (weapon)
        {
            case WeaponType.Knife:
                if (knifeHolder)
                    knifeHolder.SetActive(true);
                currentHolder = knifeHolder;
                break;
            case WeaponType.Shotgun:
                if (shotgunHolder)
                    shotgunHolder.SetActive(true);
                currentHolder = shotgunHolder;
                break;
        }
    }
}