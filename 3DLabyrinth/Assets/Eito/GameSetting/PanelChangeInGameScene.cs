using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelChangeInGameScene : MonoBehaviour
{
    // PanelChangeのゲームシーン版

    public GameObject mainPanel;   // サウンド、カメラ、クレジット、戻るボタン
    public GameObject soundPanel;  // サウンド設定
    public GameObject cameraPanel; // X軸、Y軸のカメラ感度設定

    AudioSource m_SEGenerator;
    [SerializeField]
    AudioClip m_submitSE;
    [SerializeField]
    AudioClip m_cancelSE;

    // コントローラをフォーカスするためのもの
    private EventSystem m_eventSystem;


    private void Start()
    {
        m_eventSystem = EventSystem.current;
        m_SEGenerator = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //// UIが開いてて、
        //// コントローラの選択が外れていて、
        //// コントローラの入力を受け取ったとき、
        //// FocusButtonを実行する　
        //if (!mainPanel.activeSelf  &&
        //    !soundPanel.activeSelf &&
        //    !cameraPanel.activeSelf) return;

        //Debug.Log("よお");

        //if (m_eventSystem.currentSelectedGameObject != null) return;

        //Debug.Log("フォーカス無い");

        //if (Input.anyKeyDown)
        //{
        //    Debug.Log("通ったよ");
        //    FocusButton();
        //}

        // スタートボタンを押したらオプションが出る
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            ShowOption();
        }
    }

    public void ShowOption()
    {
        // メインパネルが出ていなければ表示しゲームを止め、
        // 反対ならメインパネルを消してゲームに戻る
        if (mainPanel.activeSelf)
        {
            mainPanel.SetActive(false);
            soundPanel.SetActive(false);
            cameraPanel.SetActive(false);
            ResumeGame();
        }
        else
        {
            mainPanel.SetActive(true);
            soundPanel.SetActive(false);
            cameraPanel.SetActive(false);
            FocusButton();
            StopGame();
        }
    }

    private void StopGame()
    {
        //Time.timeScale = 0;
        PlayerMove.s_canMove = false;
        LookMove.s_canLookMove = false;
    }

    private void ResumeGame()
    {
        //Time.timeScale = 1.0f;
        PlayerMove.s_canMove = true;
        LookMove.s_canLookMove = true;
    }

    private void FocusButton()
    {
        // UI切り替え時にこれを実行すればいい感じにフォーカスされる
        m_eventSystem.SetSelectedGameObject(GameObject.FindGameObjectWithTag("FirstSelectedButton"));
    }
    public void SoundView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(true);
        cameraPanel.SetActive(false);
        FocusButton();
        PlaySE(m_submitSE);
    }

    public void CameraView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(false);
        cameraPanel.SetActive(true);
        FocusButton();
        PlaySE(m_submitSE);
    }

    public void OnClickBack()
    {
        mainPanel.SetActive(true);
        soundPanel.SetActive(false);
        cameraPanel.SetActive(false);
        FocusButton();
        PlaySE(m_cancelSE);
    }

    // SEも鳴らす
    private void PlaySE(AudioClip se)
    {
        m_SEGenerator.clip = se;
        m_SEGenerator.Play();
    }
}
