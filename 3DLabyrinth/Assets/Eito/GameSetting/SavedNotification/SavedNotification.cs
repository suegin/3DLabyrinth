using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SavedNotification : MonoBehaviour
{
    private CanvasGroup m_group;
    private WaitForSeconds m_wait = new WaitForSeconds(2);

    // Start is called before the first frame update
    void Start()
    {
        // 最初は見えない
        m_group = GetComponent<CanvasGroup>();
        m_group.alpha = 0;
    }

    public void ShowText()
    {
        // 一定時間このオブジェクトを見えるようにする
        // 経過後、また透明にする　
        StartCoroutine(ShowAndDisappear());
    }

    private IEnumerator ShowAndDisappear()
    {
        m_group.alpha = 1;
        yield return m_wait;
        m_group.alpha = 0;
    }
}
