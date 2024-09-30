using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    float bottomY; // �{�^���̏�����Y���W
    float speed = 0.5f;�@// �{�^���̒��ރX�s�[�h

    bool active;�@// �{�^���������ꂽ��������ĂȂ����̃t���O

    public DoorScript door; // �h�A�X�N���v�g�Ƃ̘A��
    void Update()
    {
        if (active && transform.position.y > bottomY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y <= bottomY )
            {
                door.isOpen = true;
                enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active && other.CompareTag("Player"))�@// �v���C���[�������������
        {
            active = true;
        }
    }
}