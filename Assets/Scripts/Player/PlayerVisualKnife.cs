using UnityEngine;

public class PlayerVisualKnife : MonoBehaviour
{
    public static PlayerVisualKnife Instance { get; private set; }

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private const string IS_RUN_KNIFE = "IsRunKnife";

    private const string IS_ATTACK_KNIFE = "IsAttackKnife";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animationRun();
        animationAttack();

        //AdjustPlayerFactingDirection();
    }

    //private void AdjustPlayerFactingDirection()
    //{
    //    var mousePosition = GameInput.Instance.GetMousePosition();
    //    var playerPosition = PlayerMove.Instance.GetPlayerScreenPosition();

    //    if (mousePosition.x < playerPosition.x)
    //        spriteRenderer.flipX = true;
    //    else
    //        spriteRenderer.flipX = false;
    //}

    public void animationRun()
    {
        animator.SetBool(IS_RUN_KNIFE, PlayerKnife.Instance.IsRun());
    }

    public void animationAttack()
    {
        animator.SetBool(IS_ATTACK_KNIFE, PlayerKnife.Instance.Knife.IsAttack());

        //ActiveWeapon.Instance.GetActiveWeapon().SetAttack(false); // пусть пока будет здесь
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out EnemyEntity enemyEntity))
        {
            Debug.Log(100);
        }
    }
}
