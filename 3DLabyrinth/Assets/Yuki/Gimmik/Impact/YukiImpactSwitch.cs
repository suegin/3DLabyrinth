using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class YukiImpactSwitch : MonoBehaviour, ISwitch
{
    // �g�O���ƈႢ�A�X�C�b�`���̂��I���I�t�̏�Ԃ��Ƃ炸�A�ݒ肵���I�u�W�F�N�g�̃I���I�t��������
    // ������C���p�N�g�X�C�b�`�ƌĂڂ��@

    [SerializeField]
    private List<ToggleState> m_objects = new List<ToggleState>(); 

    // ���g�̃��b�V�������_���[
    //private Renderer m_renderer;

    [SerializeField]
    private Material m_onMaterial;
    [SerializeField]
    private Material m_offMaterial;

    private void Start()
    {
        //m_renderer = GetComponent<MeshRenderer>();
    }

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

        // ���g�̐F��ς���A�j���[�V����
        // ���
    }
}
