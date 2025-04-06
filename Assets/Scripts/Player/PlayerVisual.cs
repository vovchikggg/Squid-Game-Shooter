using UnityEngine;

public class WithVisual : MonoBehaviour
{
    private Animator animator;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, PlayerMove.Instance.IsRunning());
    }
}
