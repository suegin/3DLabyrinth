using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    bool isActive;　// 当たったかどうかのフラグ
    public DoorScript door; // ドアスクリプトとの連動

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive && other.CompareTag("Ball"))　// ボールが当たったら
        {
            isActive = true;
            door.isOpen = true;
        }
    }
}
