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
        // �ŏ��͌����Ȃ�
        m_text = GetComponent<TextMeshProUGUI>();
        m_text.enabled = false;
    }

    public void ShowText()
    {
        // ��莞�Ԃ��̃I�u�W�F�N�g��������悤�ɂ���
        // �o�ߌ�A�܂������ɂ���@
        StartCoroutine(ShowAndDisappear());
    }

    private IEnumerator ShowAndDisappear()
    {
        m_text.enabled = true;
        yield return m_wait;
        m_text.enabled = false;
    }
}
