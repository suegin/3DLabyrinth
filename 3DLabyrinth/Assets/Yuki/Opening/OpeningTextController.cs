using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

// オープニングはこのスクリプトだけで完結させよ

public class OpeningTextController : MonoBehaviour
{
    // シーンが始まったらテキストを表示して
    // 一定時間たったらフェードして次のテキストを表示…をしたい
    // 一定時間立つ他、Aボタンを押しても次に進む　

    private const int kTextNum = 10;
    private string[] m_texts =
    {
        "aaa",
        "iii"
    };

    private TextMeshProUGUI m_textComponent;
    // フェードインアウトの時間
    private const float kTextFadeTime = 1.0f;
    // テキスト送りの間隔
    private const float kNextTextTime = 3.0f;
    // タイマー
    private float m_timer;
    // 今のテキストの通し番号
    private int m_textNum = 0;

    // アルファ調節用
    private Color m_alpha = new Color(0.0f, 0.0f, 0.0f, 1.0f/60);
    private Color m_clearBlack = new Color(1, 1, 1, 0);

    // 有効かどうか
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
        // 有効かどうか
        if (!m_enabled) return;

        // タイマー加算
        m_timer += Time.deltaTime;

        // ここで一元管理して入力とる
        bool pushAButton = Input.GetKeyDown(KeyCode.A);

        if (m_timer < kTextFadeTime)
        {
            // フェードインの段階
            m_textComponent.color += m_alpha;
            // ここで入力があったら、強制的にタイマーを1.0fに
            if (pushAButton)
            {
                m_timer = kTextFadeTime;
                m_textComponent.color = Color.black;
            }
        }
        else if (m_timer < kTextFadeTime + kNextTextTime)
        {
            // 完全に不透明で待機する時間
            // 入力でフェードアウトに移行
            if (pushAButton)
            {
                m_timer = kTextFadeTime + kNextTextTime;
            }
        }
        else if (m_timer < kTextFadeTime * 2 + kNextTextTime)
        {
            // フェードアウト
            m_textComponent.color -= m_alpha;
            // 入力あったら次へ
            if (pushAButton)
            {
                m_timer = kTextFadeTime * 2 + kNextTextTime;
                m_textComponent.color = m_clearBlack;
            }
        }
        else
        {
            // すべて終わったら次のテキストへ
            m_timer = 0;
            m_textNum++;
            // 最後の文字まで言ったら終了。
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
        // 現在の通し番号に応じてテキストを切り替える
        m_textComponent.text = m_texts[m_textNum];
    }

    private IEnumerator End()
    {
        // フェードを待つ
        yield return YukiFadeManager.FadeOut(1.0f);
    }
}
