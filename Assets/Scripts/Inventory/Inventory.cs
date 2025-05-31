using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            activeSlot = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            activeSlot = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            activeSlot = 2;

        if (Input.GetKeyDown(KeyCode.E))
        {
            var inventorySlotChild = default(GameObject);
            
            foreach (Transform child in slots[activeSlot].transform)
            {
                inventorySlotChild = child.gameObject;
            }
            var weaponSlotChild = default(GameObject);
            
            foreach (Transform child in weaponSlot.transform)
            {
                weaponSlotChild = child.gameObject;
            }
            
            (inventorySlotChild, weaponSlotChild) = (weaponSlotChild, inventorySlotChild);

            foreach (Transform child in slots[activeSlot].transform)
            {
                Destroy(child.gameObject);
            }
            
            foreach (Transform child in weaponSlot.transform)
            {
                Destroy(child.gameObject);
            }

            if (inventorySlotChild)
                Instantiate(inventorySlotChild, slots[activeSlot].transform);
            
            if (weaponSlotChild)
                Instantiate(weaponSlotChild, weaponSlot.transform);
        }
    }
    
    public bool weaponSlotIsFull;
    public bool[] isFull;
    public GameObject weaponSlot;
    public GameObject[] slots;
    
    public int activeSlot;
}
