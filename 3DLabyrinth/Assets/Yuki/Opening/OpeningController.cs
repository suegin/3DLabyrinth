using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

// オープニングはこのスクリプトだけで完結させよ

public class OpeningController : MonoBehaviour
{
    // シーンが始まったらテキストを表示して
    // 一定時間たったらフェードして次のテキストを表示…をしたい
    // 一定時間立つ他、Aボタンを押しても次に進む　

    private string[] m_texts =
    {
        "テスト",
        "オープニングの文字を表示できます",
        "何行でも書けます",
        "今は終了時にシーンをロードするけど",
        "デリゲートで汎用性を高められると思う"
    };

    private CanvasGroup m_canvasGroup;
    private TextMeshProUGUI m_text;
    // フェードインアウトの時間
    private const float kTextFadeTime = 1.5f;
    // テキスト送りの間隔
    private const float kNextTextTime = 3.0f;
    // タイマー
    private float m_timer;
    // 今のテキストの通し番号
    private int m_textNum = 0;

    // 有効かどうか
    private bool m_enabled = true;

    private void Start()
    {
        Application.targetFrameRate = 60;

        // いろいろ取得
        m_canvasGroup = GetComponent<CanvasGroup>();
        m_text = GetComponent<TextMeshProUGUI>();
        SetText();

        // 配列の要素数は1から数える
        //Debug.Log(m_texts.Length);

        // フェード
        StartCoroutine(YukiFadeManager.FadeIn(1.0f));
    }

    // Update is called once per frame
    private void Update()
    {
        // 有効かどうか
        if (!m_enabled) return;

        // タイマー加算
        m_timer += Time.deltaTime;

        // ここで一元管理して入力とる
        bool pushedAnyButton = Input.anyKeyDown;

        if (m_timer < kTextFadeTime)
        {
            //Debug.Log($"{m_texts[m_textNum]}, フェードイン中");
            // フェードインの段階
            // 割り算御免
            m_canvasGroup.alpha += Time.deltaTime / kTextFadeTime;
            // ここで入力があったら、強制的にタイマーを1.0fに
            if (pushedAnyButton)
            {
                m_timer = kTextFadeTime;
                m_canvasGroup.alpha = 1.0f;
            }
        }
        else if (m_timer < kTextFadeTime + kNextTextTime)
        {
            //Debug.Log($"{m_texts[m_textNum]}, 待機");
            // 完全に不透明で待機する時間
            // 入力でフェードアウトに移行
            if (pushedAnyButton)
            {
                m_timer = kTextFadeTime + kNextTextTime;
            }
        }
        else if (m_timer < kTextFadeTime * 2 + kNextTextTime)
        {
            //Debug.Log($"{m_texts[m_textNum]}, アウト");
            // フェードアウト
            // 割り算御免
            m_canvasGroup.alpha -= Time.deltaTime / kTextFadeTime;
            // 入力あったら次へ
            if (pushedAnyButton)
            {
                m_timer = kTextFadeTime * 2 + kNextTextTime;
                m_canvasGroup.alpha = 0;
            }
        }
        else
        {
            // すべて終わったら次のテキストへ
            m_timer = 0;
            m_textNum++;
            // 最後の文字まで言ったら終了。
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
        // 現在の通し番号に応じてテキストを切り替える
        m_text.text = m_texts[m_textNum];
    }

    private IEnumerator End()
    {
        // フェードを待つ
        yield return YukiFadeManager.FadeOut(1.0f);
        // シーンをロード
        SceneManager.LoadScene("LabyrinthTest");
    }
}
