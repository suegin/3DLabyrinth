using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image fadePanel;             // �t�F�[�h�p��UI�p�l��
    public float fadeTime = 1.0f;   // �t�F�[�h�̊����ɂ����鎞��
    public bool isFade = false;
    private void Start()
    {
        
    }
    public void ChangeScene()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }
    public IEnumerator FadeOutAndLoadScene()
    {
        fadePanel.enabled = true;                 // �p�l����L����
        float elapsedTime = 0.0f;                 // �o�ߎ��Ԃ�������
        Color startColor = fadePanel.color;       // �t�F�[�h�p�l���̊J�n�F���擾
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // �t�F�[�h�p�l���̍ŏI�F��ݒ�

        // �t�F�[�h�A�E�g�A�j���[�V���������s
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;                        // �o�ߎ��Ԃ𑝂₷
            float t = Mathf.Clamp01(elapsedTime / fadeTime);  // �t�F�[�h�̐i�s�x���v�Z
            fadePanel.color = Color.Lerp(startColor, endColor, t); // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
            yield return null;                                     // 1�t���[���ҋ@
        }

        isFade = true;
        Debug.Log(isFade);
        fadePanel.color = endColor;  // �t�F�[�h������������ŏI�F�ɐݒ�
    }
}
