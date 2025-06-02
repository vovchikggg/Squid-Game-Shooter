using UnityEngine;

public class PlayerKnife : MonoBehaviour
{
    public static PlayerKnife Instance { get; private set; }

    [SerializeField] public Knife Knife;

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
            Knife.SetAttack(true);
        }
        else
        {
            Knife.SetAttack(false);
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
