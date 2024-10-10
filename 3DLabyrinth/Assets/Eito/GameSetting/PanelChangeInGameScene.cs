using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelChangeInGameScene : MonoBehaviour
{
    // PanelChange�̃Q�[���V�[����

    public GameObject mainPanel;   // �T�E���h�A�J�����A�N���W�b�g�A�߂�{�^��
    public GameObject soundPanel;  // �T�E���h�ݒ�
    public GameObject cameraPanel; // X���AY���̃J�������x�ݒ�

    // �R���g���[�����t�H�[�J�X���邽�߂̂���
    private EventSystem m_eventSystem;

    private void Start()
    {
        m_eventSystem = EventSystem.current;
    }

    private void FocusButton()
    {
        // UI�؂�ւ����ɂ�������s����΂��������Ƀt�H�[�J�X�����
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
