using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    float buttomY; // �{�^���̏�����Y���W
    float speed = 0.5f;�@// �{�^���̒��ރX�s�[�h
    bool isActive;�@// �{�^����������Ă��邩�ǂ����̃t���O
    public DoorScript door; // �h�A�X�N���v�g�Ƃ̘A��

    void Start()
    {
            
    }
    void Update()
    {
        if (isActive && transform.position.y > buttomY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y <= buttomY )
            {
                door.isOpen = true;
                enabled = false; // ���x��isOpen = true �ɂ��鏈�������s����Ȃ����߂̑΍�
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive && other.CompareTag("Player"))�@// �v���C���[�������������
        {
             isActive = true;
        }
    }
}