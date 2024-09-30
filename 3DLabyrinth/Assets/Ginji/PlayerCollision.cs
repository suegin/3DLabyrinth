using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // �I�u�W�F�N�g���Փ˂����Ƃ�
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter: " + collision.gameObject.name);
    }

    // �I�u�W�F�N�g�����ꂽ��
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit: " + collision.gameObject.name);
    }

    // �I�u�W�F�N�g���G��Ă����
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Stay: " + collision.gameObject.name);
    }

    /* �I�u�W�F�N�g���m�̏d�Ȃ蔻�� */
    // �I�u�W�F�N�g���d�Ȃ����Ƃ�
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.gameObject.name);
    }

    // �I�u�W�F�N�g�����ꂽ��
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit: " + other.gameObject.name);
    }

    // �I�u�W�F�N�g���d�Ȃ��Ă����
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay: " + other.gameObject.name);
    }
}
