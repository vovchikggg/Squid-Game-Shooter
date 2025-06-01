using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private void Start()
    {
        Instance = this;
        
        activeSlot = 0;
        ShowActiveSlot();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeSlot = 0;
            ShowActiveSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeSlot = 1;
            ShowActiveSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeSlot = 2;
            ShowActiveSlot();
        }

        if (Input.GetKeyDown(KeyCode.E))
            ItemUse.Instance.UseItem();
        
        if (Input.GetKeyDown(KeyCode.Q))
            slots[activeSlot].transform.GetComponent<Slot>().DropItem();
    }

    private void ShowActiveSlot()
    {
        foreach (var slot in slots)
            slot.GetComponent<Slot>().ChangeSlotColor();
    }
    
    public bool weaponSlotIsFull;
    public bool[] isFull;
    public GameObject weaponSlot;
    public GameObject[] slots;
    
    public int activeSlot;
}
