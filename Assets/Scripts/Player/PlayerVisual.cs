using UnityEngine;

public class WithVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, PlayerMove.Instance.IsRunning());
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
}
