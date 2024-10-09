using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// カメラにアタッチして使います
public class LookMove : MonoBehaviour
{
    public float x_sensitivity = 100f;
    public float y_sensitivity = 100f;
    Vector3 _targetPos;
    private Vector3 m_targetOffset = new Vector3(0, 0, 10);
    private GameObject m_camera;

    private float m_xRotate;
    private float m_yRotate;

    private void Start()
    {
        _targetPos = transform.position + m_targetOffset;
        m_camera = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        m_xRotate = Input.GetAxis("Horizontal") * x_sensitivity;
        m_yRotate = Input.GetAxis("Vertical") * y_sensitivity;
    }

    private void FixedUpdate()
    {
        //Debug.Log(Vector3.SignedAngle(new Vector3(m_targetOffset.x, 0, m_targetOffset.z), m_targetOffset, transform.right));

        float angle = Vector3.SignedAngle(new Vector3(m_targetOffset.x, 0, m_targetOffset.z), m_targetOffset, transform.right);

        // カメラの向きの制限
        if (angle > 80)
        {
            if (m_yRotate > 0)
            {
                m_yRotate = 0;
            }
            //Debug.Log("aaa");
        }
        if (angle < -80)
        {
            if (m_yRotate < 0)
            {
                m_yRotate = 0;
            }
            //Debug.Log("aaa");
        }

        // クオータニオン使う
        Quaternion quaternionX = Quaternion.AngleAxis(m_xRotate * Time.fixedDeltaTime, Vector3.up);
        // 自身の向きに合わせて上下の視点移動の軸は変えないといけないっぽい
        Quaternion quaternionY = Quaternion.AngleAxis(m_yRotate * Time.fixedDeltaTime, transform.right);

        m_targetOffset = quaternionX * m_targetOffset;
        m_targetOffset = quaternionY * m_targetOffset;
        // あとプレイヤーも回転
        transform.rotation *= quaternionX;

        // 計算結果をターゲットに反映
        _targetPos = transform.position + m_targetOffset;

        //Debug.Log(_targetPos);

        // Unityに
        m_camera.transform.LookAt(_targetPos);
    }
}
