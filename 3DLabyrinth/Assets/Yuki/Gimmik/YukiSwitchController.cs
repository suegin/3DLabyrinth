using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiSwitchController : MonoBehaviour
{
    // �X�C�b�`(����)���I���Ȃ̂�
    public bool isOn { get; private set; } = false;

    // �����̃��b�V�������_���[
    private MeshRenderer m_meshRenderer;

    // �G�f�B�^�ŃI�b�P�[
    [SerializeField]
    private Material[] m_materials = new Material[2];

    // Start is called before the first frame update
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        ChangeSwitchState(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interect()
    {
        // ��ԃt���O�𔽓]����
        isOn = !isOn;
        ChangeSwitchState(isOn);
    }

    private void ChangeSwitchState(bool state)
    {
        // �����̏�Ԃɉ����ăf�[�^��ς���
        if (isOn)
        {
            // �I���̎��̏��
            transform.localPosition = Vector3.zero;
            m_meshRenderer.material = m_materials[0];
        }
        else
        {
            // �I�t�̎��̏��
            transform.localPosition = new Vector3(0, 2, 0);
            m_meshRenderer.material = m_materials[1];
        }
    }
}
