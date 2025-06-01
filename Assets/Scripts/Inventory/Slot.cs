using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private bool isInventorySlot;
    [SerializeField] private int i;

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            if (!isInventorySlot)
                Inventory.Instance.weaponSlotIsFull = false;
            else
                Inventory.Instance.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Spawn>())
            {
                Inventory.Instance.isFull[i] = false;
                child.GetComponent<Spawn>().SpawnDroppedItem();
                Destroy(child.gameObject);
            }
        }
    }
    
    public void ChangeSlotColor()
    {
        if (inventory.activeSlot == i)
        {
            var activeSlotColor = new Color(225f / 255f, 225f / 255f, 225f / 255f, 200f / 255f);
            inventory.slots[i].transform.GetComponent<Image>().color = activeSlotColor;
        }
        else
        {
            var inactiveSlotColor = new Color(0f / 255f, 0f / 255f, 0f / 255f, 200f / 255f);
            inventory.slots[i].transform.GetComponent<Image>().color = inactiveSlotColor;
        }
    }
}
