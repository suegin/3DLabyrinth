using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;  // �T�E���h�A�J�����A�N���W�b�g�A�߂�{�^��
    public GameObject soundPanel; // �T�E���h�ݒ�
    public GameObject GameStartBuuton;
    public GameObject OptionButton;
    public GameObject LogoutButton;
    public GameObject TitleScene;

    // true:�\���@false:��\��
    void Start()
    {
        mainPanel.SetActive(false); 
        soundPanel.SetActive(false);
        GameStartBuuton.SetActive(true);
        OptionButton.SetActive(true);
        LogoutButton.SetActive(true);
        TitleScene.SetActive(true);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        soundPanel.SetActive(false);
        GameStartBuuton.SetActive(false);
        OptionButton.SetActive(false);
        LogoutButton.SetActive(false);
        TitleScene.SetActive(false);
    }

    public void SoundView()
    {
        mainPanel.SetActive(false);
        soundPanel.SetActive(true);
        GameStartBuuton.SetActive(false);
        OptionButton.SetActive(false);
        LogoutButton.SetActive(false);
        TitleScene.SetActive(false);
    }

    public void OnClickBack()
    {
        mainPanel.SetActive(false);
        GameStartBuuton.SetActive(true);
        OptionButton.SetActive(true);
        LogoutButton.SetActive(true);
        TitleScene.SetActive(true);
    }
}
