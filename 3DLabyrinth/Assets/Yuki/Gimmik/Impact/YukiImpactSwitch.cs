using System.Collections.Generic;
using UnityEngine;

public class YukiImpactSwitch : MonoBehaviour, ISwitch
{
    // �g�O���ƈႢ�A�X�C�b�`���̂��I���I�t�̏�Ԃ��Ƃ炸�A�ݒ肵���I�u�W�F�N�g�̃I���I�t��������
    // ������C���p�N�g�X�C�b�`�ƌĂڂ��@

    [SerializeField]
    private List<ToggleState> m_objects = new List<ToggleState>(); 

    // �{�[�����������Ă�Interact�����s
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Interact();
        }
    }

    public void Interact()
    {
        // ���̃X�C�b�`�Ɏw�肳�ꂽ���ׂẴI�u�W�F�N�g�̃X�e�[�g�𔽓]
        foreach (var obj in m_objects)
        {
            obj.state = !obj.state;
        }

        // ���g�̃O���t�B�b�N��������ƃA�j���[�V��������

        // ���
    }
}
