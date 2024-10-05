using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;  // �T�E���h�A�J�����A�N���W�b�g�A�߂�{�^��
    public GameObject soundPanel; // �T�E���h�ݒ�
    public GameObject titleSceneView;

    // true:�\���@false:��\��
    void Start()
    {
        mainPanel.SetActive(false); 
        soundPanel.SetActive(false);
        titleSceneView.SetActive(true);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        soundPanel.SetActive(false);
        titleSceneView.SetActive(false);
    }

    public void SoundView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(true);
        titleSceneView.SetActive(false);
    }
   
    public void CameraView()
    {

    }

    public void OnClickBack()
    {
        mainPanel.SetActive(false);
        titleSceneView.SetActive(true);
    }
}
