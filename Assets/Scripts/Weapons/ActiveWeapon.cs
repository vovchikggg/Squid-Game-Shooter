using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public static ActiveWeapon Instance { get; private set; }
    [SerializeField] private Knife sword;

    private void Awake()
    {
        Instance = this;
    }

    public Knife GetActiveWeapon()
    {
        return sword;
    }
}
