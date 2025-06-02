using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Knife : Item
{
    [SerializeField] private int damageAmount;
    
    [SerializeField] private WeaponOwner weaponOwner;

    private string IS_ATTACK_KNIFE = "IsAttackKnife";

    //public event EventHandler OnSwordSwing;

    private PolygonCollider2D _polygonCollider2D;

    private bool isAttackKnife = false;

    private Animator animator;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        AttackColliderTurnOff();
    }

    public void FixedUpdate()
    {
        if (isAttackKnife)
        {
            AttackColliderTurnOn();
        }
        else
        {
            AttackColliderTurnOff();
        }
    }

    public void SetAnimationAttackKnife()
    {
        if (animator)
            animator.SetBool(IS_ATTACK_KNIFE, isAttackKnife);
    }


    //public void Attack()
    //{
    //    //AttackColliderTurnOff();
    //    //_polygonCollider2D.enabled = false;
    //    Debug.Log("Pressedasdvaw");

    //    //OnSwordSwing?.Invoke(this, EventArgs.Empty);
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.GetComponent<Pickup>().itemPickedUp) return;

        switch (weaponOwner)
        {
            case WeaponOwner.Player:
            {
                if (collision.transform.TryGetComponent(out EnemyEntity enemyEntity))
                    enemyEntity.TakeDamage(damageAmount);
                break;
            }
            case WeaponOwner.Enemy:
            {
                if (collision.transform.TryGetComponent(out PlayerEntity playerEntity))
                    playerEntity.TakeDamage(damageAmount);
                break;
            }
        }

        if (collision.transform.TryGetComponent(out Chest chest))
            chest.TakeDamage(damageAmount);
    }

    public void AttackColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }

    private void AttackColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }

    public bool GetAttack()
    {
        return isAttackKnife;
    }

    public void SetAttack(bool _isAttackKnife)
    {
        isAttackKnife = _isAttackKnife;
    }
}
