using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderOnEnable : MonoBehaviour
{
    // �X���C�_�[���A�N�e�B�u�ɂȂ������A
    // �ݒ�̒l�ɃX���C�_�[�̈ʒu�����킹�邽�߂̃X�N���v�g

    private Slider m_slider;
    private void Awake()
    {
        m_slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        float resultValue = 0.0f;
        // �������ǂ���ł悢�̂ł�
        switch (name)
        {
            case "Master":
                resultValue = GameSettingManager.s_masterVolume;
                break;
            case "BGM":
                resultValue = GameSettingManager.s_bgmVolume;
                break;
            case "SE":
                resultValue = GameSettingManager.s_seVolume;
                break;
            case "Horizontal":
                resultValue = GameSettingManager.s_xSensitivity;
                break;
            case "Vertical":
                resultValue = GameSettingManager.s_ySensitivity;
                break;
            default:
                throw new System.Exception("�Ȃ񂩃I�u�W�F�N�g�̖��O�Ƃ��ԈႦ�Ă񂶂��");
                // ���������͎��s����Ȃ��̂�break���Ȃ�
        }
        m_slider.value = resultValue;
    }
}
