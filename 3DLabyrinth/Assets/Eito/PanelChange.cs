using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;   // サウンド、カメラ、クレジット、戻るボタン
    public GameObject soundPanel;  // サウンド設定
    public GameObject cameraPanel; // X軸、Y軸のカメラ感度設定
    public GameObject titleSceneView;

    // コントローラをフォーカスするためのもの
    private EventSystem m_eventSystem;

    private void FocusButton()
    {
        // UI切り替え時にこれを実行すればいい感じにフォーカスされる
        m_eventSystem.SetSelectedGameObject(GameObject.FindGameObjectWithTag("FirstSelectedButton"));
    }

    // true:表示　false:非表示
    void Start()
    {
        m_eventSystem = EventSystem.current;

        mainPanel.SetActive(false); 
        soundPanel.SetActive(false);
        cameraPanel.SetActive(false);
        titleSceneView.SetActive(true);
        FocusButton();
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        soundPanel.SetActive(false);
        cameraPanel.SetActive(false);
        titleSceneView.SetActive(false);
        FocusButton(); 
    }

    public void SoundView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(true);
        cameraPanel.SetActive(false);
        titleSceneView.SetActive(false);
        FocusButton();
    }
   
    public void CameraView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(false);
        cameraPanel.SetActive(true);
        titleSceneView.SetActive(false);
        FocusButton();
    }

    public void OnClickBack()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(false);
        titleSceneView.SetActive(true);
        FocusButton();
    }
}
