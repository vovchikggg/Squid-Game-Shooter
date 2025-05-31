using UnityEngine;

public class Use : MonoBehaviour
{
    [SerializeField] public GameObject icon;

    public void UseItem()
    {
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        // (inventory.isFull[inventory.activeSlot], inventory.weaponSlotIsFull) =
        //     (inventory.weaponSlotIsFull, inventory.isFull[inventory.activeSlot]);
        // Instantiate(icon, inventory.weaponSlot.transform);
        // Destroy(gameObject);
    }
}