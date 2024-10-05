using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ˆÚ“®‚·‚é

    private float x_sensitivity = 10f;
    private float y_sensitivity = 10f;

    private float m_xMove = 0;
    private float m_zMove = 0;

    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_xMove = Input.GetAxis("HorizontalLeft") * x_sensitivity;
        m_zMove = Input.GetAxis("VerticalLeft") * y_sensitivity * -1;
    }

    private void FixedUpdate()
    {
        // ‚¢‚¢Š´‚¶‚ÉŽ©•ª‚ÌŒü‚«‚É‚ ‚í‚¹‚ÄAddForce‚ð‰ñ“]‚³‚¹‚½‚¢
        //Debug.Log(transform.eulerAngles);
        Vector3 power = new Vector3(m_xMove, 0, m_zMove);
        power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        m_rigidbody.AddForce(power);
    }
}
