using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �J�����ɃA�^�b�`���Ďg���܂�
public class LookMove : MonoBehaviour
{
    private float x_sensitivity = 100f;
    private float y_sensitivity = 100f;
    Vector3 _targetPos;
    [SerializeField]
    GameObject m_target;
    private Vector3 m_targetOffset = new Vector3(0, 0, 10);
    private GameObject m_camera;

    private void Start()
    {
        _targetPos = transform.position + m_targetOffset;
        m_camera = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // ������]�ł��Ȃ��p�x�ɂȂ����Ƃ��ɖ߂��p�̈ʒu��ێ�
        Vector3 tempPos = _targetPos;

        float x_mouse = Input.GetAxis("Horizontal") * x_sensitivity;
        float y_mouse = Input.GetAxis("Vertical") * y_sensitivity;

        // �N�I�[�^�j�I���g��
        Quaternion quaternionX = Quaternion.AngleAxis(x_mouse * Time.deltaTime, Vector3.up);
        // ���g�̌����ɍ��킹�ď㉺�̎��_�ړ��̎��͕ς��Ȃ��Ƃ����Ȃ����ۂ�
        Quaternion quaternionY = Quaternion.AngleAxis(y_mouse * Time.deltaTime, transform.right);

        m_targetOffset = quaternionX * m_targetOffset;
        m_targetOffset = quaternionY * m_targetOffset;
        // ���ƃv���C���[����]
        transform.rotation *= quaternionX;

        // �v�Z���ʂ��^�[�Q�b�g�ɔ��f
        _targetPos = transform.position + m_targetOffset;

        // �J�����̌����̐���
        if (Vector3.Angle(_targetPos, new Vector3(m_targetOffset.x, 0, m_targetOffset.z)) > 80)
        {
            //_targetPos = new Vector3(_targetPos.x, tempPos.y, _targetPos.z);
        }

        Debug.Log(_targetPos);

        // Unity��
        m_camera.transform.LookAt(_targetPos);
    }
}
