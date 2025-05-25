using UnityEngine;

public class Camera1 : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj)
        {
            player = playerObj.transform;
        }
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (player)
        {
            var temp = transform.position;
            temp.x = player.position.x;
            temp.y = player.position.y;
            transform.position = temp;
        }
    }
}
