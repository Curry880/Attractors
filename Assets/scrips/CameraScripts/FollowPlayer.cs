using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player; // プレイヤーのTransform
    [SerializeField] float smoothTime = 0.3f; // カメラのスムーズさ
    [SerializeField] float maxOffset = 2f; // 最大オフセット距離
    [SerializeField] float speedThreshold = 5f; // プレイヤーの速度しきい値

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // プレイヤーの速度を取得
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        float playerSpeed = rb.velocity.magnitude;

        // プレイヤーの速度がしきい値以上の場合、オフセットを適用
        Vector3 targetPosition = player.position;
        
        if (playerSpeed > speedThreshold)
        {
            Vector3 offset = rb.velocity.normalized * maxOffset;
            targetPosition += new Vector3(offset.x, offset.y, 0);
        }
        

        // カメラのスムーズな移動
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //z座標は固定値
        newPosition.z = -10f;
        transform.position = newPosition;
    }
}