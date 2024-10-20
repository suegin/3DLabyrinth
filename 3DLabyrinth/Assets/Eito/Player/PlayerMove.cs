using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private bool m_canMove = true;

    private float m_moveSpeed = 10f;



    // private bool isRunning; // 移動しているかしていないかのフラグ
    // private AudioSource audioSource;


    private Rigidbody m_rigidbody;

    // �|�[�Y���Ɏ����̑��x���L�����Ă���
    private Vector3 m_pausedVelocity = Vector3.zero;

   // public AudioClip footStep; // 流す足音の設定

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
       // audioSource = GetComponent<AudioSource>();
       // isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        //m_inputAxis.x = Input.GetAxis("Horizontal");
        //m_inputAxis.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // �����邩�ǂ���
        if (!m_canMove) return;

        // いい感じに自分の向きにあわせてAddForceを回転させたい
        // 入力が1以上にならないようにする
        //if (m_inputAxis.sqrMagnitude > 1)
        //{
        //    m_inputAxis.Normalize();
        //}
        //m_inputAxis *= m_moveSpeed;

        // 重力以外を設定
        //Vector3 power = new Vector3(m_inputAxis.x, m_rigidbody.velocity.y, m_inputAxis.z);
        //power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        //m_rigidbody.velocity = power;
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
