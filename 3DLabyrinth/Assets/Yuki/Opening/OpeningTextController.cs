using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

// �I�[�v�j���O�͂��̃X�N���v�g�����Ŋ���������

public class OpeningTextController : MonoBehaviour
{
    // �V�[�����n�܂�����e�L�X�g��\������
    // ��莞�Ԃ�������t�F�[�h���Ď��̃e�L�X�g��\���c��������
    // ��莞�ԗ����AA�{�^���������Ă����ɐi�ށ@

    private const int kTextNum = 10;
    private string[] m_texts =
    {
        "aaa",
        "iii"
    };

    private TextMeshProUGUI m_textComponent;
    // �t�F�[�h�C���A�E�g�̎���
    private const float kTextFadeTime = 1.0f;
    // �e�L�X�g����̊Ԋu
    private const float kNextTextTime = 3.0f;
    // �^�C�}�[
    private float m_timer;
    // ���̃e�L�X�g�̒ʂ��ԍ�
    private int m_textNum = 0;

    // �A���t�@���ߗp
    private Color m_alpha = new Color(0.0f, 0.0f, 0.0f, 1.0f/60);
    private Color m_clearBlack = new Color(1, 1, 1, 0);

    // �L�����ǂ���
    private bool m_enabled = true;

    private void Start()
    {
        Application.targetFrameRate = 60;

        m_textComponent = GetComponent<TextMeshProUGUI>();
        SetText();
    }

    // Update is called once per frame
    private void Update()
    {
        // �L�����ǂ���
        if (!m_enabled) return;

        // �^�C�}�[���Z
        m_timer += Time.deltaTime;

        // �����ňꌳ�Ǘ����ē��͂Ƃ�
        bool pushAButton = Input.GetKeyDown(KeyCode.A);

        if (m_timer < kTextFadeTime)
        {
            // �t�F�[�h�C���̒i�K
            m_textComponent.color += m_alpha;
            // �����œ��͂���������A�����I�Ƀ^�C�}�[��1.0f��
            if (pushAButton)
            {
                m_timer = kTextFadeTime;
                m_textComponent.color = Color.black;
            }
        }
        else if (m_timer < kTextFadeTime + kNextTextTime)
        {
            // ���S�ɕs�����őҋ@���鎞��
            // ���͂Ńt�F�[�h�A�E�g�Ɉڍs
            if (pushAButton)
            {
                m_timer = kTextFadeTime + kNextTextTime;
            }
        }
        else if (m_timer < kTextFadeTime * 2 + kNextTextTime)
        {
            // �t�F�[�h�A�E�g
            m_textComponent.color -= m_alpha;
            // ���͂������玟��
            if (pushAButton)
            {
                m_timer = kTextFadeTime * 2 + kNextTextTime;
                m_textComponent.color = m_clearBlack;
            }
        }
        else
        {
            // ���ׂďI������玟�̃e�L�X�g��
            m_timer = 0;
            m_textNum++;
            // �Ō�̕����܂Ō�������I���B
            if (m_textNum > kTextNum)
            {
                End();
                m_enabled = false;
            }
            SetText();
        }
    }

    private void SetText()
    {
        // ���݂̒ʂ��ԍ��ɉ����ăe�L�X�g��؂�ւ���
        m_textComponent.text = m_texts[m_textNum];
    }

    private IEnumerator End()
    {
        // �t�F�[�h��҂�
        yield return YukiFadeManager.FadeOut(1.0f);
    }
}
