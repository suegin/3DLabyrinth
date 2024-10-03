using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRayCaster : MonoBehaviour
{
    private Image m_cursor;
    private Color m_red = new Color(1, 0, 0);
    private Color m_gray = new Color(0.8f, 0.8f, 0.8f);

    // �����̏��
    private bool m_isGrabbingBall = false;
    public bool isCatchedCollider {  get; private set; }
    // Start is called before the first frame update
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

        if (m_isGrabbingBall)
        {
            // �������� �����Ȃ邩��֐���
            m_isGrabbingBall = false;
        }
        else if ()
        {
            // ���鏈��

        }
    }

    private void Ray()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10);

        // �܂��Ώۂ͂Ȃ��Ƃ��čl����
        isCatchedCollider = false;
        m_cursor.color = m_gray;

        // �R���C�_�[��null�Ȃ�return
        if (hit.collider == null) return;

        if (hit.collider.tag == "Ball")
        {
            isCatchedCollider = true;
            m_cursor.color = m_red;
        }
    }

    private void Catch()
    {

    }

    private void Grab()
    {

    }

    private void Throw()
    {

    }
}
