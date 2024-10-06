using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;   // サウンド、カメラ、クレジット、戻るボタン
    public GameObject soundPanel;  // サウンド設定
    public GameObject cameraPanel; // X軸、Y軸のカメラ感度設定
    public GameObject titleSceneView;

    // true:表示　false:非表示
    void Start()
    {
        mainPanel.SetActive(false); 
        soundPanel.SetActive(false);
        cameraPanel.SetActive(false);
        titleSceneView.SetActive(true);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        soundPanel.SetActive(false);
        cameraPanel.SetActive(false);
        titleSceneView.SetActive(false);
    }

    public void SoundView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(true);
        cameraPanel.SetActive(false);
        titleSceneView.SetActive(false);
    }
   
    public void CameraView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(false);
        cameraPanel.SetActive(true);
        titleSceneView.SetActive(false);
    }

    public void OnClickBack()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(false);
        titleSceneView.SetActive(true);
    }
}
