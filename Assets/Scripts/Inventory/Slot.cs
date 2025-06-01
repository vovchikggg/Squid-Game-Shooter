using UnityEngine;

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
}
