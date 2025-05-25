using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private float xOffset = 3;
    private float yOffset = 3;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        var playerPos = new Vector2(player.position.x + xOffset, player.position.y + yOffset);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
