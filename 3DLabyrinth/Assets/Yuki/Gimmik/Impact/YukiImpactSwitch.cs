// IEnumerator���������݂����̂ŁA�������̂ق����킩��₷�����ȁ[���Ɓ@�v���܂���
using ListCollection = System.Collections.Generic;
using Coroutine = System.Collections;
using UnityEngine;
using System.Runtime.CompilerServices;

public class YukiImpactSwitch : MonoBehaviour, ISwitch
{
    // �g�O���ƈႢ�A�X�C�b�`���̂��I���I�t�̏�Ԃ��Ƃ炸�A�ݒ肵���I�u�W�F�N�g�̃I���I�t��������
    // ������C���p�N�g�X�C�b�`�ƌĂڂ��@

    [SerializeField]
    private ListCollection.List<ToggleState> m_objects = new ListCollection.List<ToggleState>();

    // ���g�̃��b�V�������_���[
    private Renderer m_renderer;

    private Material m_onMaterial;
    private Material m_offMaterial;
    [SerializeField]
    private AudioClip m_doorSE;

    // ����ł��邩�ǂ���
    public bool isActive = true;

    private void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();
        // ����͂߂�ǂ��̂Ń��[�h
        m_onMaterial = (Material)Resources.Load("DarkGreen");
        m_offMaterial = (Material)Resources.Load("Green");
    }

    // �{�[�����������Ă�Interact�����s
    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive) return;

        if (collision.gameObject.tag == "Ball")
        {
            Interact();
        }
    }

    public void Interact()
    {
        // �A�N�e�B�u�Ȃ�
        if (!isActive) return;

        // ���̃X�C�b�`�Ɏw�肳�ꂽ���ׂẴI�u�W�F�N�g�̃X�e�[�g�𔽓]
        foreach (var obj in m_objects)
        {
            obj.SetState(!obj.GetState(), m_doorSE);
        }

        // �F��������ƕς��āA���ɖ߂�
        // ����ς�DOTWeen�ł͂ł��Ȃ��̂ŃR���[�`����
        StartCoroutine(ChangeColor(0.5f));
    }

    private Coroutine.IEnumerator ChangeColor(float time)
    {
        // �F��ς���
        m_renderer.material = m_onMaterial;
        yield return new WaitForSeconds(time);
        m_renderer.material = m_offMaterial;
    }
}