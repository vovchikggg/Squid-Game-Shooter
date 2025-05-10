using UnityEngine;

public class PlayerVisualShotGun : MonoBehaviour
{
    public static PlayerVisualShotGun Instance { get; private set; }

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private const string IS_RUN_SHOT_GUN = "IsRunShotGun";

    private const string IS_FIRE_SHOT_GUN = "IsFireShotGun";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animationRun();
        animationFire();

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
        animator.SetBool(IS_RUN_SHOT_GUN, PlayerShotGun.Instance.IsRun());
    }

    public void animationFire()
    {
        animator.SetBool(IS_FIRE_SHOT_GUN, PlayerShotGun.Instance.ShotGun.GetFire());

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
