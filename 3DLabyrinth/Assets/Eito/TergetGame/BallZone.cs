using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallZone : MonoBehaviour
{
    private TestRespawn m_testRespawn;
    private PlayerRayCaster m_playerRay;

    private void Start()
    {
        m_testRespawn = transform.parent.GetComponent<TestRespawn>();
        m_playerRay = GameObject.Find("Main Camera").GetComponent<PlayerRayCaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("�{�[��������");
        }
    }

    // �{�[�����o������Ƃɖ߂�
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("�{�[���o�Ă�");
            // �v���C���[���{�[���������Ă�����A���Ƃ�����
            if (m_playerRay.m_isGrabbingBall)
            {
                m_playerRay.Drop();
            }
            m_testRespawn.Respawn(other.gameObject);
        }
    }
}
