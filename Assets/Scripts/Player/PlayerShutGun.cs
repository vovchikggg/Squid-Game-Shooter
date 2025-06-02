using UnityEngine;
using System;

public class PlayerShotGun : MonoBehaviour
{
    public static PlayerShotGun Instance { get; private set; }

    [SerializeField] public ShotGun ShotGun;

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
