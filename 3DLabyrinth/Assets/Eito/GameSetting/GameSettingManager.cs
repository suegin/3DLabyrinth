using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettingManager : MonoBehaviour
{
    // ���̃X�N���v�g�̓J�����̊��x�Ɖ��ʂ�
    // �X���C�_�[�ɔ��f������A�X���C�_�[�̒l�̕ω������Ċ��x�ɔ��f��������
    // PlayerPrefs�ɋL�^�����肵�܂��B

    // �ǂ��ł�������[��
    public static float s_xSensitivity;
    public static float s_ySensitivity;
    public static float s_masterVolume;
    public static float s_bgmVolume;
    public static float s_seVolume;

    // ���̃X�N���v�g��AudioMixer�̑��������
    [SerializeField]
    private AudioMixer m_audioMixer;

    private void Start()
    {
        // �Z�[�u�f�[�^���特�ʂƃJ�������x���擾
        s_masterVolume = PlayerPrefs.GetFloat("Master", 0);
        s_bgmVolume = PlayerPrefs.GetFloat("BGM", 0);
        s_seVolume = PlayerPrefs.GetFloat("SE", 0);

        s_xSensitivity = PlayerPrefs.GetFloat("CameraX", 100);
        s_ySensitivity = PlayerPrefs.GetFloat("CameraY", 100);

        // ���ʂ̊e�v�f�𔽉f
        m_audioMixer.SetFloat("Master_Volume", s_masterVolume);
        m_audioMixer.SetFloat("BGM_Volume", s_bgmVolume);
        m_audioMixer.SetFloat("SE_Volume", s_seVolume);

        // �J�������x�͂��̃X�N���v�g�̕ϐ����{�̂Ȃ̂Ŕ��f�Ƃ��͂Ȃ�
    }

    // �X���C�_�[���A�N�Z�X����֐�
    public void ChangeMasterVolume(float value)
    {
        m_audioMixer.SetFloat("Master_Volume", value);
        s_masterVolume = value;
    }

    public void ChangeBGMVolume(float value)
    {
        m_audioMixer.SetFloat("BGM_Volume", value);
        s_bgmVolume = value;
    }

    public void ChangeSEVolume(float value)
    {
        m_audioMixer.SetFloat("SE_Volume", value);
        s_seVolume = value;
    }

    // �߂�{�^���������ꂽ���Ɍ��݂̒l���Z�[�u
    public void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat("Master", s_masterVolume);
        PlayerPrefs.SetFloat("BGM", s_bgmVolume);
        PlayerPrefs.SetFloat("SE", s_seVolume);
        PlayerPrefs.Save();
    }

    // �J�������x�ύX
    public void ChangeXSensitivity(float value)
    {
        s_xSensitivity = value;
    }

    public void ChangeYSensitivity(float value)
    {
        s_ySensitivity = value;
    }

    public void SaveCameraSettings()
    {
        PlayerPrefs.SetFloat("CameraX", s_xSensitivity);
        PlayerPrefs.SetFloat("CameraY", s_ySensitivity);
        PlayerPrefs.Save();
    }
}
