using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] public ShotGun Gun;
    private Animator animator;
    private const string IS_ATTACK_KNIFE = "IsPersonalAttackGun";
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Gun.isFireShotGun)
        {
            Debug.Log("player is near to shotgun");
            animator.SetBool(IS_ATTACK_KNIFE, true); 
        }
        else
        {
            animator.SetBool(IS_ATTACK_KNIFE, false);
        }
            
    }
}