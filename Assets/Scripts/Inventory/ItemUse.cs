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
        var weaponSlotChild = default(GameObject);
        
        foreach (Transform child in Inventory.Instance.slots[Inventory.Instance.activeSlot].transform)
        {
            var iconComponent = child.GetComponent<Icon>();
            if (iconComponent)
                inventorySlotChild = iconComponent.icon;
        }
        foreach (Transform child in Inventory.Instance.weaponSlot.transform)
        {
            var iconComponent = child.GetComponent<Icon>();
            if (iconComponent)
                weaponSlotChild = iconComponent.icon;
        }

        if (!weaponSlotChild || !inventorySlotChild) return;
        foreach (Transform child in Inventory.Instance.slots[Inventory.Instance.activeSlot].transform)
            Destroy(child.gameObject);
        foreach (Transform child in Inventory.Instance.weaponSlot.transform)
            Destroy(child.gameObject);
        
        (Inventory.Instance.weaponSlotIsFull, Inventory.Instance.isFull[Inventory.Instance.activeSlot]) =
            (Inventory.Instance.isFull[Inventory.Instance.activeSlot], Inventory.Instance.weaponSlotIsFull);
        
        Instantiate(weaponSlotChild, Inventory.Instance.slots[Inventory.Instance.activeSlot].transform);
        Instantiate(inventorySlotChild, Inventory.Instance.weaponSlot.transform);

        foreach (Transform child in Inventory.Instance.slots[Inventory.Instance.activeSlot].transform)
        {
            child.GetComponent<Spawn>().enabled = true;
            child.GetComponent<Icon>().enabled = true;
        }
        foreach (Transform child in Inventory.Instance.weaponSlot.transform)
        {
            child.GetComponent<Spawn>().enabled = true;
            child.GetComponent<Icon>().enabled = true;
        }
    }
}