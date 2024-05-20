using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float timeLimit = 60f; // 制限時間（秒）
    [SerializeField] TextMeshProUGUI timerText; // タイマー表示用のUIテキスト
    [SerializeField] EnemySpawner enemySpawner; // EnemySpawnerの参照

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float remainingTime = timeLimit - elapsedTime;
        if (remainingTime < 0)
        {
            remainingTime = 0;
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
            }
            Debug.Log("TimeUp");
            // 制限時間が終了したら何か処理を行う
        }

        // タイマー表示を更新
        timerText.text = "Time: " + remainingTime.ToString("F2");

        /*
        // 一定時間経過ごとに敵を出現させる処理
        if (elapsedTime >= 10f) // 例：10秒ごとに敵を出現させる
        {
            enemySpawner.SpawnEnemies();
            elapsedTime = 0f; // 経過時間をリセット
        }
        */
    }
}