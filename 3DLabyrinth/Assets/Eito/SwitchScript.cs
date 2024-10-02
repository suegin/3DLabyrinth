using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    float buttomY; // ボタンの初期のY座標
    float speed = 0.5f;　// ボタンの沈むスピード
    bool isActive;　// ボタンが押されているかどうかのフラグ
    public DoorScript door; // ドアスクリプトとの連動

    void Start()
    {
            
    }
    void Update()
    {
        if (isActive && transform.position.y > buttomY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y <= buttomY )
            {
                door.isOpen = true;
                enabled = false; // 何度もisOpen = true にする処理が実行されないための対策
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive && other.CompareTag("Player"))　// プレイヤーが乗っかったら
        {
             isActive = true;
        }
    }
}