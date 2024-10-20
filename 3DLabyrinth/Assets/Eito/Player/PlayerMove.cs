using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 移動する
    private bool m_canMove = true;
    private float m_moveSpeed = 10f;

    private Vector3 m_inputAxis;

    private Rigidbody m_rigidbody;

    // ポーズ時に自分の速度を記憶しておく
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
        // 動けるかどうか
        if (!m_canMove) return;

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

    public void Stop()
    {
        // メニューが開いていたりしているときに動きを止めたい
        // 速度を記憶
        m_pausedVelocity = m_rigidbody.velocity;
        // 実際の速度をゼロに
        m_rigidbody.useGravity = false;
        m_rigidbody.velocity = Vector3.zero;
        // 動けませーン
        m_canMove = false;
    }

    public void Resume()
    {
        // 動きを再開
        m_rigidbody.useGravity = true;
        m_rigidbody.velocity = m_pausedVelocity;
        // 記憶は削除
        m_pausedVelocity = Vector3.zero;
        // 動けまーす
        m_canMove = true;
    }
}
