using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public static ItemUse Instance;
    
    [SerializeField] private Inventory inventory;

    private void Awake()
    {
        Instance = this;
    }
    
    public void UseItem()
    {
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        var inventorySlotChild = default(GameObject);
        foreach (Transform child in Inventory.Instance.slots[Inventory.Instance.activeSlot].transform)
        {
            inventorySlotChild = child.GetComponent<Icon>().icon;
            Destroy(child.gameObject);
        }
            
        var weaponSlotChild = default(GameObject);
        foreach (Transform child in Inventory.Instance.weaponSlot.transform)
        {
            weaponSlotChild = child.GetComponent<Icon>().icon;
            Destroy(child.gameObject);
        }

        if (weaponSlotChild)
            Instantiate(weaponSlotChild, Inventory.Instance.slots[Inventory.Instance.activeSlot].transform);
        if (inventorySlotChild)
            Instantiate(inventorySlotChild, Inventory.Instance.weaponSlot.transform);
    }
}