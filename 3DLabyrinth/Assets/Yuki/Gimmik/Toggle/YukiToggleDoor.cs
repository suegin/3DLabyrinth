using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiToggleDoor : MonoBehaviour
{
    // �G�f�B�^�Ŋ֘A�Â���X�C�b�`���w��
    [SerializeField]
    private List< YukiToggleSwitchController> m_switches = new List<YukiToggleSwitchController>();

    private Vector3 m_speed = new Vector3(0, 1, 0);

    private Vector3 m_initPos;

    private void Start()
    {
        // �ŏ��̎����̈ʒu
        m_initPos = transform.position;
    }

    void FixedUpdate()
    {
        // �I���I�t�ŏ�����ς���
        if (CheckSwitches())
        {
            // �͈͂Ɏ��߂�
            if (transform.position.y < m_initPos.y + 7)
            {
                transform.Translate(m_speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if (transform.position.y > m_initPos.y)
            {
                transform.Translate(-m_speed * Time.fixedDeltaTime);
            }
        }
    }

    private bool CheckSwitches()
    {
        // ���X�g�̑S�X�C�b�`�����Ĉ�ł��I���Ȃ牶��Ԃ�
        foreach(var sw in m_switches)
        {
            if (sw.isOn)
            {
                return true;
            }
        }
        return false;
    }
}
