using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;   // �T�E���h�A�J�����A�N���W�b�g�A�߂�{�^��
    public GameObject soundPanel;  // �T�E���h�ݒ�
    public GameObject cameraPanel; // X���AY���̃J�������x�ݒ�
    public GameObject titleSceneView;

    // �R���g���[�����t�H�[�J�X���邽�߂̂���
    private EventSystem m_eventSystem;

    private void FocusButton()
    {
        // UI�؂�ւ����ɂ�������s����΂��������Ƀt�H�[�J�X�����
        m_eventSystem.SetSelectedGameObject(GameObject.FindGameObjectWithTag("FirstSelectedButton"));
    }

    // true:�\���@false:��\��
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
