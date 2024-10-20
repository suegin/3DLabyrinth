using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �ړ�����
    private bool m_canMove = true;
    private float m_moveSpeed = 10f;

    private Vector3 m_inputAxis;

    private Rigidbody m_rigidbody;

    // �|�[�Y���Ɏ����̑��x���L�����Ă���
    private Vector3 m_pausedVelocity = Vector3.zero;

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
        // �����邩�ǂ���
        if (!m_canMove) return;

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

    public void Stop()
    {
        // ���j���[���J���Ă����肵�Ă���Ƃ��ɓ������~�߂���
        // ���x���L��
        m_pausedVelocity = m_rigidbody.velocity;
        // ���ۂ̑��x���[����
        m_rigidbody.useGravity = false;
        m_rigidbody.velocity = Vector3.zero;
        // �����܂��[��
        m_canMove = false;
    }

    public void Resume()
    {
        // �������ĊJ
        m_rigidbody.useGravity = true;
        m_rigidbody.velocity = m_pausedVelocity;
        // �L���͍폜
        m_pausedVelocity = Vector3.zero;
        // �����܁[��
        m_canMove = true;
    }
}
