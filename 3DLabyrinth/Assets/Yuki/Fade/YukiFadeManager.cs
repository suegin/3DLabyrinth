using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YukiFadeManager : MonoBehaviour
{
    // よくあるフェードインアウトの処理

    private static CanvasGroup m_fadePanel;

    private const int kApplicationFrameRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        m_fadePanel = GetComponent<CanvasGroup>();
    }

    public static IEnumerator FadeIn(float time)
    {
        // time秒でアルファが1減るように
        float alphaValue = 1.0f / kApplicationFrameRate / time; 

        // 透明度下げる
        while (m_fadePanel.alpha > 0)
        {
            m_fadePanel.alpha -= alphaValue;
            yield return null;
        }
    }

    public static IEnumerator FadeOut(float time)
    {
        // time秒でアルファが1増えるように
        float alphaValue = 1.0f / kApplicationFrameRate / time;

        // 透明度上げる
        while (m_fadePanel.alpha < 1)
        {
            m_fadePanel.alpha += alphaValue;
            yield return null;
        }
    }
}
