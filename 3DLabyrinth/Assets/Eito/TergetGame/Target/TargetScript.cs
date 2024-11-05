using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �p�l�������E�Ɉړ������邾��
public class TargetScript : MonoBehaviour
{
    // �I�̐U�ꕝ(���W�̒l)
    private Vector3 m_initPos;
    private const float kTargetMoveWidth = 8.0f;
    private bool m_canMove = true;
    private int m_frameTimer = 0;
    // ���b������
    private const float kCycle = 3;
    private const float kFactor = 360 / (50 * kCycle);

    private void Start()
    {
        m_initPos = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ��������킩��˂���
        if (m_canMove)
        {
            m_frameTimer++;
            float rad = m_frameTimer * kFactor * Mathf.Deg2Rad;
            Debug.Log(rad);
            Vector3 pos = new Vector3(m_initPos.x , m_initPos.y,  m_initPos.z + Mathf.Cos(rad) * kTargetMoveWidth);
            // �����ɍ��킹�č��W��ς���
            transform.localPosition = pos;
        }
    }

    public void SetCanMove(bool value)
    {
        m_canMove = value;
    }
}
