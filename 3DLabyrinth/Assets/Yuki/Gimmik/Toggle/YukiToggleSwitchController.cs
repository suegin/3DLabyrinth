using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiToggleSwitchController : MonoBehaviour, ISwitch
{
    // ���̃X�C�b�`�́A�������Ώۂ�����̃I���I�t��Ԃ����ē���

    // �X�C�b�`(����)���I���Ȃ̂�
    public bool isOn { get; private set; } = false;

    // �����̃��b�V�������_���[
    private MeshRenderer m_meshRenderer;

    // �G�f�B�^�ŃI�b�P�[
    [SerializeField]
    private Material m_offMaterial;
    [SerializeField]
    private Material m_onMaterial;
    // ��x�I���ɂ�����A�I�t�ɂł��邩
    [SerializeField]
    private bool m_canTurnOff = false;

    // Start is called before the first frame update
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        ChangeSwitchState(isOn);
    }

    public void Interact()
    {
        if (isOn && !m_canTurnOff) return;

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
            m_meshRenderer.material = m_onMaterial;
        }
        else
        {
            // �I�t�̎��̏��
            transform.localPosition = new Vector3(0, 2, 0);
            m_meshRenderer.material = m_offMaterial;
        }
    }

    // �{�[���ŃX�C�b�`�I��
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Interact();
        }
    }
}
