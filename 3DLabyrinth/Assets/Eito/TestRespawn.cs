using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRespawn : MonoBehaviour
{
    private GameObject m_RespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        m_RespawnPoint = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RetryBoard")) // �ڐG�����I�u�W�F�N�g�̃^�O��RetryBoard�����r
        {
            // �ڐG�����I�u�W�F�N�g���\��
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Ball"))�@// �ڐG�����I�u�W�F�N�g�̃^�O��Ball�����r
        {
            // �ڐG�����I�u�W�F�N�g��\��
            other.gameObject.SetActive(true);
            other.gameObject.transform.position = m_RespawnPoint.transform.position; // �X�^�[�g�ʒu�ɖ߂�
        }
    }
}
