using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player; // �v���C���[��Transform
    [SerializeField] float smoothTime = 0.3f; // �J�����̃X���[�Y��
    [SerializeField] float maxOffset = 2f; // �ő�I�t�Z�b�g����
    [SerializeField] float speedThreshold = 5f; // �v���C���[�̑��x�������l

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // �v���C���[�̑��x���擾
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        float playerSpeed = rb.velocity.magnitude;

        // �v���C���[�̑��x���������l�ȏ�̏ꍇ�A�I�t�Z�b�g��K�p
        Vector3 targetPosition = player.position;
        
        if (playerSpeed > speedThreshold)
        {
            Vector3 offset = rb.velocity.normalized * maxOffset;
            targetPosition += new Vector3(offset.x, offset.y, 0);
        }
        

        // �J�����̃X���[�Y�Ȉړ�
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //z���W�͌Œ�l
        newPosition.z = -10f;
        transform.position = newPosition;
    }
}