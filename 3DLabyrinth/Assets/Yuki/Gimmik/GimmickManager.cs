using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    // ����Ȗ��O�����Ǒ��d�������}�l�W�����g���܂���

    // ���t���[���ݒ肵��ToggleState�����I�u�W�F�N�g��bool�l���݂ē����悤�ɂ��悤��

    // List�`���[�֗���
    [SerializeField]
    List<ToggleState> m_observeObjects = new List<ToggleState>();

    // ���삷��I�u�W�F�N�g�Q
    Collider m_wallCollider;
    [SerializeField]
    List<YukiImpactSwitch> m_swiches = new List<YukiImpactSwitch>();

    bool m_clear = false;

    private void Start()
    {
        m_wallCollider = GameObject.Find("InvisibleWall").GetComponent<Collider>();
    }

    void Update()
    {
        // �����N���A�����Ȃ���s���Ȃ��Ă�����
        if (m_clear) return;

        if (CheckStates())
        {
            // �ʂ��悤�ɂ���
            m_wallCollider.enabled = false;
            foreach (var obj in m_swiches)
            {
                // �X�C�b�`���@�\���Ȃ�����
                obj.isActive = false;
            }
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
