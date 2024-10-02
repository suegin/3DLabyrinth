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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_xMove = Input.GetAxis("HorizontalLeft") * x_sensitivity;
        m_zMove = Input.GetAxis("VerticalLeft") * y_sensitivity * -1;
    }

    private void FixedUpdate()
    {
        Debug.Log(m_xMove);
        transform.Translate(m_xMove * Time.fixedDeltaTime, 0, m_zMove * Time.fixedDeltaTime);
    }
}
