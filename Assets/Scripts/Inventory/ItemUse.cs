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

        (Inventory.Instance.weaponSlotIsFull, Inventory.Instance.isFull[Inventory.Instance.activeSlot]) =
            (Inventory.Instance.isFull[Inventory.Instance.activeSlot], Inventory.Instance.weaponSlotIsFull);
        
        foreach (Transform child in Inventory.Instance.slots[Inventory.Instance.activeSlot].transform)
        {
            var useComponent = child.GetComponent<Icon>();
            if (useComponent)
            {
                inventorySlotChild = useComponent.icon;
                Destroy(child.gameObject);
            }
        }
        foreach (Transform child in Inventory.Instance.weaponSlot.transform)
        {
            var useComponent = child.GetComponent<Icon>();
            if (useComponent)
            {
                weaponSlotChild = useComponent.icon;
                Destroy(child.gameObject);
            }
        }

        if (weaponSlotChild)
            Instantiate(weaponSlotChild, Inventory.Instance.slots[Inventory.Instance.activeSlot].transform);
        if (inventorySlotChild)
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