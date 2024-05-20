using UnityEngine;

public class _EnemyOrbit : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float moveSpeed = 5f; // 敵キャラの移動速度
    public float orbitSpeed = 5f; // プレイヤーの周りを回る速度
    public float orbitDistance = 100f; // プレイヤーからの回転軌道の半径

    private Rigidbody2D rb;
    private bool isOrbiting = false; // 回転モードに入っているかどうか
    public float pow = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (player.position - transform.position);
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        //rb.AddForce((player.position - transform.position) * pow / distance);
        rb.AddForce((player.position - transform.position)* distance);
        /*
        if (distance > orbitDistance)
        {
            // プレイヤーに向かって移動
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.AddForce((player.position - transform.position) * pow);
        }
        */
        /*
        if (distance < orbitDistance)
        {
            Debug.Log("a");
            rb.AddForce((player.position - transform.position)* pow);
        }
        */
        if (distance > orbitDistance)
        {
            Debug.Log("b");
            rb.AddForce((player.position - transform.position).normalized * moveSpeed);
        }
    }

    void OrbitAroundPlayer()
    {
        // プレイヤーの周りを回るロジック
        Vector2 direction = (transform.position - player.position).normalized;
        Vector2 perpendicularDirection = new Vector2(-direction.y, direction.x); // 時計回り
        rb.velocity = perpendicularDirection * orbitSpeed;
    }
}
