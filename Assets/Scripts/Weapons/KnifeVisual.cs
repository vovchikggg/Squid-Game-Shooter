using System;
using UnityEngine;

public class KnifeVisual : MonoBehaviour //���� ����� ����� �� ���
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
