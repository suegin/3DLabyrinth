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
        // �ŏ��͌����Ȃ�
        m_group = GetComponent<CanvasGroup>();
        m_group.alpha = 0;
    }

    public void ShowText()
    {
        // ��莞�Ԃ��̃I�u�W�F�N�g��������悤�ɂ���
        // �o�ߌ�A�܂������ɂ���@
        StartCoroutine(ShowAndDisappear());
    }

    private IEnumerator ShowAndDisappear()
    {
        m_group.alpha = 1;
        yield return m_wait;
        m_group.alpha = 0;
    }
}
