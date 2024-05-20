using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player; // �v���C���[��Transform
    [SerializeField] float speed = 3f; // �G�̈ړ����x
    [SerializeField] float acceleration = 2f; // �����x
    [SerializeField] float deceleration = 2f; // �����x
    private Rigidbody2D rb;
    private Vector2 velocity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // �v���C���[�ւ̕������v�Z
        Vector2 direction = (player.position - transform.position).normalized;
        Vector2 targetVelocity = direction * speed;

        // ������K�p����
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
