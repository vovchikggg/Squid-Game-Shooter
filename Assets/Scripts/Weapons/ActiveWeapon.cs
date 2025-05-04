using Unity.VisualScripting;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public static ActiveWeapon Instance { get; private set; }
    [SerializeField] private Weapons activeWeapon;
    [SerializeField] private Sword sword;
    [SerializeField] private Gun gun;

    private void Awake()
    {
        Instance = this;
    }
    
    public Weapons GetActiveWeapon()
    {
        return activeWeapon;
    }

    public Sword GetSword() => sword;
    public Gun GetGun() => gun;
}
