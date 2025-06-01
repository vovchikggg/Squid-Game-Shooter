using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private float xOffset = 3f;
    private float yOffset = 3f;
    private float zOffset = -0.75f;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        var playerPos = new Vector3(player.position.x + xOffset, player.position.y + yOffset, zOffset);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
