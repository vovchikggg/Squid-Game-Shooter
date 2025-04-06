using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector2 temp = transform.position; //Важен именно Vector3, а не Vector2
        temp.x = player.position.x;
        temp.y = player.position.y;

        transform.position = temp;
    }
}
