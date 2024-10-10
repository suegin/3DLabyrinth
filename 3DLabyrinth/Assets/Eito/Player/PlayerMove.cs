using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ˆÚ“®‚·‚é

    private float x_sensitivity = 20f;
    private float y_sensitivity = 20f;

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
        m_xMove = Input.GetAxis("Horizontal") * x_sensitivity;
        m_zMove = Input.GetAxis("Vertical") * y_sensitivity;
    }

    private void FixedUpdate()
    {
        // ƒƒjƒ…[‚ªŠJ‚¢‚Ä‚¢‚½‚è‚µ‚Ä‚¢‚é‚Æ‚«‚É“®‚«‚ğ~‚ß‚½‚¢
        if (!s_canMove) return;

        // ‚¢‚¢Š´‚¶‚É©•ª‚ÌŒü‚«‚É‚ ‚í‚¹‚ÄAddForce‚ğ‰ñ“]‚³‚¹‚½‚¢
        //Debug.Log(transform.eulerAngles);
        Vector3 power = new Vector3(m_xMove, 0, m_zMove);
        power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        m_rigidbody.AddForce(power);
    }
}
