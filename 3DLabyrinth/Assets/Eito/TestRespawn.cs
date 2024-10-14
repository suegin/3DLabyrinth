using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRespawn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RetryBoard")) // 接触したオブジェクトのタグがRetryBoardかを比較
        {
            // 接触したオブジェクトを非表示
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Ball"))　// 接触したオブジェクトのタグがBallかを比較
        {
            // 接触したオブジェクトを表示
            other.gameObject.SetActive(true);
            other.gameObject.transform.position = new Vector3(2, 0, -6); // スタート位置に戻す
        }
    }
}
