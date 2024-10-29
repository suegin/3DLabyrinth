using UnityEngine;

public class TestRespawn : MonoBehaviour
{
    private GameObject m_RespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        m_RespawnPoint = transform.GetChild(0).gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))�@// �ڐG�����I�u�W�F�N�g�̃^�O��Ball�����r
        {
            Respawn(other.gameObject);
        }
    }

    public void Respawn(GameObject obj)
    {
        // �e�q�֌W�����邩������Ȃ��̂ŉ������Ă���
        obj.transform.parent = null;
        // ���x��0�� RigidBody���Ȃ���͂Ȃ��͂�
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.transform.position = m_RespawnPoint.transform.position; // �X�^�[�g�ʒu�ɖ߂�
    }
}
