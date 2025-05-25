using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject icon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (var i = 0; i < Inventory.Instance.slots.Length; i++)
            {
                if (!Inventory.Instance.isFull[i])
                {
                    Inventory.Instance.isFull[i] = true;
                    Instantiate(icon, Inventory.Instance.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
