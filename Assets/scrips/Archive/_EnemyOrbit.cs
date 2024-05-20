using UnityEngine;

public class _EnemyOrbit : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public float moveSpeed = 5f; // �G�L�����̈ړ����x
    public float orbitSpeed = 5f; // �v���C���[�̎������鑬�x
    public float orbitDistance = 100f; // �v���C���[����̉�]�O���̔��a

    private Rigidbody2D rb;
    private bool isOrbiting = false; // ��]���[�h�ɓ����Ă��邩�ǂ���
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
            // �v���C���[�Ɍ������Ĉړ�
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
        // �v���C���[�̎������郍�W�b�N
        Vector2 direction = (transform.position - player.position).normalized;
        Vector2 perpendicularDirection = new Vector2(-direction.y, direction.x); // ���v���
        rb.velocity = perpendicularDirection * orbitSpeed;
    }
}
