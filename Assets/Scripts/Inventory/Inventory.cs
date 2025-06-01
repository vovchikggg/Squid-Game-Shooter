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
            ItemUse.Instance.UseItem();
        
        if (Input.GetKeyDown(KeyCode.Q))
            slots[activeSlot].transform.GetComponent<Slot>().DropItem();
    }
    
    public bool weaponSlotIsFull;
    public bool[] isFull;
    public GameObject weaponSlot;
    public GameObject[] slots;
    
    public int activeSlot;
}
