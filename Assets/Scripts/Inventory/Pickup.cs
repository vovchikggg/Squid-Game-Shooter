using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] public GameObject icon;
    public bool itemPickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;

        if (!other.CompareTag("Player")) return;
        
        for (var i = 0; i < Inventory.Instance.slots.Length; i++)
        {
            if (!Inventory.Instance.isFull[i])
            {
                itemPickedUp = true;
                Inventory.Instance.isFull[i] = true;
                Instantiate(icon, Inventory.Instance.slots[i].transform);
                Destroy(gameObject);
                break;
            }
        }
    }
}
