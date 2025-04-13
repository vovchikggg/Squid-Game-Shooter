using System;
using UnityEngine;

public class SwordVisual : MonoBehaviour
{
    [SerializeField] private Sword sword;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void TriggerEndAttackAnimation()
    {
        sword.AttackColliderTurnOff();
    }
}
