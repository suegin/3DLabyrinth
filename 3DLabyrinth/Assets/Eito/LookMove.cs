using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// カメラにアタッチして使います
public class LookMove : MonoBehaviour
{
    private float x_sensitivity = 100f;
    private float y_sensitivity = 100f;
    Vector3 _targetPos;
    [SerializeField]
    GameObject m_target;

    // Update is called once per frame
    void Update()
    {
        _targetPos = m_target.transform.position;


        float x_mouse = Input.GetAxis("Horizontal") * x_sensitivity;
        float y_mouse = Input.GetAxis("Vertical") * y_sensitivity;

        // クオータニオン使う
        Quaternion quaternionX = Quaternion.AngleAxis(x_mouse * Time.deltaTime, transform.up);
        // 自身の向きに合わせて上下の視点移動の軸は変えないといけないっぽい
        Quaternion quaternionY = Quaternion.AngleAxis(y_mouse * Time.deltaTime, transform.right);

        _targetPos = quaternionX * _targetPos;
        _targetPos = quaternionY * _targetPos;

        // カメラの向きの
        //Debug.Log(Vector3.Angle(_targetPos, ));

        // 計算結果をターゲットに反映
        m_target.transform.position = _targetPos;

        // Unityに
        transform.LookAt(_targetPos);
    }
}
