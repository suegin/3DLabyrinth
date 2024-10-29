using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �p�l�������E�Ɉړ������邾��
public class TargetScript : MonoBehaviour
{
    private Vector3 targetPos;
    // �I�̐U�ꕝ(���W�̒l)
    private const float kTargetMoveWidth = 10.0f;
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
        transform.Translate(new Vector3 (Mathf.Cos(Time.time * 2) * kTargetMoveWidth * Time.fixedDeltaTime, 0.0f, 0.0f)); // ���E�ړ�
    }

    public void SetCanMove(bool value)
    {
        m_canMove = value;
    }
}