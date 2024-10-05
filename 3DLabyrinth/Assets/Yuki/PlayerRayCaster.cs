using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRayCaster : MonoBehaviour
{
    private Image m_cursor;
    private Color m_red = new Color(1, 0, 0);
    private Color m_gray = new Color(0.8f, 0.8f, 0.8f);
    private Vector3 m_grabPosition = new Vector3(0.5f, -0.2f, 0.7f);
    private const float kThrowPower = 15f;

    // �����̏��
    private bool m_isGrabbingBall = false;
    public bool isCatchedCollider {  get; private set; }

    // ����L���X�g�ɓ����Ă���I�u�W�F�N�g
    private RaycastHit m_raycastHit;
    // �������Ă���Q�[���I�u�W�F�N�g
    private GameObject m_grabObject;
    void Start()
    {
        m_cursor = GameObject.Find("Cursor").GetComponent<Image>();
    }

    void FixedUpdate()
    {
        // �{�[��������
        Ray();

        // ���͂Ƃ� �l�X�g���C�ɓ���Ȃ������̂ő���return
        if (!Input.GetKeyDown("joystick button 0")) return;

        // ���łɃ{�[���������Ă�����
        if (m_isGrabbingBall)
        {
            // �������� �����Ȃ邩��֐���
            Throw();
            m_isGrabbingBall = false;
        }
        // �łȂ��āA���E�Ƀ{�[��������Ȃ�
        else if (isCatchedCollider)
        {
            // ���鏈��
            Grab();
            m_isGrabbingBall = true;
        }
    }

    private void Ray()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out m_raycastHit, 10);

        // �܂��Ώۂ͂Ȃ��Ƃ��čl����
        isCatchedCollider = false;
        m_cursor.color = m_gray;

        // �R���C�_�[��null�Ȃ�return
        if (m_raycastHit.collider == null) return;

        if (m_raycastHit.collider.tag == "Ball")
        {
            isCatchedCollider = true;
            m_cursor.color = m_red;
        }
    }

    private void Grab()
    {
        Debug.Log("����");
        // ���g�̃����o�ϐ��ɋL�^
        m_grabObject = m_raycastHit.collider.gameObject;
        // ���Ă�I�u�W�F�N�g�������̎q����
        // ���\�b�h�`�F�[������������
        m_grabObject.transform.SetParent(transform, true);
        // ���̃I�u�W�F�N�g�����̈ʒu�Ɉړ�(���ފ���)
        m_grabObject.transform.localPosition = m_grabPosition;
        // �I�u�W�F�N�g�̕������Z�𖳌�������
        m_grabObject.GetComponent<Rigidbody>().isKinematic = true;
        m_grabObject.GetComponent<SphereCollider>().enabled = false;
    }

    private void Throw()
    {
        Debug.Log("������");
        // ���������Ă��������𕜊�������
        m_grabObject.GetComponent<Rigidbody>().isKinematic = false;
        m_grabObject.GetComponent<SphereCollider>().enabled = true;
        // �e�q�֌W����
        m_grabObject.transform.SetParent(null);
        // ����(�J����)�̌�����AddForce
        m_grabObject.GetComponent<Rigidbody>()
            .AddForce(transform.forward * kThrowPower, ForceMode.Impulse);
    }
}
