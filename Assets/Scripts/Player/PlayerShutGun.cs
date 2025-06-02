using UnityEngine;
using System;

public class PlayerShotGun : MonoBehaviour
{
    public static PlayerShotGun Instance { get; private set; }

    [SerializeField] public ShotGun ShotGun;
        private Animator animator;

    private const string IS_RUN_SHOT_GUN = "IsRunShotGun";

    private const string IS_FIRE_SHOT_GUN = "IsFireShotGun";

    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += Player_OnPlayerAttack; //пишем не в Awake, так как Awake рандомно вызывается
    }

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
            ShotGun.SetFire(true);
        }
        else
        {
            ShotGun.SetFire(false);
        }
        animationRun();
        animationFire();
    }

    public void animationRun()
    {
        animator.SetBool(IS_RUN_SHOT_GUN, PlayerController.Instance.IsRun());
    }

    public void animationFire()
    {
        animator.SetBool(IS_FIRE_SHOT_GUN, PlayerShotGun.Instance.ShotGun.GetFire());

        //ActiveWeapon.Instance.GetActiveWeapon().SetAttack(false); // пусть пока будет здесь
    }
    
    public void Attack()
    {

    }

    public Vector3 GetPlayerScreenPosition()
    {
        var playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
