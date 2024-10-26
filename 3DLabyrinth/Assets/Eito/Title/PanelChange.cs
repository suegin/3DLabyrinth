using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainView;   // サウンド、カメラ、クレジット、戻るボタン
    public GameObject soundView;  // サウンド設定
    public GameObject cameraView; // X軸、Y軸のカメラ感度設定
    public GameObject creditView;
    public GameObject titleSceneView;

    private AudioSource bgmAudioSource;
    public AudioClip bgmAudioClip;

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
       // bgmAudioSource = GetComponent<AudioSource>();

        mainView.SetActive(false); 
        soundView.SetActive(false);
        cameraView.SetActive(false);
        creditView.SetActive(false);
        titleSceneView.SetActive(true);
        FocusButton();
    }

    public void MainView()
    {
        mainView.SetActive(true);
        soundView.SetActive(false);
        cameraView.SetActive(false);
        creditView.SetActive(false);
        titleSceneView.SetActive(false);
        FocusButton(); 
    }

    public void SoundView()
    {
        mainView.SetActive(false);
        soundView.SetActive(true);
        cameraView.SetActive(false);
        creditView.SetActive(false);
        titleSceneView.SetActive(false);
        FocusButton();
    }
   
    public void CameraView()
    {
        mainView.SetActive(false);
        soundView.SetActive(false);
        cameraView.SetActive(true);
        creditView.SetActive(false);
        titleSceneView.SetActive(false);
        FocusButton();
    }
    public void CreditView()
    {
        mainView.SetActive(false);
        soundView.SetActive(false);
        cameraView.SetActive(false);
        creditView.SetActive(true);
        titleSceneView.SetActive(false);

     //   PauseBgm();

        FocusButton();
    }

    public void OnClickBack()
    {
        mainView.SetActive(false);
        soundView.SetActive(false);
        titleSceneView.SetActive(true);
        FocusButton();
    }

    //public void PauseBgm()
    //{
    //    bgmAudioSource.Pause();
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "CreditView")
        {
            bgmAudioSource.Play();
            Debug.Log("aaa");
        }
    }
}
