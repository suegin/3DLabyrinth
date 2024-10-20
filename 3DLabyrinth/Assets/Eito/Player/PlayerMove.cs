using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 移動する

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
        // メニューが開いていたりしているときに動きを止めたい
        if (!s_canMove)
        {
            m_rigidbody.velocity = Vector3.zero;
            return;
        }

        // いい感じに自分の向きにあわせてAddForceを回転させたい
        // 入力が1以上にならないようにする
        if (m_inputAxis.sqrMagnitude > 1)
        {
            m_inputAxis.Normalize();
        }
        m_inputAxis *= m_moveSpeed;

        // 重力以外を設定
        Vector3 power = new Vector3(m_inputAxis.x, m_rigidbody.velocity.y, m_inputAxis.z);
        power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        m_rigidbody.velocity = power;
    }
}
