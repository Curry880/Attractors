using UnityEngine;

public class EnemyMerge : MonoBehaviour
{
    [SerializeField] float sizeMultiplier = 1.1f; // ���̎��̃T�C�Y������
    [SerializeField] float speedMultiplier = 1.2f; // ���̎��̑��x������
    private EnemyMovement enemyMovement;
    [SerializeField] bool canMerge = true;
    Enemy enemy;



    void Start()
    {
        enemy = GetComponent<Enemy>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyMerge colEnemy = collision.gameObject.GetComponent<EnemyMerge>();
            Enemy colenemy = collision.gameObject.GetComponent<Enemy>();
            if (canMerge && colEnemy.canMerge && enemy.mergeCount >= colenemy.mergeCount)
            {
                // ���̏���
                canMerge = false;
                colEnemy.canMerge = false;
                enemyMovement.IncreaseSpeed(speedMultiplier);
                transform.localScale *= sizeMultiplier;
                Destroy(collision.gameObject);
                enemy.IncrementMergeCount();
                canMerge = true;
            }
        }
    }
}
