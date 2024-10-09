using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderOnEnable : MonoBehaviour
{
    // スライダーがアクティブになった時、
    // 設定の値にスライダーの位置をあわせるためのスクリプト

    private Slider m_slider;
    private void Awake()
    {
        m_slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        float resultValue = 0.0f;
        // 汚いけどこれでよいのです
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
                throw new System.Exception("なんかオブジェクトの名前とか間違えてんじゃね");
                // ここから先は実行されないのでbreakもなし
        }
        m_slider.value = resultValue;
    }
}
