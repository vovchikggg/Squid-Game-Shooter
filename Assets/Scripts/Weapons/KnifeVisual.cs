using System;
using UnityEngine;

public class KnifeVisual : MonoBehaviour //пока класс нигде не исп
{
    [SerializeField] private Knife sword;

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
