using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

// �I�[�v�j���O�͂��̃X�N���v�g�����Ŋ���������

public class OpeningController : MonoBehaviour
{
    // �V�[�����n�܂�����e�L�X�g��\������
    // ��莞�Ԃ�������t�F�[�h���Ď��̃e�L�X�g��\���c��������
    // ��莞�ԗ����AA�{�^���������Ă����ɐi�ށ@

    private string[] m_texts =
    {
        "�e�X�g",
        "�I�[�v�j���O�̕�����\���ł��܂�",
        "���s�ł������܂�",
        "���͏I�����ɃV�[�������[�h���邯��",
        "�f���Q�[�g�Ŕėp�������߂���Ǝv��"
    };

    private CanvasGroup m_canvasGroup;
    private TextMeshProUGUI m_text;
    // �t�F�[�h�C���A�E�g�̎���
    private const float kTextFadeTime = 1.5f;
    // �e�L�X�g����̊Ԋu
    private const float kNextTextTime = 3.0f;
    // �^�C�}�[
    private float m_timer;
    // ���̃e�L�X�g�̒ʂ��ԍ�
    private int m_textNum = 0;

    // �L�����ǂ���
    private bool m_enabled = true;

    private void Start()
    {
        Application.targetFrameRate = 60;

        // ���낢��擾
        m_canvasGroup = GetComponent<CanvasGroup>();
        m_text = GetComponent<TextMeshProUGUI>();
        SetText();

        // �z��̗v�f����1���琔����
        //Debug.Log(m_texts.Length);

        // �t�F�[�h
        StartCoroutine(YukiFadeManager.FadeIn(1.0f));
    }

    // Update is called once per frame
    private void Update()
    {
        // �L�����ǂ���
        if (!m_enabled) return;

        // �^�C�}�[���Z
        m_timer += Time.deltaTime;

        // �����ňꌳ�Ǘ����ē��͂Ƃ�
        bool pushedAnyButton = Input.anyKeyDown;

        if (m_timer < kTextFadeTime)
        {
            //Debug.Log($"{m_texts[m_textNum]}, �t�F�[�h�C����");
            // �t�F�[�h�C���̒i�K
            // ����Z���
            m_canvasGroup.alpha += Time.deltaTime / kTextFadeTime;
            // �����œ��͂���������A�����I�Ƀ^�C�}�[��1.0f��
            if (pushedAnyButton)
            {
                m_timer = kTextFadeTime;
                m_canvasGroup.alpha = 1.0f;
            }
        }
        else if (m_timer < kTextFadeTime + kNextTextTime)
        {
            //Debug.Log($"{m_texts[m_textNum]}, �ҋ@");
            // ���S�ɕs�����őҋ@���鎞��
            // ���͂Ńt�F�[�h�A�E�g�Ɉڍs
            if (pushedAnyButton)
            {
                m_timer = kTextFadeTime + kNextTextTime;
            }
        }
        else if (m_timer < kTextFadeTime * 2 + kNextTextTime)
        {
            //Debug.Log($"{m_texts[m_textNum]}, �A�E�g");
            // �t�F�[�h�A�E�g
            // ����Z���
            m_canvasGroup.alpha -= Time.deltaTime / kTextFadeTime;
            // ���͂������玟��
            if (pushedAnyButton)
            {
                m_timer = kTextFadeTime * 2 + kNextTextTime;
                m_canvasGroup.alpha = 0;
            }
        }
        else
        {
            // ���ׂďI������玟�̃e�L�X�g��
            m_timer = 0;
            m_textNum++;
            // �Ō�̕����܂Ō�������I���B
            if (m_textNum >= m_texts.Length)
            {
                StartCoroutine(End());
                m_enabled = false;
            }
            else
            {
                SetText();
            }
        }
    }

    private void SetText()
    {
        // ���݂̒ʂ��ԍ��ɉ����ăe�L�X�g��؂�ւ���
        m_text.text = m_texts[m_textNum];
    }

    private IEnumerator End()
    {
        // �t�F�[�h��҂�
        yield return YukiFadeManager.FadeOut(1.0f);
        // �V�[�������[�h
        SceneManager.LoadScene("LabyrinthTest");
    }
}
