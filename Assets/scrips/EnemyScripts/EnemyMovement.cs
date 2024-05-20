using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player; // プレイヤーのTransform
    [SerializeField] float speed = 3f; // 敵の移動速度
    [SerializeField] float acceleration = 2f; // 加速度
    [SerializeField] float deceleration = 2f; // 減速度
    private Rigidbody2D rb;
    private Vector2 velocity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // プレイヤーへの方向を計算
        Vector2 direction = (player.position - transform.position).normalized;
        Vector2 targetVelocity = direction * speed;

        // 慣性を適用する
        if (targetVelocity.magnitude > 0.1f)
        {
            velocity = Vector2.Lerp(velocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            velocity = Vector2.Lerp(velocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }
        
        //velocity = Vector2.Lerp(velocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        rb.velocity = velocity;
    }
    public void IncreaseSpeed(float multiplier)
    {
        speed *= multiplier;
    }
}
