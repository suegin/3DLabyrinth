using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingVariable : MonoBehaviour
{
    // ���̃X�N���v�g�̓J�����̊��x�Ɖ��ʂ�
    // �X���C�_�[�ɔ��f������A�X���C�_�[�̒l�̕ω������Ċ��x�ɔ��f��������
    // PlayerPrefs�ɋL�^�����肵�܂��B

    public static int s_xSensitivity;
    public static int s_ySensitivity;
    public static int s_masterVolume;
    public static int s_bgmVolume;
    public static int s_seVolume;
    public Slider m_audioSlider;

    private void Start()
    {
        // �Z�[�u�f�[�^���特�ʂ��J�������x���擾
        s_bgmVolume = PlayerPrefs.GetInt("BGM", 0);
    }
}
