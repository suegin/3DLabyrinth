using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRespawn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
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
            other.gameObject.transform.position = new Vector3(2, 0, -6); // �X�^�[�g�ʒu�ɖ߂�
        }
    }
}
