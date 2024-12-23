using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class CreditScript : MonoBehaviour
{
    private Vector3 staffrollPosition;
    private EventSystem m_eventSystem;
    
    public RectTransform rectTransform; // スクロールしたいものを入れる
    public float endPos; // スクロールが終わる際のY座標の指定
    public GameObject creditView;
    public GameObject titleSceneView;
    public GameObject titleBgm;
    public GameObject backGround;
    public GameObject creditBackGround;

    // Start is called before the first frame update
    void Start()
    {
        staffrollPosition = rectTransform.anchoredPosition;
        m_eventSystem = EventSystem.current;
        AudioSource source = this.GetComponent<AudioSource>();
        titleBgm.SetActive(false); // タイトルシーンで流れているBGMを消す
        backGround.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        creditBackGround.SetActive(true);
        // Aボタンを押すとスクロールスピードが上がる
        if (Input.GetKey("joystick button 0"))　
        {
            staffrollPosition.y += 1f;
        }
        // Bボタンを押すとタイトルシーンに戻る
        if (Input.GetKey("joystick button 1"))
        {
            SceneManager.LoadScene(3); // クレジットリセット(タイトルシーン再ロード)
            creditView.SetActive(false);
            titleSceneView.SetActive(true);
            FocusButton();
        }

        // +Y座標にスクロールする
        if (rectTransform.anchoredPosition.y < endPos)
        {
            staffrollPosition.y += 0.2f; // スクロールスピード
            rectTransform.anchoredPosition = staffrollPosition;
        }
    }

    private void FocusButton()
    {
        // UI切り替え時にこれを実行すればいい感じにフォーカスされる
        m_eventSystem.SetSelectedGameObject(GameObject.FindGameObjectWithTag("FirstSelectedButton"));
    }
}
