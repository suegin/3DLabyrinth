using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    // Ç›ÇÒÇ»ëÂçDÇ´static
    public static CoinText instance;
    private static TextMeshProUGUI m_text;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        SetTextNum(0);
    }

    public static void SetTextNum(int value)
    {
        m_text.text = value.ToString();
    }
}
