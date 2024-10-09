using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingVariable : MonoBehaviour
{
    // このスクリプトはカメラの感度と音量を
    // スライダーに反映したり、スライダーの値の変化を見て感度に反映させたり
    // PlayerPrefsに記録したりします。

    public static int s_xSensitivity;
    public static int s_ySensitivity;
    public static int s_masterVolume;
    public static int s_bgmVolume;
    public static int s_seVolume;
    public Slider m_audioSlider;

    private void Start()
    {
        // セーブデータから音量をカメラ感度を取得
        s_bgmVolume = PlayerPrefs.GetInt("BGM", 0);
    }
}
