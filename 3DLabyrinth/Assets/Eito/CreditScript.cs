using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour
{
    private Vector3 staffrollPosition;
    public RectTransform rectTransform; // スクロールしたいものを入れる
    public float endPos; // スクロールが終わる際のY座標の指定

    // Start is called before the first frame update
    void Start()
    {
        staffrollPosition = rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Aボタンを押すとスクロールスピードが上がる
        if (Input.GetKey("joystick button 0"))　
        {
            staffrollPosition.y += 1f;
        }

        // +Y座標にスクロールする
        if (rectTransform.anchoredPosition.y < endPos)
        {
            staffrollPosition.y += 0.3f;
            rectTransform.anchoredPosition = staffrollPosition;
        }
    }
}
