using UnityEngine;

public class EnemySword : MonoBehaviour
{
    [SerializeField] public Knife Knife;
    private Animator animator;
    private const string IS_ATTACK_KNIFE = "IsPersonalAttackKnife";
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Knife.GetAttack())
        {
           Debug.Log("player is near");
           animator.SetBool(IS_ATTACK_KNIFE, true); 
        }
        else
        {
            animator.SetBool(IS_ATTACK_KNIFE, false);
        }
            
    }
}
