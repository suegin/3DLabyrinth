using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    public DoorScript door; // �h�A�X�N���v�g�Ƃ̘A��
    [SerializeField]
    private AudioClip m_targetSE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !door.isOpen)�@// ����̃{�[��������������
        {
            door.DoorOpen();
            // SE��炷
            SEGenerator.GenerateSEAtPoint(transform.position, m_targetSE);
            // ���ׂ̃X�N���v�g�Ɏ~�߂�Ǝw�����o��
            GetComponent<TargetScript>().SetCanMove(false);
        }
    }
}
