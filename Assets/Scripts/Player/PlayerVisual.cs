using UnityEngine;

public class WithVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private const string IS_RUN_KNIFE = "IsRunKnife";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUN_KNIFE, PlayerMove.Instance.IsRunKnife());
        AdjustPlayerFactingDirection();
    }

    private void AdjustPlayerFactingDirection()
    {
        var mousePosition = GameInput.Instance.GetMousePosition();
        var playerPosition = PlayerMove.Instance.GetPlayerScreenPosition();

        if (mousePosition.x < playerPosition.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out EnemyEntity enemyEntity))
        {
            Debug.Log(100);
        }
    }
}
