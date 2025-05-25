using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private int i;

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
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
