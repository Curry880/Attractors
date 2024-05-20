using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float timeLimit = 60f; // �������ԁi�b�j
    [SerializeField] TextMeshProUGUI timerText; // �^�C�}�[�\���p��UI�e�L�X�g
    [SerializeField] EnemySpawner enemySpawner; // EnemySpawner�̎Q��

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
            // �������Ԃ��I�������牽���������s��
        }

        // �^�C�}�[�\�����X�V
        timerText.text = "Time: " + remainingTime.ToString("F2");

        /*
        // ��莞�Ԍo�߂��ƂɓG���o�������鏈��
        if (elapsedTime >= 10f) // ��F10�b���ƂɓG���o��������
        {
            enemySpawner.SpawnEnemies();
            elapsedTime = 0f; // �o�ߎ��Ԃ����Z�b�g
        }
        */
    }
}