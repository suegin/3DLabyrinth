using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 移動する

    private float m_moveSpeedX = 10f;
    private float m_moveSpeedZ = 10f;

    private float m_xMove = 0;
    private float m_zMove = 0;

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
        m_xMove = Input.GetAxis("Horizontal") * m_moveSpeedX;
        m_zMove = Input.GetAxis("Vertical") * m_moveSpeedZ;
    }

    private void FixedUpdate()
    {
        // メニューが開いていたりしているときに動きを止めたい
        if (!s_canMove) return;

        // いい感じに自分の向きにあわせてAddForceを回転させたい
        //Debug.Log(transform.eulerAngles);
        Vector3 power = new Vector3(m_xMove, 0, m_zMove);
        power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        m_rigidbody.velocity = power;
    }
}
