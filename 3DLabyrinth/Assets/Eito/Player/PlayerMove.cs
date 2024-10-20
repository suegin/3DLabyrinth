using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �ړ�����

    private float m_moveSpeed = 10f;

    private Vector3 m_inputAxis;

    private Rigidbody m_rigidbody;

    public static bool s_canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_inputAxis.x = Input.GetAxis("Horizontal");
        m_inputAxis.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // ���j���[���J���Ă����肵�Ă���Ƃ��ɓ������~�߂���
        if (!s_canMove)
        {
            m_rigidbody.velocity = Vector3.zero;
            return;
        }

        // ���������Ɏ����̌����ɂ��킹��AddForce����]��������
        // ���͂�1�ȏ�ɂȂ�Ȃ��悤�ɂ���
        if (m_inputAxis.sqrMagnitude > 1)
        {
            m_inputAxis.Normalize();
        }
        m_inputAxis *= m_moveSpeed;

        // �d�͈ȊO��ݒ�
        Vector3 power = new Vector3(m_inputAxis.x, m_rigidbody.velocity.y, m_inputAxis.z);
        power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        m_rigidbody.velocity = power;
    }
}
