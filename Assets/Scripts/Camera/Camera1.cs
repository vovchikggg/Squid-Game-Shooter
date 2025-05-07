using UnityEngine;

public class Camera1 : MonoBehaviour
{
    private Transform player;
    private Transform gameOverUI;

    void Start()
    {
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj)
        {
            player = playerObj.transform;
        }
        
        var gameOverUIObj = GameObject.FindGameObjectWithTag("GameOverUI");
        if (gameOverUIObj)
        {
            gameOverUI = gameOverUIObj.transform;
        }
    }

    void LateUpdate()
    {
        if (player)
        {
            var temp = transform.position;
            temp.x = player.position.x;
            temp.y = player.position.y;
            transform.position = temp;
            return;
        }

        if (gameOverUI)
        {
            var temp = transform.position;
            temp.x = gameOverUI.position.x;
            temp.y = gameOverUI.position.y;
            transform.position = temp;
            
            Camera.main.orthographicSize = 25f;
        }
    }
}
