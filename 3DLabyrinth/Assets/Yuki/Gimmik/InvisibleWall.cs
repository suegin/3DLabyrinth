using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    // ���t���[���ݒ肵��ToggleState�����I�u�W�F�N�g��bool�l���݂ē����悤�ɂ��悤��

    // List�`���[�֗���
    [SerializeField]
    List<ToggleState> m_observeObjects = new List<ToggleState>();

    bool m_clear = false;

    void Update()
    {
        // �����N���A�����Ȃ���s���Ȃ��Ă�����
        if (m_clear) return;

        if (CheckStates())
        {
            // �ʂ��悤�ɂ���
            GetComponent<Collider>().enabled = false;
            m_clear = true;
        }
    }

    private bool CheckStates()
    {
        // �S��true�Ȃ�true��f��
        bool result = true;
        foreach (var obj in m_observeObjects)
        {
            result &= obj.state;
        }
        return result;
    }
}
