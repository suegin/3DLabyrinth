using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchNumTextController : MonoBehaviour
{
    private TextMeshPro m_text;
    private int m_num;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshPro>();
        ShowText();
    }

    private void ShowText()
    {
        m_text.text = m_num.ToString();
    }

    public void DecreaseText()
    {
        --m_num;
        ShowText();
    }
    public void IncreaseText()
    {
        ++m_num;
        ShowText();
    }
}
