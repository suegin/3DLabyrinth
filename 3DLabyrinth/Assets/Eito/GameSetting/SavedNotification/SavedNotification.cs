using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SavedNotification : MonoBehaviour
{
    private TextMeshProUGUI m_text;
    private WaitForSeconds m_wait = new WaitForSeconds(2);

    // Start is called before the first frame update
    void Start()
    {
        // 最初は見えない
        m_text = GetComponent<TextMeshProUGUI>();
        m_text.enabled = false;
    }

    public void ShowText()
    {
        // 一定時間このオブジェクトを見えるようにする
        // 経過後、また透明にする　
        StartCoroutine(ShowAndDisappear());
    }

    private IEnumerator ShowAndDisappear()
    {
        m_text.enabled = true;
        yield return m_wait;
        m_text.enabled = false;
    }
}
