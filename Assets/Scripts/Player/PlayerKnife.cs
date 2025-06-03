using UnityEngine;

public class PlayerKnife : MonoBehaviour
{
    public static PlayerKnife Instance { get; private set; }
    private Animator animator;
    private const string IS_RUN_KNIFE = "IsRunKnife";
    private const string IS_ATTACK_KNIFE = "IsAttackKnife";

    [SerializeField] public Knife Knife;

    private void Player_OnPlayerAttack(object sender, System.EventArgs e)
    {
        Attack();

        //ActiveWeapon.Instance.GetActiveWeapon().SetAttack(true);

    }

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) // 0 - левая кнопка мыши
        {
            Knife.SetAttack(true);
            animator.SetBool(IS_ATTACK_KNIFE, true);
        }
        else
        {
            Knife.SetAttack(false);
            animator.SetBool(IS_ATTACK_KNIFE, false);
        }
    }

    public void Attack()
    {

    }
    
    public void animationRun()
    {
        animator.SetBool(IS_RUN_KNIFE, PlayerController.Instance.IsRun());
    }

    public void animationAttack()
    {
        animator.SetBool(IS_ATTACK_KNIFE, PlayerKnife.Instance.Knife.GetAttack());
        
        //ActiveWeapon.Instance.GetActiveWeapon().SetAttack(false); // пусть пока будет здесь
    }

    public Vector3 GetPlayerScreenPosition()
    {
        var playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
