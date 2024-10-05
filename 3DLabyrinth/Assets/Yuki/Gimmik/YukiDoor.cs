using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiDoor : MonoBehaviour
{
    // �G�f�B�^�Ŋ֘A�Â���X�C�b�`���w��
    [SerializeField]
    private List< YukiSwitchController> m_switches = new List<YukiSwitchController>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // �I���I�t�ŏ�����ς���
        if (CheckSwitches())
        {

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
