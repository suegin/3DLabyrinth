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

    // コントローラをフォーカスするためのもの
    private EventSystem m_eventSystem;

    private void Start()
    {
        m_eventSystem = EventSystem.current;
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
    }

    public void CameraView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(false);
        cameraPanel.SetActive(true);
        FocusButton();
    }

    public void OnClickBack()
    {
        mainPanel.SetActive(true);
        soundPanel.SetActive(false);
        cameraPanel.SetActive(false);
        FocusButton();
    }
}
