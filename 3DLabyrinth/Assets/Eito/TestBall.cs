using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    bool isActive;�@// �����������ǂ����̃t���O
    public DoorScript door; // �h�A�X�N���v�g�Ƃ̘A��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive && other.CompareTag("Ball"))�@// �{�[��������������
        {
            isActive = true;
            door.isOpen = true;
        }
    }
}
