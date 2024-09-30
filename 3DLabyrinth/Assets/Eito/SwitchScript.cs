using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    float bottomY; // ボタンの初期のY座標
    float speed = 0.5f;　// ボタンの沈むスピード

    bool active;　// ボタンが押されたか押されてないかのフラグ

    public DoorScript door; // ドアスクリプトとの連動
    void Update()
    {
        if (active && transform.position.y > bottomY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y <= bottomY )
            {
                door.isOpen = true;
                enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active && other.CompareTag("Player"))　// プレイヤーが乗っかったら
        {
            active = true;
        }
    }
}