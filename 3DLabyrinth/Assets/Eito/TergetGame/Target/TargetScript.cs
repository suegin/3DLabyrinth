using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// パネルを左右に移動させるだけ
public class TargetScript : MonoBehaviour
{
    // 的の振れ幅(座標の値)
    private Vector3 m_initPos;
    private const float kTargetMoveWidth = 8.0f;
    private bool m_canMove = true;
    private int m_frameTimer = 0;
    // 何秒周期か
    private const float kCycle = 3;
    private const float kFactor = 360 / (50 * kCycle);

    private void Start()
    {
        m_initPos = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // これもうわかんねえな
        if (m_canMove)
        {
            m_frameTimer++;
            float rad = m_frameTimer * kFactor * Mathf.Deg2Rad;
            Debug.Log(rad);
            Vector3 pos = new Vector3(m_initPos.x , m_initPos.y,  m_initPos.z + Mathf.Cos(rad) * kTargetMoveWidth);
            // 向きに合わせて座標を変える
            transform.localPosition = pos;
        }
    }

    public void SetCanMove(bool value)
    {
        m_canMove = value;
    }
}
