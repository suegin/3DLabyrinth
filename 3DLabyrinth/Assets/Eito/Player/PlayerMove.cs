using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �ړ�����

    private float x_sensitivity = 20f;
    private float y_sensitivity = 20f;

    private float m_xMove = 0;
    private float m_zMove = 0;�@

   // private bool isRunning; // �ړ����Ă��邩���Ă��Ȃ����̃t���O
   // private AudioSource audioSource;

    private Rigidbody m_rigidbody;

    public static bool s_canMove = true;

   // public AudioClip footStep; // ���������̐ݒ�

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
        m_xMove = Input.GetAxis("Horizontal") * x_sensitivity;
        m_zMove = Input.GetAxis("Vertical") * y_sensitivity;
    }

    private void FixedUpdate()
    {
        // ���j���[���J���Ă����肵�Ă���Ƃ��ɓ������~�߂���
        if (!s_canMove) return;

        // ���������Ɏ����̌����ɂ��킹��AddForce����]��������
        //Debug.Log(transform.eulerAngles);
        Vector3 power = new Vector3(m_xMove, 0, m_zMove);
        power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        m_rigidbody.AddForce(power);
    }
}
