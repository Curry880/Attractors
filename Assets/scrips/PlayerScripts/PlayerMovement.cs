using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float deceleration = 2f;
    private Rigidbody2D rb;
    private Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力を取得
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 移動方向に基づいて速度を計算
        Vector2 playerVelocity = new Vector2(moveX, moveY) * speed;

        // 慣性を適用する
        if (playerVelocity.magnitude > 0.1f)
        {
            velocity = Vector2.Lerp(velocity, playerVelocity, acceleration * Time.deltaTime);
        }
        else
        {
            velocity = Vector2.Lerp(velocity, Vector2.zero, deceleration * Time.deltaTime);
        }

        rb.velocity = velocity;
    }
    public void IncreaseSpeed(float multiplier)
    {
        speed *= multiplier;
    }
}