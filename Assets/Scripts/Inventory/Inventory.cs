using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private void Start()
    {
        Instance = this;
    }
    
    public bool[] isFull;
    public GameObject[] slots;
}
