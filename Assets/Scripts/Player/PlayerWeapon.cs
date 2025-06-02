using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject shotgunHolder;   // Ссылка на GameObject, содержащий персонажа с дробовиком
    public GameObject knifeHolder;      // Ссылка на GameObject, содержащий персонажа с ножом
    public enum WeaponType { Knife, Shotgun }; // Перечисление типов оружия
    public WeaponType currentWeapon = WeaponType.Knife;
    private GameObject currentHolder;   // Текущий активный WeaponHolder

    void Start()
    {
        if (knifeHolder != null) knifeHolder.SetActive(true);  // Start with Knife
        if (shotgunHolder != null) shotgunHolder.SetActive(false);
        currentHolder = knifeHolder; // Устанавливаем начальный holder
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(WeaponType.Knife);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(WeaponType.Shotgun);
        }
    }

    void SetWeapon(WeaponType weapon)
    {
        if (weapon == currentWeapon) return; // Nothing to do

        currentWeapon = weapon;

        if (currentHolder != null) currentHolder.SetActive(false);  // Отключаем старое оружие

        switch (weapon)
        {
            case WeaponType.Knife:
                if (knifeHolder != null) knifeHolder.SetActive(true);
                currentHolder = knifeHolder;
                break;
            case WeaponType.Shotgun:
                if (shotgunHolder != null) shotgunHolder.SetActive(true);
                currentHolder = shotgunHolder;
                break;
        }
    }
}