using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// パネルを左右に移動させるだけ
public class TargetScript2 : MonoBehaviour
{
    private Vector3 targetPos;
    // 的の振れ幅(座標の値)
    private const float kTargetMoveWidth = 15.0f;
    private const float kTargetMoveHeight = 3.0f;
    private bool m_canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_canMove)
        transform.Translate(new Vector3 (Mathf.Sin(Time.time * 2) * kTargetMoveWidth * Time.fixedDeltaTime,
            0.0f, Mathf.Sin(Time.time * 5) * kTargetMoveHeight * Time.fixedDeltaTime)); // 左右移動
    }

    public void SetCanMove(bool value)
    {
        m_canMove = value;
    }
}
