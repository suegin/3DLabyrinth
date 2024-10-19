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

    AudioSource m_SEGenerator;
    [SerializeField]
    AudioClip m_submitSE;
    [SerializeField]
    AudioClip m_cancelSE;

    // �R���g���[�����t�H�[�J�X���邽�߂̂���
    private EventSystem m_eventSystem;


    private void Start()
    {
        m_eventSystem = EventSystem.current;
        m_SEGenerator = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //// UI���J���ĂāA
        //// �R���g���[���̑I�����O��Ă��āA
        //// �R���g���[���̓��͂��󂯎�����Ƃ��A
        //// FocusButton�����s����@
        //if (!mainPanel.activeSelf  &&
        //    !soundPanel.activeSelf &&
        //    !cameraPanel.activeSelf) return;

        //Debug.Log("�您");

        //if (m_eventSystem.currentSelectedGameObject != null) return;

        //Debug.Log("�t�H�[�J�X����");

        //if (Input.anyKeyDown)
        //{
        //    Debug.Log("�ʂ�����");
        //    FocusButton();
        //}

        // �X�^�[�g�{�^������������I�v�V�������o��
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            ShowOption();
        }
    }

    public void ShowOption()
    {
        // ���C���p�l�����o�Ă��Ȃ���Ε\�����Q�[�����~�߁A
        // ���΂Ȃ烁�C���p�l���������ăQ�[���ɖ߂�
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
        // UI�؂�ւ����ɂ�������s����΂��������Ƀt�H�[�J�X�����
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

    // SE���炷
    private void PlaySE(AudioClip se)
    {
        m_SEGenerator.clip = se;
        m_SEGenerator.Play();
    }
}
