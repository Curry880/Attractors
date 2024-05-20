using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMerge : MonoBehaviour
{
    [SerializeField] float sizeMultiplier = 1.1f; // 合体時のサイズ増加率
    [SerializeField] float speedMultiplier = 1.2f; // 合体時の速度増加率
    private PlayerMovement playerMovement;
    [SerializeField] bool canMerge = true;
    [SerializeField] int mergeCount = 0;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            playerMovement.IncreaseSpeed(speedMultiplier);
            transform.localScale *= sizeMultiplier;
            Debug.Log("Destroy:ItemPick");
            Destroy(collision.gameObject);
            mergeCount++;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Destroy:EnemyAtack");
            Destroy(collision.gameObject);
        }
    }
}
