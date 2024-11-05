using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// パネルを左右に移動させるだけ
public class TargetScript2 : MonoBehaviour
{
    private Vector3 m_initPos;
    // 的の振れ幅(座標の値)
    private const float kTargetMoveWidth = 8.0f;
    private const float kTargetMoveHeight = 1.0f;
    private bool m_canMove = true;
    private int m_frameTimer = 0;
    // 何秒周期か
    private const float kCycle = 3;
    private const float kFactor = 360 / (50 * kCycle);

    // Start is called before the first frame update
    void Start()
    {
        m_initPos = transform.position;
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
            Vector3 pos = new Vector3(m_initPos.x + Mathf.Cos(rad) * kTargetMoveWidth,
                m_initPos.y + Mathf.Cos(rad * 5) * kTargetMoveHeight,
                m_initPos.z);
            // 向きに合わせて座標を変える
            transform.localPosition = pos;
        }
    }

    public void SetCanMove(bool value)
    {
        m_canMove = value;
    }
}
