using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    float defaultY;     // ���̏�����Y���W
    float openY = 5f;   // ���̃I�[�v������Y���W
    float speed = 1f;   // ���̊J�̃X�s�[�h

    public bool isOpen; // �����J���邩�߂邩�̃t���O

    void Start()
    {
        defaultY = transform.position.y;
    }

    void Update()
    {
        if (isOpen && transform.position.y < openY)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (!isOpen && transform.position.y > defaultY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
    }
}