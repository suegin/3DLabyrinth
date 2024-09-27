using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �J�����ɃA�^�b�`���Ďg���܂�
public class LookMove : MonoBehaviour
{
    private float x_sensitivity = 1f;
    private float y_sensitivity = 1f;
    Vector3 _targetPos;
    [SerializeField]
    GameObject m_target;

    // Update is called once per frame
    void Update()
    {
        _targetPos = m_target.transform.position;


        float x_mouse = Input.GetAxis("Horizontal") * x_sensitivity;
        float y_mouse = Input.GetAxis("Vertical") * y_sensitivity;

        // �N�I�[�^�j�I���g��
        Quaternion quaternionX = Quaternion.AngleAxis(x_mouse, transform.up);
        // ���g�̌����ɍ��킹�ď㉺�̎��_�ړ��̎��͕ς��Ȃ��Ƃ����Ȃ����ۂ�
        Quaternion quaternionY = Quaternion.AngleAxis(y_mouse, transform.right);

        _targetPos = quaternionX * _targetPos;
        _targetPos = quaternionY * _targetPos;

        // �v�Z���ʂ��^�[�Q�b�g�ɔ��f
        m_target.transform.position = _targetPos;

        // Unity��
        transform.LookAt(_targetPos);
    }
}
