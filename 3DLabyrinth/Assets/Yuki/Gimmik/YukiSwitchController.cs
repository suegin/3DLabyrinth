using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiSwitchController : MonoBehaviour
{
    // �X�C�b�`(����)���I���Ȃ̂�
    private bool m_isOn = false;

    // �����̃��b�V�������_���[
    private MeshRenderer m_meshRenderer;

    // �G�f�B�^�ŃI�b�P�[
    [SerializeField]
    Material[] m_materials = new Material[2];

    // Start is called before the first frame update
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        ChangeSwitchState(m_isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interect()
    {
        // ��ԃt���O�𔽓]����
        m_isOn = !m_isOn;
        ChangeSwitchState(m_isOn);
    }

    private void ChangeSwitchState(bool state)
    {
        // �����̏�Ԃɉ����ăf�[�^��ς���
        if (m_isOn)
        {
            // �I���̎��̏��
            m_meshRenderer.material = m_materials[0];
            transform.localPosition += new Vector3(0, 2, 0);
        }
        else
        {
            // �I�t�̎��̏��
            m_meshRenderer.material = m_materials[1];
        }
    }
}
