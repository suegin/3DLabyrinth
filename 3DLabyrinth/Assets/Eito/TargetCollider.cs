using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
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
        if (other.CompareTag("Ball"))�@// �{�[��������������
        {
            door.isOpen = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))�@// �{�[��������������
        {
            door.isOpen = true;
        }
    }
}
