using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YukiFadeManager : MonoBehaviour
{
    // �悭����t�F�[�h�C���A�E�g�̏���

    private static CanvasGroup m_fadePanel;

    // Start is called before the first frame update
    void Start()
    {
        m_fadePanel = GetComponent<CanvasGroup>();
    }

    public static IEnumerator FadeIn(float time)
    {
        // time�b�ŃA���t�@��1����悤��
        float alphaValue = 1 / time; 

        // �����x������
        while (m_fadePanel.alpha > 0)
        {
            m_fadePanel.alpha -= alphaValue;
            yield return null;
        }
    }

    public static IEnumerator FadeOut(float time)
    {
        // time�b�ŃA���t�@��1������悤��
        float alphaValue = 1 / time;

        // �����x������
        while (m_fadePanel.alpha < 1)
        {
            m_fadePanel.alpha += alphaValue;
            yield return null;
        }
    }
}
