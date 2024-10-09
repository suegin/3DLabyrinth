using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettingManager : MonoBehaviour
{
    // このスクリプトはカメラの感度と音量を
    // スライダーに反映したり、スライダーの値の変化を見て感度に反映させたり
    // PlayerPrefsに記録したりします。

    // どこでも見れるやーつ
    public static float s_xSensitivity;
    public static float s_ySensitivity;
    public static float s_masterVolume;
    public static float s_bgmVolume;
    public static float s_seVolume;

    // このスクリプトでAudioMixerの操作もする
    [SerializeField]
    private AudioMixer m_audioMixer;

    private void Start()
    {
        // セーブデータから音量とカメラ感度を取得
        s_masterVolume = PlayerPrefs.GetFloat("Master", 0);
        s_bgmVolume = PlayerPrefs.GetFloat("BGM", 0);
        s_seVolume = PlayerPrefs.GetFloat("SE", 0);

        s_xSensitivity = PlayerPrefs.GetFloat("CameraX", 100);
        s_ySensitivity = PlayerPrefs.GetFloat("CameraY", 100);

        // 音量の各要素を反映
        m_audioMixer.SetFloat("Master_Volume", s_masterVolume);
        m_audioMixer.SetFloat("BGM_Volume", s_bgmVolume);
        m_audioMixer.SetFloat("SE_Volume", s_seVolume);

        // カメラ感度はこのスクリプトの変数が本体なので反映とかはない
    }

    // スライダーがアクセスする関数
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

    // 戻るボタンが押された時に現在の値をセーブ
    public void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat("Master", s_masterVolume);
        PlayerPrefs.SetFloat("BGM", s_bgmVolume);
        PlayerPrefs.SetFloat("SE", s_seVolume);
        PlayerPrefs.Save();
    }

    // カメラ感度変更
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
